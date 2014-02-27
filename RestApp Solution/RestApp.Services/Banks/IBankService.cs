using System.Collections.Generic;
using RestApp.Core.Domain.Banks;

namespace RestApp.Services.Banks
{
    /// <summary>
    /// Bank service interface
    /// </summary>
    public partial interface IBankService
    {
        #region GETS

        /// <summary>
        /// Gets a Bank
        /// </summary>
        /// <param name="bankId">Bank identifier</param>
        /// <returns>Bank</returns>
        Bank GetBankById(int bankId);

        /// <summary>
        /// Gets a Bank by name
        /// </summary>
        /// <param name="name">Bank Name</param>
        /// <returns>Bank</returns>
        Bank GetBankByName(string name);

        /// <summary>
        /// Gets a Bank by Code
        /// </summary>
        /// <param name="type">Bank Code</param>
        /// <returns>Bank</returns>
        Bank GetBankByCode(int code);

        /// <summary>
        /// Gets a Bank by Account
        /// </summary>
        /// <param name="type">Bank Account</param>
        /// <returns>Bank</returns>
        Bank GetBankByAccount(int account);

        /// <summary>
        /// Gets all Banks
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Bank</returns>
        IList<Bank> GetAllBanks(bool showHidden = false);

        /// <summary>
        /// Get banks filtered
        /// </summary>
        /// <param name="bank">query</param>
        /// <returns>IList<Bank></returns>
        IList<Bank> GetFilteredBanks(string q);

        /// <summary>
        /// Avaible Name
        /// </summary>
        /// <param name="name, id">Bank Name and Id</param>
        /// <returns>bool</returns>
        bool IsNameAvailable(string name, int id);

        /// <summary>
        /// Avaible Code
        /// </summary>
        /// <param name="name, id">Bank Code and Id</param>
        /// <returns>bool</returns>
        bool IsCodeAvailable(int code, int id);

        /// <summary>
        /// Avaible Account
        /// </summary>
        /// <param name="account, id">Bank Account and Id</param>
        /// <returns>bool</returns>
        bool IsAccountAvailable(string account, int id);

        #endregion

        #region Insert/Update/Delete

        /// <summary>
        /// Deletes a Bank
        /// </summary>
        /// <param name="bank">Bank</param>
        void DeleteBank(Bank bank);

        /// <summary>
        /// Inserts a Bank
        /// </summary>
        /// <param name="bank">Bank</param>
        void InsertBank(Bank bank);

        /// <summary>
        /// Updates the Bank
        /// </summary>
        /// <param name="bank">Bank</param>
        void UpdateBank(Bank bank);

        #endregion
    }
}
