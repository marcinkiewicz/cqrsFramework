namespace Marcinkiewicz.CqrsFramework.Data.Models
{
    public abstract class User : TrackableEntity
    {
        /// <summary>
        /// Gets or sets user name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets user email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets password hash.
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets value indicating whether user account is confirmed.
        /// </summary>
        public bool IsConfirmed { get; set; }

        /// <summary>
        /// Gets or sets value indicating whether user account is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets value indicating whether user account is soft removed.
        /// </summary>
        public bool IsRemoved { get; set; }
    }
}
