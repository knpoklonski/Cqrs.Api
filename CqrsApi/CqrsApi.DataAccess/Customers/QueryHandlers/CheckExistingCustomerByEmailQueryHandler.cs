using System.Threading.Tasks;
using CqrsApi.Domain.Customers.Queries;
using CqrsApi.Domain.Infrastructure;
using CqrsApi.Domain.Infrastructure.Queries;
using Dapper;

namespace CqrsApi.DataAccess.Customers.QueryHandlers
{
    public class CheckExistingCustomerByEmailQueryHandler : IQueryHandlerAsync<CheckExistingCustomerByEmailQuery, bool>
    {
        private readonly IDataBaseConnectionProvider _provider;

        public CheckExistingCustomerByEmailQueryHandler(IDataBaseConnectionProvider provider)
        {
            _provider = provider;
        }

        public async Task<bool> Ask(CheckExistingCustomerByEmailQuery query)
        {
            using (var connection = _provider.GetConnection())
            {
                connection.Open();

                return await connection.ExecuteScalarAsync<bool>(
                    @"SELECT count(1) 
                    FROM Customers
                    WHERE Email = @Email",
                    new
                    {
                        query.Email
                    });
            }
        }
    }
}