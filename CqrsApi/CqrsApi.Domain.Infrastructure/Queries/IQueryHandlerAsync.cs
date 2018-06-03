using System.Threading.Tasks;

namespace CqrsApi.Domain.Infrastructure.Queries
{
    public interface IQueryHandlerAsync<in TQuery, TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> Ask(TQuery query);
    }
}