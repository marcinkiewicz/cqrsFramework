using System;

namespace Marcinkiewicz.CqrsFramework.Domain.Common
{
    /// <summary>
    /// Dto containing only entity Id
    /// </summary>
    public class IdDto
    {
        /// <summary>
        /// Gets or sets entity id.
        /// </summary>
        public Guid Id { get; set; }
    }
}
