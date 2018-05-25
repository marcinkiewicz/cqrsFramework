using System.Threading.Tasks;

namespace Marcinkiewicz.CqrsFramework.Domain.Common
{
    /// <summary>
    /// Service bus mediator
    /// </summary>
    public interface IServiceBus
    {
        /// <summary>
        /// Push message to the service bus queue
        /// </summary>
        /// <param name="message">Domain event</param>
        /// <returns></returns>
        Task SendAsync(IDomainEvent domainEvent);
    }
}
