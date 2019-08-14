namespace QuizManagement.Application.Operation.Handlers
{
    using System;
    using System.Linq;
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
                        name: parameters.Name,
                        userId: parameters.UserId,
                        questions: parameters.Questions.Select(
                            question => Question.CreateNewQuestion(
                                text: question.Text,
                                isMultipleChoice: question.IsMultipleChoice,
                                answers: question.Answers.Select(
                                    answer => Answer.CreateNewAnswer(
                                        text: answer.Text,
                                        isCorrect: answer.IsCorrect))
                                    .ToList()))
                            .ToList(),
                        topicId: parameters.TopicId,
                        isPublic: parameters.IsPublic,
                        imageUrl: parameters.ImageUrl))
                .ConfigureAwait(false);

            return new CreateQuizResults();
        }
    }
}
