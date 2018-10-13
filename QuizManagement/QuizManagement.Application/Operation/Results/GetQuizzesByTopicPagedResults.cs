namespace QuizManagement.Application.Operation.Results
{
    using System.Collections.Generic;
    using Shared.Contracts.Common;
    using Shared.Contracts.QuizManagement.Results.InnerTypes;
    using Shared.Operation;

    public class GetQuizzesByTopicPagedResults : GetPagedResult<QuizResult>, IResult
    {
        public GetQuizzesByTopicPagedResults(
            IEnumerable<QuizResult> list,
            int totalCount,
            int itemCount,
            int startIndex,
            int endIndex) : base(list, totalCount, itemCount, startIndex, endIndex)
        {
        }
    }
}
