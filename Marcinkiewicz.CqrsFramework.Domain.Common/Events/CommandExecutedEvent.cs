namespace Marcinkiewicz.CqrsFramework.Domain.Common
{
    /// <summary>
    /// Event broadcasted when command was executed by handler.
    /// </summary>
    public class CommandExecutedEvent : ICommandExecutedEvent
    {
        /// <inheritdoc />
        public string CommandName { get; set; }

        /// <inheritdoc />
        public bool Success { get; set; }

        /// <inheritdoc />
        public string EventTypeName => nameof(CommandExecutedEvent);
    }
}
