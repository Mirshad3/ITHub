using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ITHub.Data;
using ITHub.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace ITHub.Controllers.JobController
{
    public class JobsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _HostEnvironment;
        public JobsController(ApplicationDbContext context, IHostingEnvironment HostEnvironment)
        {
            _context = context;
            _HostEnvironment = HostEnvironment;
        }

        // GET: Jobs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.jobs.Include(j => j.Company).Include(j => j.CurrencyType).Include(j => j.Locations).Include(j => j.Remuneration).Include(j => j.WorkMode);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Jobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.jobs == null)
            {
                return NotFound();
            }

            var job = await _context.jobs
                .Include(j => j.Company)
                .Include(j => j.CurrencyType)
                .Include(j => j.Locations)
                .Include(j => j.Remuneration)
                .Include(j => j.WorkMode)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // GET: Jobs/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.companies, "Id", "Name");
            ViewData["JobType"] = new SelectList(_context.jobTypes, "Id", "Name");
            ViewData["Location"] = new SelectList(_context.locations, "Id", "Name");
            ViewData["experienceLevels"] = new SelectList(_context.experienceLevels, "Id", "Name");
            ViewData["jobTechnologies"] = new SelectList(_context.jobTechnologies, "Id", "Name");
            ViewData["jobFunction"] = new SelectList(_context.jobFunction, "Id", "Name");
            ViewData["workModes"] = new SelectList(_context.workModes, "Id", "Name");
            ViewData["jobTechnologies"] = new SelectList(_context.jobTechnologies, "Id", "Name");
            ViewData["remuneration"] = new SelectList(_context.remuneration, "Id", "Name");
            ViewData["remunerationRanges"] = new SelectList(_context.remunerationRanges, "Id", "Name");
            ViewData["currencyTypes"] = new SelectList(_context.currencyTypes, "Id", "Name");
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Job job, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string filename = "";
                string uploads = Path.Combine(_HostEnvironment.WebRootPath, "img/JobPost/");
                if (file.Length > 0)
                {
                    filename = Guid.NewGuid() + file.FileName;
                    string filePath = Path.Combine(uploads, filename);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
                job.JobImageId = filename;
                job.CreatedDate = DateTime.Now;
                _context.Add(job);
                _context.SaveChanges();
                var jobId = job.Id;
                var jobWithExperienceLevel = new List<JobWithExperienceLevel>(); 
                foreach (var id in job.SelectedexperienceLevelIds)
                {
                    var item = new JobWithExperienceLevel()
                    {
                        ExperienceLevelId = id,
                        JobId = jobId
                    };
                    jobWithExperienceLevel.Add(item);
                }
                _context.jobWithExperienceLevels.AddRange(jobWithExperienceLevel);
                var jobWithTechnologies = new List<JobWithTechnologies>();
                foreach (var id in job.SelectedjobTechnologiesIds)
                {
                    var item = new JobWithTechnologies()
                    {
                        JobTechnologiesId = id,
                        JobId = jobId
                    };
                    jobWithTechnologies.Add(item);
                }
                _context.jobWithTechnologies.AddRange(jobWithTechnologies);
                var jobWithFunction = new List<JobWithFunction>();
                foreach (var id in job.SelectedjobFunctionsIds)
                {
                    var item = new JobWithFunction()
                    {
                        JobFunctionId = id,
                        JobId = jobId
                    };
                    jobWithFunction.Add(item);
                }
                _context.jobWithFunction.AddRange(jobWithFunction);
                var jobWithJobType = new List<JobWithJobType>();
                foreach (var id in job.SelectedjobTypeIds)
                {
                    var item = new JobWithJobType()
                    {
                        JobTypeId = id,
                        JobId = jobId
                    };
                    jobWithJobType.Add(item);
                }
                _context.jobWithJobType.AddRange(jobWithJobType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.companies, "Id", "Name");
            ViewData["JobType"] = new SelectList(_context.jobTypes, "Id", "Name");
            ViewData["Location"] = new SelectList(_context.locations, "Id", "Name");
            ViewData["experienceLevels"] = new SelectList(_context.experienceLevels, "Id", "Name");
            ViewData["jobTechnologies"] = new SelectList(_context.jobTechnologies, "Id", "Name");
            ViewData["jobFunction"] = new SelectList(_context.jobFunction, "Id", "Name");
            ViewData["workModes"] = new SelectList(_context.workModes, "Id", "Name");
            ViewData["jobTechnologies"] = new SelectList(_context.jobTechnologies, "Id", "Name");
            ViewData["remuneration"] = new SelectList(_context.remuneration, "Id", "Name");
            ViewData["remunerationRanges"] = new SelectList(_context.remunerationRanges, "Id", "Name");
            ViewData["currencyTypes"] = new SelectList(_context.currencyTypes, "Id", "Name");
            return View(job);
        }

        // GET: Jobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.jobs == null)
            {
                return NotFound();
            }

            var job = await _context.jobs.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            var i = _context.jobWithExperienceLevels.Where(a => a.JobId == id).ToList();
            _context.jobWithExperienceLevels.AddRange(i);
            //jobWithExperienceLevels.AddRange(i);
            var j = _context.jobWithJobType.Where(a => a.JobId == id).ToList();
            _context.jobWithJobType.AddRange(j);
            var k = _context.jobWithFunction.Where(a => a.JobId == id).ToList();
            _context.jobWithFunction.AddRange(k);
            var l = _context.jobWithTechnologies.Where(a => a.JobId == id).ToList();
            _context.jobWithTechnologies.AddRange(l);
            int[] GetExistingExperienceLevelIds = new int[i.Count];
            int[] GetExistingJobTypeIds = new int[j.Count];
            int[] GetExistingFunctionIds = new int[k.Count];
            int[] GetExistingTechnologiesIds = new int[l.Count];
            int iCount = 0, jCount = 0, kCount = 0, lCount = 0;
            foreach (var item in i)
            {
                GetExistingExperienceLevelIds[iCount] = item.ExperienceLevelId;
                iCount++;
            }
            foreach (var item in j)
            {
                GetExistingJobTypeIds[jCount] = item.JobTypeId;
                jCount++;
            }
            foreach (var item in k)
            {
                GetExistingFunctionIds[kCount] = item.JobFunctionId;
                kCount++;
            }
            foreach (var item in l)
            {
                GetExistingTechnologiesIds[lCount] = item.JobTechnologiesId;
                lCount++;
            }
            ViewData["JobWithExperienceLevelId"] = new MultiSelectList(_context.experienceLevels, "Id", "Name", GetExistingExperienceLevelIds);
            ViewData["jobWithJobTypeIds"] = new MultiSelectList(_context.jobTypes, "Id", "Name", GetExistingJobTypeIds);
            ViewData["JobWithFunctionIds"] = new MultiSelectList(_context.jobFunction, "Id", "Name", GetExistingFunctionIds);
            ViewData["JobWithTechnologiesIds"] = new MultiSelectList(_context.jobTechnologies, "Id", "Name", GetExistingTechnologiesIds); 

            ViewData["CompanyId"] = new SelectList(_context.companies, "Id", "Name");
            ViewData["Location"] = new SelectList(_context.locations, "Id", "Name"); 
             ViewData["workModes"] = new SelectList(_context.workModes, "Id", "Name");
             ViewData["remuneration"] = new SelectList(_context.remuneration, "Id", "Name");
            ViewData["remunerationRanges"] = new SelectList(_context.remunerationRanges, "Id", "Name");
            ViewData["currencyTypes"] = new SelectList(_context.currencyTypes, "Id", "Name");
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Job job)
        {
            if (id != job.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var jobs = _context.jobWithExperienceLevels.Where(m=>m.JobId==id);
                    foreach(var exp in jobs)
                    {
                        _context.jobWithExperienceLevels.Remove(exp);
                    }
                    var jobType = _context.jobWithJobType.Where(m => m.JobId == id);
                    foreach (var exp in jobType)
                    {
                        _context.jobWithJobType.Remove(exp);
                    }
                    var jobFun = _context.jobWithFunction.Where(m => m.JobId == id);
                    foreach (var exp in jobFun)
                    {
                        _context.jobWithFunction.Remove(exp);
                    }
                    var jobTech = _context.jobWithTechnologies.Where(m => m.JobId == id);
                    foreach (var exp in jobTech)
                    {
                        _context.jobWithTechnologies.Remove(exp);
                    }
                    var jobId = job.Id;
                    var jobWithExperienceLevel = new List<JobWithExperienceLevel>();
                    foreach (var ids in job.SelectedexperienceLevelIds)
                    {
                        var item = new JobWithExperienceLevel()
                        {
                            ExperienceLevelId = ids,
                            JobId = jobId
                        };
                        jobWithExperienceLevel.Add(item);
                    }
                    _context.jobWithExperienceLevels.AddRange(jobWithExperienceLevel);
                    var jobWithTechnologies = new List<JobWithTechnologies>();
                    foreach (var ids in job.SelectedjobTechnologiesIds)
                    {
                        var item = new JobWithTechnologies()
                        {
                            JobTechnologiesId = ids,
                            JobId = jobId
                        };
                        jobWithTechnologies.Add(item);
                    }
                    _context.jobWithTechnologies.AddRange(jobWithTechnologies);
                    var jobWithFunction = new List<JobWithFunction>();
                    foreach (var ids in job.SelectedjobFunctionsIds)
                    {
                        var item = new JobWithFunction()
                        {
                            JobFunctionId = ids,
                            JobId = jobId
                        };
                        jobWithFunction.Add(item);
                    }
                    _context.jobWithFunction.AddRange(jobWithFunction);
                    var jobWithJobType = new List<JobWithJobType>();
                    foreach (var ids in job.SelectedjobTypeIds)
                    {
                        var item = new JobWithJobType()
                        {
                            JobTypeId = ids,
                            JobId = jobId
                        };
                        jobWithJobType.Add(item);
                    }
                    _context.jobWithJobType.AddRange(jobWithJobType);
                    _context.Update(job);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobExists(job.Id))
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
            var i = _context.jobWithExperienceLevels.Where(a => a.JobId == id).ToList();
            _context.jobWithExperienceLevels.AddRange(i);
            //jobWithExperienceLevels.AddRange(i);
            var j = _context.jobWithJobType.Where(a => a.JobId == id).ToList();
            _context.jobWithJobType.AddRange(j);
            var k = _context.jobWithFunction.Where(a => a.JobId == id).ToList();
            _context.jobWithFunction.AddRange(k);
            var l = _context.jobWithTechnologies.Where(a => a.JobId == id).ToList();
            _context.jobWithTechnologies.AddRange(l);
            int[] GetExistingExperienceLevelIds = new int[i.Count];
            int[] GetExistingJobTypeIds = new int[j.Count];
            int[] GetExistingFunctionIds = new int[k.Count];
            int[] GetExistingTechnologiesIds = new int[l.Count];
            int iCount = 0, jCount = 0, kCount = 0, lCount = 0;
            foreach (var item in i)
            {
                GetExistingExperienceLevelIds[iCount] = item.ExperienceLevelId;
                iCount++;
            }
            foreach (var item in j)
            {
                GetExistingJobTypeIds[jCount] = item.JobTypeId;
                jCount++;
            }
            foreach (var item in k)
            {
                GetExistingFunctionIds[kCount] = item.JobFunctionId;
                kCount++;
            }
            foreach (var item in l)
            {
                GetExistingTechnologiesIds[lCount] = item.JobTechnologiesId;
                lCount++;
            }
            ViewData["JobWithExperienceLevelId"] = new MultiSelectList(_context.experienceLevels, "Id", "Name", GetExistingExperienceLevelIds);
            ViewData["jobWithJobTypeIds"] = new MultiSelectList(_context.jobTypes, "Id", "Name", GetExistingJobTypeIds);
            ViewData["JobWithFunctionIds"] = new MultiSelectList(_context.jobFunction, "Id", "Name", GetExistingFunctionIds);
            ViewData["JobWithTechnologiesIds"] = new MultiSelectList(_context.jobTechnologies, "Id", "Name", GetExistingTechnologiesIds);

            ViewData["CompanyId"] = new SelectList(_context.companies, "Id", "Name");
            ViewData["Location"] = new SelectList(_context.locations, "Id", "Name");
            ViewData["workModes"] = new SelectList(_context.workModes, "Id", "Name");
            ViewData["remuneration"] = new SelectList(_context.remuneration, "Id", "Name");
            ViewData["remunerationRanges"] = new SelectList(_context.remunerationRanges, "Id", "Name");
            ViewData["currencyTypes"] = new SelectList(_context.currencyTypes, "Id", "Name");
            return View(job);
        }

        // GET: Jobs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.jobs == null)
            {
                return NotFound();
            }

            var job = await _context.jobs
                .Include(j => j.Company)
                .Include(j => j.CurrencyType)
                .Include(j => j.Locations)
                .Include(j => j.Remuneration)
                .Include(j => j.WorkMode)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.jobs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.jobs'  is null.");
            }
            var job = await _context.jobs.FindAsync(id);
            if (job != null)
            {
                _context.jobs.Remove(job);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobExists(int id)
        {
          return _context.jobs.Any(e => e.Id == id);
        }
    }
}
