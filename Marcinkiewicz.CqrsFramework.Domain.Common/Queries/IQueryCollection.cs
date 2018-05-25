using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marcinkiewicz.CqrsFramework.Domain.Common
{
    /// <summary>
    /// Query parametrized by <typeparamref name="TQueryParameter"/>
    /// returning collection of <typeparamref name="TQueryModel"/>
    /// </summary>
    /// <typeparam name="TQueryModel"></typeparam>
    /// <typeparam name="TQueryParameter"></typeparam>
    public interface IQueryCollection<TQueryModel, TQueryParameter> : IQuery
        where TQueryModel : IQueryModel
        where TQueryParameter : IQueryParameter
    {
        /// <summary>
        /// Execute query based on specified parameter and return execution result.
        /// </summary>
        /// <param name="parameter">Query filters</param>
        /// <returns>Result of the query</returns>
        Task<IEnumerable<TQueryModel>> GetResultsAsync(TQueryParameter parameter);
    }
}
