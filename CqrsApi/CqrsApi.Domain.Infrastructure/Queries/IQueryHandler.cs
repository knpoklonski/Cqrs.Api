namespace CqrsApi.Domain.Infrastructure.Queries
{
    public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery<TResult>
    {
        TResult Ask(TQuery query);
    }
}