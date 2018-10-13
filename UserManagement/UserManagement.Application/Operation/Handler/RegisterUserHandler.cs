namespace UserManagement.Application.Operation.Handler
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain;
    using Parameters;
    using Repositories;
    using Results;
    using Shared.Operation;

    public class RegisterUserHandler
        : IHandler<RegisterUserParameters, RegisterUserResults>
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserHandler(
            IUserRepository userRepository)
        {
            _userRepository = userRepository
                              ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<RegisterUserResults> ExecuteAsync(
            RegisterUserParameters parameters,
            CancellationToken ct = default(CancellationToken))
        {
            await _userRepository
                .RegisterUser(
                    User.CreateNewUser(
                        parameters.Email,
                        parameters.Username,
                        parameters.Password), ct)
                .ConfigureAwait(false);

            return new RegisterUserResults();
        }
    }
}
