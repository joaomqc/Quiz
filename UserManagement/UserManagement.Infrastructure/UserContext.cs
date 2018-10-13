namespace UserManagement.Infrastructure
{
    using Entities;
    using Microsoft.EntityFrameworkCore;

    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
