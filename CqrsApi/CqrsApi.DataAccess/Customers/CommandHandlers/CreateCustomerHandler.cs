using System.Data;
using System.Threading.Tasks;
using CqrsApi.Domain.Customers;
using CqrsApi.Domain.Customers.Commands;
using CqrsApi.Domain.Infrastructure;
using CqrsApi.Domain.Infrastructure.Commands;
using CqrsApi.Domain.Shared;
using Dapper;

namespace CqrsApi.DataAccess.Customers.CommandHandlers
{
    public class CreateCustomerHandler : ICommandHandlerAsync<CreateCustomerCommand, CommandResult<CustomerDetails>>
    {
        private readonly IDataBaseConnectionProvider _provider;

        public CreateCustomerHandler(IDataBaseConnectionProvider provider)
        {
            _provider = provider;
        }

        public async Task<CommandResult<CustomerDetails>> ExecuteAsync(CreateCustomerCommand command)
        {
            using (var connection = _provider.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    var customerDetails = await connection.QuerySingleAsync<CustomerDetails>(
                        @"INSERT INTO Customers (Name, Email)
                          VALUES(@Name, @Email);
                          SELECT * FROM Customers WHERE Id = SCOPE_IDENTITY();",
                        new
                        {
                            command.Name,
                            command.Email
                        },
                        transaction);

                    transaction.Commit();

                    return CommandResult<CustomerDetails>.Success(customerDetails);
                }
            }
        }
    }
}