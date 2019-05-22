namespace UserManagement.RPC.Controllers
{
    using System;
    using System.Net.Mail;
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

        public override async Task<GetUserByUserIdResult> GetUserByUserId(
            GetUserByUserIdParameter request,
            ServerCallContext context)
        {
            if (string.IsNullOrWhiteSpace(request.UserId) || !Guid.TryParse(request.UserId, out var userId))
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "username"));
            }

            var user =
                await _executor
                    .ExecuteAsync<GetUserByExternalIdParameters, GetUserByExternalIdResults>(
                        new GetUserByExternalIdParameters(userId))
                    .ConfigureAwait(false);

            return new GetUserByUserIdResult {
                Email = user.Email,
                Username = user.Username
            };
        }

        public override async Task<Empty> RegisterUser(
            RegisterUserParameter request,
            ServerCallContext context)
        {
            if (string.IsNullOrWhiteSpace(request.Username) ||
                string.IsNullOrWhiteSpace(request.Email))
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid fields."));
            }

            try
            {
                new MailAddress(request.Email);
            }
            catch
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid field."));
            }
            
            var registerResult =
                await _executor
                    .ExecuteAsync<RegisterUserParameters, RegisterUserResults>(
                        new RegisterUserParameters(
                            request.Email,
                            request.Username,
                            request.Password))
                    .ConfigureAwait(false);

            if (!registerResult.Succeeded)
            {
                throw new RpcException(new Status(StatusCode.Unauthenticated, "Credentials already registered."));
            }

            return new Empty();
        }

        public override async Task<AuthenticateUserResult> AuthenticateUser(
            AuthenticateUserParameter request,
            ServerCallContext context)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid fields."));
            }

            var tokenResult =
                await _executor
                    .ExecuteAsync<AuthenticateUserParameters, AuthenticateUserResults>(
                        new AuthenticateUserParameters(
                            request.Username,
                            request.Password))
                    .ConfigureAwait(false);

            if (tokenResult.Token == null)
            {
                throw new RpcException(new Status(StatusCode.Unauthenticated, "Invalid credentials."));
            }
            
            return new AuthenticateUserResult
            {
                AccessToken = tokenResult.Token.AccessToken,
                ExpiresIn = tokenResult.Token.ExpiresIn
            };
        }
    }
}
