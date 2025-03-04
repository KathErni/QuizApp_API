using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApp.Domain.Entity
{
    public class Quiz
    {
        [Key]
        public int QuizId { get; set; }

        public required string Question { get; set; }

        public required string Answer { get; set; }

        [ForeignKey(nameof(User))]
        public int CreatedBy { get; set; }

        public User User { get; set; }
    }
}
