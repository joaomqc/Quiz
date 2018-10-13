namespace Shared.Contracts.Common
{
    using System.Collections.Generic;

    public class GetPagedResult<ResultType>
    {
        public GetPagedResult(
            IEnumerable<ResultType> list,
            int totalCount,
            int itemCount,
            int startIndex,
            int endIndex)
        {
            List = list;
            TotalCount = totalCount;
            ItemCount = itemCount;
            StartIndex = startIndex;
            EndIndex = endIndex;
        }

        public IEnumerable<ResultType> List { get; }
        public int ItemCount { get; }
        public int TotalCount { get; }
        public int StartIndex { get; }
        public int EndIndex { get; }
    }
}
