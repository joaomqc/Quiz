namespace Shared.Contracts.QuizManagement.Results.InnerTypes
{
    using System.Collections.Generic;

    public class QuestionResult
    {
        public QuestionResult(
            int id,
            string text,
            bool isMultipleChoice,
            IEnumerable<AnswerResult> answers)
        {
            Id = id;
            Text = text;
            IsMultipleChoice = isMultipleChoice;
            Answers = answers;
        }

        public int Id { get; }
        public string Text { get; }
        public bool IsMultipleChoice { get; }
        public IEnumerable<AnswerResult> Answers { get; }
    }
}
