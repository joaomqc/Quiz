namespace Shared.Contracts.QuizManagement.Parameters.InnerTypes
{
    public class AnswerParameter
    {
        public AnswerParameter(
            string text,
            bool isCorrect)
        {
            Text = text;
            IsCorrect = isCorrect;
        }
        
        public string Text { get; }
        public bool IsCorrect { get; }
    }
}
