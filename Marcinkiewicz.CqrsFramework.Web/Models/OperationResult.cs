using System;

namespace Marcinkiewicz.CqrsFramework.Web.Models
{
    public class OperationResult
    {
        /// <summary>
        /// Response returned when successfully added new entity.
        /// </summary>
        public class AddOperatioResult
        {
            /// <summary>
            /// Newly added entity id
            /// </summary>
            public Guid Id { get; set; }
        }

        /// <summary>
        /// Creates response with newly created entity id.
        /// </summary>
        /// <param name="entityId">Entity id</param>
        /// <returns>Response model</returns>
        public static AddOperatioResult Added(Guid entityId)
        {
            return new AddOperatioResult
            {
                Id = entityId
            };
        }
    }
}
