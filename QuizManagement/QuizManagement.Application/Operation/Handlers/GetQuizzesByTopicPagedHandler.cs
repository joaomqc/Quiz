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

    public class GetQuizzesByTopicPagedHandler
        : IHandler<GetQuizzesByTopicPagedParameters, GetQuizzesByTopicPagedResults>
    {
        private readonly IQuizzesRepository _quizzesRepository;

        public GetQuizzesByTopicPagedHandler(
            IQuizzesRepository quizzesRepository)
        {
            _quizzesRepository = quizzesRepository;
        }

        public async Task<GetQuizzesByTopicPagedResults> ExecuteAsync(
            GetQuizzesByTopicPagedParameters parameters,
            CancellationToken ct = default(CancellationToken))
        {
            var quizzes =
                await _quizzesRepository
                    .GetByTopicPagedAsync(
                        parameters.TopicId,
                        parameters.StartIndex,
                        parameters.NumberOfItems,
                        ct)
                    .ConfigureAwait(false);

            return new GetQuizzesByTopicPagedResults(
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
