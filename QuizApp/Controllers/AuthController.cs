using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using QuizApp.Domain.Data;
using QuizApp.Domain.DTO;
using QuizApp.Domain.Entity;
using QuizApp.Domain.Services;

namespace QuizApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {

        //REGISTER: Auth/register
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(CreateUser request)
        {
            var user = await authService.RegisterAsync(request);
            if (user is null)
            {
                return BadRequest("User already exists.");
            }

            return Ok(user);
        }

        [HttpPut("login/edit/{id}")]
        public async Task<ActionResult<User>> UserEdit(int id, [FromBody] CreateUser request)
        {
            var user = await authService.UserEdit(id, request);
            if(user == null)
            {
                return NotFound();
            }

            return Ok(user);
            
        }



        //LOGIN: Auth/login
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(userDTO request)
        {
            var token = await authService.LoginAsync(request);

            if (token is null)
            {
                return BadRequest("Invalid Username or Password.");
            }
            return Ok(token);
        }

        //AUTHENTICATION BY ID: Auth/user/3
        [Authorize(Policy = "admin")]
        [HttpGet("user/{id}")]
        public async Task<ActionResult<User>> AuthenticateById(int id)
        {
            var user = await authService.AuthenticateById(id);
            if (user is null)
            {
                return BadRequest("User does not exist or you are not authorized to access this feature.");
            }
            return Ok(user);
        }

        //DELETE: Auth/user/3
        [Authorize(Policy = "admin")]
        [HttpDelete("user/{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await authService.DeleteUser(id);
            if (user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        //TEST
        [Authorize(Policy = "user")]
        [HttpGet]
        //Authenticated Users Only 
        public IActionResult AuthenticatedEndpoint()
        {
            return Ok("You are a User.");
        }


        [Authorize(Policy = "admin")]
        //[Authorize]
        [HttpGet("admin")]
        //Authenticated Admins Only 
        public IActionResult AdminEndpoint()
        {
            return Ok("You are the admin!");
        }

    }
}
