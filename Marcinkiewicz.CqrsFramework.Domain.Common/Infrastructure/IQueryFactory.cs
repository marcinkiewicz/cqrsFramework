namespace Marcinkiewicz.CqrsFramework.Domain.Common
{
    public interface IQueryFactory
    {
        /// <summary>
        /// Creates new query of <typeparamref name="TQuery"/> type
        /// </summary>
        /// <typeparam name="TQuery">Query type</typeparam>
        /// <returns>New instance of query</returns>
        TQuery Create<TQuery>() where TQuery : IQuery;
    }
}
