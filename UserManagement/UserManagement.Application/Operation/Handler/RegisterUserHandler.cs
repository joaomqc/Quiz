namespace UserManagement.Application.Operation.Handler
{
    using System;
    using System.Threading.Tasks;
    using Domain;
    using Parameters;
    using Repositories;
    using Results;
    using Shared.Operation;

    public class RegisterUserHandler
        : IHandler<RegisterUserParameters, RegisterUserResults>
    {
        private readonly IUsersRepository _usersRepository;

        public RegisterUserHandler(
            IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository
                              ?? throw new ArgumentNullException(nameof(usersRepository));
        }

        public async Task<RegisterUserResults> ExecuteAsync(RegisterUserParameters parameters)
        {
            await _usersRepository
                .RegisterUser(
                    new User(
                        parameters.Email,
                        parameters.Username),
                    parameters.Password)
                .ConfigureAwait(false);

            return new RegisterUserResults();
        }
    }
}
