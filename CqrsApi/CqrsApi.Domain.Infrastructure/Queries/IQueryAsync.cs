using System.Threading.Tasks;

namespace CqrsApi.Domain.Infrastructure.Queries
{
    public interface IQueryAsync<in TCriterion, TResult> where TCriterion : ICriterion
    {
        Task<TResult> Ask(TCriterion criterion);
    }
}