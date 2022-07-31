using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ITHub.Models;
using Microsoft.AspNetCore.Authorization;
using ITHub.ViewModels;
using ITHub.Data;
using Microsoft.EntityFrameworkCore;

namespace ITHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
[AllowAnonymous]
    public IActionResult Index()
{
    return View();
}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet, Route("~/Filters")]
        [AllowAnonymous]
        public async Task<ActionResult<FilterVM>> GetFilters()
        {
            if (_context.jobTypes == null)
                return NotFound();
            var levelsa = await _context.experienceLevels.ToListAsync();
            var listfilter = new FilterVM();
            var filters = new FilterVM
            {
                experienceLevel = new ExperienceLevelVM() {  Title= "Experience Level", Type= "checkbox", Options = await _context.experienceLevels.ToListAsync() },
                jobFunctions = new JobFunctionVM() {  Title = "Tools & Technologies", Type = "pill", Options = await _context.jobFunction.ToListAsync() },
                jobTechnologies = new ToolsAndTechVM() {  Title = "Job Function", Type = "pill", Options = await _context.jobTechnologies.ToListAsync() },
                jobType = new JobTypeVM {  Title = "Job Type", Type = "pill", Options = await _context.jobTypes.ToListAsync() },
                remuneration = new RemunerationVM {  Title = "Remuneration", Type = "radio", Options = await _context.remuneration.ToListAsync() },
                workMode = new WorkModeVM {  Title = "Workmode", Type = "radio", Options = await _context.workModes.ToListAsync() },
                remunerationRange = new RemunerationRangeVM { Title = "Workmode", Type = "radio", Options = await _context.remunerationRanges.ToListAsync() },
                datePosted = new DatePostedVM { Title = "Workmode", Type = "radio", Options = await _context.datePosteds.ToListAsync() }

            };
            return filters; 
        }
    }
}
