namespace UserManagement.Api.Controllers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Operation.Parameters;
    using Application.Operation.Results;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Shared.Contracts.UserManagement.Parameters;
    using Shared.Contracts.UserManagement.Results;
    using Shared.Executors;

    [Authorize]
    [Route("usermanagement/users")]
    [Produces("application/json")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IExecutor _executor;

        public UsersController(IExecutor executor)
        {
            _executor = executor
                        ?? throw new ArgumentNullException(nameof(executor));
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(GetUserByIdResult), 200)]
        public async Task<IActionResult> GetUserById(
            int id,
            CancellationToken ct = default(CancellationToken))
        {
            var user =
                await _executor
                    .ExecuteAsync<GetUserByIdParameters, GetUserByIdResults>(
                        new GetUserByIdParameters(id), ct)
                    .ConfigureAwait(false);

            var result =
                new GetUserByIdResult(
                    user.Id,
                    user.Email,
                    user.Username,
                    user.Password);

            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(void), 200)]
        public async Task<IActionResult> RegisterUser(
            RegisterUserParameter parameters,
            CancellationToken ct = default(CancellationToken))
        {
            await _executor
                .ExecuteAsync<RegisterUserParameters, RegisterUserResults>(
                    new RegisterUserParameters(
                        parameters.Username,
                        parameters.Email,
                        parameters.Password), ct)
                .ConfigureAwait(false);

            return Ok();
        }

        [HttpPost]
        [Route("authenticate")]
        [ProducesResponseType(typeof(AuthenticateUserResult), 200)]
        public async Task<IActionResult> AuthenticateUser(
            AuthenticateUserParameter parameters,
            CancellationToken ct = default(CancellationToken))
        {
            var isAuthenticated =
                await _executor
                    .ExecuteAsync<AuthenticateUserParameters, AuthenticateUserResults>(
                        new AuthenticateUserParameters(
                            parameters.Username,
                            parameters.Password), ct);

            if (!isAuthenticated.IsAuthenticated)
            {
                return BadRequest();
            }

            var user =
                await _executor
                    .ExecuteAsync<GetUserByUsernameParameters, GetUserByUsernameResults>(
                        new GetUserByUsernameParameters(parameters.Username), ct)
                    .ConfigureAwait(false);
            
            var result = new AuthenticateUserResult(user.Id);

            return Ok(result);
        }
    }
}
