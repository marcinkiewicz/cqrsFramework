namespace Marcinkiewicz.CqrsFramework.Domain.Common
{
    /// <summary>
    /// Command executed event
    /// </summary>
    public interface ICommandExecutedEvent : IDomainEvent
    {
        /// <summary>
        /// Gets or sets command name
        /// </summary>
        string CommandName { get; set; }

        /// <summary>
        /// Gets or sets value indicating whether 
        /// command was executed successfuly
        /// </summary>
        bool Success { get; set; }
    }
}
