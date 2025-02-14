using Microsoft.EntityFrameworkCore;
using QuizApp.Domain.Entity;
using System.Data.Common;

namespace QuizApp.Domain.Data
{
    public class QuizDbContext : DbContext
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options) { }

        public DbSet<UserInfo> Quizzes { get; set; }
        public DbSet<UserInfo>Teachers { get; set; }
        public DbSet<QuizApp.Domain.Entity.Teacher> Teacher { get; set; } = default!;
    }

    
}
