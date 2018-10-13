namespace Shared.Contracts.QuizManagement.Results.InnerTypes
{
    using System;

    public class QuizResult
    {
        public QuizResult(
            int id,
            string name,
            DateTime creationTimestamp,
            int userId,
            TopicResult topic,
            bool isPublic)
        {
            Id = id;
            Name = name;
            CreationTimestamp = creationTimestamp;
            UserId = userId;
            Topic = topic;
            IsPublic = isPublic;
        }

        public int Id { get; }
        public string Name { get; }
        public DateTime CreationTimestamp { get; }
        public int UserId { get; }
        public TopicResult Topic { get; }
        public bool IsPublic { get; }
    }
}
