namespace QuizManagement.Domain
{
    using System;

    public class QuizDetails
    {
        public QuizDetails(
            int id,
            string name,
            DateTime creationTimestamp,
            int userId,
            Topic topic,
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
        public Topic Topic { get; }
        public bool IsPublic { get; }
    }
}
