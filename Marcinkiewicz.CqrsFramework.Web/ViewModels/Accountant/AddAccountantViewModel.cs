using System.ComponentModel.DataAnnotations;

namespace Marcinkiewicz.CqrsFramework.Web.ViewModels.Accountant
{
    public class AddAccountantViewModel
    {
        /// <summary>
        /// Gets or sets first name of the accountant
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets last name of the accountant
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets password
        /// </summary>
        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets email
        /// </summary>
        [Required]
        public string Email { get; set; }
    }
}
