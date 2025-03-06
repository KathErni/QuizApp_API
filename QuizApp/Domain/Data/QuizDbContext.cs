using Microsoft.EntityFrameworkCore;
using QuizApp.Domain.Entity;
using System.Data.Common;

namespace QuizApp.Domain.Data
{
    public class QuizDbContext : DbContext
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options) { }


        public DbSet<User> Users { get; set; }

        public DbSet<Quiz> Quizzes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                 .HasIndex(u => u.Username).IsUnique();
        }
    }

    

       
}
