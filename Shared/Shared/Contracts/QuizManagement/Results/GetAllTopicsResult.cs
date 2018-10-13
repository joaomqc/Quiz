namespace Shared.Contracts.QuizManagement.Results
{
    using InnerTypes;
    using System.Collections.Generic;

    public class GetAllTopicsResult
    {
        public GetAllTopicsResult(IEnumerable<TopicDetailsResult> topics)
        {
            Topics = topics;
        }

        public IEnumerable<TopicDetailsResult> Topics { get; }
    }
}
