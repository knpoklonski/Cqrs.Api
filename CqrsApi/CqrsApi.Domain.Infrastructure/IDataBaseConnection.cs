using System.Data;

namespace CqrsApi.Domain.Infrastructure
{
    public interface IDataBaseConnectionProvider
    {
        IDbConnection GetConnection();
    }
}