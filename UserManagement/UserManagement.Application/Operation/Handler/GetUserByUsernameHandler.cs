namespace UserManagement.Application.Operation.Handler
{
    using System;
    using System.Threading.Tasks;
    using Parameters;
    using Repositories;
    using Results;
    using Shared.Operation;

    public class GetUserByUsernameHandler
        : IHandler<GetUserByUsernameParameters, GetUserByUsernameResults>
    {
        private readonly IUsersRepository _usersRepository;

        public GetUserByUsernameHandler(
            IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository
                              ?? throw new ArgumentNullException(nameof(usersRepository));
        }

        public async Task<GetUserByUsernameResults> ExecuteAsync(GetUserByUsernameParameters parameters)
        {
            var user =
                await _usersRepository
                    .GetByUsername(parameters.Username)
                    .ConfigureAwait(false);

            return new GetUserByUsernameResults(
                user.Username,
                user.Email);
        }
    }
}
