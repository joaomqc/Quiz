namespace QuizManagement.Domain
{
    using System;

    public class Comment
    {
        public static Comment CreateNewComment(
            string text,
            DateTime creationTimestamp,
            int userId)
        {
            return new Comment(
                0,
                text,
                creationTimestamp,
                userId);
        }

        public Comment(
            int id,
            string text,
            DateTime creationTimestamp,
            int userId)
        {
            Id = id;
            Text = text;
            CreationTimestamp = creationTimestamp;
            UserId = userId;
        }

        public int Id { get; }
        public string Text { get; }
        public DateTime CreationTimestamp { get; }
        public int UserId { get; }
    }
}
