using System.Collections.Generic;
using System.Threading.Tasks;
using CqrsApi.Domain.Customers;
using CqrsApi.Domain.Customers.Queries;
using CqrsApi.Domain.Infrastructure;
using CqrsApi.Domain.Infrastructure.Queries;
using Dapper;

namespace CqrsApi.DataAccess.Customers.QueryHandlers
{
    public class GetManyCustomersQueryHandler : IQueryHandlerAsync<GetManyQuery, IEnumerable<Customer>>
    {
        private readonly IDataBaseConnectionProvider _provider;

        public GetManyCustomersQueryHandler(IDataBaseConnectionProvider provider)
        {
            _provider = provider;
        }

        public async Task<IEnumerable<Customer>> Ask(GetManyQuery query)
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
                        query.Top,
                        query.Skip
                    });
            }
        }
    }
}