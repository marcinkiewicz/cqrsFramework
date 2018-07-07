using Marcinkiewicz.CqrsFramework.Domain.Accountant.Models;
using Marcinkiewicz.CqrsFramework.Domain.Common;

namespace Marcinkiewicz.CqrsFramework.Domain.Accountant.Queries
{
    /// <summary>
    /// Get accountant details
    /// </summary>
    public interface IGetAccountantDetailsQuery : IQuery<AccountantDto, IdQueryParam>
    {
    }
}