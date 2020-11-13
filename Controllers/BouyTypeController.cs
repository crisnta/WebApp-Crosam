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
    public class BouyTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BouyTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BouyType
        public async Task<IActionResult> Index()
        {
            return View(await _context.BouyType.ToListAsync());
        }

        // GET: BouyType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bouyType = await _context.BouyType
                .FirstOrDefaultAsync(m => m.BouyTypeId == id);
            if (bouyType == null)
            {
                return NotFound();
            }

            return View(bouyType);
        }

        // GET: BouyType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BouyType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BouyTypeId,BouyTypeName")] BouyType bouyType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bouyType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bouyType);
        }

        // GET: BouyType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bouyType = await _context.BouyType.FindAsync(id);
            if (bouyType == null)
            {
                return NotFound();
            }
            return View(bouyType);
        }

        // POST: BouyType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BouyTypeId,BouyTypeName")] BouyType bouyType)
        {
            if (id != bouyType.BouyTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bouyType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BouyTypeExists(bouyType.BouyTypeId))
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
            return View(bouyType);
        }

        // GET: BouyType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bouyType = await _context.BouyType
                .FirstOrDefaultAsync(m => m.BouyTypeId == id);
            if (bouyType == null)
            {
                return NotFound();
            }

            return View(bouyType);
        }

        // POST: BouyType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bouyType = await _context.BouyType.FindAsync(id);
            _context.BouyType.Remove(bouyType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BouyTypeExists(int id)
        {
            return _context.BouyType.Any(e => e.BouyTypeId == id);
        }
    }
}
