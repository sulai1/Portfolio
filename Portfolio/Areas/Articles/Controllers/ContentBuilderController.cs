using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Areas.Articles.Data;
using Portfolio.Areas.Articles.Models;

namespace Portfolio.Areas.Articles
{

    [Area("Articles")]
    public class ContentBuilderController : Controller
    {

        SectionBuilder builder = new SectionBuilder()
        {
            Title = "test",
            Content = new List<IContent>() {
                new TextContent() { Text="text content 1"},
                new TextContent() { Text="text content 2"}
            }
        };
        public IActionResult Index()
        {
            return View(builder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string type, [Bind("Title")] SectionBuilder builder)
        {
            return View(builder);
        }
    }
}