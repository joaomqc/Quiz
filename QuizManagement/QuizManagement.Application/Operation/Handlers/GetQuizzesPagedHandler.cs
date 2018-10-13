namespace QuizManagement.Application.Operation.Handlers
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Parameters;
    using Repositories;
    using Results;
    using Shared.Contracts.QuizManagement.Results.InnerTypes;
    using Shared.Operation;

    public class GetQuizzesPagedHandler : IHandler<GetQuizzesPagedParameters, GetQuizzesPagedResults>
    {
        private readonly IQuizzesRepository _quizRepository;

        public GetQuizzesPagedHandler(
            IQuizzesRepository quizRepository)
        {
            _quizRepository = quizRepository
                              ?? throw new ArgumentNullException(nameof(quizRepository));
        }

        public async Task<GetQuizzesPagedResults> ExecuteAsync(
            GetQuizzesPagedParameters parameters,
            CancellationToken ct = default(CancellationToken))
        {
            var quizzes =
                await _quizRepository
                    .GetPublicPagedAsync(
                        parameters.StartIndex,
                        parameters.NumberOfItems,
                        ct)
                    .ConfigureAwait(false);
            
            return new GetQuizzesPagedResults(
                quizzes.List
                    .Select(quiz => new QuizResult(
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
