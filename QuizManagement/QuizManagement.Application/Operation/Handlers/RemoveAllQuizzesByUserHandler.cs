namespace QuizManagement.Application.Operation.Handlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Parameters;
    using Repositories;
    using Results;
    using Shared.Operation;

    public class RemoveAllQuizzesByUserHandler
        : IHandler<RemoveAllQuizzesByUserParameters, RemoveAllQuizzesByUserResults>
    {
        private readonly IQuizzesRepository _quizzesRepository;

        public RemoveAllQuizzesByUserHandler(
            IQuizzesRepository quizzesRepository)
        {
            _quizzesRepository = quizzesRepository
                                 ?? throw new ArgumentNullException(nameof(quizzesRepository));
        }

        public async Task<RemoveAllQuizzesByUserResults> ExecuteAsync(
            RemoveAllQuizzesByUserParameters parameters,
            CancellationToken ct = default(CancellationToken))
        {
            await _quizzesRepository
                .RemoveAllByUserIdAsync(parameters.UserId, ct)
                .ConfigureAwait(false);

            return new RemoveAllQuizzesByUserResults();
        }
    }
}
