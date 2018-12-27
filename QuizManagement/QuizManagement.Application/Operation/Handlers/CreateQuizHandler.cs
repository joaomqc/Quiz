namespace QuizManagement.Application.Operation.Handlers
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain;
    using Parameters;
    using Repositories;
    using Results;
    using Shared.Operation;

    public class CreateQuizHandler : IHandler<CreateQuizParameters, CreateQuizResults>
    {
        private readonly IQuizzesRepository _quizzesRepository;

        public CreateQuizHandler(
            IQuizzesRepository quizzesRepository)
        {
            _quizzesRepository = quizzesRepository
                                 ?? throw new ArgumentNullException(nameof(quizzesRepository));
        }

        public async Task<CreateQuizResults> ExecuteAsync(CreateQuizParameters parameters)
        {
            await _quizzesRepository
                .InsertAsync(
                    Quiz.CreateNewQuiz(
                        parameters.Name,
                        parameters.CreationTimestamp,
                        parameters.UserId,
                        parameters.Questions.Select(
                            question => Question.CreateNewQuestion(
                                question.Text,
                                question.IsMultipleChoice,
                                question.Answers.Select(
                                    answer => Answer.CreateNewAnswer(
                                        answer.Text,
                                        answer.IsCorrect))
                                    .ToList()))
                            .ToList(),
                        parameters.TopicId,
                        parameters.IsPublic))
                .ConfigureAwait(false);

            return new CreateQuizResults();
        }
    }
}
