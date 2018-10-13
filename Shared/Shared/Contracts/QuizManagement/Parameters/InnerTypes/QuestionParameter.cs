namespace Shared.Contracts.QuizManagement.Parameters.InnerTypes
{
    using System.Collections.Generic;

    public class QuestionParameter
    {
        public QuestionParameter(
            string text,
            bool isMultipleChoice,
            IEnumerable<AnswerParameter> answers)
        {
            Text = text;
            IsMultipleChoice = isMultipleChoice;
            Answers = answers;
        }
        
        public string Text { get; }
        public bool IsMultipleChoice { get; }
        public IEnumerable<AnswerParameter> Answers { get; }
    }
}
