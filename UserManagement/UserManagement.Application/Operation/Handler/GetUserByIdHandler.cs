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
        private readonly IUserRepository _userRepository;

        public GetUserByIdHandler(
            IUserRepository userRepository)
        {
            _userRepository = userRepository
                              ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<GetUserByIdResults> ExecuteAsync(
            GetUserByIdParameters parameters,
            CancellationToken ct = default(CancellationToken))
        {
            var user =
                await _userRepository
                    .GetById(parameters.Id, ct)
                    .ConfigureAwait(false);

            return new GetUserByIdResults(
                user.Id,
                user.Email,
                user.Username,
                user.Password);
        }
    }
}
