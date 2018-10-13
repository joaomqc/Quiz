namespace QuizManagement.Application.Operation.Parameters
{
    using Shared.Operation;

    public class GetPublicQuizzesByUserPagedParameters : IParameter
    {
        public GetPublicQuizzesByUserPagedParameters(
            int userId,
            int startIndex,
            int numberOfItems)
        {
            UserId = userId;
            StartIndex = startIndex;
            NumberOfItems = numberOfItems;
        }

        public int UserId { get; }
        public int StartIndex { get; }
        public int NumberOfItems { get; }
    }
}
