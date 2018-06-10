using Marcinkiewicz.CqrsFramework.Domain.Common;
using System;

namespace Marcinkiewicz.CqrsFramework.Domain.Accountant.Commands
{
    /// <summary>
    /// Update accountant command
    /// </summary>
    public class UpdateAccountantCommand : UpdateCommand
    {
        /// <summary>
        /// Initialize new instance of <see cref="UpdateAccountantCommand"/>
        /// </summary>
        /// <param name="accountantId">Accountant id</param>
        public UpdateAccountantCommand(Guid accountantId)
            : base(accountantId)
        {
        }

        /// <summary>
        /// Gets or sets first name of the accountant
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets last name of the accountant
        /// </summary>
        public string LastName { get; set; }
    }
}
