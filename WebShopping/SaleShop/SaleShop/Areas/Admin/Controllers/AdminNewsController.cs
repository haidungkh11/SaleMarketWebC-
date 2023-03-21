using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using SaleShop.Helpper;
using SaleShop.Models;

namespace SaleShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminNewsController : Controller
    {
        private readonly dbMarketsContext _context;

        public INotyfService _notyfService { get; }
        public AdminNewsController(dbMarketsContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;

        }

        // GET: Admin/AdminNews
        public IActionResult Index(int? page)
        {
            var collection = _context.News.AsNoTracking().ToList();
            
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 10;
            var lsTinDangs = _context.News
                .AsNoTracking()
                .OrderBy(x => x.PostId);
            PagedList<News> models = new PagedList<News>(lsTinDangs, pageNumber, pageSize);

            ViewBag.CurrentPage = pageNumber;
            return View(models);
        }

        // GET: Admin/AdminNews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.News == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .Include(n => n.Account)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // GET: Admin/AdminNews/Create
        public IActionResult Create()
        {
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountId");
            return View();
        }

        // POST: Admin/AdminNews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostId,Title,Scontents,Contents,Thumb,Published,Alias,CreatedDate,Author,AccountId,Tags,CatId,IsHot,IsNewfeed,MetaKey,MetaDesc,Views")] News news, Microsoft.AspNetCore.Http.IFormFile fThumb)
        {
            if (ModelState.IsValid)
            {
                if (fThumb != null)
                {
                    string extension = Path.GetExtension(fThumb.FileName);
                    string imageName = Utilities.SEOUrl(news.Title) + extension;
                    news.Thumb = await Utilities.UploadFile(fThumb, @"news", imageName.ToLower());
                }
                if (string.IsNullOrEmpty(news.Thumb)) news.Thumb = "default.jpg";
                news.Alias = Utilities.SEOUrl(news.Title);
                news.CreatedDate = DateTime.Now;


                _context.Add(news);
                await _context.SaveChangesAsync();
                _notyfService.Success("Thêm mới thành công");
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        // GET: Admin/AdminNews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.News == null)
            {
                return NotFound();
            }

            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountId", news.AccountId);
            return View(news);
        }

        // POST: Admin/AdminNews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostId,Title,Scontents,Contents,Thumb,Published,Alias,CreatedDate,Author,AccountId,Tags,CatId,IsHot,IsNewfeed,MetaKey,MetaDesc,Views")] News news, Microsoft.AspNetCore.Http.IFormFile fThumb)
        {
            if (id != news.PostId)
            {
                return NotFound();
            }
            try
            {
                news.Title = Utilities.ToTitleCase(news.Title);
                if (fThumb != null)
                {
                    string extension = Path.GetExtension(fThumb.FileName);
                    string imageName = Utilities.SEOUrl(news.Title) + extension;
                    news.Thumb = await Utilities.UploadFile(fThumb, @"news", imageName.ToLower());
                }
                if (string.IsNullOrEmpty(news.Thumb)) news.Thumb = "default.jpg";
                news.Alias = Utilities.SEOUrl(news.Title);
                news.CreatedDate = DateTime.Now;
                _context.Update(news);
                await _context.SaveChangesAsync();
                _notyfService.Success("Edit successful");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsExists(news.PostId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));


            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountId", news.AccountId);
            return View(news);
        }

        // GET: Admin/AdminNews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.News == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .Include(n => n.Account)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // POST: Admin/AdminNews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.News == null)
            {
                return Problem("Entity set 'dbMarketsContext.News'  is null.");
            }
            var news = await _context.News.FindAsync(id);
            if (news != null)
            {
                _context.News.Remove(news);
            }

            await _context.SaveChangesAsync();
            _notyfService.Success("Delete successful");
            return RedirectToAction(nameof(Index));
        }

        private bool NewsExists(int id)
        {
            return _context.News.Any(e => e.PostId == id);
        }
    }
}
