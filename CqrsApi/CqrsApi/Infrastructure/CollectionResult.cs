using System.Collections.Generic;

namespace CqrsApi.Infrastructure
{
    public class CollectionResult<T>
    {
        public CollectionResult(IEnumerable<T> data, int top, int skip, string baseLink)
        {
            Top = top;
            Skip = skip;
            Data = data;
        }

        public int Top { get; }
        public int Skip { get; }
        public IEnumerable<T> Data { get; set; }
        public string PrevLink { get; set; }
        public string NextLink { get; set; }
    }
}