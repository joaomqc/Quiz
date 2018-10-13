namespace QuizManagement.Infrastructure
{
    using Entities;
    using Microsoft.EntityFrameworkCore;

    public class QuizContext : DbContext
    {
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Topic> Topics { get; set; }
    }
}
