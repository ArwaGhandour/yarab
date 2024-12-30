using Bank.Models.Entities;
using Bank.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bank.Models.ViewModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.Intrinsics.X86;

namespace Bank.Controllers
{
    public class AccountsController : Controller
    {
        private readonly AppDBContext _appdb;
        public AccountsController(AppDBContext appdb)
        {
            _appdb = appdb;
        }
        public async Task<IActionResult> GetAllAccounts()
        {
            var all = await _appdb.accounts.Include(x=>x.customer).ToListAsync();
            return View(all);
        }
        [HttpGet]
        public async Task<IActionResult> Create(Accounts acc)
        {
            var cus = await _appdb.Customers.ToListAsync();
            Accountviewmodel avm = new Accountviewmodel
            {
                customers = cus,
                AccBalance = acc.Balance,
                CustomerIDDD=acc.CustomerIDD,
                AccountNumber=acc.AccountNumber,
                AccountType=acc.AccountType,
            };
            return View(avm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Accountviewmodel avm)
        {
            Accounts acc = new Accounts()
            {
                Balance=avm.AccBalance,
                CustomerIDD=avm.CustomerIDDD,
                AccountNumber =avm.AccountNumber,
                AccountType=avm.AccountType,

            };
            await _appdb.accounts.AddAsync(acc);
            await _appdb.SaveChangesAsync();
            return RedirectToAction("GetAllAccounts");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            

            var upd = await _appdb.accounts.FirstOrDefaultAsync(x => x.AccountsID == id);
            var cust = await _appdb.Customers.ToListAsync();
            Accountviewmodel acc = new Accountviewmodel()
            {
              CustomerIDDD=upd.CustomerIDD,
               AccBalance=upd.Balance,
               customers=cust,
                AccountNumber = upd.AccountNumber,
                AccountType = upd.AccountType,

            };
            return View(acc);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Accountviewmodel avm,int id)
        {
            var upd = await _appdb.accounts.FirstOrDefaultAsync(x => x.AccountsID == id);
            upd.CustomerIDD = avm.CustomerIDDD;
            upd.AccountNumber = avm.AccountNumber;
            upd.AccountType = avm.AccountType;
            upd.Balance = avm.AccBalance;
            _appdb.accounts.Update(upd);
            await _appdb.SaveChangesAsync();
            return RedirectToAction("GetAllAccounts");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var upd = await _appdb.accounts.FirstOrDefaultAsync(x => x.AccountsID == id);
            return View(upd);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Accounts acc)
        {
            _appdb.accounts.Remove(acc);
            await _appdb.SaveChangesAsync();
            return RedirectToAction("GetAllAccounts");
        }
        public async Task<IActionResult> Details(int id)
        {
            var upd = await _appdb.accounts.Include(x=>x.customer).FirstOrDefaultAsync(x => x.AccountsID == id);
            return View(upd);
        }
    }
}
