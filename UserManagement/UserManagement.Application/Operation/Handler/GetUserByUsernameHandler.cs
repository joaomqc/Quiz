namespace UserManagement.Application.Operation.Handler
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Parameters;
    using Repositories;
    using Results;
    using Shared.Operation;

    public class GetUserByUsernameHandler
        : IHandler<GetUserByUsernameParameters, GetUserByUsernameResults>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByUsernameHandler(
            IUserRepository userRepository)
        {
            _userRepository = userRepository
                              ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<GetUserByUsernameResults> ExecuteAsync(
            GetUserByUsernameParameters parameters,
            CancellationToken ct = default(CancellationToken))
        {
            var user =
                await _userRepository
                    .GetByUsername(parameters.Username, ct)
                    .ConfigureAwait(false);

            return new GetUserByUsernameResults(user.Id);
        }
    }
}
