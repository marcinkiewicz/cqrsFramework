using System.Threading.Tasks;

namespace Marcinkiewicz.CqrsFramework.Domain.Common
{
    /// <summary>
    /// Command bus contract
    /// </summary>
    public interface ICommandBus
    {
        /// <summary>
        /// Broadcast command to handlers
        /// </summary>
        /// <typeparam name="TCommand">Command type</typeparam>
        /// <param name="command">Command to be sent</param>
        /// <returns></returns>
        Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
