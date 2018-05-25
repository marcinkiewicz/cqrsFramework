using System;

namespace Marcinkiewicz.CqrsFramework.Domain.Common
{
    /// <summary>
    /// Query pagination supportive query params
    /// </summary>
    public class PagedQueryParam : IQueryParameter
    {
        /// <summary>
        /// Gets or sets page
        /// </summary>
        public short Page { get; set; }

        /// <summary>
        /// Gets or sets page size
        /// </summary>
        public short PageSize { get; set; }

        /// <summary>
        /// Creates new instance of <see cref="PagedQueryParam"/>
        /// </summary>
        /// <param name="page">Page</param>
        /// <param name="pageSize">Page size (max items per page)</param>
        public PagedQueryParam(short page, short pageSize, Guid? ownerId = null)
        {
            this.Page = page;
            this.PageSize = pageSize;
        }
    }
}
