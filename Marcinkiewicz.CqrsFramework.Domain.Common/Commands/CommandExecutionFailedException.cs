using System;

namespace Marcinkiewicz.CqrsFramework.Domain.Common
{
    /// <summary>
    /// Exception thrown when command execution has failed
    /// </summary>
    public class CommandExecutionFailedException : Exception
    {
        /// <summary>
        /// Creates new instance of <see cref="CommandExecutionFailedException"/>
        /// </summary>
        /// <param name="innerException"></param>
        public CommandExecutionFailedException(Exception innerException)
            : base("Command execution failed", innerException)
        {
        }
    }
}
