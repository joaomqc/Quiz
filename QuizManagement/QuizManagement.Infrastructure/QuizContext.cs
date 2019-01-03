namespace QuizManagement.Infrastructure
{
    using System;
    using Entities;
    using Microsoft.EntityFrameworkCore;

    public class QuizContext : DbContext
    {
        private readonly string _connectionString;

        public QuizContext(string connectionString)
        {
            _connectionString = connectionString ??
                                throw new ArgumentNullException(nameof(connectionString));
        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Topic> Topics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(_connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("quizmanagement");
        }
    }
}
