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
    public class RemunerationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RemunerationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Remunerations
        public async Task<IActionResult> Index()
        {
              return View(await _context.remuneration.ToListAsync());
        }

        // GET: Remunerations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.remuneration == null)
            {
                return NotFound();
            }

            var remuneration = await _context.remuneration
                .FirstOrDefaultAsync(m => m.Id == id);
            if (remuneration == null)
            {
                return NotFound();
            }

            return View(remuneration);
        }

        // GET: Remunerations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Remunerations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Value")] Remuneration remuneration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(remuneration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(remuneration);
        }

        // GET: Remunerations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.remuneration == null)
            {
                return NotFound();
            }

            var remuneration = await _context.remuneration.FindAsync(id);
            if (remuneration == null)
            {
                return NotFound();
            }
            return View(remuneration);
        }

        // POST: Remunerations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Value")] Remuneration remuneration)
        {
            if (id != remuneration.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(remuneration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RemunerationExists(remuneration.Id))
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
            return View(remuneration);
        }

        // GET: Remunerations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.remuneration == null)
            {
                return NotFound();
            }

            var remuneration = await _context.remuneration
                .FirstOrDefaultAsync(m => m.Id == id);
            if (remuneration == null)
            {
                return NotFound();
            }

            return View(remuneration);
        }

        // POST: Remunerations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.remuneration == null)
            {
                return Problem("Entity set 'ApplicationDbContext.remuneration'  is null.");
            }
            var remuneration = await _context.remuneration.FindAsync(id);
            if (remuneration != null)
            {
                _context.remuneration.Remove(remuneration);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RemunerationExists(int id)
        {
          return _context.remuneration.Any(e => e.Id == id);
        }
    }
}
