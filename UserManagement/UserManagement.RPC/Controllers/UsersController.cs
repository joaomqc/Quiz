namespace UserManagement.RPC.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Application.Operation.Parameters;
    using Application.Operation.Results;
    using Grpc.Core;
    using Shared.Contracts.Common;
    using Shared.Contracts.UserManagement.Users;
    using Shared.Executors;

    public class UsersController : UsersService.UsersServiceBase
    {
        private readonly IExecutor _executor;

        public UsersController(IExecutor executor)
        {
            _executor = executor ?? throw new ArgumentNullException(nameof(executor));
        }

        public override async Task<GetUserByUsernameResult> GetUserByUsername(
            GetUserByUsernameParameter request,
            ServerCallContext context)
        {
            var user =
                await _executor
                    .ExecuteAsync<GetUserByUsernameParameters, GetUserByUsernameResults>(
                        new GetUserByUsernameParameters(request.Username))
                    .ConfigureAwait(false);

            return new GetUserByUsernameResult {
                Email = user.Email,
                Username = user.Username
            };
        }

        public override async Task<Empty> RegisterUser(
            RegisterUserParameter request,
            ServerCallContext context)
        {
            await _executor
                .ExecuteAsync<RegisterUserParameters, RegisterUserResults>(
                    new RegisterUserParameters(
                        request.Username,
                        request.Email,
                        request.Password))
                .ConfigureAwait(false);

            return new Empty();
        }

        public override async Task<AuthenticateUserResult> AuthenticateUser(
            AuthenticateUserParameter request,
            ServerCallContext context)
        {
            var isAuthenticated =
                await _executor
                    .ExecuteAsync<AuthenticateUserParameters, AuthenticateUserResults>(
                        new AuthenticateUserParameters(
                            request.Username,
                            request.Password))
                    .ConfigureAwait(false);
            
            return new AuthenticateUserResult
            {
                IsAuthenticated = isAuthenticated.IsAuthenticated
            };
        }
    }
}
