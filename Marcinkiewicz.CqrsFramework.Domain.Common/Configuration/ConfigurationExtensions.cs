using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Marcinkiewicz.CqrsFramework.Domain.Common.Configuration
{
    /// <summary>
    /// Class containing <see cref="IServiceCollection"/> extensions 
    /// to register database in the IoC container.
    /// </summary>
    public static class ConfigurationExtensions
    {
        private const string DomainAssembylName = "Marcinkiewicz.CqrsFramework.Domain";
        /// <summary>
        /// Register command handlers, commands, queries and infrastructure.
        /// </summary>
        /// <param name="services">DI container</param>
        public static void RegisterDomain(this IServiceCollection services)
        {
            services.AddSingleton<IQueryFactory, QueryFactory>();
            services.AddScoped<ICommandBus, CommandBus>();

            IEnumerable<TypeInfo> assembliesTypesInfo = GetTypesInfo(DomainAssembylName);
            AddCommandHandlers(services, assembliesTypesInfo);
            AddEvents(services, assembliesTypesInfo);
            AddQueries(services, assembliesTypesInfo);

            AddDomainModelFactories(services, assembliesTypesInfo);
        }

        private static void AddDomainModelFactories(IServiceCollection services, IEnumerable<TypeInfo> typesInfo)
        {
            var domainModelFactoryTypes = typesInfo
                .Where(ti => ti.IsClass)
                .Where(ti => !ti.IsAbstract)
                .Where(ti => typeof(IDomainModelFactory).IsAssignableFrom(ti));

            foreach (var domainModelFactoryType in domainModelFactoryTypes)
            {
                // Look for detailed interface e.g. ISpecificDomainModelFactory 
                // (which implements IDomainModelFactory)
                // in order to register SpecificDomainModelFactory with ISpecificDomainModelFactory
                // and not with IDomainModelFactory
                Type specificDomainModelFactory = domainModelFactoryType
                    .ImplementedInterfaces
                    .Where(i => typeof(IDomainModelFactory).IsAssignableFrom(i))
                    .First();

                services.AddScoped(specificDomainModelFactory, domainModelFactoryType);
            }
        }

        private static void AddCommandHandlers(IServiceCollection services, IEnumerable<TypeInfo> typesInfo)
        {
            var commandHandlerTypes = typesInfo
                .Where(ti => ti.IsClass)
                .Where(ti => !ti.IsAbstract)
                .Where(ti => typeof(ICommandHandler).IsAssignableFrom(ti));

            foreach (var commandHandlerType in commandHandlerTypes)
            {
                IEnumerable<Type> genericHandlers = commandHandlerType
                    .ImplementedInterfaces
                    .Where(i => i.IsGenericType)
                    .Where(i => typeof(ICommandHandler).IsAssignableFrom(i));

                // One handler implements one ICommandHandler
                // but can implement multiple ICommandHandler<T> in order to
                // handle multiple commands
                foreach (var genericHandler in genericHandlers)
                {
                    services.AddScoped(genericHandler, commandHandlerType);
                }
            }

            // Register factory that create specific command handlers
            services.AddScoped<Func<Type, ICommandHandler>>((IServiceProvider sp) =>
                commandType => sp.GetService(typeof(ICommandHandler<>).MakeGenericType(commandType)) as ICommandHandler);
        }

        private static void AddQueries(IServiceCollection services, IEnumerable<TypeInfo> typesInfo)
        {
            var queryTypes = typesInfo
                .Where(ti => ti.IsClass)
                .Where(ti => !ti.IsAbstract)
                .Where(ti => typeof(IQuery).IsAssignableFrom(ti));

            foreach (var queryType in queryTypes)
            {
                services.AddScoped(queryType);
            }
        }

        private static void AddEvents(IServiceCollection services, IEnumerable<TypeInfo> typesInfo)
        {
            var eventTypes = typesInfo
                .Where(ti => ti.IsClass)
                .Where(ti => !ti.IsAbstract)
                .Where(ti => typeof(IDomainEvent).IsAssignableFrom(ti));

            foreach (var eventType in eventTypes)
            {
                services.AddScoped(eventType);
            }

            // Register factory that create specific events based on the command
            services.AddScoped<Func<ICommand, IEnumerable<ICommandExecutedEvent>>>((IServiceProvider sp) =>
            {
                Func<ICommand, IEnumerable<ICommandExecutedEvent>> factoryFn = (cmd) =>
                {
                    IEnumerable<Type> evtTypes = cmd
                        .GetType()
                        .GetTypeInfo()
                        .ImplementedInterfaces
                        .Where(i => i.IsGenericType)
                        .Where(i => i.GenericTypeArguments.Any(arg => arg.GetInterface(nameof(ICommandExecutedEvent)) != null))
                        .SelectMany(i => i.GenericTypeArguments.Where(arg => arg.IsClass));

                    if (evtTypes == null || !evtTypes.Any())
                    {
                        throw new ArgumentException("This command does not have any events.");
                    }

                    List<ICommandExecutedEvent> events = new List<ICommandExecutedEvent>();

                    foreach (var evtType in evtTypes)
                    {
                        ICommandExecutedEvent evt = sp.GetService(evtType) as ICommandExecutedEvent;
                        evt.CommandName = cmd.GetType().FullName;
                        evt.Success = true;
                        events.Add(evt);
                    }
                    return events;
                };
                return factoryFn;
            });
        }

        private static IEnumerable<TypeInfo> GetTypesInfo(string assemblyName)
        {
            IEnumerable<TypeInfo> assemblyTypesInfo = Assembly
                    .Load(new AssemblyName(assemblyName))
                    .GetTypes()
                    .Select(t => t.GetTypeInfo());

            return assemblyTypesInfo;
        }
    }
}
