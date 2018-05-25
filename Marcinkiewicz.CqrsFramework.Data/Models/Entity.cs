using System;

namespace Marcinkiewicz.CqrsFramework.Data.Models
{
    /// <summary>
    /// Base class for data entities
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Gets or sets unique identifier
        /// </summary>
        public Guid Id { get; set; }
    }
}
