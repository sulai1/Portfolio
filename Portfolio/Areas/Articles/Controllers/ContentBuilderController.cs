using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Areas.Articles.Data;
using Portfolio.Areas.Articles.Models;

namespace Portfolio.Areas.Articles
{
    public class ContentBuilderController : Controller
    {
        [Area("Articles")]
        public IActionResult Index()
        {
            SectionBuilder builder = new SectionBuilder()
            {
                Title = "test",
                Content = new List<IContent>()
                {
                    new TextContent()
                    {
                        Text="test"
                    },
                    new ImageContent()
                    {
                        Path="/images/banner1.svg",
                        Alt="image of banner"
                    },
                    new CodeContent()
                    {
                        Text="<div>code</div>",
                        Type="html"
                    },
                    new ExampleContent()
                    {
                        Text="<div>code</div>",
                        Type="html"
                    }
                }
            };
            return View(builder);
        }
    }
}