using System.Collections.Generic;
using System.Threading.Tasks;
using CqrsApi.Domain.Customers;
using CqrsApi.Domain.Customers.Criterions;
using CqrsApi.Domain.Infrastructure;
using CqrsApi.Domain.Infrastructure.Queries;
using Dapper;

namespace CqrsApi.DataAccess.Customers.Queries
{
    public class GetManyCustomersQuery : IQueryAsync<GetManyCriterion, IEnumerable<Customer>>
    {
        private readonly IDataBaseConnectionProvider _provider;

        public GetManyCustomersQuery(IDataBaseConnectionProvider provider)
        {
            _provider = provider;
        }

        public async Task<IEnumerable<Customer>> Ask(GetManyCriterion criterion)
        {
            using (var connection = _provider.GetConnection())
            {
                connection.Open();

                return await connection.QueryAsync<Customer>(
                    @"SELECT Id
                       FROM Customers
                       ORDER BY Id DESC
                       OFFSET     (@SKIP) ROWS      
                       FETCH NEXT (@Top)  ROWS ONLY;",
                    new
                    {
                        criterion.Top,
                        criterion.Skip
                    });
            }
        }
    }
}