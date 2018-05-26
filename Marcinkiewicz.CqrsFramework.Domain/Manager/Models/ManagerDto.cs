using Marcinkiewicz.CqrsFramework.Domain.Common;

namespace Marcinkiewicz.CqrsFramework.Domain.Manager.Models
{
    /// <summary>
    /// Entity representing manager
    /// </summary>
    public class ManagerDto: IdDto
    {
        /// <summary>
        /// Gets or sets corporate number of the manager
        /// </summary>
        public string CorporateNumber { get; set; }
    }
}
