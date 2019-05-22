namespace UserManagement.Infrastructure.Repositories
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Application;
    using Application.Repositories;
    using Application.Services;
    using Domain;
    using Microsoft.EntityFrameworkCore;

    public class UsersRepository : IUsersRepository
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly UserContext _context;

        public UsersRepository(
            IPasswordHasher passwordHasher,
            UserContext context)
        {
            _passwordHasher = passwordHasher
                              ?? throw new ArgumentNullException(nameof(passwordHasher));
            _context = context
                       ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<User> GetByExternalIdAsync(
            Guid externalId,
            CancellationToken ct = default(CancellationToken))
        {
            var user =
                await _context.Users
                    .FirstOrDefaultAsync(u => u.ExternalId == externalId, ct)
                    .ConfigureAwait(false);

            return new User(
                user.Email,
                user.Username);
        }

        public async Task RegisterUserAsync(
            User user,
            string password,
            CancellationToken ct = default(CancellationToken))
        {
            var userEntity =
                new Entities.User
                {
                    ExternalId = Guid.NewGuid(),
                    Email = user.Email,
                    Username = user.Username,
                    Password = _passwordHasher.HashPassword(password)
                };

            _context.Users.Add(userEntity);

            await _context.SaveChangesAsync(ct);
        }

        public async Task<Guid?> ValidateCredentialsAsync(
            string username,
            string password,
            CancellationToken ct = default(CancellationToken))
        {
            var user =
                await _context.Users
                    .FirstOrDefaultAsync(u => u.Username == username, ct)
                    .ConfigureAwait(false);

            if (user == null || !_passwordHasher.VerifyPassword(password, user.Password))
            {
                return null;
            }

            return user.ExternalId;
        }

        public async Task<bool> CheckUserExistsAsync(
            User user,
            CancellationToken ct = default(CancellationToken))
        {
            return await _context.Users
                .AnyAsync(
                    dbUser => 
                        dbUser.Username == user.Username
                        || dbUser.Email == user.Email,
                    ct)
                .ConfigureAwait(false);
        }
    }
}
