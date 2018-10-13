namespace QuizManagement.Domain
{
    public class Answer
    {
        public static Answer CreateNewAnswer(
            string text,
            bool isCorrect)
        {
            return new Answer(
                0,
                text,
                isCorrect);
        }

        public Answer(
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
