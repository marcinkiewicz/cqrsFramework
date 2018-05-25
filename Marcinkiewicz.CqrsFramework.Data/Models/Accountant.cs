using System.Collections.Generic;

namespace Marcinkiewicz.CqrsFramework.Data.Models
{
    /// <summary>
    /// Entity representing accountant
    /// </summary>
    public class Accountant: User
    {
        /// <summary>
        /// Gets or sets first name of the doctor.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets last name of the doctor.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets list of documents created by this accountant
        /// </summary>
        public virtual ICollection<Document> DocumentsList { get; set; }
    }
}
