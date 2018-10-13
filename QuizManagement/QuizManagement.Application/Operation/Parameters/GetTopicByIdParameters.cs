namespace QuizManagement.Application.Operation.Parameters
{
    using Shared.Operation;

    public class GetTopicByIdParameters : IParameter
    {
        public GetTopicByIdParameters(
            int topicId)
        {
            TopicId = topicId;
        }

        public int TopicId { get; }
    }
}
