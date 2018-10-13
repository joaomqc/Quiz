namespace QuizManagement.Domain
{
    using System;
    using System.Collections.Generic;

    public class QuizAttempt
    {
        public QuizAttempt(
            int id,
            int userId,
            DateTime creationTimestamp,
            Quiz quiz,
            IEnumerable<QuestionAttempt> questionAttempts)
        {
            Id = id;
            UserId = userId;
            CreationTimestamp = creationTimestamp;
            Quiz = quiz;
            QuestionAttempts = questionAttempts;
        }

        public int Id { get; }
        public int UserId { get; }
        public DateTime CreationTimestamp { get; }
        public Quiz Quiz { get; }
        public IEnumerable<QuestionAttempt> QuestionAttempts { get; }
    }
}
