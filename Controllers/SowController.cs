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
    public class SowController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SowController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sow
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sow.Include(s => s.BouyType).Include(s => s.Cuelga).Include(s => s.CuelgaType).Include(s => s.Seed).Include(s => s.Seeder).Include(s => s.Substratum).Include(s => s.Supplier);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Sow/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sow = await _context.Sow
                .Include(s => s.BouyType)
                .Include(s => s.Cuelga)
                .Include(s => s.CuelgaType)
                .Include(s => s.Seed)
                .Include(s => s.Seeder)
                .Include(s => s.Substratum)
                .Include(s => s.Supplier)
                .FirstOrDefaultAsync(m => m.SowId == id);
            if (sow == null)
            {
                return NotFound();
            }

            return View(sow);
        }

        // GET: Sow/Create
        public IActionResult Create()
        {
            ViewData["BouyTypeId"] = new SelectList(_context.BouyType, "BouyTypeId", "BouyTypeName");
            ViewData["CuelgaId"] = new SelectList(_context.Cuelga, "CuelgaId", "CuelgaLenght");
            ViewData["CuelgaTypeId"] = new SelectList(_context.CuelgaType, "CuelgaTypeId", "CuelgaTypeName");
            ViewData["SeedId"] = new SelectList(_context.Seed, "SeedId", "SeedSize");
            ViewData["SeederId"] = new SelectList(_context.Seeder, "SeederID", "SeederName");
            ViewData["SubstratumId"] = new SelectList(_context.Set<Substratum>(), "SubstratumId", "SubstratumName");
            ViewData["SupplierId"] = new SelectList(_context.Supplier, "SupplierId", "SupplierName");
            return View();
        }

        // POST: Sow/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SowId,CuelgaTypeId,SupplierId,SeederId,SubstratumId,CuelgaId,SeedId,BouyTypeId,Linea,CantidadColgado,Fecha")] Sow sow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BouyTypeId"] = new SelectList(_context.BouyType, "BouyTypeId", "BouyTypeId", sow.BouyTypeId);
            ViewData["CuelgaId"] = new SelectList(_context.Cuelga, "CuelgaId", "CuelgaId", sow.CuelgaId);
            ViewData["CuelgaTypeId"] = new SelectList(_context.CuelgaType, "CuelgaTypeId", "CuelgaTypeId", sow.CuelgaTypeId);
            ViewData["SeedId"] = new SelectList(_context.Seed, "SeedId", "SeedId", sow.SeedId);
            ViewData["SeederId"] = new SelectList(_context.Seeder, "SeederID", "SeederID", sow.SeederId);
            ViewData["SubstratumId"] = new SelectList(_context.Set<Substratum>(), "SubstratumId", "SubstratumId", sow.SubstratumId);
            ViewData["SupplierId"] = new SelectList(_context.Supplier, "SupplierId", "SupplierId", sow.SupplierId);
            return View(sow);
        }

        // GET: Sow/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sow = await _context.Sow.FindAsync(id);
            if (sow == null)
            {
                return NotFound();
            }
            ViewData["BouyTypeId"] = new SelectList(_context.BouyType, "BouyTypeId", "BouyTypeName", sow.BouyTypeId);
            ViewData["CuelgaId"] = new SelectList(_context.Cuelga, "CuelgaId", "CuelgaLenght", sow.CuelgaId);
            ViewData["CuelgaTypeId"] = new SelectList(_context.CuelgaType, "CuelgaTypeId", "CuelgaTypeName", sow.CuelgaTypeId);
            ViewData["SeedId"] = new SelectList(_context.Seed, "SeedId", "SeedSize", sow.SeedId);
            ViewData["SeederId"] = new SelectList(_context.Seeder, "SeederID", "SeederName", sow.SeederId);
            ViewData["SubstratumId"] = new SelectList(_context.Set<Substratum>(), "SubstratumId", "SubstratumName", sow.SubstratumId);
            ViewData["SupplierId"] = new SelectList(_context.Supplier, "SupplierId", "SupplierName", sow.SupplierId);
            return View(sow);
        }

        // POST: Sow/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SowId,CuelgaTypeId,SupplierId,SeederId,SubstratumId,CuelgaId,SeedId,BouyTypeId,Linea,CantidadColgado,Fecha")] Sow sow)
        {
            if (id != sow.SowId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SowExists(sow.SowId))
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
            ViewData["BouyTypeId"] = new SelectList(_context.BouyType, "BouyTypeId", "BouyTypeId", sow.BouyTypeId);
            ViewData["CuelgaId"] = new SelectList(_context.Cuelga, "CuelgaId", "CuelgaId", sow.CuelgaId);
            ViewData["CuelgaTypeId"] = new SelectList(_context.CuelgaType, "CuelgaTypeId", "CuelgaTypeId", sow.CuelgaTypeId);
            ViewData["SeedId"] = new SelectList(_context.Seed, "SeedId", "SeedId", sow.SeedId);
            ViewData["SeederId"] = new SelectList(_context.Seeder, "SeederID", "SeederID", sow.SeederId);
            ViewData["SubstratumId"] = new SelectList(_context.Set<Substratum>(), "SubstratumId", "SubstratumId", sow.SubstratumId);
            ViewData["SupplierId"] = new SelectList(_context.Supplier, "SupplierId", "SupplierId", sow.SupplierId);
            return View(sow);
        }

        // GET: Sow/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sow = await _context.Sow
                .Include(s => s.BouyType)
                .Include(s => s.Cuelga)
                .Include(s => s.CuelgaType)
                .Include(s => s.Seed)
                .Include(s => s.Seeder)
                .Include(s => s.Substratum)
                .Include(s => s.Supplier)
                .FirstOrDefaultAsync(m => m.SowId == id);
            if (sow == null)
            {
                return NotFound();
            }

            return View(sow);
        }

        // POST: Sow/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sow = await _context.Sow.FindAsync(id);
            _context.Sow.Remove(sow);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SowExists(int id)
        {
            return _context.Sow.Any(e => e.SowId == id);
        }
    }
}
