using System.Threading.Tasks;

namespace Marcinkiewicz.CqrsFramework.Domain.Common
{
    /// <summary>
    /// No-op service bus
    /// </summary>
    public class DummyServiceBus : IServiceBus
    {
        /// <inheritdoc />
        public Task SendAsync(IDomainEvent domainEvent)
        {
            // no-op
            return Task.CompletedTask;
        }
    }
}
