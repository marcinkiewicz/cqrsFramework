# CQRS Framework

Simple comprehensive CQRS framework. Easy to use at early stage of applications development using .NET Core.

# Solution Structure

### Marcinkiewicz.CQRSFramework.Data

Data has no dependencies to another projects and serves as a middle layer between Domain and the Database.
-	Contains data access class ([DataContext.cs](https://github.com/marcinkiewicz/cqrsFramework/blob/master/Marcinkiewicz.CqrsFramework.Domain.Data/DataContext.cs)) that provide access to the database tables using [Entity Framewok ORM](https://docs.microsoft.com/en-us/ef/core/)
-	Aggregates data models (each of them representing single database table)
-	Expose configuration extension ([ConfigurationExtensions.cs)](https://github.com/marcinkiewicz/cqrsFramework/blob/master/Marcinkiewicz.CqrsFramework.Data/Configuration/ConfigurationExtensions.cs) to register data access class to the IoC container build in .NET core framework [(Dependency Injection in .NET Core)](https://docs.microsoft.com/pl-pl/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-2.1) that can be used in the Startup class of the project
-	Data mapping using EF Core Fluent API ([DataContextConfiguration.cs)](https://github.com/marcinkiewicz/cqrsFramework/blob/master/Marcinkiewicz.CqrsFramework.Data/Configuration/DataContextConfiguration.cs)

Registering data access layer in application [Startup.cs](https://github.com/marcinkiewicz/cqrsFramework/blob/master/Marcinkiewicz.CqrsFramework.Web/Startup.cs) class:
```cs
   // Registering data access layer in Marcinkiewicz.CQRSFramework.Web Startup.cs
   services.RegisterDatabase("sampleconnectionstring");
```

### Marcinkiewicz.CQRSFramework.Domain.Common

Part of the Domain that contains infrastructure definitions, base classes and interfaces extracted from and used by by application Domain. The reason to keep it separate from the rest of domain is to provide required tools to seamlessly create application domain with focus on the business context and not technical implementation.

-	Commands
    -	Base classes and interfaces for commands
    -	Abstract CRUD commands (Add, Delete, Update)
    -   Base classes, interfaces and exceptions for command handlers
-	Queries
    -	Base classes and interfaces for queries
    -	Parametrized queries with base parameters
-	Models
    -	Basic DTO models
    -	Model factory contract
-	Infrastructure
    - [CommandBus](https://github.com/marcinkiewicz/cqrsFramework/blob/master/Marcinkiewicz.CqrsFramework.Domain.Common/Infrastructure/CommandBus.cs) implementing *ICommandBus* interface, responsible for matching command with applicable command handler, executing command, handling failure and sending post-command event
    - [QueryFactory](https://github.com/marcinkiewicz/cqrsFramework/blob/master/Marcinkiewicz.CqrsFramework.Domain.Common/Infrastructure/QueryFactory.cs) implementing *IQueryFactory* interface, responsible for creating queries based on requested interface
    - [DummyServiceBus](https://github.com/marcinkiewicz/cqrsFramework/blob/master/Marcinkiewicz.CqrsFramework.Domain.Common/Infrastructure/QueryFactory.cs) implementing *IServiceBus* interface,  responsible for broadcasting the events - production implementation can utilize AzureService bus.
- Configuration extensions ([ConfigurationExtensions.cs)](https://github.com/marcinkiewicz/cqrsFramework/blob/master/Marcinkiewicz.CqrsFramework.Domain.Common/Configuration/ConfigurationExtensions.cs) that registers whole Domain (commands, queries, events, model factories, command handlers and infrastructure)

> Marcinkiewicz.CQRSFramework.Domain.Common provides both interfaces and implementations of the CQRS infrastructure which enables both quick ramp up (CommandBus and QueryFactory impelemntations are fully functional) and extensibility (exposed interfaces can be implemented the way that is the most suitable for Developer).

Registering domain layer in application [Startup.cs](https://github.com/marcinkiewicz/cqrsFramework/blob/master/Marcinkiewicz.CqrsFramework.Web/Startup.cs) class:
```cs
   // Registering domain layer in Marcinkiewicz.CQRSFramework.Web Startup.cs
    services.RegisterDomain();
```


# Commanding

1. Adding new Accountant - simplified diagram (do not include Event broadcasting)

![alt text](https://raw.githubusercontent.com/marcinkiewicz/cqrsFramework/master/Docs/Assets/CqrsPostAddDiagram.png)

# Querying

1. Fetching all accountants


> DOCUMENTATION IS NOT COMPLETE YET