using System.Threading.Tasks;
using CqrsApi.Domain.Customers;
using CqrsApi.Domain.Customers.Queries;
using CqrsApi.Domain.Infrastructure;
using CqrsApi.Domain.Infrastructure.Queries;
using Dapper;

namespace CqrsApi.DataAccess.Customers.QueryHandlers
{
    public class FindByIdCustomerQueryHandler : IQueryHandlerAsync<FindByIdQuery, CustomerDetails>
    {
        private readonly IDataBaseConnectionProvider _provider;

        public FindByIdCustomerQueryHandler(IDataBaseConnectionProvider provider)
        {
            _provider = provider;
        }

        public async Task<CustomerDetails> Ask(FindByIdQuery query)
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