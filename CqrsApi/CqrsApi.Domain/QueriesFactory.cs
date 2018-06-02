using System;
using CqrsApi.Domain.Infrastructure.Queries;

namespace CqrsApi
{
    public class QueriesFactory : IQueriesFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public QueriesFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IQueryAsync<TCriterion, TResult> CreateQueryAsync<TCriterion, TResult>() where TCriterion : ICriterion
        {
            return (IQueryAsync<TCriterion, TResult>) _serviceProvider.GetService(typeof(IQueryAsync<TCriterion, TResult>));
        }

        public IQuery<TCriterion, TResult> Create<TCriterion, TResult>() where TCriterion : ICriterion
        {
            return (IQuery<TCriterion, TResult>)_serviceProvider.GetService(typeof(IQuery<TCriterion, TResult>));
        }
    }
}