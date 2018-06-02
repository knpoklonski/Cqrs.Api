namespace CqrsApi.Domain.Infrastructure.Queries
{
    public interface IQueriesFactory
    {
        IQueryAsync<TCriterion, TResult> CreateQueryAsync<TCriterion, TResult>() where TCriterion : ICriterion;

        IQuery<TCriterion, TResult> Create<TCriterion, TResult>() where TCriterion : ICriterion;
    }
}