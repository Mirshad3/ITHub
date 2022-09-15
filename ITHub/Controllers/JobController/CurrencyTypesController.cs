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
    public class CurrencyTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CurrencyTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CurrencyTypes
        public async Task<IActionResult> Index()
        {
              return View(await _context.currencyTypes.ToListAsync());
        }

        // GET: CurrencyTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.currencyTypes == null)
            {
                return NotFound();
            }

            var currencyType = await _context.currencyTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (currencyType == null)
            {
                return NotFound();
            }

            return View(currencyType);
        }

        // GET: CurrencyTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CurrencyTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Value")] CurrencyType currencyType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(currencyType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(currencyType);
        }

        // GET: CurrencyTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.currencyTypes == null)
            {
                return NotFound();
            }

            var currencyType = await _context.currencyTypes.FindAsync(id);
            if (currencyType == null)
            {
                return NotFound();
            }
            return View(currencyType);
        }

        // POST: CurrencyTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Value")] CurrencyType currencyType)
        {
            if (id != currencyType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(currencyType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurrencyTypeExists(currencyType.Id))
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
            return View(currencyType);
        }

        // GET: CurrencyTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.currencyTypes == null)
            {
                return NotFound();
            }

            var currencyType = await _context.currencyTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (currencyType == null)
            {
                return NotFound();
            }

            return View(currencyType);
        }

        // POST: CurrencyTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.currencyTypes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.currencyTypes'  is null.");
            }
            var currencyType = await _context.currencyTypes.FindAsync(id);
            if (currencyType != null)
            {
                _context.currencyTypes.Remove(currencyType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CurrencyTypeExists(int id)
        {
          return _context.currencyTypes.Any(e => e.Id == id);
        }
    }
}
