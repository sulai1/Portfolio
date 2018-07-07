﻿using System;
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
                new TextContent() { Text="text content 2"},
                new CodeContent() { Text="<p>code content</p>", Type="html"},
                new ExampleContent(){ Text="<p>Example content</p>", Type="html"},
                new ImageContent(){ Path="file://D:/Pictures/Texturen/bee.jpg", Alt="image"}
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