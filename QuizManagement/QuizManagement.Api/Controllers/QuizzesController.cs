namespace QuizManagement.Api.Controllers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Operation.Parameters;
    using Application.Operation.Results;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Shared.Contracts.QuizManagement.Parameters;
    using Shared.Contracts.QuizManagement.Results;
    using Shared.Executors;

    [Authorize]
    [Route("quizmanagement/quizzes")]
    [Produces("application/json")]
    [ApiController]
    public class QuizzesController : ControllerBase
    {
        private readonly IExecutor _executor;

        public QuizzesController(IExecutor queryExecutor)
        {
            _executor = queryExecutor ?? throw new ArgumentNullException(nameof(queryExecutor));
        }
        
        [HttpGet]
        [Route("test")]
        public async Task<IActionResult> GetTest()
        {
            return Ok(await Task.FromResult("hello"));
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(GetQuizzesPagedResult), 200)]
        public async Task<IActionResult> GetQuizzesPaged(
            int startIndex,
            int numberOfItems,
            CancellationToken ct = default(CancellationToken))
        {
            var quizzes =
                await _executor
                    .ExecuteAsync<GetQuizzesPagedParameters, GetQuizzesPagedResults>(
                        new GetQuizzesPagedParameters(
                            startIndex,
                            numberOfItems), ct)
                    .ConfigureAwait(false);

            var result =
                new GetQuizzesPagedResult(
                    quizzes.List,
                    quizzes.TotalCount,
                    quizzes.ItemCount,
                    quizzes.StartIndex,
                    quizzes.EndIndex);

            return Ok(result);
        }

        [HttpGet]
        [Route("{quizId:int}")]
        [ProducesResponseType(typeof(GetQuizByIdResult), 200)]
        public async Task<IActionResult> GetQuiz(
            int quizId,
            CancellationToken ct = default(CancellationToken))
        {
            var quiz =
                await _executor
                    .ExecuteAsync<GetQuizByIdParameters, GetQuizByIdResults>(
                        new GetQuizByIdParameters(
                            quizId), ct)
                    .ConfigureAwait(false);

            var result =
                new GetQuizByIdResult(
                    quiz.Id,
                    quiz.Name,
                    quiz.CreationTimestamp,
                    quiz.UserId,
                    quiz.Questions,
                    quiz.Topic,
                    quiz.IsPublic);

            return Ok(result);
        }

        [HttpGet]
        [Route("user/{userId:int}")]
        [ProducesResponseType(typeof(GetQuizzesPagedResult), 200)]
        public async Task<IActionResult> GetQuizzesByUserPaged(
            int userId,
            int startIndex,
            int numberOfItems,
            CancellationToken ct = default(CancellationToken))
        {
            var quizzes =
                await _executor
                    .ExecuteAsync<GetAllQuizzesByUserPagedParameters, GetAllQuizzesByUserPagedResults>(
                        new GetAllQuizzesByUserPagedParameters(
                            userId,
                            startIndex,
                            numberOfItems), ct)
                    .ConfigureAwait(false);
            
            var result =
                new GetQuizzesPagedResult(
                    quizzes.List,
                    quizzes.TotalCount,
                    quizzes.ItemCount,
                    quizzes.StartIndex,
                    quizzes.EndIndex);

            return Ok(result);
        }

        [HttpGet]
        [Route("user/{userId:int}/public")]
        [ProducesResponseType(typeof(GetQuizzesPagedResult), 200)]
        public async Task<IActionResult> GetPublicQuizzesByUserPaged(
            int userId,
            int startIndex,
            int numberOfItems,
            CancellationToken ct = default(CancellationToken))
        {
            var quizzes =
                await _executor
                    .ExecuteAsync<GetPublicQuizzesByUserPagedParameters, GetPublicQuizzesByUserPagedResults>(
                        new GetPublicQuizzesByUserPagedParameters(
                            userId,
                            startIndex,
                            numberOfItems), ct)
                    .ConfigureAwait(false);

            var result =
                new GetQuizzesPagedResult(
                    quizzes.List,
                    quizzes.TotalCount,
                    quizzes.ItemCount,
                    quizzes.StartIndex,
                    quizzes.EndIndex);

            return Ok(result);
        }

        [HttpGet]
        [Route("topic/{topicId:int}")]
        [ProducesResponseType(typeof(GetQuizzesPagedResult), 200)]
        public async Task<IActionResult> GetQuizzesByTopicPaged(
            int topicId,
            int startIndex,
            int numberOfItems,
            CancellationToken ct = default(CancellationToken))
        {
            var quizzes =
                await _executor
                    .ExecuteAsync<GetQuizzesByTopicPagedParameters, GetQuizzesByTopicPagedResults>(
                        new GetQuizzesByTopicPagedParameters(
                            topicId,
                            startIndex,
                            numberOfItems), ct)
                    .ConfigureAwait(false);

            var result =
                new GetQuizzesPagedResult(
                    quizzes.List,
                    quizzes.TotalCount,
                    quizzes.ItemCount,
                    quizzes.StartIndex,
                    quizzes.EndIndex);

            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(void), 200)]
        public async Task<IActionResult> CreateQuiz(
            CreateQuizParameter parameters,
            CancellationToken ct = default(CancellationToken))
        {
            await _executor
                .ExecuteAsync<CreateQuizParameters, CreateQuizResults>(
                    new CreateQuizParameters(
                        parameters.Name,
                        parameters.CreationTimestamp,
                        parameters.UserId,
                        parameters.Questions,
                        parameters.TopicId,
                        parameters.IsPublic),
                    ct)
                .ConfigureAwait(false);

            return Ok();
        }

        [HttpDelete]
        [Route("{quizId:int}")]
        [ProducesResponseType(typeof(void), 200)]
        public async Task<IActionResult> RemoveQuiz(
            int quizId,
            CancellationToken ct = default(CancellationToken))
        {
            await _executor
                .ExecuteAsync<RemoveQuizByIdParameters, RemoveQuizByIdResults>(
                    new RemoveQuizByIdParameters(quizId), ct)
                .ConfigureAwait(false);

            return Ok();
        }

        [HttpDelete]
        [Route("/user/{userId:int}")]
        [ProducesResponseType(typeof(void), 200)]
        public async Task<IActionResult> RemoveAllQuizzesByUser(
            int userId,
            CancellationToken ct = default(CancellationToken))
        {
            await _executor
                .ExecuteAsync<RemoveAllQuizzesByUserParameters, RemoveAllQuizzesByUserResults>(
                    new RemoveAllQuizzesByUserParameters(userId), ct)
                .ConfigureAwait(false);

            return Ok();
        }

        [HttpDelete]
        [Route("/user/{userId:int}/private")]
        [ProducesResponseType(typeof(void), 200)]
        public async Task<IActionResult> RemovePrivateQuizzesByUser(
            int userId,
            CancellationToken ct = default(CancellationToken))
        {
            await _executor
                .ExecuteAsync<RemovePrivateQuizzesByUserParameters, RemovePrivateQuizzesByUserResults>(
                    new RemovePrivateQuizzesByUserParameters(userId), ct)
                .ConfigureAwait(false);

            return Ok();
        }
    }
}
