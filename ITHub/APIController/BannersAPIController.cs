using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITHub.Data;
using ITHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace ITHub.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class BannersAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BannersAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BannersAPI
        [HttpGet] 
        public async Task<ActionResult<IEnumerable<Banners>>> Getbanners()
        {
            return await _context.banners.ToListAsync();
        }

        // GET: api/BannersAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Banners>> GetBanners(int id)
        {
            var banners = await _context.banners.FindAsync(id);

            if (banners == null)
            {
                return NotFound();
            }

            return banners;
        }

        // PUT: api/BannersAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBanners(int id, Banners banners)
        {
            if (id != banners.Id)
            {
                return BadRequest();
            }

            _context.Entry(banners).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BannersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BannersAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Banners>> PostBanners(Banners banners)
        {
            _context.banners.Add(banners);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBanners", new { id = banners.Id }, banners);
        }

        // DELETE: api/BannersAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBanners(int id)
        {
            var banners = await _context.banners.FindAsync(id);
            if (banners == null)
            {
                return NotFound();
            }

            _context.banners.Remove(banners);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BannersExists(int id)
        {
            return _context.banners.Any(e => e.Id == id);
        }
    }
}
