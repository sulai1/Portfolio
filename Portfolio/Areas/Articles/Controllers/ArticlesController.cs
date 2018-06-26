using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio.Areas.Articles.Models;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Areas.Articles.Controllers
{
    [Area("Articles")]
    public class ArticlesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ArticlesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: Articles
        public async Task<IActionResult> Index()
        {

            var user = _userManager.Users.FirstOrDefault(x => x.Id == _userManager.GetUserId(User));
            await _context.Articles.Where(x => x.Owner == user).ToListAsync();
            return View(await _context.Articles.Where(x => x.Owner == user).ToListAsync());
        }

        public async Task<IActionResult> Preview(int id)
        {
            var article = await _context.ArticleWithSections(id);
            return View(article);
        }

        public IActionResult All()
        {
            var article = _context.Articles.Where(a=>a.IsPublic).AsEnumerable();
            return View(article);
        }

        public IActionResult Categories()
        {
            var categories = _context.Articles.Where(a => a.IsPublic).Select(a => a.Category).Distinct();
            return View(categories);
        }

        public IActionResult ByCategory(string category)
        {
            var byCategory = from article in _context.Articles where article.Category.Contains(category) select article;
            return View(byCategory);
        }


        // GET: Articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .FirstOrDefaultAsync(m => m.ArticleId == id);
            
            if (article == null)
            {
                return NotFound();
            }
            _context.Entry(article).Reference(a => a.Owner);

            return View(article);
        }

        // GET: Articles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArticleId,Title,Category,IsPublic")] Article article)
        {
            article.CreationDate = DateTime.Now;
            article.LastModified = DateTime.Now;
            article.Owner = _userManager.Users.FirstOrDefault(x => x.Id == _userManager.GetUserId(User));
            if (ModelState.IsValid)
            {
                _context.Add(article);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var article = await _context.Articles.FindAsync(id);
            _context.Entry(article).Collection(a => a.Sections).Load();
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArticleId,Title,Category,IsPublic,OwnerId")] Article article)
        {
            article.LastModified = DateTime.Now;
            if (id != article.ArticleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(article);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.ArticleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: Articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .FirstOrDefaultAsync(m => m.ArticleId == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.ArticleId == id);
        }
    }
}
