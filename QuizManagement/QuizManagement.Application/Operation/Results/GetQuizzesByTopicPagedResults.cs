namespace QuizManagement.Application.Operation.Results
{
    using System.Collections.Generic;
    using Domain;
    using Shared.Common;
    using Shared.Operation;

    public class GetQuizzesByTopicPagedResults : PagedResult<QuizDetails>, IResult
    {
        public GetQuizzesByTopicPagedResults(
            IEnumerable<QuizDetails> list,
            int totalCount,
            int itemCount,
            int startIndex,
            int endIndex) : base(list, totalCount, itemCount, startIndex, endIndex)
        {
        }
    }
}
