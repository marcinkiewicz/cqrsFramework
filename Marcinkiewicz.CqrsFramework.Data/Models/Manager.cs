using System.Collections.Generic;

namespace Marcinkiewicz.CqrsFramework.Data.Models
{
    public class Manager: User
    {
        /// <summary>
        /// Gets or sets corporate identification number
        /// </summary>
        public string CorporateNumber { get; set; }

        /// <summary>
        /// Gets or sets list of processed documents
        /// </summary>
        public virtual ICollection<Document> ProcessedDocumentsList { get; set; }
    }
}
