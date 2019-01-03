namespace QuizManagement.Infrastructure
{
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;

    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<QuizContext>
    {
        public QuizContext CreateDbContext(string[] args)
        {

            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();

            return new QuizContext(configuration["ConnectionStrings:DefaultConnection"]);
        }
    }
}
