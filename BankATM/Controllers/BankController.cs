using BankATM.Models;
using BankATM.DataAccess.EF.Repository;
using Microsoft.AspNetCore.Mvc;
using BankATM.DataAccess.EF.Models;
using BankATM.DataAccess.EF.Context;
using System;
using System.Linq;

namespace BankATM.Controllers
{
    public class BankController : Controller
    {
        private readonly CustomersRepository _repo;

        public BankController(CustomersRepository repo, ApplicationDbContext context)
        {
            _repo = repo;

            _context = context;
        }

        public IActionResult Index()
        {
            CustomersViewModel account = new CustomersViewModel();

            account.CustomersList = _repo.GetAllCustomersInfos();

            account.CurrentCustomer = account.CustomersList.FirstOrDefault();

            return View(account);
        }

        private readonly ApplicationDbContext _context;

   
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if the user exists in the database
                var user = _context.Users.FirstOrDefault(u => u.Username == model.AccountNumber && u.Password == model.PinNumber);

                if (user != null)
                {
                    // User authentication successful
                    // You can set a session or cookie here to remember the user's session
                    return RedirectToAction("Dashboard"); // Redirect to the main app page
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login credentials.");
                }
            }
            return View(model);
        }

        public IActionResult CustomersDetails(int id)
        {
            var account = _repo.GetbyId(id);

            CustomersViewModel model = new CustomersViewModel();

            model.CurrentCustomer = account;
            return View(model);
        }

        [HttpGet]
        public IActionResult DepositView(int id)
        {
            CustomersViewModel myobjct = new CustomersViewModel();

            myobjct.CustomersList = _repo.GetAllCustomersInfos();
            myobjct.CurrentCustomer = myobjct.CustomersList.FirstOrDefault();

            return View(myobjct);
        }

        [HttpPost]
        public IActionResult DepositFunds(CustomersInfo model)
        {
            var currentAccount = _repo.GetbyId(model.CustomerId);
            decimal newBalance = 0.0m;

            if (currentAccount != null)
            {
                newBalance = currentAccount.Balance + model.DepositAmount;

                var newMoney = new CustomersInfo
                {
                    CustomerId = model.CustomerId,
                    Balance = model.Balance,
                    NewBalance = newBalance,
                    WithdrawAmount = model.WithdrawAmount,
                    AccountNumber = model.AccountNumber,
                    PinNumber = model.PinNumber,
                    DepositAmount = model.DepositAmount,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    TransactionDate = DateTime.Now,
                };

                var result = _repo.Update(newMoney);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult WithdrawView()
        {
            CustomersViewModel myobjct1 = new CustomersViewModel();

            myobjct1.CustomersList = _repo.GetAllCustomersInfos();
            myobjct1.CurrentCustomer = myobjct1.CustomersList.FirstOrDefault();

            return View(myobjct1);
        }

        [HttpPost]
        public IActionResult WithDrawnFunds(CustomersInfo model)
        {
            var currentAccount = _repo.GetbyId(model.CustomerId);
            decimal newBalance = 0.0m;

            if (currentAccount != null)
            {
                newBalance = currentAccount.Balance - model.WithdrawAmount;

                var newMoney = new CustomersInfo
                {
                    CustomerId = model.CustomerId,
                    Balance = model.Balance,
                    NewBalance = newBalance,
                    WithdrawAmount = model.WithdrawAmount,
                    AccountNumber = model.AccountNumber,
                    PinNumber = model.PinNumber,
                    DepositAmount = model.DepositAmount,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    TransactionDate = DateTime.Now,
                };

                var result = _repo.Update(newMoney);
            }
            return RedirectToAction("Index");
        }
    }
}
