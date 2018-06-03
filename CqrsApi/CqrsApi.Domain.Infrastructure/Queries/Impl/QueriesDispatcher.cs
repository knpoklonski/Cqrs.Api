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

        public async Task<TResult> ExecuteAsync<TResult, TCriterion>(TCriterion criterion) where TCriterion : IQuery
        {
            return await _queryHandlerFactory.CreateAsyncHandler<TCriterion, TResult>().Ask(criterion);
        }

        public TResult Execute<TResult, TCriterion>(TCriterion criterion) where TCriterion : IQuery
        {
            return _queryHandlerFactory.CreateHandler<TCriterion, TResult>().Ask(criterion);
        }
    }
}