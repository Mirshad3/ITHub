using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ITHub.Data;
using ITHub.Models;

namespace ITHub.Controllers
{
    public class BannersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BannersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Banners
        public async Task<IActionResult> Index()
        {
              return View(await _context.banners.ToListAsync());
        }

        // GET: Banners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.banners == null)
            {
                return NotFound();
            }

            var banners = await _context.banners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (banners == null)
            {
                return NotFound();
            }

            return View(banners);
        }

        // GET: Banners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Banners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Link,ImagePath,Status,CreatedDate,UserId")] Banners banners)
        {
            if (ModelState.IsValid)
            {
                _context.Add(banners);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(banners);
        }

        // GET: Banners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.banners == null)
            {
                return NotFound();
            }

            var banners = await _context.banners.FindAsync(id);
            if (banners == null)
            {
                return NotFound();
            }
            return View(banners);
        }

        // POST: Banners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Link,ImagePath,Status,CreatedDate,UserId")] Banners banners)
        {
            if (id != banners.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(banners);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BannersExists(banners.Id))
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
            return View(banners);
        }

        // GET: Banners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.banners == null)
            {
                return NotFound();
            }

            var banners = await _context.banners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (banners == null)
            {
                return NotFound();
            }

            return View(banners);
        }

        // POST: Banners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.banners == null)
            {
                return Problem("Entity set 'ApplicationDbContext.banners'  is null.");
            }
            var banners = await _context.banners.FindAsync(id);
            if (banners != null)
            {
                _context.banners.Remove(banners);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BannersExists(int id)
        {
          return _context.banners.Any(e => e.Id == id);
        }
    }
}
