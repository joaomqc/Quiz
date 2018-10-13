namespace Shared.Contracts.QuizManagement.Results.InnerTypes
{
    public class AnswerResult
    {
        public AnswerResult(
            int id,
            string text,
            bool isCorrect)
        {
            Id = id;
            Text = text;
            IsCorrect = isCorrect;
        }

        public int Id { get; }
        public string Text { get; }
        public bool IsCorrect { get; }
    }
}
