namespace QuizManagement.Application.Operation.Parameters
{
    using System;
    using Shared.Operation;

    public class GetAllQuizzesByUserPagedParameters : IParameter
    {
        public GetAllQuizzesByUserPagedParameters(
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
