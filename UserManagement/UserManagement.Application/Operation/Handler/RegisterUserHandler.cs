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
            var userExists =
                await _usersRepository
                    .CheckUserExistsAsync(
                        new User(
                            email: parameters.Email,
                            username: parameters.Username))
                    .ConfigureAwait(false);

            if (userExists)
            {
                return new RegisterUserResults(false);
            }

            await _usersRepository
                .RegisterUserAsync(
                    new User(
                        parameters.Email,
                        parameters.Username),
                    parameters.Password)
                .ConfigureAwait(false);

            return new RegisterUserResults(true);
        }
    }
}
