using System;

namespace Marcinkiewicz.CqrsFramework.Domain.Common
{
    /// <summary>
    /// Represent parameter of query containing entity Id
    /// </summary>
    public class IdQueryParam: IQueryParameter
    {
        /// <summary>
        /// Creates new instance of <see cref="IdQueryParam"/>
        /// </summary>
        /// <param name="id">Entity id</param>
        public IdQueryParam(Guid id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets or sets entity id.
        /// </summary>
        public Guid Id { get; }
    }
}
