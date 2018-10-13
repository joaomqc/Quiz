namespace QuizManagement.Application.Operation.Parameters
{
    using Shared.Operation;

    public class GetAllQuizzesByUserPagedParameters : IParameter
    {
        public GetAllQuizzesByUserPagedParameters(
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
