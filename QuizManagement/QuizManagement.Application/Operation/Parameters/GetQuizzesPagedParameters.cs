namespace QuizManagement.Application.Operation.Parameters
{
    using Shared.Operation;

    public class GetQuizzesPagedParameters : IParameter
    {
        public GetQuizzesPagedParameters(
            int startIndex,
            int numberOfItems)
        {
            StartIndex = startIndex;
            NumberOfItems = numberOfItems;
        }

        public int StartIndex { get; }
        public int NumberOfItems { get; }
    }
}
