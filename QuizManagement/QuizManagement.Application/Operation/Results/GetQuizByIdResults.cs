namespace QuizManagement.Application.Operation.Results
{
    using System;
    using System.Collections.Generic;
    using Domain;
    using Shared.Operation;

    public class GetQuizByIdResults : IResult
    {
        public GetQuizByIdResults(
            int id,
            string name,
            DateTime creationTimestamp,
            int userId,
            IEnumerable<Question> questions,
            TopicDetails topic,
            bool isPublic)
        {
            Id = id;
            Name = name;
            CreationTimestamp = creationTimestamp;
            UserId = userId;
            Questions = questions;
            Topic = topic;
            IsPublic = isPublic;
        }

        public int Id { get; }
        public string Name { get; }
        public DateTime CreationTimestamp { get; }
        public int UserId { get; }
        public IEnumerable<Question> Questions { get; }
        public TopicDetails Topic { get; }
        public bool IsPublic { get; }
    }
}
