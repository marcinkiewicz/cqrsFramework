using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Marcinkiewicz.CqrsFramework.Domain.Accountant.Commands;
using Marcinkiewicz.CqrsFramework.Domain.Accountant.Models;
using Marcinkiewicz.CqrsFramework.Domain.Accountant.Queries;
using Marcinkiewicz.CqrsFramework.Domain.Common;
using Marcinkiewicz.CqrsFramework.Web.Models;
using Marcinkiewicz.CqrsFramework.Web.ViewModels.Accountant;
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
        public async Task<IActionResult> GetList()
        {
            GetAccountantsListQuery query = this.queryFactory.Create<GetAccountantsListQuery>();

            // Configured to contain only first and last name
            IEnumerable<AccountantDto> result = await query.GetResultsAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAccountantViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data model.");
            }

            AddAccountantCommand command = new AddAccountantCommand
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = model.Password
            };

            try
            {
                await this.commandBus.SendAsync(command);
            }
            catch
            {
                return BadRequest("Failed to add accountant.");
            }

            return Ok(OperationResult.Added(command.Id));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            GetAccountantDetailsQuery query = this.queryFactory.Create<GetAccountantDetailsQuery>();

            // Configured to contain all details including documents list
            AccountantDto result = await query.GetResultsAsync(new IdQueryParam(id));
            return Ok(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateAccountantViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data model.");
            }

            UpdateAccountantCommand command = new UpdateAccountantCommand(id)
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            try
            {
                await this.commandBus.SendAsync(command);
            }
            catch
            {
                return BadRequest("Failed to update accountant.");
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteAccountantCommand command = new DeleteAccountantCommand(id);

            try
            {
                await this.commandBus.SendAsync(command);
            }
            catch
            {
                return BadRequest("Failed to delete accountant.");
            }

            return Ok();
        }
    }
}
