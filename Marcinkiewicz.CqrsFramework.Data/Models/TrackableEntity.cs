using System;

namespace Marcinkiewicz.CqrsFramework.Data.Models
{
    /// <summary>
    /// Entity with trackable state.
    /// </summary>
    public abstract class TrackableEntity: Entity
    {
        /// <summary>
        /// Gets or sets date of entity creation.
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Gets or sets datetime of last modification.
        /// </summary>
        public DateTime LastModificationDate { get; set; }
    }
}
