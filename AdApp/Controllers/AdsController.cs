using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdData;
using AdData.Models;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace AdApp.Controllers
{
    public class AdsController : Controller
    {
        private readonly AdContext _context;

        public AdsController(AdContext context)
        {
            _context = context;
        }

        // GET: Ads
        public async Task<IActionResult> Index(string searchString, string sortOrder, string filterText, string searchCategory)
        {
            ViewData["Categories"] = new SelectList(_context.Categories, "CategoryName", "CategoryName");

            

            ViewBag.TitleSortParam = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.DateSortParam = sortOrder == "date_asc" ? "date_desc" : "date_asc";
            ViewBag.FilterButton = String.IsNullOrEmpty(filterText) ? "ABC" : "";

            ViewData["Ads"] = _context.Ads;

            ViewData["CurrentUser"] = CurrentUser.User;

            IEnumerable<Ad> ads = null;
            if (!String.IsNullOrEmpty(searchString))
            {
                ads = await (_context.Ads.Include(e => e.Category).Include(e => e.User).Where(e => (e.Title.Contains(searchString) || e.Description.Contains(searchString)) && e.ExpirationDate > DateTime.Now)).ToListAsync();  
            }
            else
            {
                ads = await (_context.Ads.Include(e => e.Category).Include(e => e.User).Where(e => e.ExpirationDate > DateTime.Now)).ToListAsync();
            }

            if (!String.IsNullOrEmpty(searchCategory))
            {
                ads = ads.Where(e => e.Category.CategoryName.Equals(searchCategory));
            }


            switch (sortOrder)
            {
                case "title_desc":
                    ads = ads.OrderByDescending(e => e.Title);
                    break;
                case "date_asc":
                    ads = ads.OrderBy(e => e.AddDate);
                    break;
                case "date_desc":
                    ads = ads.OrderByDescending(e => e.AddDate);
                    break;
                default:
                    ads = ads.OrderBy(e => e.Title);
                    break;
            }
            return View(ads);
        }

        // GET: Ads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
           
            ViewData["Comments"] = new SelectList(_context.Comments);
            if (id == null)
            {
                return NotFound();
            }

            var ad = await _context.Ads
                .Include(e => e.Category)
                .Include(e => e.User)
                .Include(e => e.Comments)
                .ThenInclude(comment => comment.User)
                .FirstOrDefaultAsync(e => e.Id == id);
            if (ad == null)
            {
                return NotFound();
            }

            return View(ad);
        }

        // GET: Ads/Create
        public IActionResult Create()
        {
            if (CurrentUser.User == null)
            {
                return RedirectToAction(nameof(Index), "Home");
            }

            ViewData["Categories"] = new SelectList(_context.Categories, "Id", "CategoryName");
            //ViewData["Users"] = new SelectList(_context.Users, "Id", "Username");
            return View();
        }

        // POST: Ads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,AddDate,ExpirationDate,UserIdVal,CategoryIdVal")] Ad ad, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                using(var stream = new MemoryStream())
                {

                    await image.CopyToAsync(stream);
                    ad.Image = stream.ToArray();
                }

                ad.AddDate = DateTime.Now;
                ad.ExpirationDate = ad.AddDate.AddDays(7);
                //ad.User = _context.Users.FirstOrDefault(e => e.Id == ad.UserIdVal);
                if (CurrentUser.User != null)
                {
                    ad.User = _context.Users.FirstOrDefault(e => e.Username == CurrentUser.User.Username);
                }
                ad.Category = _context.Categories.FirstOrDefault(e => e.Id == ad.CategoryIdVal);
                _context.Add(ad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Categories"] = new SelectList(_context.Categories, "Id", "Id", ad.CategoryIdVal);
            //ViewData["Users"] = new SelectList(_context.Users, "Id", "Id", ad.UserIdVal);
            return View(ad);
        }

        // GET: Ads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (CurrentUser.User == null)
            {
                return RedirectToAction(nameof(Index), "Home");
            }

            if (id == null)
            {
                return NotFound();
            }

            var ad = await _context.Ads.FindAsync(id);
            if (ad == null)
            {
                return NotFound();
            }
            return View(ad);
        }

        // POST: Ads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,AddDate,ExpirationDate")] Ad ad)
        {
            if (id != ad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdExists(ad.Id))
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
            return View(ad);
        }

        // GET: Ads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["Categories"] = new SelectList(_context.Categories, "CategoryName", "CategoryName");

            if (CurrentUser.User == null)
            {
                return RedirectToAction(nameof(Index), "Home");
            }

            if (id == null)
            {
                return NotFound();
            }

            var ad = await _context.Ads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ad == null)
            {
                return NotFound();
            }

            return View(ad);
        }

        // POST: Ads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ad = await _context.Ads.FindAsync(id);
            _context.Ads.Remove(ad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdExists(int id)
        {
            return _context.Ads.Any(e => e.Id == id);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment([Bind("Id", "CommentValue")] Ad ad)
        {
            if (!String.IsNullOrEmpty(ad.CommentValue))
            {
                Comment comment = new Comment();

                comment.AddedComment = ad.CommentValue;
                comment.Ad = _context.Ads.FirstOrDefault(e => e.Id == ad.Id);
                comment.User = _context.Users.FirstOrDefault(e => e.Username == CurrentUser.User.Username);
                //comment.User = CurrentUser.User;
                _context.Comments.Add(comment);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Details), "Ads", ad);
        }

        public IActionResult Logout()
        {
            CurrentUser.User = null;
            return RedirectToAction(nameof(Index), "Home");
        }

    }
}
