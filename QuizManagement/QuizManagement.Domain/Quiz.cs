namespace QuizManagement.Domain
{
    using System;
    using System.Collections.Generic;

    public class Quiz
    {
        public static Quiz CreateNewQuiz(
            string name,
            Guid userId,
            IEnumerable<Question> questions,
            int topicId,
            bool isPublic,
            string imageUrl)
        {
            return new Quiz(
                id: 0,
                name: name,
                creationTimestamp: DateTime.UtcNow,
                userId: userId,
                questions: questions,
                topicId: topicId,
                isPublic: isPublic,
                imageUrl: imageUrl,
                comments: new List<Comment>());
        }

        public Quiz(
            int id,
            string name,
            DateTime creationTimestamp,
            Guid userId,
            IEnumerable<Question> questions,
            int topicId,
            bool isPublic,
            string imageUrl,
            IEnumerable<Comment> comments)
        {
            Id = id;
            Name = name;
            CreationTimestamp = creationTimestamp;
            UserId = userId;
            Questions = questions;
            TopicId = topicId;
            IsPublic = isPublic;
            ImageUrl = imageUrl;
            Comments = comments;
        }

        public int Id { get; }
        public string Name { get; }
        public DateTime CreationTimestamp { get; }
        public Guid UserId { get; }
        public IEnumerable<Question> Questions { get; }
        public int TopicId { get; }
        public bool IsPublic { get; }
        public string ImageUrl { get; }
        public IEnumerable<Comment> Comments { get; }
    }
}
