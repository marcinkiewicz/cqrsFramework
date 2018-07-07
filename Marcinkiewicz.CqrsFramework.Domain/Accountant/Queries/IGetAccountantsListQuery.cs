using Marcinkiewicz.CqrsFramework.Domain.Accountant.Models;
using Marcinkiewicz.CqrsFramework.Domain.Common;

namespace Marcinkiewicz.CqrsFramework.Domain.Accountant.Queries
{
    /// <summary>
    /// Get accountants list
    /// </summary>
    public interface IGetAccountantsListQuery : IQueryCollection<AccountantDto>
    {
    }
}
