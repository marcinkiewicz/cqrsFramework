using System.Collections.Generic;
using System.Threading.Tasks;
using Marcinkiewicz.CqrsFramework.Domain.Accountant.Models;
using Marcinkiewicz.CqrsFramework.Domain.Accountant.Queries;
using Marcinkiewicz.CqrsFramework.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace Marcinkiewicz.CqrsFramework.Web.Controllers
{
    [Route("api/[controller]")]
    public class AccountantController : Controller
    {
        private readonly ICommandBus commandBus;
        private readonly IQueryFactory queryFactory;

        public AccountantController(ICommandBus commandBus, IQueryFactory queryFactory)
        {
            this.commandBus = commandBus;
            this.queryFactory = queryFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetAccountantsListQuery query = this.queryFactory.Create<GetAccountantsListQuery>();
            IEnumerable<AccountantDto> result = await query.GetResultsAsync();
            return Ok(result);
        }
    }
}
