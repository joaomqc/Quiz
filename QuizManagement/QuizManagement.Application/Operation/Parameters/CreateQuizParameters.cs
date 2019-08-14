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
            Guid userId,
            IEnumerable<Question> questions,
            int topicId,
            bool isPublic,
            string imageUrl)
        {
            Name = name;
            UserId = userId;
            Questions = questions;
            TopicId = topicId;
            IsPublic = isPublic;
            ImageUrl = imageUrl;
        }
        
        public string Name { get; }
        public Guid UserId { get; }
        public IEnumerable<Question> Questions { get; }
        public int TopicId { get; }
        public bool IsPublic { get; }
        public string ImageUrl { get; }
    }
}
