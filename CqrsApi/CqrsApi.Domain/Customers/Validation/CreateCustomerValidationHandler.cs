using System.Threading.Tasks;
using CqrsApi.Domain.Customers.Commands;
using CqrsApi.Domain.Customers.Queries;
using CqrsApi.Domain.Customers.Validation.Exceptions;
using CqrsApi.Domain.Infrastructure.Commands;
using CqrsApi.Domain.Infrastructure.Queries;

namespace CqrsApi.Domain.Customers.Validation
{
    public class CreateCustomerValidationHandler : IValidationHandler<CreateCustomerCommand>
    {
        private readonly IQueriesDispatcher _queriesDispatcher;

        public CreateCustomerValidationHandler(IQueriesDispatcher queriesDispatcher)
        {
            _queriesDispatcher = queriesDispatcher;
        }

        public async Task Validate(CreateCustomerCommand command)
        {
            var query = new CheckExistingCustomerByEmailQuery(command.Email);
            var isCustomerAlreadyExist = await _queriesDispatcher.ExecuteAsync<bool, CheckExistingCustomerByEmailQuery>(query);

            if (isCustomerAlreadyExist)
            {
                throw new CustomerWithEmailAlreadyExistException(command.Email);
            }
        }
    }
}