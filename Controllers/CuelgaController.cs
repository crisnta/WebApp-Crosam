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
    public class CuelgaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CuelgaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cuelga
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Cuelga.Include(c => c.CuelgaType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Cuelga/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuelga = await _context.Cuelga
                .Include(c => c.CuelgaType)
                .FirstOrDefaultAsync(m => m.CuelgaId == id);
            if (cuelga == null)
            {
                return NotFound();
            }

            return View(cuelga);
        }

        // GET: Cuelga/Create
        public IActionResult Create()
        {
            ViewData["CuelgaTypeId"] = new SelectList(_context.Set<CuelgaType>(), "CuelgaTypeId", "CuelgaTypeId");
            return View();
        }

        // POST: Cuelga/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CuelgaId,CuelgaTypeId,CuelgaLenght")] Cuelga cuelga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cuelga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CuelgaTypeId"] = new SelectList(_context.Set<CuelgaType>(), "CuelgaTypeId", "CuelgaTypeId", cuelga.CuelgaTypeId);
            return View(cuelga);
        }

        // GET: Cuelga/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuelga = await _context.Cuelga.FindAsync(id);
            if (cuelga == null)
            {
                return NotFound();
            }
            ViewData["CuelgaTypeId"] = new SelectList(_context.Set<CuelgaType>(), "CuelgaTypeId", "CuelgaTypeId", cuelga.CuelgaTypeId);
            return View(cuelga);
        }

        // POST: Cuelga/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CuelgaId,CuelgaTypeId,CuelgaLenght")] Cuelga cuelga)
        {
            if (id != cuelga.CuelgaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cuelga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuelgaExists(cuelga.CuelgaId))
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
            ViewData["CuelgaTypeId"] = new SelectList(_context.Set<CuelgaType>(), "CuelgaTypeId", "CuelgaTypeId", cuelga.CuelgaTypeId);
            return View(cuelga);
        }

        // GET: Cuelga/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuelga = await _context.Cuelga
                .Include(c => c.CuelgaType)
                .FirstOrDefaultAsync(m => m.CuelgaId == id);
            if (cuelga == null)
            {
                return NotFound();
            }

            return View(cuelga);
        }

        // POST: Cuelga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cuelga = await _context.Cuelga.FindAsync(id);
            _context.Cuelga.Remove(cuelga);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuelgaExists(int id)
        {
            return _context.Cuelga.Any(e => e.CuelgaId == id);
        }
    }
}
