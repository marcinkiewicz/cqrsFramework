using Marcinkiewicz.CqrsFramework.Data.Models.Enums;
using System;

namespace Marcinkiewicz.CqrsFramework.Data.Models
{
    /// <summary>
    /// Entity representing single document created by accountant
    /// </summary>
    public class Document: TrackableEntity
    {
        /// <summary>
        /// Gets or sets order status
        /// </summary>
        public DocumentStatus Status { get; set; }

        /// <summary>
        /// Gets or sets date when document was processed by manager
        /// </summary>
        public DateTime? ProcessedDateTime { get; set; }

        /// <summary>
        /// Gets or sets id of accountant who created the document
        /// </summary>
        public Guid? CreatedById { get; set; }

        /// <summary>
        /// Gets or sets accountant who created the document
        /// </summary>
        public virtual Accountant CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets id of manager who processed the document
        /// </summary>
        public Guid? ProcessedById { get; set; }

        /// <summary>
        /// Gets or sets manager who processed the document
        /// </summary>
        public virtual Manager ProcessedBy { get; set; }
    }
}
