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
    public class ExperienceLevelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExperienceLevelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExperienceLevels
        public async Task<IActionResult> Index()
        {
              return View(await _context.experienceLevels.ToListAsync());
        }

        // GET: ExperienceLevels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.experienceLevels == null)
            {
                return NotFound();
            }

            var experienceLevel = await _context.experienceLevels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (experienceLevel == null)
            {
                return NotFound();
            }

            return View(experienceLevel);
        }

        // GET: ExperienceLevels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExperienceLevels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Value")] ExperienceLevel experienceLevel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(experienceLevel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(experienceLevel);
        }

        // GET: ExperienceLevels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.experienceLevels == null)
            {
                return NotFound();
            }

            var experienceLevel = await _context.experienceLevels.FindAsync(id);
            if (experienceLevel == null)
            {
                return NotFound();
            }
            return View(experienceLevel);
        }

        // POST: ExperienceLevels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Value")] ExperienceLevel experienceLevel)
        {
            if (id != experienceLevel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(experienceLevel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExperienceLevelExists(experienceLevel.Id))
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
            return View(experienceLevel);
        }

        // GET: ExperienceLevels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.experienceLevels == null)
            {
                return NotFound();
            }

            var experienceLevel = await _context.experienceLevels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (experienceLevel == null)
            {
                return NotFound();
            }

            return View(experienceLevel);
        }

        // POST: ExperienceLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.experienceLevels == null)
            {
                return Problem("Entity set 'ApplicationDbContext.experienceLevels'  is null.");
            }
            var experienceLevel = await _context.experienceLevels.FindAsync(id);
            if (experienceLevel != null)
            {
                _context.experienceLevels.Remove(experienceLevel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExperienceLevelExists(int id)
        {
          return _context.experienceLevels.Any(e => e.Id == id);
        }
    }
}
