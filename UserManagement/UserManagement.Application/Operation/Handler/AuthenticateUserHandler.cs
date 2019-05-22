namespace UserManagement.Application.Operation.Handler
{
    using System;
    using System.Threading.Tasks;
    using Parameters;
    using Repositories;
    using Results;
    using Services;
    using Shared.Operation;

    public class AuthenticateUserHandler
        : IHandler<AuthenticateUserParameters, AuthenticateUserResults>
    {
        private readonly ITokenService _tokenService;
        private readonly IUsersRepository _usersRepository;

        public AuthenticateUserHandler(
            ITokenService tokenService,
            IUsersRepository usersRepository)
        {
            _tokenService = tokenService ??
                throw new ArgumentNullException(nameof(tokenService));
            _usersRepository = usersRepository ??
                throw new ArgumentNullException(nameof(usersRepository));
        }

        public async Task<AuthenticateUserResults> ExecuteAsync(AuthenticateUserParameters parameters)
        {
            var userId =
                await _usersRepository
                    .ValidateCredentialsAsync(
                        parameters.Username,
                        parameters.Password)
                    .ConfigureAwait(false);

            if (!userId.HasValue)
            {
                return new AuthenticateUserResults(null);
            }

            var token = _tokenService.GetToken(userId.Value);

            return new AuthenticateUserResults(token);

        }
    }
}
