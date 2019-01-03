namespace QuizManagement.Application.Operation.Handlers
{
    using System;
    using System.Threading.Tasks;
    using Parameters;
    using Repositories;
    using Results;
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

        public async Task<GetAllQuizzesByUserPagedResults> ExecuteAsync(GetAllQuizzesByUserPagedParameters parameters)
        {
            var quizzes =
                await _quizzesRepository
                    .GetAllByUserPagedAsync(
                        parameters.UserId,
                        parameters.StartIndex,
                        parameters.NumberOfItems)
                    .ConfigureAwait(false);

            return new GetAllQuizzesByUserPagedResults(
                quizzes.List,
                quizzes.TotalCount,
                quizzes.ItemCount,
                quizzes.StartIndex,
                quizzes.EndIndex);
        }
    }
}
