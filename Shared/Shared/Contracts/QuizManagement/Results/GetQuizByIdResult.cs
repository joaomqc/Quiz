namespace Shared.Contracts.QuizManagement.Results
{
    using System;
    using System.Collections.Generic;
    using InnerTypes;

    public class GetQuizByIdResult
    {
        public GetQuizByIdResult(
            int id,
            string name,
            DateTime creationTimestamp,
            int userId,
            IEnumerable<QuestionResult> questions,
            TopicResult topic,
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
        public IEnumerable<QuestionResult> Questions { get; }
        public TopicResult Topic { get; }
        public bool IsPublic { get; }
    }
}
