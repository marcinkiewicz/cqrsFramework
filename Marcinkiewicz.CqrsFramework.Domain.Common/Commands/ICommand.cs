namespace Marcinkiewicz.CqrsFramework.Domain.Common
{
    /// <summary>
    /// Command continued with <typeparamref name="TEvent"/> event
    /// </summary>
    public interface ICommand<TEvent> where TEvent: ICommandExecutedEvent
    {
        /// <summary>
        /// Force command to suppress event broadcasting after execution.
        /// </summary>
        bool SuppressEvent { get; set; }
    }

    /// <summary>
    /// Command continued with <see cref="CommandExecutedEvent"/>
    /// </summary>
    public interface ICommand: ICommand<CommandExecutedEvent>
    {
    }
}
