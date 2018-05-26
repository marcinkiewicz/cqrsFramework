using System.Threading.Tasks;
using Marcinkiewicz.CqrsFramework.Data;
using Marcinkiewicz.CqrsFramework.Domain.Accountant.Commands;
using Marcinkiewicz.CqrsFramework.Domain.Common;

namespace Marcinkiewicz.CqrsFramework.Domain.Accountant
{
    internal class AccountantService : CommandHandlerBase,
        ICommandHandler<AddAccountantCommand>,
        ICommandHandler<UpdateAccountantCommand>,
        ICommandHandler<DeleteAccountantCommand>

    {
        private readonly AccountantFactory accountantFactory;

        /// <summary>
        /// Initialize new instance of <see cref=""/>
        /// </summary>
        /// <param name="dataContext"></param>
        /// <param name="accountantFactory"></param>
        public AccountantService(IDataContext dataContext, AccountantFactory accountantFactory)
            : base(dataContext)
        {
            this.accountantFactory = accountantFactory;
        }

        /// <summary>
        /// Handle <see cref="AddAccountantCommand"/>
        /// </summary>
        /// <param name="command">Command object</param>
        public async Task HandleImmediateAsync(AddAccountantCommand command)
        {
            Data.Models.Accountant model = accountantFactory.Create(command);
            DataContext.Accountants.Add(model);
            await this.Finalize();
        }

        /// <summary>
        /// Handle <see cref="UpdateAccountantCommand"/>
        /// </summary>
        /// <param name="command">Command object</param>
        public async Task HandleImmediateAsync(UpdateAccountantCommand command)
        {
            Data.Models.Accountant model = accountantFactory.Create(command);
            DataContext.Accountants.Attach(model);

            if (!string.IsNullOrEmpty(command.FirstName))
            {
                DataContext.SetPropertyModified(model, nameof(model.FirstName));
            }

            if (!string.IsNullOrEmpty(command.LastName))
            {
                DataContext.SetPropertyModified(model, nameof(model.LastName));
            }

            DataContext.SetPropertyModified(model, nameof(model.LastModificationDate));

            await this.Finalize();
        }

        /// <summary>
        /// Handle <see cref="DeleteAccountantCommand"/>
        /// </summary>
        /// <param name="command">Command object</param>
        public async Task HandleImmediateAsync(DeleteAccountantCommand command)
        {
            Data.Models.Accountant model = accountantFactory.Create(command);
            DataContext.Accountants.Attach(model);

            DataContext.SetPropertyModified(model, nameof(model.IsRemoved));
            DataContext.SetPropertyModified(model, nameof(model.LastModificationDate));

            await this.Finalize();
        }
    }
}
