using System.Threading.Tasks;
using CqrsApi.Domain.Infrastructure.Commands;

namespace CqrsApi.Domain.Customers.Commands
{
    public class CreateCustomerValidationDecorator : ICommandHandlerAsync<CreateCustomerCommand>
    {
        private readonly ICommandHandlerAsync<CreateCustomerCommand> _commandHandler;
        private readonly IValidationHandler<CreateCustomerCommand> _validationHandler;

        public CreateCustomerValidationDecorator(
            ICommandHandlerAsync<CreateCustomerCommand> commandHandler,
            IValidationHandler<CreateCustomerCommand> validationHandler)
        {
            _commandHandler = commandHandler;
            _validationHandler = validationHandler;
        }

        public async Task ExecuteAsync(CreateCustomerCommand command)
        {
            await _validationHandler.Validate(command);
            await _commandHandler.ExecuteAsync(command);
        }
    }
}