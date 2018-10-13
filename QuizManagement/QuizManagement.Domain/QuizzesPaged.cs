namespace QuizManagement.Domain
{
    using System.Collections.Generic;
    using Shared.Contracts.Common;

    public class QuizzesPaged : GetPagedResult<QuizDetails>
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
