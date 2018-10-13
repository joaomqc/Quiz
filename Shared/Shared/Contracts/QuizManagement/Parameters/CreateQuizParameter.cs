namespace Shared.Contracts.QuizManagement.Parameters
{
    using System;
    using System.Collections.Generic;
    using InnerTypes;

    public class CreateQuizParameter
    {
        public CreateQuizParameter(
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
