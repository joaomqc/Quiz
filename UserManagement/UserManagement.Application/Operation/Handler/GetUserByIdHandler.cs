namespace UserManagement.Application.Operation.Handler
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Parameters;
    using Repositories;
    using Results;
    using Shared.Operation;

    public class GetUserByIdHandler
        : IHandler<GetUserByIdParameters, GetUserByIdResults>
    {
        private readonly IUsersRepository _usersRepository;

        public GetUserByIdHandler(
            IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository
                              ?? throw new ArgumentNullException(nameof(usersRepository));
        }

        public async Task<GetUserByIdResults> ExecuteAsync(GetUserByIdParameters parameters)
        {
            var user =
                await _usersRepository
                    .GetById(parameters.Id)
                    .ConfigureAwait(false);

            return new GetUserByIdResults(
                user.Id,
                user.Email,
                user.Username,
                user.Password);
        }
    }
}
