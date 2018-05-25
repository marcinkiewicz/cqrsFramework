namespace Marcinkiewicz.CqrsFramework.Domain.Common
{
    public interface IDomainEvent
    {
        /// <summary>
        /// Gets or sets type name of the event
        /// </summary>
        /// <remarks>
        /// Should represent typeof() result of the class that implements this interface
        /// </remarks>
        string EventTypeName { get; }
    }
}
