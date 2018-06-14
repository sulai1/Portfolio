using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Cheat_Sheet.Areas.MVC6.Controllers
{
    [Area("MVC6")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}