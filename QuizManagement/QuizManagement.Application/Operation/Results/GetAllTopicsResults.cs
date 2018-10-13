namespace QuizManagement.Application.Operation.Results
{
    using System.Collections.Generic;
    using Shared.Contracts.QuizManagement.Results.InnerTypes;
    using Shared.Operation;

    public class GetAllTopicsResults : IResult
    {
        public GetAllTopicsResults(IEnumerable<TopicDetailsResult> topics)
        {
            Topics = topics;
        }

        public IEnumerable<TopicDetailsResult> Topics { get; }
    }
}
