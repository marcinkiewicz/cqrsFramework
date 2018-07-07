using AutoMapper;
using Marcinkiewicz.CqrsFramework.Data;
using Marcinkiewicz.CqrsFramework.Domain.Accountant.Models;
using Marcinkiewicz.CqrsFramework.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Marcinkiewicz.CqrsFramework.Domain.Accountant.Queries
{
    internal class GetAccountantDetailsQuery : QueryBase, IGetAccountantDetailsQuery
    {
        /// <summary>
        /// Initialize new instance of <see cref="GetAccountantDetailsQuery"/>
        /// </summary>
        /// <param name="dataContext">Data access class</param>
        /// <param name="mapper">Entity mapper</param>
        public GetAccountantDetailsQuery(IDataContext dataContext, IMapper mapper)
            : base(dataContext, mapper)
        {
        }

        /// <summary>
        /// Gets accountant details
        /// </summary>
        /// <param name="parameter">Query parameter</param>
        /// <returns></returns>
        public async Task<AccountantDto> GetResultsAsync(IdQueryParam parameter)
        {
            Data.Models.Accountant accountant = await this
                .DataContext
                .Accountants
                .Include(mdl => mdl.DocumentsList)
                .AsNoTracking()
                .Where(mdl => !mdl.IsRemoved)
                .FirstAsync(mdl => mdl.Id == parameter.Id);

            AccountantDto result = Mapper.Map<AccountantDto>(accountant);
            return result;
        }
    }
}
