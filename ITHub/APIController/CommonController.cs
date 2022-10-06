using ITHub.Data;
using ITHub.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ITHub.APIController
{
     
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CommonController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet, Route("~/api/TrendingTechnology")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<JobTechnologies>>> GetTrendingTechnologies()
        {
            return await _context.jobTechnologies.ToListAsync();
        }

        [HttpGet, Route("~/api/TrendingCompanyList")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Company>>> GetTrendingCompanyList()
        {
            return await _context.companies.ToListAsync();
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet, Route("~/api/AppliedJobList")]
        public async Task<ActionResult<IEnumerable<AppliedJobs>>> GetAppliedJobList()
        {
            return await _context.appliedJobs.ToListAsync();
        }
    }
}
