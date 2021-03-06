﻿using System;
using CqrsApi.Domain.Infrastructure.Queries;

namespace CqrsApi.Domain
{
    public class QueryHandlersFactory : IQueryHandlersFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryHandlersFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IQueryHandlerAsync<TQuery, TResult> CreateAsyncHandler<TQuery, TResult>() where TQuery : IQuery<TResult>
        {
            return (IQueryHandlerAsync<TQuery, TResult>) _serviceProvider.GetService(typeof(IQueryHandlerAsync<TQuery, TResult>));
        }

        public IQueryHandler<TQuery, TResult> CreateHandler<TQuery, TResult>() where TQuery : IQuery<TResult>
        {
            return (IQueryHandler<TQuery, TResult>)_serviceProvider.GetService(typeof(IQueryHandler<TQuery, TResult>));
        }
    }
}