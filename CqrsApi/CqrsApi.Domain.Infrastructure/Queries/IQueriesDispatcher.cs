namespace CqrsApi.Domain.Infrastructure.Queries
{
    public interface IQueriesDispatcher
    {
        TResult Execute<TResult, TCriterion>(TCriterion criterion) where TCriterion : ICriterion;
    }
}