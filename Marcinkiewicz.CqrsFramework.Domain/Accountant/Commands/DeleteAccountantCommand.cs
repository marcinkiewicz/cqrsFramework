using Marcinkiewicz.CqrsFramework.Domain.Common;
using System;

namespace Marcinkiewicz.CqrsFramework.Domain.Accountant.Commands
{
    /// <summary>
    /// Delete client command
    /// </summary>
    public class DeleteAccountantCommand : DeleteCommand
    {
        /// <summary>
        /// Initialize new instance of <see cref="DeleteAccountantCommand"/>
        /// </summary>
        /// <param name="accountantId">Accountant id</param>
        public DeleteAccountantCommand(Guid accountantId) 
            : base(accountantId)
        {
        }
    }
}
