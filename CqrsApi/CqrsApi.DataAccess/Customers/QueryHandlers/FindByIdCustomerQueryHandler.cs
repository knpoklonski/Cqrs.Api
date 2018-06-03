using System.Threading.Tasks;
using CqrsApi.Domain.Customers;
using CqrsApi.Domain.Infrastructure;
using CqrsApi.Domain.Infrastructure.Queries;
using CqrsApi.Domain.Shared.Queries;
using Dapper;

namespace CqrsApi.DataAccess.Customers.QueryHandlers
{
    public class FindByIdCustomerQueryHandler : IQueryHandlerAsync<FindByIdQuery<CustomerDetails>, CustomerDetails>
    {
        private readonly IDataBaseConnectionProvider _provider;

        public FindByIdCustomerQueryHandler(IDataBaseConnectionProvider provider)
        {
            _provider = provider;
        }

        public async Task<CustomerDetails> Ask(FindByIdQuery<CustomerDetails> query)
        {
            using (var connection = _provider.GetConnection())
            {
                connection.Open();

                return await connection.QuerySingleOrDefaultAsync<CustomerDetails>(
                    @"SELECT Id, Name, Email 
                    FROM Customers
                    WHERE Id = @Id",
                    new
                    {
                        query.Id
                        
                    });
            }
        }
    }
}