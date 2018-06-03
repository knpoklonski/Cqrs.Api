using CqrsApi.Domain.Infrastructure.Queries;

namespace CqrsApi.Domain.Customers.Queries
{
    public class GetManyQuery : IQuery
    {
        private const int DefaultTop = 10;
        private const int DefaultSkip = 0;

        public GetManyQuery(int? top, int? skip)
        {
            Top = top ?? DefaultTop;
            Skip = skip ?? DefaultSkip;
        }

        public int Top { get; }
        public int Skip { get; }
    }
}