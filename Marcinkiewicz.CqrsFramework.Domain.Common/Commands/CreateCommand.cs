using System;

namespace Marcinkiewicz.CqrsFramework.Domain.Common
{
    /// <summary>
    /// Abstract class for creational type of commands that automaticaly creates new Id for entity
    /// </summary>
    public abstract class CreateCommand : ICommand
    {
        /// <summary>
        /// Gets or sets entity id
        /// </summary>
        public Guid Id { get; }

        /// <inheritdoc />
        public Guid? ExecutionContextUserId { get; set; }

        /// <inheritdoc />
        public bool SuppressEvent { get; set; }

        /// <summary>
        /// Creates new instance of class inheriting from <see cref="CreateCommand"/>
        /// </summary>
        public CreateCommand()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
