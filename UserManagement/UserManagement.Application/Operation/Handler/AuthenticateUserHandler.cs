namespace UserManagement.Application.Operation.Handler
{
    using System;
    using System.Threading.Tasks;
    using Parameters;
    using Repositories;
    using Results;
    using Shared.Operation;

    public class AuthenticateUserHandler
        : IHandler<AuthenticateUserParameters, AuthenticateUserResults>
    {
        private readonly IUsersRepository _usersRepository;

        public AuthenticateUserHandler(
            IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository
                              ?? throw new ArgumentNullException(nameof(usersRepository));
        }

        public async Task<AuthenticateUserResults> ExecuteAsync(AuthenticateUserParameters parameters)
        {
            var isAuthenticated =
                await _usersRepository
                    .ValidateCredentials(
                        parameters.Username,
                        parameters.Password)
                    .ConfigureAwait(false);

            return new AuthenticateUserResults(isAuthenticated);
        }
    }
}
