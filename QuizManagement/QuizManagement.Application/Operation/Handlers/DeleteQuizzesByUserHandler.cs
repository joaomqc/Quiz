namespace QuizManagement.Application.Operation.Handlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Parameters;
    using Repositories;
    using Results;
    using Shared.Operation;

    public class DeleteQuizzesByUserHandler
        : IHandler<DeleteQuizzesByUserParameters, DeleteQuizzesByUserResults>
    {
        private readonly IQuizzesRepository _quizzesRepository;

        public DeleteQuizzesByUserHandler(
            IQuizzesRepository quizzesRepository)
        {
            _quizzesRepository = quizzesRepository
                                 ?? throw new ArgumentNullException(nameof(quizzesRepository));
        }

        public async Task<DeleteQuizzesByUserResults> ExecuteAsync(DeleteQuizzesByUserParameters parameters)
        {
            await _quizzesRepository
                .DeleteByUserIdAsync(parameters.UserId, parameters.KeepPublic)
                .ConfigureAwait(false);

            return new DeleteQuizzesByUserResults();
        }
    }
}
