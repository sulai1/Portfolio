using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
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
                new ImageContent(){ Path="/images/test.jpg", Alt="image"}
            }
        };
        private readonly IHostingEnvironment _environment;

        public ContentBuilderController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View(builder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string json)
        {
            builder = SectionBuilder.Deserialize(json);
            return View(builder);
        }

        [HttpPost]
        public async Task<string> AddImage()
        {
            string bodyAsString;
            using (var streamReader = new StreamReader(Request.Body, Encoding.ASCII))
            {
                bodyAsString = await streamReader.ReadToEndAsync();
             
                
            }
            var info = Regex.Match(bodyAsString, @"\S*,").ToString();
            var format = Regex.Match(info, @"(?<=data:image/\w*;)(\w*)").ToString();
            if (format == "base64")
            {
                string type = Regex.Match(info.ToString(), @"(?<=data:image/)\w*").ToString().ToLower();
                var imgContent = bodyAsString.Substring(info.Length);
                byte[] data = Convert.FromBase64String(imgContent);
                MemoryStream ms1 = new MemoryStream(data);
                var name = Path.Combine("images", "usrimg", Regex.Match(info.ToString(), @"[\w*,\s,\.]+(?=;)").ToString() + "." + type);
                using (var imageFile = new FileStream(Path.Combine(_environment.WebRootPath, name), FileMode.Create))
                {
                    imageFile.Write(data, 0, data.Length);
                    imageFile.Flush();
                }
                return @"\"+name;
            }
            return "Error";

        }
    }
}