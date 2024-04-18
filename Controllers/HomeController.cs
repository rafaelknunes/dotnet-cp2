using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FIAP_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home/Index
        public IActionResult Index()
        {
            return View();
        }
        // GET: Home/Privacy
        public IActionResult Privacy()
        {
            return View();
        }

    }
}
