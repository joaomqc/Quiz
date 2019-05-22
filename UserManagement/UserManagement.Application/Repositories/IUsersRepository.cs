namespace UserManagement.Application.Repositories
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain;

    public interface IUsersRepository
    {
        Task<User> GetByExternalIdAsync(
            Guid externalId,
            CancellationToken ct = default(CancellationToken));

        Task RegisterUserAsync(
            User user,
            string password,
            CancellationToken ct = default(CancellationToken));

        Task<Guid?> ValidateCredentialsAsync(
            string username,
            string password,
            CancellationToken ct = default(CancellationToken));

        Task<bool> CheckUserExistsAsync(
            User user,
            CancellationToken ct = default(CancellationToken));
    }
}
