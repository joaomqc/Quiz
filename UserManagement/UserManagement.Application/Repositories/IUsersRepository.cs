namespace UserManagement.Application.Repositories
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain;

    public interface IUsersRepository
    {
        Task<User> GetByUsername(
            string username,
            CancellationToken ct = default(CancellationToken));

        Task RegisterUser(
            User user,
            string password,
            CancellationToken ct = default(CancellationToken));

        Task<bool> ValidateCredentials(
            string username,
            string password,
            CancellationToken ct = default(CancellationToken));
    }
}
