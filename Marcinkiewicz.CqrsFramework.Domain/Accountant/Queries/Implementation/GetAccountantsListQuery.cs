using AutoMapper;
using Marcinkiewicz.CqrsFramework.Data;
using Marcinkiewicz.CqrsFramework.Domain.Accountant.Models;
using Marcinkiewicz.CqrsFramework.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marcinkiewicz.CqrsFramework.Domain.Accountant.Queries
{
    /// <summary>
    /// Get list od diet templates for trainer
    /// </summary>
    internal class GetAccountantsListQuery : QueryBase, IGetAccountantsListQuery
    {
        /// <summary>
        /// Initialize new instance of <see cref="GetAccountantsListQuery"/>
        /// </summary>
        /// <param name="dataContext">Data access class</param>
        /// <param name="mapper">Entity mapper</param>
        public GetAccountantsListQuery(IDataContext dataContext, IMapper mapper)
            : base(dataContext, mapper)
        {
        }

        /// <summary>
        /// Get list od accountants
        /// </summary>
        /// <returns>List of accountants</returns>
        public async Task<IEnumerable<AccountantDto>> GetResultsAsync()
        {
            IQueryable<AccountantDto> accountantsQuery = this
               .DataContext
               .Accountants
               .AsNoTracking()
               .Where(mdl => mdl.IsActive)
               .Where(mdl => mdl.IsConfirmed)
               .Where(mdl => !mdl.IsRemoved)
                   .Select(mdl => Mapper.Map<AccountantDto>(mdl));

            IEnumerable<AccountantDto> result = await accountantsQuery.ToListAsync();
            return result;
        }
    }
}