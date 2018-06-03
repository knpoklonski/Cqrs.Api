using System.Data;
using System.Threading.Tasks;
using CqrsApi.Domain.Customers.Commands;
using CqrsApi.Domain.Infrastructure;
using CqrsApi.Domain.Infrastructure.Commands;
using Dapper;

namespace CqrsApi.DataAccess.Customers.CommandHandlers
{
    public class CreateCustomerHandler : ICommandHandlerAsync<CreateCustomerCommand>
    {
        private readonly IDataBaseConnectionProvider _provider;

        public CreateCustomerHandler(IDataBaseConnectionProvider provider)
        {
            _provider = provider;
        }

        public async Task ExecuteAsync(CreateCustomerCommand command)
        {
            using (var connection = _provider.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    await connection.ExecuteAsync(
                        @"INSERT INTO Customers(Name, Email)
                          VALUES(@Name, @Email)",
                        new
                        {
                            command.Name,
                            command.Email
                        });

                    transaction.Commit();
                }   
            }
        }
    }
}