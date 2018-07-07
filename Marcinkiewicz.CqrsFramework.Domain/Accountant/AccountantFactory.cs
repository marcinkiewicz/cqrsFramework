using Marcinkiewicz.CqrsFramework.Domain.Accountant.Commands;
using Marcinkiewicz.CqrsFramework.Domain.Common;
using Marcinkiewicz.CqrsFramework.Security.Services;
using System;

namespace Marcinkiewicz.CqrsFramework.Domain.Accountant
{
    /// <summary>
    /// Accountant data model factory
    /// </summary>
    internal class AccountantFactory : IDataModelFactory
    {
        private readonly IPasswordService passwordService;

        /// <summary>
        /// Initialize new instance of <see cref="AccountantFactory"/>
        /// </summary>
        /// <param name="passwordService">Password operations service</param>
        public AccountantFactory(IPasswordService passwordService)
        {
            this.passwordService = passwordService;
        }

        /// <summary>
        /// Create new <see cref="Data.Models.Accountant"/> based on <see cref="AddAccountantCommand"/>
        /// </summary>
        /// <param name="command">Accountant details</param>
        /// <returns>Data model</returns>
        internal Data.Models.Accountant Create(AddAccountantCommand command)
        {
            return new Data.Models.Accountant
            {
                Id = command.Id,
                PasswordHash = passwordService.GenerateHash(command.Password),
                Email = command.Email,

                FirstName = command.FirstName,
                LastName = command.LastName,
                UserName = command.Email,

                IsActive = true,
                IsConfirmed = false,
                IsRemoved = false,

                CreateDate = DateTime.UtcNow,
                LastModificationDate = DateTime.UtcNow
            };
        }

        /// <summary>
        /// Create new <see cref="Data.Models.Accountant"/> based on <see cref="UpdateAccountantCommand"/>
        /// </summary>
        /// <param name="command">Accountant details</param>
        /// <returns>Data model</returns>
        internal Data.Models.Accountant Create(UpdateAccountantCommand command)
        {
            return new Data.Models.Accountant
            {
                Id = command.Id,
                FirstName = command.FirstName,
                LastName = command.LastName,
                LastModificationDate = DateTime.UtcNow
            };
        }

        /// <summary>
        /// Create new <see cref="Data.Models.Accountant"/> based on <see cref="DeleteAccountantCommand"/>
        /// </summary>
        /// <param name="command">Accountant details</param>
        /// <returns>Data model</returns>
        internal Data.Models.Accountant Create(DeleteAccountantCommand command)
        {
            return new Data.Models.Accountant
            {
                Id = command.Id,
                IsRemoved = true,
                LastModificationDate = DateTime.UtcNow
            };
        }
    }
}
