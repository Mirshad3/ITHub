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
using ITHub.Wrappers;

namespace ITHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _context;
        private readonly IUriService _uriService;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IUriService uriService)
        {
            _logger = logger;
            _context = context;
            _uriService = uriService;
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
        public async Task<IActionResult> GetFilters()
        {
            if (_context.jobTypes == null)
                return NotFound();
            var filters = new FilterVM
            {
                experienceLevel = new ExperienceLevelVM() {  Title= "Experience Level", Type= "checkbox", Options = await _context.experienceLevels.ToListAsync() },
                jobFunctions = new JobFunctionVM() {  Title = "Tools & Technologies", Type = "pill", Options = await _context.jobFunction.ToListAsync() },
                jobTechnologies = new ToolsAndTechVM() {  Title = "Job Function", Type = "pill", Options = await _context.jobTechnologies.ToListAsync() },
                jobType = new JobTypeVM {  Title = "Job Type", Type = "pill", Options = await _context.jobTypes.ToListAsync() },
                remuneration = new RemunerationVM {  Title = "Remuneration", Type = "radio", Options = await _context.remuneration.ToListAsync() },
                workMode = new WorkModeVM {  Title = "Workmode", Type = "radio", Options = await _context.workModes.ToListAsync() },
                remunerationRange = new RemunerationRangeVM { Title = "Remuneration Range", Type = "radio", Options = await _context.remunerationRanges.ToListAsync() },
                datePosted = new DatePostedVM { Title = "Date Posted", Type = "radio", Options = await _context.datePosteds.ToListAsync() }

            };
            return Ok(new Response<FilterVM>(filters));
            //return filters; 
        }
        //////experienceLevel=Internship,Associate &jobTechnologies=Node,.Net
        //////&jobFunctions=Frontend&jobType=Temporary,Contract
        //////&remuneration=ByMonthly&remunerationRange=3&datePosted=Past24hrs
        [HttpGet, Route("~/JobList")]
        [AllowAnonymous]
        public async Task<IActionResult> JobsWithSearch(string experienceLevel, string jobTechnologies, string jobFunctions, string jobType,string remuneration,string remunerationRange,string datePosted, string workMode, string searchString, [FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var datas =   _context.jobs.Include(j => j.Company).Include(j => j.CurrencyType).Include(j => j.Locations).Include(j => j.Remuneration).Include(j => j.WorkMode).ToList();
            var newData = new List<JobsVM>();
            foreach (var job in datas)
            {
                var datasa = new JobsVM()
                {
                    BriefDescription = job.Description,
                    Company = job.Company,
                    CurrencyType = job.CurrencyType,
                    Description = job.Description,
                    ExpireDate = job.ExpireDate,
                    Id = job.Id,
                    IsPegged = job.IsPegged,
                    JobImageId = "/img/JobPost/" + job.JobImageId,
                    JobSalary = job.JobSalary,
                    Locations = job.Locations,
                    NoOfVacancy = job.NoOfVacancy,
                    LongDescription = job.LongDescription,
                    PostingDate = job.PostingDate,
                    CreatedDate = job.CreatedDate,
                    Title = job.Title,
                    Status = job.Status,
                    Remuneration = job.Remuneration,
                    JobFunction = _context.jobWithFunction.Where(a => a.JobId == job.Id).Select(m => m.JobFunction).ToList(),
                    ExperienceLevel = _context.jobWithExperienceLevels.Where(a => a.JobId == job.Id).Select(m => m.ExperienceLevel).ToList(),
                    JobTechnologies = _context.jobWithTechnologies.Where(a => a.JobId == job.Id).Select(m => m.JobTechnologies).ToList(),
                    JobTypes = _context.jobWithJobType.Where(a => a.JobId == job.Id).Select(m => m.JobType).ToList(),
                    WorkMode = job.WorkMode,
                    RemunerationMax = job.RemunerationMax,
                    RemunerationMin = job.RemunerationMin
                };
                newData.Add(datasa);
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                newData = newData.Where(m => m.Title.Contains(searchString) || m.Description.Contains(searchString)).ToList();
            }
            if (!String.IsNullOrEmpty(experienceLevel))
            {

                newData = newData.Where(m => experienceLevel.Split(',').Any(k=> m.ExperienceLevel.Any(p=>p.Value == k))).ToList();
            }
            if (!String.IsNullOrEmpty(jobTechnologies))
            {
              newData = newData.Where(m => jobTechnologies.Split(',').Any(k => m.JobTechnologies.Any(p => p.Value == k))).ToList();
             }
            if (!String.IsNullOrEmpty(jobFunctions))
            {

                newData = newData.Where(m => jobFunctions.Split(',').Any(k => m.JobFunction.Any(p => p.Value == k))).ToList();
             }
            if (!String.IsNullOrEmpty(jobType))
            {
                newData = newData.Where(m => jobType.Split(',').Any(k => m.JobTypes.Any(p => p.Value == k))).ToList();
            }
            if (!String.IsNullOrEmpty(remuneration))
            {
                newData = newData.Where(m => m.Remuneration.Value == remuneration).ToList();
            }
            //if (!String.IsNullOrEmpty(remunerationRange))
            //{
            //    newData = newData.Where(m => m.remunerationRange == remunerationRange).ToList();
            //}
            if (!String.IsNullOrEmpty(workMode))
            {
                newData = newData.Where(m => m.WorkMode.Value == workMode).ToList();
            }
            if (!String.IsNullOrEmpty(datePosted))
            {
                if (datePosted == "Past24hrs") { 
                newData = newData.Where(m => m.PostingDate >= DateTime.Today.AddDays(-1)).ToList();
                }
                else if (datePosted == "PastWeek")
                {
                    newData = newData.Where(m => m.PostingDate >= DateTime.Today.AddDays(-7)).ToList();
                }
                else if (datePosted == "PastMonth")
                {
                    newData = newData.Where(m => m.PostingDate >= DateTime.Today.AddDays(-30)).ToList();
                }
            }
            var pagedData = newData.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
        .Take(validFilter.PageSize)
        .ToList();
            var totalRecords = newData.Count();
           
            var pagedReponse = PaginationHelper.CreatePagedReponse<JobsVM>(pagedData, validFilter, totalRecords, _uriService, route);
            return Ok(pagedReponse);
            
        }
        [Route("~/JobSearch")]
        public async Task<IActionResult> JobsSearch(string search,string searchString, [FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var datas = _context.jobs.Include(j => j.Company).Include(j => j.CurrencyType).Include(j => j.Locations).Include(j => j.Remuneration).Include(j => j.WorkMode).ToList();
           
            if (!String.IsNullOrEmpty(search))
            {
                datas = datas.Where(m=>m.Title.Contains(search) || m.Description.Contains(search) ).ToList();
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                var contains = searchString.Split('&');
                foreach (var val in contains)
                {
                    if (val.Split('=').First() == "experienceLevel")
                    {
                        foreach (var data in val.Split('=').Last().Split('&'))
                        {
                            //datas = datas.Where(m=>m.)
                        }

                    };
                }
                //if (!String.IsNullOrEmpty(searchString))
                //{
                //    var c = job.Where(p => p.Forfatter.Initialer.Contains(searchString)).ToList();
                //    return View(c);
                //}
                //{
                //    if (searchProject != 0)
                //    {
                //        var d = job.Where(p => p.P.ProjektId.Equals(searchProject)).ToList();
                //        return View(d);
                //    }
                //}
            }














            var pagedData = datas.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
        .Take(validFilter.PageSize)
        .ToList();
            var totalRecords = datas.Count();
            foreach (var job in pagedData)
            {
                var id = job.Id;
                var i = _context.jobWithExperienceLevels.Where(a => a.JobId == id).Select(m => m.ExperienceLevelId).ToArray();
                job.SelectedexperienceLevelIds = i;
                var j = _context.jobWithJobType.Where(a => a.JobId == id).Select(m => m.JobTypeId).ToArray();
                job.SelectedjobTypeIds = j;
                var k = _context.jobWithFunction.Where(a => a.JobId == id).Select(m => m.JobFunctionId).ToArray();
                job.SelectedjobFunctionsIds = k;
                var l = _context.jobWithTechnologies.Where(a => a.JobId == id).Select(m => m.JobTechnologiesId).ToArray();
                job.SelectedjobTechnologiesIds = l;
                job.JobImageId = "img/JobPost/" + job.JobImageId;
            }
            var pagedReponse = PaginationHelper.CreatePagedReponse<Job>(pagedData, validFilter, totalRecords, _uriService, route);
            return Ok(pagedReponse);
            //return Ok(new PagedResponse<List<Job>>(pagedData.Result, validFilter.PageNumber, validFilter.PageSize));





           
            // var e = job.Where(p => p.Forfatter.Initialer.Contains(searchString) && p.P.ProjektId.Equals(searchProject)).ToList();

            //var e = job.ToList();
            //return datas;
        }
    }
}
