using System;
using CqrsApi.Domain.Infrastructure.Queries;

namespace CqrsApi
{
    public class QueryHandlerFactory : IQueryHandlerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryHandlerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IQueryHandlerAsync<TCriterion, TResult> CreateAsyncHandler<TCriterion, TResult>() where TCriterion : IQuery
        {
            return (IQueryHandlerAsync<TCriterion, TResult>) _serviceProvider.GetService(typeof(IQueryHandlerAsync<TCriterion, TResult>));
        }

        public IQueryHandler<TCriterion, TResult> CreateHandler<TCriterion, TResult>() where TCriterion : IQuery
        {
            return (IQueryHandler<TCriterion, TResult>)_serviceProvider.GetService(typeof(IQueryHandler<TCriterion, TResult>));
        }
    }
}