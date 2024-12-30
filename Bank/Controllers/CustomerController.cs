using Bank.Models;
using Bank.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bank.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDBContext _appdb;
        public CustomerController(AppDBContext appdb)
        {
            _appdb = appdb;
        }
        public async Task<IActionResult> GetAllCustomers()
        {
            var all = await _appdb.Customers.ToListAsync();
            return View(all);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Customer cust)
        {
            await _appdb.Customers.AddAsync(cust);
            await _appdb.SaveChangesAsync();
           return RedirectToAction("GetAllCustomers");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var upd = await _appdb.Customers.FirstOrDefaultAsync(x => x.CustomerID == id);
            return View( upd);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Customer cust)
        {
             _appdb.Customers.Update(cust);
            await _appdb.SaveChangesAsync();
            return RedirectToAction("GetAllCustomers");
        }
        [HttpGet]
        public async Task<IActionResult>Delete(int id)
        {
            var upd = await _appdb.Customers.FirstOrDefaultAsync(x => x.CustomerID == id);
            return View(upd);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Customer cust)
        {
            _appdb.Customers.Remove(cust);
            await _appdb.SaveChangesAsync();
            return RedirectToAction("GetAllCustomers");
        }
        public async Task <IActionResult>Details(int id)
        {
            var upd = await _appdb.Customers.FirstOrDefaultAsync(x => x.CustomerID == id);
            return View(upd);
        }
    }
}
