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
    public class SubstratumController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubstratumController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Substratum
        public async Task<IActionResult> Index()
        {
            return View(await _context.Substratum.ToListAsync());
        }

        // GET: Substratum/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var substratum = await _context.Substratum
                .FirstOrDefaultAsync(m => m.SubstratumId == id);
            if (substratum == null)
            {
                return NotFound();
            }

            return View(substratum);
        }

        // GET: Substratum/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Substratum/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubstratumId,SubstratumName")] Substratum substratum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(substratum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(substratum);
        }

        // GET: Substratum/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var substratum = await _context.Substratum.FindAsync(id);
            if (substratum == null)
            {
                return NotFound();
            }
            return View(substratum);
        }

        // POST: Substratum/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubstratumId,SubstratumName")] Substratum substratum)
        {
            if (id != substratum.SubstratumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(substratum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubstratumExists(substratum.SubstratumId))
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
            return View(substratum);
        }

        // GET: Substratum/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var substratum = await _context.Substratum
                .FirstOrDefaultAsync(m => m.SubstratumId == id);
            if (substratum == null)
            {
                return NotFound();
            }

            return View(substratum);
        }

        // POST: Substratum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var substratum = await _context.Substratum.FindAsync(id);
            _context.Substratum.Remove(substratum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubstratumExists(int id)
        {
            return _context.Substratum.Any(e => e.SubstratumId == id);
        }
    }
}
