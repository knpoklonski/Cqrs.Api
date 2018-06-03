namespace CqrsApi.Domain.Infrastructure.Queries
{
    public interface IQueryHandlerFactory
    {
        IQueryHandlerAsync<TQuery, TResult> CreateAsyncHandler<TQuery, TResult>() where TQuery : IQuery;

        IQueryHandler<TQuery, TResult> CreateHandler<TQuery, TResult>() where TQuery : IQuery;
    }
}