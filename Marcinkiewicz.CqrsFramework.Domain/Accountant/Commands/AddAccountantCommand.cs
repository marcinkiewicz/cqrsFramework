using Marcinkiewicz.CqrsFramework.Domain.Common;

namespace Marcinkiewicz.CqrsFramework.Domain.Accountant.Commands
{
    /// <summary>
    /// Add accountant command
    /// </summary>
    public class AddAccountantCommand : CreateCommand, ICommand
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
        /// Gets or sets password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets email
        /// </summary>
        public string Email { get; set; }
    }
}
