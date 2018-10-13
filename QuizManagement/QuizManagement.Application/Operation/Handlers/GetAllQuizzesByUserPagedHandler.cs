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

    public class GetAllQuizzesByUserPagedHandler
        : IHandler<GetAllQuizzesByUserPagedParameters, GetAllQuizzesByUserPagedResults>
    {
        private readonly IQuizzesRepository _quizzesRepository;

        public GetAllQuizzesByUserPagedHandler(
            IQuizzesRepository quizzesRepository)
        {
            _quizzesRepository = quizzesRepository
                                 ?? throw new ArgumentNullException(nameof(quizzesRepository));
        }

        public async Task<GetAllQuizzesByUserPagedResults> ExecuteAsync(
            GetAllQuizzesByUserPagedParameters parameters,
            CancellationToken ct = default(CancellationToken))
        {
            var quizzes =
                await _quizzesRepository
                    .GetAllByUserPagedAsync(
                        parameters.UserId,
                        parameters.StartIndex,
                        parameters.NumberOfItems,
                        ct)
                    .ConfigureAwait(false);

            return new GetAllQuizzesByUserPagedResults(
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
