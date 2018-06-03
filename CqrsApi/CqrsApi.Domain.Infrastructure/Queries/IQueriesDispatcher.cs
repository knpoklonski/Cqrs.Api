using System.Threading.Tasks;

namespace CqrsApi.Domain.Infrastructure.Queries
{
    public interface IQueriesDispatcher
    {
        Task<TResult> ExecuteAsync<TResult, TQuery>(TQuery criterion) where TQuery : IQuery;
        TResult Execute<TResult, TQuery>(TQuery criterion) where TQuery : IQuery;
    }
}