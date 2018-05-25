using Marcinkiewicz.CqrsFramework.Data.Configuration;
using Marcinkiewicz.CqrsFramework.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Marcinkiewicz.CqrsFramework.Data
{
    /// <summary>
    /// Database access class
    /// </summary>
    internal class DataContext : DbContext, IDataContext
    {
        /// <summary>
        /// Create new instance od <see cref="DataContext"/>
        /// </summary>
        /// <param name="options">Database options</param>
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options)
        {
        }

        /// <inheritdoc />
        public DbSet<Accountant> Accountants { get; set; }

        /// <inheritdoc />
        public DbSet<Document> Documents { get; set; }

        /// <inheritdoc />
        public DbSet<Manager> Managers { get; set; }

        /// <inheritdoc />
        public void Delete<TModel>(TModel model) where TModel : class
        {
            this.Set<TModel>().Remove(model);
        }

        /// <inheritdoc />
        public void Insert<TModel>(TModel model) where TModel : class
        {
            this.Set<TModel>().Add(model);
        }

        /// <inheritdoc />
        public void Amend<TModel>(TModel model) where TModel : class
        {
            this.Set<TModel>().Update(model);
        }

        /// <inheritdoc />
        public void SetPropertyModified<TEntity>(TEntity entity, string propertyName, bool changed = true) where TEntity : class
        {
            this.Entry<TEntity>(entity)
                .Property(propertyName)
                .IsModified = true;
        }

        /// <inheritdoc />
        public void SetCollectionModified<TEntity>(TEntity entity, string collectionName, bool changed = true) where TEntity : class
        {
            this.Entry<TEntity>(entity)
                .Collection(collectionName)
                .IsModified = true;
        }

        /// <summary>
        /// Add entities configuration on model creating
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddManager();
            modelBuilder.AddAccountant();
            modelBuilder.AddDocument();
        }
    }
}