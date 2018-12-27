namespace QuizManagement.Application.Operation.Handlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Parameters;
    using Repositories;
    using Results;
    using Shared.Operation;

    public class DeleteQuizByIdHandler : IHandler<DeleteQuizByIdParameters, DeleteQuizByIdResults>
    {
        private readonly IQuizzesRepository _quizzesRepository;

        public DeleteQuizByIdHandler(
            IQuizzesRepository quizzesRepository)
        {
            _quizzesRepository = quizzesRepository
                                 ?? throw new ArgumentNullException(nameof(quizzesRepository));
        }

        public async Task<DeleteQuizByIdResults> ExecuteAsync(DeleteQuizByIdParameters parameters)
        {
            await _quizzesRepository
                .DeleteByIdAsync(parameters.QuizId)
                .ConfigureAwait(false);

            return new DeleteQuizByIdResults();
        }
    }
}
