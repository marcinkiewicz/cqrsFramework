using Marcinkiewicz.CqrsFramework.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Marcinkiewicz.CqrsFramework.Data
{
    /// <summary>
    /// Data context represent data access class contract
    /// Contains accessible collections representing data tables
    /// and method to perform updates on the tables content
    /// </summary>
    public interface IDataContext
    {
        /// <summary>
        /// Gets or sets collection of <see cref="Accountant"/>
        /// </summary> 
        DbSet<Accountant> Accountants { get; set; }

        /// <summary>
        /// Gets or sets collection of <see cref="Document"/>
        /// </summary> 
        DbSet<Document> Documents { get; set; }

        /// <summary>
        /// Gets or sets collection of <see cref="Manager"/>
        /// </summary> 
        DbSet<Manager> Managers { get; set; }

        /// <summary>
        /// Save changes to the database
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Add entity to the database
        /// </summary>
        /// <typeparam name="TModel">Type of the entity</typeparam>
        /// <param name="model">Object to add</param>
        void Insert<TModel>(TModel model) where TModel : class;

        /// <summary>
        /// Update entity in the database
        /// </summary>
        /// <typeparam name="TModel">Type of the entity</typeparam>
        /// <param name="model">Object to update</param>
        void Amend<TModel>(TModel model) where TModel : class;

        /// <summary>
        /// Delete entity from the database
        /// </summary>
        /// <typeparam name="TModel">Type of the entity</typeparam>
        /// <param name="model">Object to remove</param>
        void Delete<TModel>(TModel model) where TModel : class;

        /// <summary>
        /// Set property as modified in the change tracker
        /// </summary>
        /// <typeparam name="TEntity">Type of the entity</typeparam>
        /// <param name="entity">Entity</param>
        /// <param name="propertyName">Name of the property</param>
        /// <param name="changed">Indicates whether value was changed</param>
        void SetPropertyModified<TEntity>(TEntity entity, string propertyName, bool changed = true) where TEntity : class;

        /// <summary>
        /// Set collection as modified in the change tracker
        /// </summary>
        /// <typeparam name="TEntity">Type of the entity</typeparam>
        /// <param name="entity">Entity</param>
        /// <param name="propertyName">Name of the collection</param>
        /// <param name="changed">Indicates whether value was changed</param>
        void SetCollectionModified<TEntity>(TEntity entity, string collectionName, bool changed = true) where TEntity : class;
    }
}