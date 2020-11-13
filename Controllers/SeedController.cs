using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using crosam.Data;
using crosam.Models;

namespace crosam.Controllers
{
    public class SeedController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SeedController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Seed
        public async Task<IActionResult> Index()
        {
            return View(await _context.Seed.ToListAsync());
        }

        // GET: Seed/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seed = await _context.Seed
                .FirstOrDefaultAsync(m => m.SeedId == id);
            if (seed == null)
            {
                return NotFound();
            }

            return View(seed);
        }

        // GET: Seed/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Seed/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SeedId,SeedSize")] Seed seed)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(seed);
        }

        // GET: Seed/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seed = await _context.Seed.FindAsync(id);
            if (seed == null)
            {
                return NotFound();
            }
            return View(seed);
        }

        // POST: Seed/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SeedId,SeedSize")] Seed seed)
        {
            if (id != seed.SeedId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeedExists(seed.SeedId))
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
            return View(seed);
        }

        // GET: Seed/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seed = await _context.Seed
                .FirstOrDefaultAsync(m => m.SeedId == id);
            if (seed == null)
            {
                return NotFound();
            }

            return View(seed);
        }

        // POST: Seed/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seed = await _context.Seed.FindAsync(id);
            _context.Seed.Remove(seed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeedExists(int id)
        {
            return _context.Seed.Any(e => e.SeedId == id);
        }
    }
}
