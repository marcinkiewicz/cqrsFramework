namespace Marcinkiewicz.CqrsFramework.Data.Models.Enums
{
    /// <summary>
    /// Status of the document
    /// </summary>
    public enum DocumentStatus
    {
        /// <summary>
        /// Document has been created by accountant
        /// </summary>
        New = 1,

        /// <summary>
        /// Document has been approved by manager
        /// </summary>
        Approved = 2,

        /// <summary>
        /// Document has been rejected by manager
        /// </summary>
        Rejected = 3,
    }
}
