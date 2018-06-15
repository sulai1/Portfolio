using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Cheat_Sheet.Areas.HTML.Controllers
{
    [Area("HTML")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Bootstrap()
        {
            return View();
        }

        public IActionResult Less()
        {
            return View();
        }
    }
}