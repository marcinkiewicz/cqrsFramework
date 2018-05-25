using Marcinkiewicz.CqrsFramework.Data;
using System;
using System.Threading.Tasks;

namespace Marcinkiewicz.CqrsFramework.Domain.Common
{
    /// <summary>
    /// Base class for command handlers utilizing <see cref="IDataContext"/>
    /// as persistence layer
    /// </summary>
    public abstract class CommandHandlerBase
    {
        /// <summary>
        /// Database context
        /// </summary>
        protected readonly IDataContext DataContext;

        /// <summary>
        /// Initializes new instance of class inheriting <see cref="CommandHandlerBase"/>
        /// </summary>
        /// <param name="dataContext"></param>
        public CommandHandlerBase(IDataContext dataContext)
        {
            this.DataContext = dataContext;
        }

        /// <summary>
        /// Save data to the persistence layer
        /// </summary>
        /// <returns></returns>
        protected async Task Finalize()
        {
            try
            {
                await this.DataContext.SaveChangesAsync();
            }
            catch(Exception exception)
            {
                throw new CommandExecutionFailedException(exception);
            }
        }
    }
}
