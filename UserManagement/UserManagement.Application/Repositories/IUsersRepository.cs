namespace UserManagement.Application.Repositories
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain;

    public interface IUsersRepository
    {
        Task<User> GetById(
            int id,
            CancellationToken ct = default(CancellationToken));

        Task<User> GetByUsername(
            string username,
            CancellationToken ct = default(CancellationToken));

        Task RegisterUser(
            User user,
            CancellationToken ct = default(CancellationToken));

        Task<bool> ValidateCredentials(
            string username,
            string password,
            CancellationToken ct = default(CancellationToken));
    }
}
