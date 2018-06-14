using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Cheat_Sheet.Controllers
{
    public class CheatSheetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}