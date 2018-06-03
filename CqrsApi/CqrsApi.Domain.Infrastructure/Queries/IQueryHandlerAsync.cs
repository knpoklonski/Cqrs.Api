using System.Threading.Tasks;

namespace CqrsApi.Domain.Infrastructure.Queries
{
    public interface IQueryHandlerAsync<in TQuery, TResult> where TQuery : IQuery
    {
        Task<TResult> Ask(TQuery query);
    }
}