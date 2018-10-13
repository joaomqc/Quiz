namespace QuizManagement.Application.Operation.Handlers
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Parameters;
    using Repositories;
    using Results;
    using Shared.Contracts.QuizManagement.Results.InnerTypes;
    using Shared.Operation;

    public class GetPublicQuizzesByUserPagedHandler
        : IHandler<GetPublicQuizzesByUserPagedParameters, GetPublicQuizzesByUserPagedResults>
    {
        private readonly IQuizzesRepository _quizzesRepository;

        public GetPublicQuizzesByUserPagedHandler(
            IQuizzesRepository quizzesRepository)
        {
            _quizzesRepository = quizzesRepository;
        }

        public async Task<GetPublicQuizzesByUserPagedResults> ExecuteAsync(
            GetPublicQuizzesByUserPagedParameters parameters,
            CancellationToken ct = default(CancellationToken))
        {
            var quizzes =
                await _quizzesRepository
                    .GetPublicByUserPagedAsync(
                        parameters.UserId,
                        parameters.StartIndex,
                        parameters.NumberOfItems,
                        ct)
                    .ConfigureAwait(false);

            return new GetPublicQuizzesByUserPagedResults(
                quizzes.List.Select(
                    quiz => new QuizResult(
                        quiz.Id,
                        quiz.Name,
                        quiz.CreationTimestamp,
                        quiz.UserId,
                        new TopicResult(
                            quiz.Topic.Id,
                            quiz.Topic.Name),
                        quiz.IsPublic))
                    .ToList(),
                quizzes.TotalCount,
                quizzes.ItemCount,
                quizzes.StartIndex,
                quizzes.EndIndex);
        }
    }
}
