namespace UserManagement.Infrastructure
{
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;

    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<UserContext>
    {
        public UserContext CreateDbContext(string[] args)
        {

            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();

            return new UserContext(configuration["ConnectionStrings:DefaultConnection"]);
        }
    }
}
