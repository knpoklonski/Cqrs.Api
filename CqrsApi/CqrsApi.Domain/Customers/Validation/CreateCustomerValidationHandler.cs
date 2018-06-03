using System;
using CqrsApi.Domain.Customers.Commands;
using CqrsApi.Domain.Customers.Validation.Exceptions;
using CqrsApi.Domain.Infrastructure.Commands;

namespace CqrsApi.Domain.Customers.Validation
{
    public class CreateCustomerValidationHandler : IValidationHandler<CreateCustomerCommand>
    {
        public void Validate(CreateCustomerCommand command)
        {
            if (string.IsNullOrEmpty(command.Email))
                throw new ArgumentNullException(nameof(command.Email));

            if (string.IsNullOrEmpty(command.Name))
                throw new ArgumentNullException(nameof(command.Name));

            if (command.Email == "poklonski.k@gmail.com")//ToDo add check from database
            {
                throw new CustomerWithEmailAlreadyExistException(command.Email);
            }
        }
    }
}