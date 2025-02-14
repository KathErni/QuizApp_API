using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authentication;

namespace QuizApp.Domain.Entity
{
    public class UserInfo
    {
        [Key]
        public int UserId { get; set; }
        public required string FirstName { get; set; }
        
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }

        public required string Username { get; set; }

        public required string Password { get; set; }

        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
