namespace QuizManagement.Application.Operation.Handlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Parameters;
    using Repositories;
    using Results;
    using Shared.Operation;

    public class RemoveQuizByIdHandler : IHandler<RemoveQuizByIdParameters, RemoveQuizByIdResults>
    {
        private readonly IQuizzesRepository _quizzesRepository;

        public RemoveQuizByIdHandler(
            IQuizzesRepository quizzesRepository)
        {
            _quizzesRepository = quizzesRepository
                                 ?? throw new ArgumentNullException(nameof(quizzesRepository));
        }

        public async Task<RemoveQuizByIdResults> ExecuteAsync(
            RemoveQuizByIdParameters parameters,
            CancellationToken ct = default(CancellationToken))
        {
            await _quizzesRepository
                .RemoveByIdAsync(parameters.QuizId, ct)
                .ConfigureAwait(false);

            return new RemoveQuizByIdResults();
        }
    }
}
