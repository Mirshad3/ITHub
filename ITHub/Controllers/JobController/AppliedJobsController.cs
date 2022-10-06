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
    public class AppliedJobsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppliedJobsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AppliedJobs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.appliedJobs.Include(a => a.CvDatas).Include(a => a.Jobs);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AppliedJobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.appliedJobs == null)
            {
                return NotFound();
            }

            var appliedJobs = await _context.appliedJobs
                .Include(a => a.CvDatas)
                .Include(a => a.Jobs)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appliedJobs == null)
            {
                return NotFound();
            }

            return View(appliedJobs);
        }

        // GET: AppliedJobs/Create
        public IActionResult Create()
        {
            ViewData["CvId"] = new SelectList(_context.cvDatas, "Id", "Id");
            ViewData["JobId"] = new SelectList(_context.jobs, "Id", "Id");
            return View();
        }

        // POST: AppliedJobs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,JobId,CvId,ApplicationState,jobAppliedDate,UserId")] AppliedJobs appliedJobs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appliedJobs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CvId"] = new SelectList(_context.cvDatas, "Id", "Id", appliedJobs.CvId);
            ViewData["JobId"] = new SelectList(_context.jobs, "Id", "Id", appliedJobs.JobId);
            return View(appliedJobs);
        }

        // GET: AppliedJobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.appliedJobs == null)
            {
                return NotFound();
            }

            var appliedJobs = await _context.appliedJobs.FindAsync(id);
            if (appliedJobs == null)
            {
                return NotFound();
            }
            ViewData["CvId"] = new SelectList(_context.cvDatas, "Id", "Id", appliedJobs.CvId);
            ViewData["JobId"] = new SelectList(_context.jobs, "Id", "Id", appliedJobs.JobId);
            return View(appliedJobs);
        }

        // POST: AppliedJobs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,JobId,CvId,ApplicationState,jobAppliedDate,UserId")] AppliedJobs appliedJobs)
        {
            if (id != appliedJobs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appliedJobs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppliedJobsExists(appliedJobs.Id))
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
            ViewData["CvId"] = new SelectList(_context.cvDatas, "Id", "Id", appliedJobs.CvId);
            ViewData["JobId"] = new SelectList(_context.jobs, "Id", "Id", appliedJobs.JobId);
            return View(appliedJobs);
        }

        // GET: AppliedJobs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.appliedJobs == null)
            {
                return NotFound();
            }

            var appliedJobs = await _context.appliedJobs
                .Include(a => a.CvDatas)
                .Include(a => a.Jobs)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appliedJobs == null)
            {
                return NotFound();
            }

            return View(appliedJobs);
        }

        // POST: AppliedJobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.appliedJobs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.appliedJobs'  is null.");
            }
            var appliedJobs = await _context.appliedJobs.FindAsync(id);
            if (appliedJobs != null)
            {
                _context.appliedJobs.Remove(appliedJobs);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppliedJobsExists(int id)
        {
          return _context.appliedJobs.Any(e => e.Id == id);
        }
    }
}
