namespace QuizManagement.Application.Operation.Handlers
{
    using System;
    using System.Threading.Tasks;
    using Parameters;
    using Repositories;
    using Results;
    using Shared.Operation;

    public class GetTopicByIdHandler : IHandler<GetTopicByIdParameters, GetTopicByIdResults>
    {
        private readonly ITopicsRepository _topicsRepository;

        public GetTopicByIdHandler(ITopicsRepository topicsRepository)
        {
            _topicsRepository = topicsRepository ??
                                throw new ArgumentNullException(nameof(topicsRepository));
        }

        public async Task<GetTopicByIdResults> ExecuteAsync(GetTopicByIdParameters parameters)
        {
            var topic = await _topicsRepository
                .GetByIdAsync(parameters.TopicId)
                .ConfigureAwait(false);

            return new GetTopicByIdResults(
                id: topic.Id,
                name: topic.Name,
                description: topic.Description,
                url: topic.Url);
        }
    }
}
