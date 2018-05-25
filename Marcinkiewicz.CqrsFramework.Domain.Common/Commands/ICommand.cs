namespace Marcinkiewicz.CqrsFramework.Domain.Common
{
    /// <summary>
    /// Saga command continued with event.
    /// </summary>
    public interface ICommand<TEvent> where TEvent: ICommandExecutedEvent
    {
        /// <summary>
        /// Force command to suppress event broadcasting after execution.
        /// </summary>
        bool SuppressEvent { get; set; }
    }

    /// <summary>
    /// No saga command
    /// </summary>
    public interface ICommand: ICommand<CommandExecutedEvent>
    {
    }
}
