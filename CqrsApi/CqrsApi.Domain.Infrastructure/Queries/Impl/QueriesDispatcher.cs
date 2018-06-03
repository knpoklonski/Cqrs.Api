using System;
using System.Threading.Tasks;

namespace CqrsApi.Domain.Infrastructure.Queries.Impl
{
    public class QueriesDispatcher : IQueriesDispatcher
    {
        private readonly IQueryHandlerFactory _queryHandlerFactory;

        public QueriesDispatcher(IQueryHandlerFactory queryHandlerFactory)
        {
            if (queryHandlerFactory == null)
                throw new ArgumentNullException(nameof(queryHandlerFactory));

            _queryHandlerFactory = queryHandlerFactory;
       }

        public async Task<TResult> ExecuteAsync<TResult, TQuery>(TQuery query) where TQuery : IQuery<TResult>
        {
            return await _queryHandlerFactory.CreateAsyncHandler<TQuery, TResult>().Ask(query);
        }

        public TResult Execute<TResult, TQuery>(TQuery query) where TQuery : IQuery<TResult>
        {
            return _queryHandlerFactory.CreateHandler<TQuery, TResult>().Ask(query);
        }
    }
}