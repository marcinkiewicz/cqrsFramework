using System.ComponentModel.DataAnnotations;

namespace Marcinkiewicz.CqrsFramework.Web.ViewModels.Accountant
{
    public class UpdateAccountantViewModel
    {
        /// <summary>
        /// Gets or sets first name of the accountant
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets last name of the accountant
        /// </summary>
        public string LastName { get; set; }
    }
}
