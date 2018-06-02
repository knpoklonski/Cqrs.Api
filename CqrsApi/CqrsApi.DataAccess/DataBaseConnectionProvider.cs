using System;
using System.Data;
using CqrsApi.Domain.Infrastructure;

namespace CqrsApi.DataAccess
{
    public class DataBaseConnectionProvider : IDataBaseConnectionProvider
    {
        private readonly IServiceProvider _provider;

        public DataBaseConnectionProvider(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IDbConnection GetConnection()
        {
            return (IDbConnection) _provider.GetService(typeof(IDbConnection));
        }
    }
}