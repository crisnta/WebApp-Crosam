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
    public class CuelgaTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CuelgaTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CuelgaType
        public async Task<IActionResult> Index()
        {
            return View(await _context.CuelgaType.ToListAsync());
        }

        // GET: CuelgaType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuelgaType = await _context.CuelgaType
                .FirstOrDefaultAsync(m => m.CuelgaTypeId == id);
            if (cuelgaType == null)
            {
                return NotFound();
            }

            return View(cuelgaType);
        }

        // GET: CuelgaType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CuelgaType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CuelgaTypeId,CuelgaTypeName")] CuelgaType cuelgaType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cuelgaType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cuelgaType);
        }

        // GET: CuelgaType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuelgaType = await _context.CuelgaType.FindAsync(id);
            if (cuelgaType == null)
            {
                return NotFound();
            }
            return View(cuelgaType);
        }

        // POST: CuelgaType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CuelgaTypeId,CuelgaTypeName")] CuelgaType cuelgaType)
        {
            if (id != cuelgaType.CuelgaTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cuelgaType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuelgaTypeExists(cuelgaType.CuelgaTypeId))
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
            return View(cuelgaType);
        }

        // GET: CuelgaType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuelgaType = await _context.CuelgaType
                .FirstOrDefaultAsync(m => m.CuelgaTypeId == id);
            if (cuelgaType == null)
            {
                return NotFound();
            }

            return View(cuelgaType);
        }

        // POST: CuelgaType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cuelgaType = await _context.CuelgaType.FindAsync(id);
            _context.CuelgaType.Remove(cuelgaType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuelgaTypeExists(int id)
        {
            return _context.CuelgaType.Any(e => e.CuelgaTypeId == id);
        }
    }
}
