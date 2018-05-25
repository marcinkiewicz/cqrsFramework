using AutoMapper;
using Marcinkiewicz.CqrsFramework.Data;

namespace Marcinkiewicz.CqrsFramework.Domain.Common
{
    /// <summary>
    /// Base class for queries utilizing <see cref="IDataContext"/>
    /// as data access layer
    /// </summary>
    public abstract class QueryBase
    {
        /// <summary>
        /// Database context
        /// </summary>
        protected readonly IDataContext DataContext;

        /// <summary>
        /// Automapper
        /// </summary>
        protected readonly IMapper Mapper;

        /// <summary>
        /// Initializes new instance of class inheriting <see cref="QueryBase"/>
        /// </summary>
        /// <param name="dataContext"></param>
        public QueryBase(IDataContext dataContext, IMapper mapper)
        {
            this.DataContext = dataContext;
            this.Mapper = mapper;
        }
    }
}
