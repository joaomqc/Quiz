namespace Shared.Common
{
    using System.Collections;
    using System.Collections.Generic;

    public class PagedResult<T>
    {
        public PagedResult(
            IEnumerable<T> list,
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

        public IEnumerable<T> List { get; }
        public int TotalCount { get; }
        public int ItemCount { get; }
        public int StartIndex { get; }
        public int EndIndex { get; }
    }
}
