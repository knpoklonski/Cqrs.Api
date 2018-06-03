using CqrsApi.Domain.Infrastructure.Commands;

namespace CqrsApi.Domain.Customers.Commands
{
    public class CreateCustomerCommand : ICommand
    {
        public CreateCustomerCommand(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; }

        public string Email { get; }
    }
}