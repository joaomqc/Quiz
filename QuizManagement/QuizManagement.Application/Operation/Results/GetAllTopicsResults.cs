namespace QuizManagement.Application.Operation.Results
{
    using System.Collections.Generic;
    using Domain;
    using Shared.Operation;

    public class GetAllTopicsResults : IResult
    {
        public GetAllTopicsResults(IEnumerable<Topic> topics)
        {
            Topics = topics;
        }

        public IEnumerable<Topic> Topics { get; }
    }
}
