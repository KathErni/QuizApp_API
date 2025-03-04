using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApp.Domain.Entity
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string HashedPassword { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;
        
        public ICollection<Quiz> Quizzes { get; set; }

    }
}
