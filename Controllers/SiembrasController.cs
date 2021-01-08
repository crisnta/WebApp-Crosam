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
    public class SiembrasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SiembrasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Siembras
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Siembras.Include(s => s.ServicioFlete).Include(s => s.Supplier);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Siembras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siembras = await _context.Siembras
                .Include(s => s.ServicioFlete)
                .Include(s => s.Supplier)
                .FirstOrDefaultAsync(m => m.SiembraId == id);
            if (siembras == null)
            {
                return NotFound();
            }

            return View(siembras);
        }

        // GET: Siembras/Create
        public IActionResult Create()
        {
            ViewData["ServicioFleteId"] = new SelectList(_context.Set<ServicioFlete>(), "ServicioFleteId", "ServicioFleteId");
            ViewData["SupplierId"] = new SelectList(_context.Supplier, "SupplierId", "SupplierId");
            return View();
        }

        // POST: Siembras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SiembraId,ServicioFleteId,SupplierId,Date,NroGuia,Recepcion,ValorUnidad,GastoSemilla,GastoFlete")] Siembras siembras)
        {
            if (ModelState.IsValid)
            {
                _context.Add(siembras);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ServicioFleteId"] = new SelectList(_context.Set<ServicioFlete>(), "ServicioFleteId", "ServicioFleteId", siembras.ServicioFleteId);
            ViewData["SupplierId"] = new SelectList(_context.Supplier, "SupplierId", "SupplierId", siembras.SupplierId);
            return View(siembras);
        }

        // GET: Siembras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siembras = await _context.Siembras.FindAsync(id);
            if (siembras == null)
            {
                return NotFound();
            }
            ViewData["ServicioFleteId"] = new SelectList(_context.Set<ServicioFlete>(), "ServicioFleteId", "ServicioFleteId", siembras.ServicioFleteId);
            ViewData["SupplierId"] = new SelectList(_context.Supplier, "SupplierId", "SupplierId", siembras.SupplierId);
            return View(siembras);
        }

        // POST: Siembras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SiembraId,ServicioFleteId,SupplierId,Date,NroGuia,Recepcion,ValorUnidad,GastoSemilla,GastoFlete")] Siembras siembras)
        {
            if (id != siembras.SiembraId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(siembras);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiembrasExists(siembras.SiembraId))
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
            ViewData["ServicioFleteId"] = new SelectList(_context.Set<ServicioFlete>(), "ServicioFleteId", "ServicioFleteId", siembras.ServicioFleteId);
            ViewData["SupplierId"] = new SelectList(_context.Supplier, "SupplierId", "SupplierId", siembras.SupplierId);
            return View(siembras);
        }

        // GET: Siembras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siembras = await _context.Siembras
                .Include(s => s.ServicioFlete)
                .Include(s => s.Supplier)
                .FirstOrDefaultAsync(m => m.SiembraId == id);
            if (siembras == null)
            {
                return NotFound();
            }

            return View(siembras);
        }

        // POST: Siembras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var siembras = await _context.Siembras.FindAsync(id);
            _context.Siembras.Remove(siembras);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiembrasExists(int id)
        {
            return _context.Siembras.Any(e => e.SiembraId == id);
        }
    }
}
