using CqrsApi.Domain.Infrastructure.Queries;

namespace CqrsApi.Domain.Customers.Criterions
{
    public class FindByIdCriterion : ICriterion
    {
        public FindByIdCriterion(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}