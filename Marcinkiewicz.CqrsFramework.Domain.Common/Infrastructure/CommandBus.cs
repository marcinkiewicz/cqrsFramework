using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marcinkiewicz.CqrsFramework.Domain.Common
{
    /// <summary>
    /// Command sending class
    /// </summary>
    internal class CommandBus : ICommandBus
    {
        private readonly IServiceBus serviceBus;
        private readonly Func<Type, ICommandHandler> handlersFactory;
        private readonly Func<ICommand, IEnumerable<ICommandExecutedEvent>> eventsFactory;
 
        /// <summary>
        /// Creates new instance of <see cref="CommandBus"/>
        /// </summary>
        /// <param name="serviceBus">Service bus</param>
        /// <param name="handlersFactory">Handler factory</param>
        /// <param name="eventsFactory">Events factory</param>
        public CommandBus(
            IServiceBus serviceBus,
            Func<Type, ICommandHandler> handlersFactory,
            Func<ICommand, IEnumerable<ICommandExecutedEvent>> eventsFactory)
        {
            this.serviceBus = serviceBus;
            this.handlersFactory = handlersFactory;
            this.eventsFactory = eventsFactory;
        }

        /// <inheritdoc />
        public async Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            ICommandHandler<TCommand> handler = this.handlersFactory(typeof(TCommand)) as ICommandHandler<TCommand>;
            if (handler == null)
            {
                throw new ArgumentException($"Command {typeof(TCommand).Name} does not have a valid handler");
            }

            // Execute command by handler
            await handler.HandleImmediateAsync(command);

            // Broadcast event if not suppressed
            if (!command.SuppressEvent)
            {
                IEnumerable<ICommandExecutedEvent> domainEvents = this.eventsFactory(command);
                foreach (var domainEvent in domainEvents)
                {
                    await this.serviceBus.SendAsync(domainEvent);
                }
            }
        }
    }
}
