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
                id: quiz.Id,
                name: quiz.Name,
                creationTimestamp: quiz.CreationTimestamp,
                userId: quiz.UserId,
                questions: quiz.Questions,
                topic: new TopicDetails(
                    id: topic.Id,
                    name: topic.Name,
                    imageUrl: topic.ImageUrl),
                isPublic: quiz.IsPublic,
                imageUrl: quiz.ImageUrl);
        }
    }
}
