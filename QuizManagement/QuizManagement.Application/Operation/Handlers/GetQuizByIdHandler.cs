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

    public class GetQuizByIdHandler : IHandler<GetQuizByIdParameters, GetQuizByIdResults>
    {
        private readonly IQuizzesRepository _quizRepository;
        private readonly ITopicsRepository _topicsRepository;

        public GetQuizByIdHandler(
            IQuizzesRepository quizRepository,
            ITopicsRepository topicsRepository)
        {
            _quizRepository = quizRepository
                              ?? throw new ArgumentNullException(nameof(quizRepository));

            _topicsRepository = topicsRepository
                                ?? throw new ArgumentNullException(nameof(topicsRepository));
        }

        public async Task<GetQuizByIdResults> ExecuteAsync(
            GetQuizByIdParameters parameters,
            CancellationToken ct = default(CancellationToken))
        {
            var quiz =
                await _quizRepository
                    .GetByIdAsync(parameters.QuizId, ct)
                    .ConfigureAwait(false);

            var topic =
                await _topicsRepository
                    .GetByIdAsync(quiz.TopicId, ct)
                    .ConfigureAwait(false);
                    

            return new GetQuizByIdResults(
                quiz.Id,
                quiz.Name,
                quiz.CreationTimestamp,
                quiz.UserId,
                quiz.Questions
                    .Select(question => new QuestionResult(
                        question.Id,
                        question.Text,
                        question.IsMultipleChoice,
                        question.Answers
                            .Select(answer => new AnswerResult(
                                answer.Id,
                                answer.Text,
                                answer.IsCorrect))
                            .ToList()))
                    .ToList(),
                new TopicResult(
                    topic.Id,
                    topic.Name),
                quiz.IsPublic);
        }
    }
}
