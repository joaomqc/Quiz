namespace UserManagement.Application.Operation.Handler
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Parameters;
    using Repositories;
    using Results;
    using Shared.Operation;

    public class AuthenticateUserHandler
        : IHandler<AuthenticateUserParameters, AuthenticateUserResults>
    {
        private IUserRepository _userRepository;

        public AuthenticateUserHandler(
            IUserRepository userRepository)
        {
            _userRepository = userRepository
                              ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<AuthenticateUserResults> ExecuteAsync(
            AuthenticateUserParameters parameters,
            CancellationToken ct = default(CancellationToken))
        {
            var isAuthenticated =
                await _userRepository
                    .ValidateCredentials(
                        parameters.Username,
                        parameters.Password,
                        ct)
                    .ConfigureAwait(false);

            return new AuthenticateUserResults(isAuthenticated);
        }
    }
}
