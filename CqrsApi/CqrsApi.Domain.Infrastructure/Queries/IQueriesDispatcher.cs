using System.Threading.Tasks;

namespace CqrsApi.Domain.Infrastructure.Queries
{
    public interface IQueriesDispatcher
    {
        Task<TResult> ExecuteAsync<TResult, TQuery>(TQuery query) where TQuery : IQuery<TResult>;
        TResult Execute<TResult, TQuery>(TQuery query) where TQuery : IQuery<TResult>;
    }
}