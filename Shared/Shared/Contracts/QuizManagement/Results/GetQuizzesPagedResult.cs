namespace Shared.Contracts.QuizManagement.Results
{
    using System.Collections.Generic;
    using Common;
    using InnerTypes;

    public class GetQuizzesPagedResult : GetPagedResult<QuizResult>
    {
        public GetQuizzesPagedResult(
            IEnumerable<QuizResult> list,
            int totalCount,
            int itemCount,
            int startIndex,
            int endIndex) : base(list, totalCount, itemCount, startIndex, endIndex)
        {
        }
    }
}
