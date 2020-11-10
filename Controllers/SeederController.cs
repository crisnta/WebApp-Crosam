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
    public class SeederController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SeederController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Seeder
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Seeder.Include(s => s.Location);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Seeder/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seeder = await _context.Seeder
                .Include(s => s.Location)
                .FirstOrDefaultAsync(m => m.SeederID == id);
            if (seeder == null)
            {
                return NotFound();
            }

            return View(seeder);
        }

        // GET: Seeder/Create
        public IActionResult Create()
        {
            ViewData["LocationID"] = new SelectList(_context.Location, "LocationID", "LocationID");
            return View();
        }

        // POST: Seeder/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SeederID,LocationID,SeederName")] Seeder seeder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seeder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationID"] = new SelectList(_context.Location, "LocationID", "LocationID", seeder.LocationID);
            return View(seeder);
        }

        // GET: Seeder/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seeder = await _context.Seeder.FindAsync(id);
            if (seeder == null)
            {
                return NotFound();
            }
            ViewData["LocationID"] = new SelectList(_context.Location, "LocationID", "LocationID", seeder.LocationID);
            return View(seeder);
        }

        // POST: Seeder/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SeederID,LocationID,SeederName")] Seeder seeder)
        {
            if (id != seeder.SeederID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seeder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeederExists(seeder.SeederID))
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
            ViewData["LocationID"] = new SelectList(_context.Location, "LocationID", "LocationID", seeder.LocationID);
            return View(seeder);
        }

        // GET: Seeder/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seeder = await _context.Seeder
                .Include(s => s.Location)
                .FirstOrDefaultAsync(m => m.SeederID == id);
            if (seeder == null)
            {
                return NotFound();
            }

            return View(seeder);
        }

        // POST: Seeder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seeder = await _context.Seeder.FindAsync(id);
            _context.Seeder.Remove(seeder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeederExists(int id)
        {
            return _context.Seeder.Any(e => e.SeederID == id);
        }
    }
}
