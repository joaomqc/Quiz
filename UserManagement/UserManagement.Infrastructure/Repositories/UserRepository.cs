namespace UserManagement.Infrastructure.Repositories
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Application;
    using Application.Repositories;
    using Domain;
    using Microsoft.EntityFrameworkCore;

    public class UserRepository : IUserRepository
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly UserContext _context;

        public UserRepository(
            IPasswordHasher passwordHasher,
            UserContext context)
        {
            _passwordHasher = passwordHasher
                              ?? throw new ArgumentNullException(nameof(passwordHasher));
            _context = context
                       ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<User> GetById(
            int id,
            CancellationToken ct = default(CancellationToken))
        {
            var user =
                await _context.Users
                    .FirstOrDefaultAsync(u => u.Id == id, ct)
                    .ConfigureAwait(false);

            return User.CreateUser(
                user.Id,
                user.Email,
                user.Username);
        }

        public async Task<User> GetByUsername(
            string username,
            CancellationToken ct = default(CancellationToken))
        {
            var user =
                await _context.Users
                    .FirstOrDefaultAsync(u => u.Username == username, ct)
                    .ConfigureAwait(false);

            return User.CreateUser(
                user.Id,
                user.Email,
                user.Username);
        }

        public async Task RegisterUser(
            User user,
            CancellationToken ct = default(CancellationToken))
        {
            var userEntity =
                new Entities.User
                {
                    Email = user.Email,
                    Username = user.Username,
                    Password = _passwordHasher.HashPassword(user.Password)
                };

            _context.Users.Add(userEntity);

            await _context.SaveChangesAsync(ct);
        }

        public async Task<bool> ValidateCredentials(
            string username,
            string password,
            CancellationToken ct = default(CancellationToken))
        {
            var user =
                await _context.Users
                    .FirstOrDefaultAsync(u => u.Username == username, ct)
                    .ConfigureAwait(false);

            return _passwordHasher.VerifyPassword(user.Password, password);
        }
    }
}
