using System;
using System.Threading.Tasks;

namespace CqrsApi.Domain.Infrastructure.Queries.Impl
{
    public class QueriesDispatcher : IQueriesDispatcher
    {
        private readonly IQueryHandlersFactory _queryHandlersFactory;

        public QueriesDispatcher(IQueryHandlersFactory queryHandlersFactory)
        {
            if (queryHandlersFactory == null)
                throw new ArgumentNullException(nameof(queryHandlersFactory));

            _queryHandlersFactory = queryHandlersFactory;
       }

        public async Task<TResult> ExecuteAsync<TResult, TQuery>(TQuery query) where TQuery : IQuery<TResult>
        {
            return await _queryHandlersFactory.CreateAsyncHandler<TQuery, TResult>().Ask(query);
        }

        public TResult Execute<TResult, TQuery>(TQuery query) where TQuery : IQuery<TResult>
        {
            return _queryHandlersFactory.CreateHandler<TQuery, TResult>().Ask(query);
        }
    }
}