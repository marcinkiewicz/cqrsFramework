using System.Threading.Tasks;

namespace Marcinkiewicz.CqrsFramework.Domain.Common
{
    /// <summary>
    /// Command handler
    /// </summary>
    public interface ICommandHandler
    { }

    /// <summary>
    /// Command handler for <typeparamref name="TCommand"/> commands
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    public interface ICommandHandler<TCommand> : ICommandHandler where TCommand: ICommand
    {
        /// <summary>
        /// Executes the command
        /// </summary>
        /// <param name="command">Command to be executed</param>
       Task HandleImmediateAsync(TCommand command);
    }
}
