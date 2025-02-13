using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApp.Domain.Entity
{
    public class Quiz
    {
        [Key]
        public int QuestId { get; set; }
        public required string Question { get; set; }

        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
        public string[] Choices { get; set; }

        public Teacher Teacher { get; set; }
    }
}
