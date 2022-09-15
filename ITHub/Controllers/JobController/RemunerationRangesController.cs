using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ITHub.Data;
using ITHub.Models;

namespace ITHub.Controllers.JobController
{
    public class RemunerationRangesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RemunerationRangesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RemunerationRanges
        public async Task<IActionResult> Index()
        {
              return View(await _context.remunerationRanges.ToListAsync());
        }

        // GET: RemunerationRanges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.remunerationRanges == null)
            {
                return NotFound();
            }

            var remunerationRange = await _context.remunerationRanges
                .FirstOrDefaultAsync(m => m.Id == id);
            if (remunerationRange == null)
            {
                return NotFound();
            }

            return View(remunerationRange);
        }

        // GET: RemunerationRanges/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RemunerationRanges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Value")] RemunerationRange remunerationRange)
        {
            if (ModelState.IsValid)
            {
                _context.Add(remunerationRange);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(remunerationRange);
        }

        // GET: RemunerationRanges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.remunerationRanges == null)
            {
                return NotFound();
            }

            var remunerationRange = await _context.remunerationRanges.FindAsync(id);
            if (remunerationRange == null)
            {
                return NotFound();
            }
            return View(remunerationRange);
        }

        // POST: RemunerationRanges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Value")] RemunerationRange remunerationRange)
        {
            if (id != remunerationRange.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(remunerationRange);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RemunerationRangeExists(remunerationRange.Id))
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
            return View(remunerationRange);
        }

        // GET: RemunerationRanges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.remunerationRanges == null)
            {
                return NotFound();
            }

            var remunerationRange = await _context.remunerationRanges
                .FirstOrDefaultAsync(m => m.Id == id);
            if (remunerationRange == null)
            {
                return NotFound();
            }

            return View(remunerationRange);
        }

        // POST: RemunerationRanges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.remunerationRanges == null)
            {
                return Problem("Entity set 'ApplicationDbContext.remunerationRanges'  is null.");
            }
            var remunerationRange = await _context.remunerationRanges.FindAsync(id);
            if (remunerationRange != null)
            {
                _context.remunerationRanges.Remove(remunerationRange);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RemunerationRangeExists(int id)
        {
          return _context.remunerationRanges.Any(e => e.Id == id);
        }
    }
}
