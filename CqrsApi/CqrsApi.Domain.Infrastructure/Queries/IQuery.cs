namespace CqrsApi.Domain.Infrastructure.Queries
{
    public interface IQuery<in TCriterion, out TResult> where TCriterion : ICriterion
    {
        TResult Ask(TCriterion criterion);
    }
}