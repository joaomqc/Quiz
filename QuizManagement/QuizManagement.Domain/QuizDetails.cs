namespace QuizManagement.Domain
{
    using System;

    public class QuizDetails
    {
        public QuizDetails(
            int id,
            string name,
            DateTime creationTimestamp,
            Guid userId,
            TopicDetails topic,
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
        public Guid UserId { get; }
        public TopicDetails Topic { get; }
        public bool IsPublic { get; }
    }
}
