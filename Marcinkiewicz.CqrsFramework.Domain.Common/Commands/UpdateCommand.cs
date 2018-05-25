using System;

namespace Marcinkiewicz.CqrsFramework.Domain.Common
{
    /// <summary>
    /// Abstract class for update type of commands.
    /// </summary>
    public abstract class UpdateCommand: ICommand
    {
        /// <summary>
        /// Gets or sets entity id
        /// </summary>
        public Guid Id { get; set; }

        /// <inheritdoc />
        public bool SuppressEvent { get; set; } = false;

        /// <summary>
        /// Creates new instance of class inheriting from <see cref="UpdateCommand"/>
        /// </summary>
        /// <param name="entityId">Entity id</param>
        public UpdateCommand(Guid entityId)
        {
            this.Id = entityId;
        }
    }
}
