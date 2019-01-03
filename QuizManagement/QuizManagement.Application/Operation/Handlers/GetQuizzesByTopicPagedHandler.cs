namespace QuizManagement.Application.Operation.Handlers
{
    using System.Threading.Tasks;
    using Parameters;
    using Repositories;
    using Results;
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

        public async Task<GetQuizzesByTopicPagedResults> ExecuteAsync(GetQuizzesByTopicPagedParameters parameters)
        {
            var quizzes =
                await _quizzesRepository
                    .GetByTopicPagedAsync(
                        parameters.TopicId,
                        parameters.StartIndex,
                        parameters.NumberOfItems)
                    .ConfigureAwait(false);

            return new GetQuizzesByTopicPagedResults(
                quizzes.List,
                quizzes.TotalCount,
                quizzes.ItemCount,
                quizzes.StartIndex,
                quizzes.EndIndex);
        }
    }
}
