namespace QuizManagement.Application.Operation.Parameters
{
    using System;
    using Shared.Operation;

    public class DeleteQuizzesByUserParameters : IParameter
    {
        public DeleteQuizzesByUserParameters(
            Guid userId,
            bool keepPublic)
        {
            UserId = userId;
            KeepPublic = keepPublic;
        }

        public Guid UserId { get; }
        public bool KeepPublic { get; }
    }
}
