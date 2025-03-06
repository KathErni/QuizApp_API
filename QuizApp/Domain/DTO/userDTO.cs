namespace QuizApp.Domain.DTO
{
    public class CreateUser
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }
    }

    public record DeleteUser
    {
        public int UserId { get; init; }
    }

    public record userDTO
    {

        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }

    public class LoginDto
    {
        public string Token { get; set; }
    }
}

