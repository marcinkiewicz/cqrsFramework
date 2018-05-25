using System;

namespace Marcinkiewicz.CqrsFramework.Domain.Common
{
    /// <summary>
    /// Abstract class for removal type of commands.
    /// </summary>
    public abstract class DeleteCommand : ICommand
    {
        /// <summary>
        /// Gets or sets entity id
        /// </summary>
        public Guid Id { get; }

        /// <inheritdoc />
        public bool SuppressEvent { get; set; }

        /// <summary>
        /// Creates new instance of class inheriting from <see cref="DeleteCommand"/>
        /// </summary>
        /// <param name="entityId">Entity id</param>
        public DeleteCommand(Guid entityId)
        {
            this.Id = entityId;
        }
    }
}
