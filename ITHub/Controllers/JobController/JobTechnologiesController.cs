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
    public class JobTechnologiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobTechnologiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: JobTechnologies
        public async Task<IActionResult> Index()
        {
              return View(await _context.jobTechnologies.ToListAsync());
        }

        // GET: JobTechnologies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.jobTechnologies == null)
            {
                return NotFound();
            }

            var jobTechnologies = await _context.jobTechnologies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobTechnologies == null)
            {
                return NotFound();
            }

            return View(jobTechnologies);
        }

        // GET: JobTechnologies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobTechnologies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Value")] JobTechnologies jobTechnologies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobTechnologies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobTechnologies);
        }

        // GET: JobTechnologies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.jobTechnologies == null)
            {
                return NotFound();
            }

            var jobTechnologies = await _context.jobTechnologies.FindAsync(id);
            if (jobTechnologies == null)
            {
                return NotFound();
            }
            return View(jobTechnologies);
        }

        // POST: JobTechnologies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Value")] JobTechnologies jobTechnologies)
        {
            if (id != jobTechnologies.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobTechnologies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobTechnologiesExists(jobTechnologies.Id))
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
            return View(jobTechnologies);
        }

        // GET: JobTechnologies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.jobTechnologies == null)
            {
                return NotFound();
            }

            var jobTechnologies = await _context.jobTechnologies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobTechnologies == null)
            {
                return NotFound();
            }

            return View(jobTechnologies);
        }

        // POST: JobTechnologies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.jobTechnologies == null)
            {
                return Problem("Entity set 'ApplicationDbContext.jobTechnologies'  is null.");
            }
            var jobTechnologies = await _context.jobTechnologies.FindAsync(id);
            if (jobTechnologies != null)
            {
                _context.jobTechnologies.Remove(jobTechnologies);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobTechnologiesExists(int id)
        {
          return _context.jobTechnologies.Any(e => e.Id == id);
        }
    }
}
