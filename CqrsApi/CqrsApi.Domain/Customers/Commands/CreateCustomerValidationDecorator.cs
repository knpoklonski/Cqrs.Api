using System.Threading.Tasks;
using CqrsApi.Domain.Infrastructure.Commands;
using CqrsApi.Domain.Shared;

namespace CqrsApi.Domain.Customers.Commands
{
    public class CreateCustomerValidationDecorator : ICommandHandlerAsync<CreateCustomerCommand, CommandResult<CustomerDetails>>
    {
        private readonly ICommandHandlerAsync<CreateCustomerCommand, CommandResult<CustomerDetails>> _commandHandler;
        private readonly IValidationHandler<CreateCustomerCommand> _validationHandler;

        public CreateCustomerValidationDecorator(
            ICommandHandlerAsync<CreateCustomerCommand, CommandResult<CustomerDetails>> commandHandler,
            IValidationHandler<CreateCustomerCommand> validationHandler)
        {
            _commandHandler = commandHandler;
            _validationHandler = validationHandler;
        }

        public async Task<CommandResult<CustomerDetails>> ExecuteAsync(CreateCustomerCommand command)
        {
            await _validationHandler.Validate(command);
            return await _commandHandler.ExecuteAsync(command);
        }
    }
}