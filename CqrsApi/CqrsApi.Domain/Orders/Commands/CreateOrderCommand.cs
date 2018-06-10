using CqrsApi.Domain.Infrastructure.Commands;

namespace CqrsApi.Domain.Orders.Commands
{
    public class CreateOrderCommand : ICommand
    {
        public CreateOrderCommand(int customerId, decimal price)
        {
            CustomerId = customerId;
            Price = price;
        }

        public int CustomerId { get;}

        public decimal Price { get; }
    }
}