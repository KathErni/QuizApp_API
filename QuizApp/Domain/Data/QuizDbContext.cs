using Microsoft.EntityFrameworkCore;
using QuizApp.Domain.Entity;
using System.Data.Common;

namespace QuizApp.Domain.Data
{
    public class QuizDbContext : DbContext
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options) { }

        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Teacher>Teachers { get; set; }
    }

    
}
