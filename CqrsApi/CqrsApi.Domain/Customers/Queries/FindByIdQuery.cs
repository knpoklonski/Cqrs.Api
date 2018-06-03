using CqrsApi.Domain.Infrastructure.Queries;

namespace CqrsApi.Domain.Customers.Queries
{
    public class FindByIdQuery : IQuery
    {
        public FindByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}