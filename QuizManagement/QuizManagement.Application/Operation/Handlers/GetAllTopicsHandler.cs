namespace QuizManagement.Application.Operation.Handlers
{
    using Parameters;
    using Results;
    using Repositories;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Shared.Contracts.QuizManagement.Results.InnerTypes;

    public class GetAllTopicsHandler
    {
        private readonly ITopicsRepository _topicRepository;

        public GetAllTopicsHandler(ITopicsRepository topicRepository)
        {
            _topicRepository = topicRepository ?? throw new ArgumentNullException(nameof(topicRepository));
        }

        public async Task<GetAllTopicsResults> ExecuteAsync(
            GetAllTopicsParameters parameters,
            CancellationToken ct = default(CancellationToken))
        {
            var topics =
                await _topicRepository
                    .GetAllAsync(ct)
                    .ConfigureAwait(false);

            return new GetAllTopicsResults(
                topics.Select(
                    topic => new TopicDetailsResult(
                        topic.Id,
                        topic.Name,
                        topic.Description))
                .ToList());
        }
    }
}
