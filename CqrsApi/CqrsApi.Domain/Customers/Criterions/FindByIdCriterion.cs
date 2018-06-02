using CqrsApi.Domain.Infrastructure.Queries;

namespace CqrsApi.Domain.Customers.Criterions
{
    public class FindByIdCriterion : ICriterion
    {
        public int Id { get; set; }
    }
}