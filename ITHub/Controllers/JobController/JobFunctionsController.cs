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
    public class JobFunctionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobFunctionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: JobFunctions
        public async Task<IActionResult> Index()
        {
              return View(await _context.jobFunction.ToListAsync());
        }

        // GET: JobFunctions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.jobFunction == null)
            {
                return NotFound();
            }

            var jobFunction = await _context.jobFunction
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobFunction == null)
            {
                return NotFound();
            }

            return View(jobFunction);
        }

        // GET: JobFunctions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobFunctions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Value")] JobFunction jobFunction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobFunction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobFunction);
        }

        // GET: JobFunctions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.jobFunction == null)
            {
                return NotFound();
            }

            var jobFunction = await _context.jobFunction.FindAsync(id);
            if (jobFunction == null)
            {
                return NotFound();
            }
            return View(jobFunction);
        }

        // POST: JobFunctions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Value")] JobFunction jobFunction)
        {
            if (id != jobFunction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobFunction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobFunctionExists(jobFunction.Id))
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
            return View(jobFunction);
        }

        // GET: JobFunctions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.jobFunction == null)
            {
                return NotFound();
            }

            var jobFunction = await _context.jobFunction
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobFunction == null)
            {
                return NotFound();
            }

            return View(jobFunction);
        }

        // POST: JobFunctions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.jobFunction == null)
            {
                return Problem("Entity set 'ApplicationDbContext.jobFunction'  is null.");
            }
            var jobFunction = await _context.jobFunction.FindAsync(id);
            if (jobFunction != null)
            {
                _context.jobFunction.Remove(jobFunction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobFunctionExists(int id)
        {
          return _context.jobFunction.Any(e => e.Id == id);
        }
    }
}
