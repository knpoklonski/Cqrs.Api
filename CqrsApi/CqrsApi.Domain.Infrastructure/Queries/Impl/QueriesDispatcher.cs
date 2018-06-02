﻿using System;

namespace CqrsApi.Domain.Infrastructure.Queries.Impl
{
    public class QueriesDispatcher : IQueriesDispatcher
    {
        private readonly IQueriesFactory _queriesFactory;

        public QueriesDispatcher(IQueriesFactory queriesFactory)
        {
            if (queriesFactory == null)
                throw new ArgumentNullException(nameof(queriesFactory));

            _queriesFactory = queriesFactory;
       }

        public TResult Execute<TResult, TCriterion>(TCriterion criterion) where TCriterion : ICriterion
        {
            return _queriesFactory.Create<TCriterion, TResult>().Ask(criterion);
        }
    }
}