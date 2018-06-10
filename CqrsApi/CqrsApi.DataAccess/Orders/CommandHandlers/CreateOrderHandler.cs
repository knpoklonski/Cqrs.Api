using System.Data;
using System.Threading.Tasks;
using CqrsApi.Domain.Infrastructure;
using CqrsApi.Domain.Infrastructure.Commands;
using CqrsApi.Domain.Orders.Commands;
using Dapper;

namespace CqrsApi.DataAccess.Orders.CommandHandlers
{
    public class CreateOrderHandler : ICommandHandlerAsync<CreateOrderCommand>
    {
        private readonly IDataBaseConnectionProvider _provider;

        public CreateOrderHandler(IDataBaseConnectionProvider provider)
        {
            _provider = provider;
        }

        public async Task ExecuteAsync(CreateOrderCommand command)
        {
            using (var connection = _provider.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    await connection.ExecuteAsync(
                        @"INSERT INTO Orders (Price, CustomerId)
                          VALUES(@Price, @CustomerId)",
                        new
                        {
                            command.Price,
                            command.CustomerId
                        },
                        transaction);

                    transaction.Commit();
                }
            }
        }
    }
}