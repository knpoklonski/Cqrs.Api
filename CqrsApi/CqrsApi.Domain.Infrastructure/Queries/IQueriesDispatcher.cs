using System.Threading.Tasks;

namespace CqrsApi.Domain.Infrastructure.Queries
{
    public interface IQueriesDispatcher
    {
        Task<TResult> ExecuteAsync<TResult, TCriterion>(TCriterion criterion) where TCriterion : ICriterion;
        TResult Execute<TResult, TCriterion>(TCriterion criterion) where TCriterion : ICriterion;
    }
}