namespace Marcinkiewicz.CqrsFramework.Security.Services
{
    /// <summary>
    /// Password hasher
    /// </summary>
    public interface IPasswordService
    {
        /// <summary>
        /// Return hash of the password using internal implementation
        /// </summary>
        /// <param name="password">Password</param>
        /// <returns>Hash of the password</returns>
        string GenerateHash(string password);

        /// <summary>
        /// Validate if hash matches the password
        /// </summary>
        /// <param name="password">Password</param>
        /// <param name="hash">Password hash</param>
        /// <returns>Value indicating whether password matches the provided hash</returns>
        bool Validate(string password, string hash);

        /// <summary>
        /// Return random password hash using internal implementation
        /// </summary>
        /// <returns>Random password hash</returns>
        string GenerateRandomPasswordHash();
    }
}
