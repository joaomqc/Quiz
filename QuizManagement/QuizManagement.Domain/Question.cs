namespace QuizManagement.Domain
{
    using System.Collections.Generic;

    public class Question
    {
        public static Question CreateNewQuestion(
            string text,
            bool isMultipleChoice,
            IEnumerable<Answer> answers)
        {
            return new Question(
                0,
                text,
                isMultipleChoice,
                answers);
        }

        public Question(
            int id,
            string text,
            bool isMultipleChoice,
            IEnumerable<Answer> answers)
        {
            Id = id;
            Text = text;
            IsMultipleChoice = isMultipleChoice;
            Answers = answers;
        }

        public int Id { get; }
        public string Text { get; }
        public bool IsMultipleChoice { get; }
        public IEnumerable<Answer> Answers { get; }
    }
}
