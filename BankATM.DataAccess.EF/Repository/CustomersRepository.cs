using BankATM.DataAccess.EF.Context;
using BankATM.DataAccess.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankATM.DataAccess.EF.Repository
{
    public class CustomersRepository
    {
        private readonly BankdataContext _context;

        public CustomersRepository(BankdataContext context)
        {
            _context = context;
        }

        public CustomersRepository()
        {
        }

        public CustomersInfo Create(CustomersInfo model)
        {
            // Ensure the entity is valid before saving it
            if (model != null)
            {
                _context.CustomersInfos.Add(model);
                _context.SaveChanges();
            }

            return model;
        }

        public CustomersInfo Update(int customerId, CustomersInfo model)
        {
            CustomersInfo modeltoUpdate = _context.CustomersInfos.Find(customerId);

            if (modeltoUpdate != null)
            {
                modeltoUpdate.AccountNumber = model.AccountNumber;
                modeltoUpdate.PinNumber = model.PinNumber;
                modeltoUpdate.FirstName = model.FirstName;
                modeltoUpdate.LastName = model.LastName;
                modeltoUpdate.Balance = model.Balance;
                modeltoUpdate.DepositAmount = model.DepositAmount;
                modeltoUpdate.NewBalance = model.NewBalance;
                modeltoUpdate.WithdrawAmount = model.WithdrawAmount;
                modeltoUpdate.TransactionDate = model.TransactionDate;

                _context.SaveChanges();
            }

            return modeltoUpdate;
        }

        public bool Delete(int customerId)
        {
            CustomersInfo modelToDelete = _context.CustomersInfos.Find(customerId);

            if (modelToDelete != null)
            {
                _context.CustomersInfos.Remove(modelToDelete);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
        public bool FindUser(CustomersInfo myuser) 
        {
            var user = _context.CustomersInfos.FirstOrDefault(u => u.AccountNumber  == myuser.AccountNumber && u.PinNumber == myuser.PinNumber);
            
            if (user == null) 
            {
                return false;
            
            }
            return true;
        }

        public List<CustomersInfo> GetAllCustomersInfos()
        {
            return _context.CustomersInfos.ToList();
        }

        public CustomersInfo GetbyId(int customerId)
        {
            return _context.CustomersInfos.Find(customerId);
        }

        public object Update(CustomersInfo newMoney)
        {
            throw new NotImplementedException();
        }
    }
}

