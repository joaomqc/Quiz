namespace UserManagement.Application.Operation.Handler
{
    using System;
    using System.Threading.Tasks;
    using Parameters;
    using Repositories;
    using Results;
    using Shared.Operation;

    public class GetUserByExternalIdHandler
        : IHandler<GetUserByExternalIdParameters, GetUserByExternalIdResults>
    {
        private readonly IUsersRepository _usersRepository;

        public GetUserByExternalIdHandler(
            IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository
                              ?? throw new ArgumentNullException(nameof(usersRepository));
        }

        public async Task<GetUserByExternalIdResults> ExecuteAsync(GetUserByExternalIdParameters parameters)
        {
            var user =
                await _usersRepository
                    .GetByExternalIdAsync(parameters.ExternalId)
                    .ConfigureAwait(false);

            return new GetUserByExternalIdResults(
                user.Username,
                user.Email);
        }
    }
}
