using Microsoft.Extensions.DependencyInjection;
using System;

namespace Marcinkiewicz.CqrsFramework.Domain.Common
{
    /// <summary>
    /// Application query factory creates new instances of queries.
    /// </summary>
    internal class QueryFactory : IQueryFactory
    {
        private readonly IServiceProvider services;

        /// <summary>
        /// Creates new instance of <see cref="QueryFactory"/>
        /// </summary>
        /// <param name="serviceProvider">IoC container</param>
        public QueryFactory(IServiceProvider serviceProvider)
        {
            this.services = serviceProvider;
        }

        /// <summary>
        /// Creates new instance of <typeparamref name="TQuery"/>
        /// </summary>
        /// <typeparam name="TQuery">Type of query to be created</typeparam>
        /// <returns>Query instance</returns>
        public TQuery Create<TQuery>() where TQuery : IQuery
        {
            TQuery query = services.GetService<TQuery>();
            if (query == null)
            {
                throw new ArgumentException($"Query {typeof(TQuery).Name} does not have a valid registered implementation");
            }

            return query;
        }
    }
}
