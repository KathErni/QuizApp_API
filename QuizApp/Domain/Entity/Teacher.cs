using System.ComponentModel.DataAnnotations;

namespace QuizApp.Domain.Entity
{
    public class Teacher
    {
        [Key]
        public int TeachId { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }

        public ICollection<Quiz> Quiz { get; set; }
    }
}
