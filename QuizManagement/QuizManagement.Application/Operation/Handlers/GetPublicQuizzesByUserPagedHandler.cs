namespace QuizManagement.Application.Operation.Handlers
{
    using System.Threading.Tasks;
    using Parameters;
    using Repositories;
    using Results;
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

        public async Task<GetPublicQuizzesByUserPagedResults> ExecuteAsync(GetPublicQuizzesByUserPagedParameters parameters)
        {
            var quizzes =
                await _quizzesRepository
                    .GetPublicByUserPagedAsync(
                        parameters.UserId,
                        parameters.StartIndex,
                        parameters.NumberOfItems)
                    .ConfigureAwait(false);

            return new GetPublicQuizzesByUserPagedResults(
                quizzes.List,
                quizzes.TotalCount,
                quizzes.ItemCount,
                quizzes.StartIndex,
                quizzes.EndIndex);
        }
    }
}
