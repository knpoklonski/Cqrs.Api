using FluentValidation;

namespace CqrsApi.Models.Orders
{
    public class OrderEditModelValidator : AbstractValidator<OrderEditModel>
    {
        public OrderEditModelValidator()
        {
            RuleFor(m => m.Price).GreaterThan(0);
        }
    }
}