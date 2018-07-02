using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdData;
using AdData.Models;

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
        public async Task<IActionResult> Index(string searchString)
        {
            List<Ad> ads = null;
            if (!String.IsNullOrEmpty(searchString))
            {
                ads =  await (_context.Ads.Include(e => e.Category).Include(e => e.User).Where(e => e.Title.Contains(searchString))).ToListAsync();
            }
            else
            {
                ads = await (_context.Ads.Include(e => e.Category).Include(e => e.User)).ToListAsync();
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
            ViewData["Categories"] = new SelectList(_context.Categories, "Id", "Id");
            ViewData["Users"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Ads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,AddDate,ExpirationDate,UserIdVal,CategoryIdVal")] Ad ad)
        {
            if (ModelState.IsValid)
            {
                ad.AddDate = DateTime.Now;
                ad.ExpirationDate = ad.AddDate.AddDays(7);
                ad.User = _context.Users.FirstOrDefault(e => e.Id == ad.UserIdVal);
                ad.Category = _context.Categories.FirstOrDefault(e => e.Id == ad.CategoryIdVal);
                _context.Add(ad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Categories"] = new SelectList(_context.Categories, "Id", "Id", ad.CategoryIdVal);
            ViewData["Users"] = new SelectList(_context.Users, "Id", "Id", ad.UserIdVal);
            return View(ad);
        }

        // GET: Ads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
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
        public async Task<IActionResult> AddComment([Bind("Id", "AddedComment", "Ad", "User")] Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
