using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using QuizApp.Domain.Data;
using QuizApp.Domain.DTO;
using QuizApp.Domain.Entity;

namespace QuizApp.Domain.Services
{
    //Factoring so controller would have service layer 
    public class AuthService : IAuthService
    {
        private readonly QuizDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(QuizDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }
        public async Task<User?> AuthenticateById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<User?> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
               return null;            
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<string?> LoginAsync(userDTO request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);

            if (user is null)
            {
                return null;
            }

            if (new PasswordHasher<User>().VerifyHashedPassword(user, user.HashedPassword, request.Password) == PasswordVerificationResult.Failed)
            {
                return null;
            }

            return CreateToken(user);
        }

        public async Task<User?> RegisterAsync(CreateUser request)
        {
         //If user exist, return null
            if(await _context.Users.AnyAsync(u => u.Username == request.Username))
            {
                return null;
            }

            var user = new User();
            var hashedPass = new PasswordHasher<User>()
                .HashPassword(user, request.Password);

            user.Username = request.Username;
            user.HashedPassword = hashedPass;
            user.Role = request.Role.ToLower();

            _context.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User?> UserEdit(int id, CreateUser request)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return null;
            }

            user.Username = request.Username;
            user.HashedPassword = new PasswordHasher<User>().HashPassword(user, request.Password);
            user.Role = request.Role.ToLower();

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private string CreateToken(User user)
        {
            //Set Claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            };
            //Used with JWT Token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:Token")!));
            //Add Credentials
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("AppSettings:Issuer"),
                audience: _configuration.GetValue<string>("AppSettings:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
                );
            //returns token using a handler
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
