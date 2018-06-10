using CqrsApi.Domain.Customers.Validation;
using CqrsApi.Domain.Infrastructure.Queries;

namespace CqrsApi.Domain.Customers.Queries
{
    public class CheckExistingCustomerByEmailQuery : IQuery<bool>
    {
        public CheckExistingCustomerByEmailQuery(string email)
        {
            Email = email;
        }

        public string Email { get; }
    }
}