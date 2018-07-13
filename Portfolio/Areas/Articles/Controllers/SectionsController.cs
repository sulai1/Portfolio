using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio.Areas.Articles.Data;
using Portfolio.Areas.Articles.Models;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Areas.Articles.Controllers
{
    [Area("Articles")]
    public class SectionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IHostingEnvironment _environment;


        public SectionsController(ApplicationDbContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        // GET: Sections
        public async Task<IActionResult> Index(int id)
        {
            var article = await _context.ArticleWithSections(id);
            return View(article);
        }

        public IActionResult View(int? id)
        {
            SectionBuilder builder;
            if (id != null)
            {
                var section = _context.Section.Find(id);
                if (section.Content != null)
                {
                    builder = SectionBuilder.Deserialize(section.Content);
                }
                else
                {
                    builder = new SectionBuilder();
                }
                builder.Id = section.SectionId;
                builder.Title = section.Title;
            }
            else
            {
                builder = new SectionBuilder();
            }
            return View(builder);
        }

        public IActionResult Edit(int? id)
        {
            SectionBuilder builder;
            if (id != null)
            {
                var section = _context.Section.Find(id);
                if (section.Content != null)
                {
                    builder = SectionBuilder.Deserialize(section.Content);
                }
                else
                {
                    builder = new SectionBuilder();
                }
                builder.Id = section.SectionId;
                builder.Title = section.Title;
            }
            else
            {
                builder = new SectionBuilder();
            }
            return View(builder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string json)
        {
            SectionBuilder builder= Data.SectionBuilder.Deserialize(json);
            var section = _context.Section.Find(builder.Id);
            section.Title = builder.Title;
            section.Content = json;
            //ToDo Validate json
            await _context.SaveChangesAsync();
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
                return @"\" + name;
            }
            return "Error";

        }
       

        // GET: Sections/Create
        public IActionResult Create(int? id)
        {
            return View();
        }

        // POST: Sections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, [Bind("SectionId,Title,Content,Example")] Section section)
        {
            var article = await _context.Articles.FindAsync(id);
            await _context.Entry(article).Collection(x => x.Sections).LoadAsync();

            section.Index = article.Sections.Count == 0 ? 0 : article.Sections.ToList().Max(x => x.Index) + 1;
            section.ArticleId = id;
            if (ModelState.IsValid)
            {
                _context.Add(section);
                await _context.SaveChangesAsync();
                //TODO type check
                return RedirectToAction(nameof(Index), new { id });
            }
            return View(section);
        }


        // GET: Sections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var section = await _context.Section
                .FirstOrDefaultAsync(m => m.SectionId == id);
            if (section == null)
            {
                return NotFound();
            }

            return View(section);
        }

        // POST: Sections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var section = await _context.Section.FindAsync(id);
            _context.Section.Remove(section);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = section.ArticleId });
        }

        private bool SectionExists(int id)
        {
            return _context.Section.Any(e => e.SectionId == id);
        }
    }
}
