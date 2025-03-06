using QuizApp.Domain.DTO;
using QuizApp.Domain.Entity;

namespace QuizApp.Domain.Services
{
    public interface IAuthService
    {
        Task<User?> GetUserById(int id);
        Task<bool> RegisterAsync(CreateUser request);
        Task <string?> LoginAsync(userDTO request);

        Task<User?> DeleteUser(int id);

        Task<User?> UserEdit(int id, CreateUser request);
    }
}
