using QuizApp.Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApp.Domain.DTO
{
    public record userDTO
    {

        public int UserId { get; set; }
       public string Name { get; set; }
        public int TeacherId { get; set; }

    }
}
