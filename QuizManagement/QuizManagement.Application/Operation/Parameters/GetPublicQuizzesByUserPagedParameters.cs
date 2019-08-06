namespace QuizManagement.Application.Operation.Parameters
{
    using System;
    using Shared.Operation;

    public class GetPublicQuizzesByUserPagedParameters : IParameter
    {
        public GetPublicQuizzesByUserPagedParameters(
            Guid userId,
            int startIndex,
            int numberOfItems)
        {
            UserId = userId;
            StartIndex = startIndex;
            NumberOfItems = numberOfItems;
        }

        public Guid UserId { get; }
        public int StartIndex { get; }
        public int NumberOfItems { get; }
    }
}
