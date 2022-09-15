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
    public class WorkModesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkModesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WorkModes
        public async Task<IActionResult> Index()
        {
              return View(await _context.workModes.ToListAsync());
        }

        // GET: WorkModes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.workModes == null)
            {
                return NotFound();
            }

            var workMode = await _context.workModes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workMode == null)
            {
                return NotFound();
            }

            return View(workMode);
        }

        // GET: WorkModes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkModes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Value")] WorkMode workMode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workMode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workMode);
        }

        // GET: WorkModes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.workModes == null)
            {
                return NotFound();
            }

            var workMode = await _context.workModes.FindAsync(id);
            if (workMode == null)
            {
                return NotFound();
            }
            return View(workMode);
        }

        // POST: WorkModes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Value")] WorkMode workMode)
        {
            if (id != workMode.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workMode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkModeExists(workMode.Id))
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
            return View(workMode);
        }

        // GET: WorkModes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.workModes == null)
            {
                return NotFound();
            }

            var workMode = await _context.workModes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workMode == null)
            {
                return NotFound();
            }

            return View(workMode);
        }

        // POST: WorkModes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.workModes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.workModes'  is null.");
            }
            var workMode = await _context.workModes.FindAsync(id);
            if (workMode != null)
            {
                _context.workModes.Remove(workMode);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkModeExists(int id)
        {
          return _context.workModes.Any(e => e.Id == id);
        }
    }
}
