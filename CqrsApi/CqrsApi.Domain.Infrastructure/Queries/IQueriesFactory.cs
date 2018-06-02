namespace CqrsApi.Domain.Infrastructure.Queries
{
    public interface IQueriesFactory
    {
        IQuery<TCriterion, TResult> Create<TCriterion, TResult>() where TCriterion : ICriterion;
    }
}