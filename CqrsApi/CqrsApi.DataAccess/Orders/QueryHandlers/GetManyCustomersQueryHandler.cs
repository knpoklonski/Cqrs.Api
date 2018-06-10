using System.Collections.Generic;
using System.Threading.Tasks;
using CqrsApi.Domain.Infrastructure;
using CqrsApi.Domain.Infrastructure.Queries;
using CqrsApi.Domain.Orders;
using CqrsApi.Domain.Orders.Queries;
using Dapper;

namespace CqrsApi.DataAccess.Orders.QueryHandlers
{
    public class GetManyOrdersQueryHandler : IQueryHandlerAsync<GetManyOrdersQuery, IEnumerable<Order>>
    {
        private readonly IDataBaseConnectionProvider _provider;

        public GetManyOrdersQueryHandler(IDataBaseConnectionProvider provider)
        {
            _provider = provider;
        }

        public async Task<IEnumerable<Order>> Ask(GetManyOrdersQuery query)
        {
            using (var connection = _provider.GetConnection())
            {
                connection.Open();

                return await connection.QueryAsync<Order>(
                    @"SELECT o.Id, o.Price, o.CreatedDate
                       FROM Orders o
                       Where o.CustomerId=@CustomerId
                       ORDER BY Id DESC
                       OFFSET     (@SKIP) ROWS      
                       FETCH NEXT (@Top)  ROWS ONLY;",
                    new
                    {
                        query.CustomerId,
                        query.Top,
                        query.Skip
                    });
            }
        }
    }
}