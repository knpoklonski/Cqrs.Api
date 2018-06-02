using System.Threading.Tasks;
using CqrsApi.Domain.Customers;
using CqrsApi.Domain.Customers.Criterions;
using CqrsApi.Domain.Infrastructure;
using CqrsApi.Domain.Infrastructure.Queries;
using Dapper;

namespace CqrsApi.DataAccess.Customers.Queries
{
    public class FindByIdCustomerQuery : IQueryAsync<FindByIdCriterion, Customer>
    {
        private readonly IDataBaseConnectionProvider _provider;

        public FindByIdCustomerQuery(IDataBaseConnectionProvider provider)
        {
            _provider = provider;
        }

        public async Task<Customer> Ask(FindByIdCriterion criterion)
        {
            using (var connection = _provider.GetConnection())
            {
                connection.Open();

                return await connection.QuerySingleOrDefaultAsync<Customer>(@"SELECT Id, Name, Email 
                                                                    FROM Customers
                                                                    WHERE Id = @Id", new {criterion.Id});
            }
        }
    }
}