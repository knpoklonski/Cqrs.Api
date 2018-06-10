using FluentValidation;

namespace CqrsApi.Models.Customers
{ 

    public class CreateCustomerValidator : AbstractValidator<CustomerEditModel>
    {
        public CreateCustomerValidator()
        {
            RuleFor(m => m.Name).NotEmpty().MinimumLength(3).MaximumLength(255);
            RuleFor(m => m.Email).NotEmpty().MaximumLength(255).EmailAddress();
        }
    }
}