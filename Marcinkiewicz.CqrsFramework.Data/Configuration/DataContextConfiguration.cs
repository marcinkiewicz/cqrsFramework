using Marcinkiewicz.CqrsFramework.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Marcinkiewicz.CqrsFramework.Data.Configuration
{
    /// <summary>
    /// Configuration class for database mapping and relations
    /// </summary>
    internal static class DataContextConfiguration
    {
        /// <summary>
        /// Add <see cref="Accountant"/> configuration to the model builder
        /// </summary>
        /// <param name="model">Model builder</param>
        internal static void AddAccountant(this ModelBuilder model)
        {
            var accountantEntity = model.Entity<Accountant>();

            // Id
            accountantEntity
                .Property(mdl => mdl.Id)
                .ValueGeneratedNever()
                .IsRequired(true);

            // UserName
            accountantEntity
                .Property(mdl => mdl.UserName)
                .HasMaxLength(255);

            // Email
            accountantEntity
                .Property(mdl => mdl.Email)
                .IsRequired(true)
                .HasMaxLength(255);

            // PasswordHash
            accountantEntity
                .Property(mdl => mdl.PasswordHash);

            // IsActive
            accountantEntity
                .Property(mdl => mdl.IsActive)
                .HasDefaultValue(true)
                .IsRequired(true);

            // IsRemoved
            accountantEntity
                .Property(mdl => mdl.IsRemoved)
                .HasDefaultValue(false)
                .IsRequired(true);

            // IsConfirmed
            accountantEntity
                .Property(mdl => mdl.IsConfirmed)
                .HasDefaultValue(false)
                .IsRequired(true);

            // LastModificationDate
            accountantEntity
               .Property(mdl => mdl.LastModificationDate)
               .HasDefaultValueSql("getutcdate()")
               .IsRequired(true);

            // CreateDate
            accountantEntity
                .Property(mdl => mdl.CreateDate)
                .HasDefaultValueSql("getutcdate()")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

            // FirstName
            accountantEntity
                .Property(mdl => mdl.FirstName)
                .IsRequired(true);

            // LastName
            accountantEntity
                .Property(mdl => mdl.LastName)
                .IsRequired(true);

            // PK
            accountantEntity
                .HasKey(mdl => mdl.Id);

            // Assign to table
            accountantEntity
                .ToTable(nameof(Accountant));
        }

        /// <summary>
        /// Add <see cref="Manager"/> configuration to the model builder
        /// </summary>
        /// <param name="model">Model builder</param>
        internal static void AddManager(this ModelBuilder model)
        {
            var managerEntity = model.Entity<Manager>();

            // Id
            managerEntity
                .Property(mdl => mdl.Id)
                .ValueGeneratedNever()
                .IsRequired(true);

            // UserName
            managerEntity
                .Property(mdl => mdl.UserName)
                .HasMaxLength(255);

            // Email
            managerEntity
                .Property(mdl => mdl.Email)
                .IsRequired(true)
                .HasMaxLength(255);

            // PasswordHash
            managerEntity
                .Property(mdl => mdl.PasswordHash);

            // IsActive
            managerEntity
                .Property(mdl => mdl.IsActive)
                .HasDefaultValue(true)
                .IsRequired(true);

            // IsRemoved
            managerEntity
                .Property(mdl => mdl.IsRemoved)
                .HasDefaultValue(false)
                .IsRequired(true);

            // IsConfirmed
            managerEntity
                .Property(mdl => mdl.IsConfirmed)
                .HasDefaultValue(false)
                .IsRequired(true);

            // LastModificationDate
            managerEntity
               .Property(mdl => mdl.LastModificationDate)
               .HasDefaultValueSql("getutcdate()")
               .IsRequired(true);

            // CreateDate
            managerEntity
                .Property(mdl => mdl.CreateDate)
                .HasDefaultValueSql("getutcdate()")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

            // CorporateNumber
            managerEntity
                .Property(mdl => mdl.CorporateNumber)
                .IsRequired(true);
            
            // PK
            managerEntity
                .HasKey(mdl => mdl.Id);

            // Assign to table
            managerEntity
                .ToTable(nameof(Manager));
        }

        /// <summary>
        /// Add <see cref="Document"/> configuration to the model builder
        /// </summary>
        /// <param name="model">Model builder</param>
        internal static void AddDocument(this ModelBuilder model)
        {
            var documentEntity = model.Entity<Document>();

            // Id
            documentEntity
                .Property(mdl => mdl.Id)
                .ValueGeneratedNever()
                .IsRequired(true);

            // Status
            documentEntity
                .Property(mdl => mdl.Status)
                .IsRequired(true);

            // LastModificationDate
            documentEntity
               .Property(mdl => mdl.LastModificationDate)
               .HasDefaultValueSql("getutcdate()")
               .IsRequired(true);

            // CreateDate
            documentEntity
                .Property(mdl => mdl.CreateDate)
                .HasDefaultValueSql("getutcdate()")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

            // ProcessedDateTime
            documentEntity
                .Property(mdl => mdl.ProcessedDateTime)
                .IsRequired(false);

            // CreatedBy : Accountant
            documentEntity
                .HasOne(mdl => mdl.CreatedBy)
                .WithMany(mdl => mdl.DocumentsList)
                .HasForeignKey(mdl => mdl.CreatedById);

            // ProcessedBy : Manager
            documentEntity
                .HasOne(mdl => mdl.ProcessedBy)
                .WithMany(mdl => mdl.ProcessedDocumentsList)
                .HasForeignKey(mdl => mdl.ProcessedById);

            // PK
            documentEntity
                .HasKey(mdl => mdl.Id);

            // Assign to table
            documentEntity
                .ToTable(nameof(Manager));
        }
    }
}
