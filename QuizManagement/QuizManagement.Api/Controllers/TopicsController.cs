namespace QuizManagement.Api.Controllers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Operation.Parameters;
    using Application.Operation.Results;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Shared.Contracts.QuizManagement.Results;
    using Shared.Executors;

    [Authorize]
    [Route("quizmanagement/topics")]
    [Produces("application/json")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        private readonly IExecutor _executor;

        public TopicsController(IExecutor executor)
        {
            _executor = executor ?? throw new ArgumentNullException(nameof(executor));
        }
        
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(GetAllTopicsResult), 200)]
        public async Task<IActionResult> GetAllTopics(
            CancellationToken ct = default(CancellationToken))
        {
            var topics =
                await _executor
                    .ExecuteAsync<GetAllTopicsParameters, GetAllTopicsResults>(
                        new GetAllTopicsParameters(), ct)
                    .ConfigureAwait(false);

            var result = new GetAllTopicsResult(topics.Topics);

            return Ok(result);
        }

        [HttpGet]
        [Route("{topicId:int}")]
        [ProducesResponseType(typeof(GetTopicByIdResult), 200)]
        public async Task<IActionResult> GetTopicById(
            int topicId,
            CancellationToken ct = default(CancellationToken))
        {
            var topic =
                await _executor
                    .ExecuteAsync<GetTopicByIdParameters, GetTopicByIdResults>(
                        new GetTopicByIdParameters(topicId), ct)
                    .ConfigureAwait(false);

            var result =
                new GetTopicByIdResult(
                    topic.Id,
                    topic.Name,
                    topic.Description);

            return Ok(result);
        }
    }
}
