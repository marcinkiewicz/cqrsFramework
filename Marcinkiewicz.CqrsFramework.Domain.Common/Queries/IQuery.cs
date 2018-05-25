using System.Threading.Tasks;

namespace Marcinkiewicz.CqrsFramework.Domain.Common
{
    /// <summary>
    /// Query interface
    /// </summary>
    public interface IQuery
    {
    }

    /// <summary>
    /// Query parametrized by <typeparamref name="TQueryParameter"/>
    /// returning value of <typeparamref name="TQueryModel"/>
    /// </summary>
    /// <typeparam name="TQueryModel"></typeparam>
    /// <typeparam name="TQueryParameter"></typeparam>
    public interface IQuery<TQueryModel, TQueryParameter>: IQuery
        where TQueryModel : IQueryModel
        where TQueryParameter : IQueryParameter
    {
        /// <summary>
        /// Execute query based on specified parameter and return execution result.
        /// </summary>
        /// <param name="parameter">Query filters</param>
        /// <returns>Result of the query</returns>
        Task<TQueryModel> GetResultsAsync(TQueryParameter parameter);
    }
}
