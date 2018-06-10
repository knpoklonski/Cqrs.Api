using System;

namespace CqrsApi.Domain.Orders
{
    public class Order
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}