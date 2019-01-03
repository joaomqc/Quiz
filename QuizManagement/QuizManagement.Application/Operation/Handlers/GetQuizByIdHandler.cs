namespace QuizManagement.Application.Operation.Handlers
{
    using System;
    using System.Threading.Tasks;
    using Domain;
    using Parameters;
    using Repositories;
    using Results;
    using Shared.Operation;

    public class GetQuizByIdHandler : IHandler<GetQuizByIdParameters, GetQuizByIdResults>
    {
        private readonly IQuizzesRepository _quizRepository;
        private readonly ITopicsRepository _topicsRepository;

        public GetQuizByIdHandler(
            IQuizzesRepository quizRepository,
            ITopicsRepository topicsRepository)
        {
            _quizRepository = quizRepository
                              ?? throw new ArgumentNullException(nameof(quizRepository));

            _topicsRepository = topicsRepository
                                ?? throw new ArgumentNullException(nameof(topicsRepository));
        }

        public async Task<GetQuizByIdResults> ExecuteAsync(GetQuizByIdParameters parameters)
        {
            var quiz =
                await _quizRepository
                    .GetByIdAsync(parameters.QuizId)
                    .ConfigureAwait(false);

            var topic =
                await _topicsRepository
                    .GetByIdAsync(quiz.TopicId)
                    .ConfigureAwait(false);


            return new GetQuizByIdResults(
                quiz.Id,
                quiz.Name,
                quiz.CreationTimestamp,
                quiz.UserId,
                quiz.Questions,
                new TopicDetails(
                    topic.Id,
                    topic.Name),
                quiz.IsPublic);
        }
    }
}
