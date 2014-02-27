using System;
using System.Collections.Generic;
using System.Linq;
using RestApp.Core.Data;
using RestApp.Core.Domain.Banks;

namespace RestApp.Services.Banks
{
    public class BankService : IBankService
    {
        #region Fields

        private readonly IRepository<Bank> gBankRepository;

        #endregion

        #region Ctor

        public BankService(IRepository<Bank> bankRepository)
        {
            this.gBankRepository = bankRepository;
        }

        #endregion

        #region GETS
       
        public virtual Bank GetBankById(int bankId)
        {
            if (bankId == 0)
                return null;

            return gBankRepository.GetById(bankId);
        }
        
        public virtual Bank GetBankByName(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
                return null;

            var query = gBankRepository.Table;
            query = query.Where(st => st.Name == name);
            query = query.OrderByDescending(t => t.Id);

            var bank = query.FirstOrDefault();
            return bank;
        }
       
        public virtual Bank GetBankByCode(int code)
        {
            if (code == 0)
                return null;

            var query = gBankRepository.Table;
            query = query.Where(st => st.Code == code);
            query = query.OrderByDescending(t => t.Id);

            var bank = query.FirstOrDefault();
            return bank;
        }

        public virtual Bank GetBankByAccount(int account)
        {
            if (account == 0)
                return null;

            var query = gBankRepository.Table;
            query = query.Where(st => st.Code == account);
            query = query.OrderByDescending(t => t.Id);

            var bank = query.FirstOrDefault();
            return bank;
        }

        public virtual IList<Bank> GetAllBanks(bool showHidden = false)
        {
            var query = gBankRepository.Table;
            if (!showHidden)
            {
                query = query.Where(t => t.Enabled);
            }
            query = query.OrderByDescending(t => t.Id);

            var banks = query.ToList();
            return banks;
        }

        public IList<Bank> GetFilteredBanks(string q)
        {
            var query = gBankRepository.Table;

            if (q != null)
            {
                if (q.Length == 1)
                {
                    query = query.Where(st => st.Name.StartsWith(q));
                }
                else if (q.Length > 1)
                {
                    query = query.Where(st => st.Name.IndexOf(q) > -1);
                } 
            }

            return query.OrderBy(t => t.Name).ToList();
        }

        public bool IsNameAvailable(string name, int id)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new Exception("Invalid Name");

            var query = gBankRepository.Table
                        .Where(st => st.Name == name &&
                                     st.Id != id).FirstOrDefault();

            return query == null;
        }

        public bool IsCodeAvailable(int code, int id)
        {
            if (code == 0)
                throw new Exception("Invalid Code");

            var query = gBankRepository.Table
                        .Where(st => st.Code == code &&
                                     st.Id != id).FirstOrDefault();

            return query == null;
        }

        public bool IsAccountAvailable(string account, int id)
        {
            if (String.IsNullOrWhiteSpace(account))
                throw new Exception("Invalid Account");

            var query = gBankRepository.Table
                        .Where(st => st.Account == account &&
                                     st.Id != id).FirstOrDefault();

            return query == null;
        }

        #endregion

        #region Insert/Update/Delete

        public virtual void DeleteBank(Bank bank)
        {
            if (bank == null)
                throw new ArgumentNullException("bank");

            gBankRepository.Delete(bank);
        }  

        public virtual void InsertBank(Bank bank)
        {
            if (bank == null)
                throw new ArgumentNullException("bank");

            gBankRepository.Insert(bank);
        }

        public virtual void UpdateBank(Bank bank)
        {
            if (bank == null)
                throw new ArgumentNullException("bank");

            gBankRepository.Update(bank);
        }

        #endregion        
    }
}