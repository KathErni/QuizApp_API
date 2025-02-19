using System.ComponentModel.DataAnnotations;

namespace QuizApp.Domain.Entity
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }

        //public ICollection<Quiz> Quizzes { get; set; }

        //public ICollection<Student> Students { get; set; }
    }
}
