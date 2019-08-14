namespace QuizManagement.Rpc.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Operation.Parameters;
    using Application.Operation.Results;
    using Grpc.Core;
    using Shared.Contracts.Common;
    using Shared.Contracts.QuizManagement.Topics;
    using Shared.Executors;

    public class TopicsController : TopicsService.TopicsServiceBase
    {
        private readonly IExecutor _executor;

        public TopicsController(IExecutor executor)
        {
            _executor = executor ?? throw new ArgumentNullException(nameof(executor));
        }

        public override async Task<GetAllTopicsResult> GetAllTopics(
            Empty request,
            ServerCallContext context)
        {
            var topics =
                await _executor
                    .ExecuteAsync<GetAllTopicsParameters, GetAllTopicsResults>(
                        new GetAllTopicsParameters())
                    .ConfigureAwait(false);

            return new GetAllTopicsResult
            {
                Topics =
                {
                    topics.Topics.Select(
                        topic => new TopicResult
                        {
                            Description = topic.Description,
                            Name = topic.Name,
                            TopicId = topic.Id,
                            ImageUrl = topic.ImageUrl
                        })
                }
            };
        }

        public override async Task<GetTopicByIdResult> GetTopicById(
            GetTopicByIdParameter request,
            ServerCallContext context)
        {
            var topic =
                await _executor
                    .ExecuteAsync<GetTopicByIdParameters, GetTopicByIdResults>(
                        new GetTopicByIdParameters(request.TopicId))
                    .ConfigureAwait(false);

            return new GetTopicByIdResult
            {
                Description = topic.Description,
                Name = topic.Name,
                TopicId = topic.Id,
                ImageUrl = topic.ImageUrl
            };
        }
    }
}
