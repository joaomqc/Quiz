namespace QuizManagement.Application.Operation.Handlers
{
    using Parameters;
    using Results;
    using Repositories;
    using System;
    using System.Threading.Tasks;

    public class GetAllTopicsHandler
    {
        private readonly ITopicsRepository _topicRepository;

        public GetAllTopicsHandler(ITopicsRepository topicRepository)
        {
            _topicRepository = topicRepository ?? throw new ArgumentNullException(nameof(topicRepository));
        }

        public async Task<GetAllTopicsResults> ExecuteAsync(GetAllTopicsParameters parameters)
        {
            var topics =
                await _topicRepository
                    .GetAllAsync()
                    .ConfigureAwait(false);

            return new GetAllTopicsResults(topics);
        }
    }
}
