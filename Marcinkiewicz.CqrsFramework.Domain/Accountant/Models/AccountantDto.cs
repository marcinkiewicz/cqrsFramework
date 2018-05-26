using Marcinkiewicz.CqrsFramework.Domain.Common;
using Marcinkiewicz.CqrsFramework.Domain.Document.Models;
using System.Collections.Generic;

namespace Marcinkiewicz.CqrsFramework.Domain.Accountant.Models
{
    public class AccountantDto: IdDto, IQueryModel
    {
        /// <summary>
        /// Gets or sets first name of the accountant
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets last name of the accountant
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets list of documents created by accountant
        /// </summary>
        public IEnumerable<DocumentDto> DocumentsList { get; set; }
    }
}
