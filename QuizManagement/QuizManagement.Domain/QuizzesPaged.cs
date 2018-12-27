namespace QuizManagement.Domain
{
    using System.Collections.Generic;
    using Shared.Common;

    public class QuizzesPaged : PagedResult<QuizDetails>
    {
        public QuizzesPaged(
            IEnumerable<QuizDetails> list,
            int totalCount,
            int itemCount,
            int startIndex,
            int endIndex) : base(list, totalCount, itemCount, startIndex, endIndex)
        {
        }
    }
}
