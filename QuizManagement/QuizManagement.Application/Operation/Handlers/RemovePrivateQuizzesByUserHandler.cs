namespace QuizManagement.Application.Operation.Handlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Parameters;
    using Repositories;
    using Results;
    using Shared.Operation;

    public class RemovePrivateQuizzesByUserHandler
        : IHandler<RemovePrivateQuizzesByUserParameters, RemovePrivateQuizzesByUserResults>
    {
        private readonly IQuizzesRepository _quizzesRepository;

        public RemovePrivateQuizzesByUserHandler(
            IQuizzesRepository quizzesRepository)
        {
            _quizzesRepository = quizzesRepository
                                 ?? throw new ArgumentNullException(nameof(quizzesRepository));
        }

        public async Task<RemovePrivateQuizzesByUserResults> ExecuteAsync(
            RemovePrivateQuizzesByUserParameters parameters,
            CancellationToken ct = default(CancellationToken))
        {
            await _quizzesRepository
                .RemovePrivateByUserIdAsync(parameters.UserId, ct)
                .ConfigureAwait(false);

            return new RemovePrivateQuizzesByUserResults();
        }
    }
}
