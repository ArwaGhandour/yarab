using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers
{
    public class TransactionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
