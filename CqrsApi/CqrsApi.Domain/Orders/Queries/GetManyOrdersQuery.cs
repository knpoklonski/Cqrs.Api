using CqrsApi.Domain.Shared.Queries;

namespace CqrsApi.Domain.Orders.Queries
{
    public class GetManyOrdersQuery : GetManyQuery<Order>
    {
        public GetManyOrdersQuery(int customerId, int? top, int? skip) : base(top, skip)
        {
            CustomerId = customerId;
        }

        public int CustomerId { get; }
    }
}