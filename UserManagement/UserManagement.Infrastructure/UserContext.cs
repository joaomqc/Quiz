namespace UserManagement.Infrastructure
{
    using System;
    using Entities;
    using Microsoft.EntityFrameworkCore;

    public class UserContext : DbContext
    {
        private readonly string _connectionString;

        public UserContext(string connectionString)
        {
            _connectionString = connectionString ??
                                throw new ArgumentNullException(nameof(connectionString));
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(_connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("usermanagement");

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .HasName("Index_Username")
                .IsUnique();
        }
    }
}
