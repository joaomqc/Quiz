namespace QuizManagement.Application.Operation.Parameters
{
    using System;
    using System.Collections.Generic;
    using Domain;
    using Shared.Operation;

    public class CreateQuizParameters : IParameter
    {
        public CreateQuizParameters(
            string name,
            int userId,
            IEnumerable<Question> questions,
            int topicId,
            bool isPublic)
        {
            Name = name;
            UserId = userId;
            Questions = questions;
            TopicId = topicId;
            IsPublic = isPublic;
        }
        
        public string Name { get; }
        public int UserId { get; }
        public IEnumerable<Question> Questions { get; }
        public int TopicId { get; }
        public bool IsPublic { get; }
    }
}
