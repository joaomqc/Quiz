namespace QuizManagement.Application.Operation.Parameters
{
    using System;
    using System.Collections.Generic;
    using Shared.Contracts.QuizManagement.Parameters.InnerTypes;
    using Shared.Operation;

    public class CreateQuizParameters : IParameter
    {
        public CreateQuizParameters(
            string name,
            DateTime creationTimestamp,
            int userId,
            IEnumerable<QuestionParameter> questions,
            int topicId,
            bool isPublic)
        {
            Name = name;
            CreationTimestamp = creationTimestamp;
            UserId = userId;
            Questions = questions;
            TopicId = topicId;
            IsPublic = isPublic;
        }
        
        public string Name { get; }
        public DateTime CreationTimestamp { get; }
        public int UserId { get; }
        public IEnumerable<QuestionParameter> Questions { get; }
        public int TopicId { get; }
        public bool IsPublic { get; }
    }
}
