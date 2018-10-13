namespace QuizManagement.Domain
{
    using System.Collections.Generic;

    public class QuestionAttempt
    {
        public QuestionAttempt(
            int id,
            Question question,
            IEnumerable<Answer> answers,
            bool isCorrect)
        {
            Id = id;
            Question = question;
            Answers = answers;
            IsCorrect = isCorrect;
        }

        public int Id { get; }
        public Question Question { get; }
        public IEnumerable<Answer> Answers { get; }
        public bool IsCorrect { get; }
    }
}
