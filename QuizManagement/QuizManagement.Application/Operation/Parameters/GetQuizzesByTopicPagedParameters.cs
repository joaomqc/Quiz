namespace QuizManagement.Application.Operation.Parameters
{
    using Shared.Operation;

    public class GetQuizzesByTopicPagedParameters : IParameter
    {
        public GetQuizzesByTopicPagedParameters(
            int topicId,
            int startIndex,
            int numberOfItems)
        {
            TopicId = topicId;
            StartIndex = startIndex;
            NumberOfItems = numberOfItems;
        }

        public int TopicId { get; }
        public int StartIndex { get; }
        public int NumberOfItems { get; }
    }
}
