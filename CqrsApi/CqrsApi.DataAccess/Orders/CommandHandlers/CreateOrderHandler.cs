using System.Data;
using System.Threading.Tasks;
using CqrsApi.Domain.Infrastructure;
using CqrsApi.Domain.Infrastructure.Commands;
using CqrsApi.Domain.Orders;
using CqrsApi.Domain.Orders.Commands;
using CqrsApi.Domain.Shared;
using Dapper;

namespace CqrsApi.DataAccess.Orders.CommandHandlers
{
    public class CreateOrderHandler : ICommandHandlerAsync<CreateOrderCommand, CommandResult<Order>>
    {
        private readonly IDataBaseConnectionProvider _provider;

        public CreateOrderHandler(IDataBaseConnectionProvider provider)
        {
            _provider = provider;
        }

        public async Task<CommandResult<Order>> ExecuteAsync(CreateOrderCommand command)
        {
            using (var connection = _provider.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    var order = await connection.QuerySingleAsync<Order>(
                        @"INSERT INTO Orders (Price, CustomerId)
                          VALUES(@Price, @CustomerId);
                          SELECT * FROM Orders WHERE Id = SCOPE_IDENTITY();",
                        new
                        {
                            command.Price,
                            command.CustomerId
                        },
                        transaction);

                    transaction.Commit();

                    return CommandResult<Order>.Success(order);
                }
            }
        }
    }
}