using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeltrettungAuftrag.Models;

namespace WeltrettungAuftrag.Controllers
{
    public class KampfsController : Controller
    {
        private readonly AuftragDBContext _context;

        public KampfsController(AuftragDBContext context)
        {
            _context = context;
        }

        // GET: Kampfs
        public async Task<IActionResult> Index()
        {
            var auftragDBContext = _context.Kampfs.Include(k => k.Aggressor).Include(k => k.Held);
            return View(await auftragDBContext.ToListAsync());
        }

        // GET: Kampfs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kampf = await _context.Kampfs
                .Include(k => k.Aggressor)
                .Include(k => k.Held)
                .FirstOrDefaultAsync(m => m.KampfId == id);
            if (kampf == null)
            {
                return NotFound();
            }

            return View(kampf);
        }

        // GET: Kampfs/Create
        public IActionResult Create()
        {
            ViewData["AggressorId"] = new SelectList(_context.Aggressors, "AggressorId", "Name");
            ViewData["HeldId"] = new SelectList(_context.Helds, "HeldId", "Nachname");
            return View();
        }

        // POST: Kampfs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KampfId,Kampfbezeichnung,AggressorId,HeldId")] Kampf kampf)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kampf);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AggressorId"] = new SelectList(_context.Aggressors, "AggressorId", "Name", kampf.AggressorId);
            ViewData["HeldId"] = new SelectList(_context.Helds, "HeldId", "Nachname", kampf.HeldId);
            return View(kampf);
        }

        // GET: Kampfs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kampf = await _context.Kampfs.FindAsync(id);
            if (kampf == null)
            {
                return NotFound();
            }
            ViewData["AggressorId"] = new SelectList(_context.Aggressors, "AggressorId", "Name", kampf.AggressorId);
            ViewData["HeldId"] = new SelectList(_context.Helds, "HeldId", "Nachname", kampf.HeldId);
            return View(kampf);
        }

        // POST: Kampfs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KampfId,Kampfbezeichnung,AggressorId,HeldId")] Kampf kampf)
        {
            if (id != kampf.KampfId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kampf);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KampfExists(kampf.KampfId))
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
            ViewData["AggressorId"] = new SelectList(_context.Aggressors, "AggressorId", "Name", kampf.AggressorId);
            ViewData["HeldId"] = new SelectList(_context.Helds, "HeldId", "Nachname", kampf.HeldId);
            return View(kampf);
        }

        // GET: Kampfs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kampf = await _context.Kampfs
                .Include(k => k.Aggressor)
                .Include(k => k.Held)
                .FirstOrDefaultAsync(m => m.KampfId == id);
            if (kampf == null)
            {
                return NotFound();
            }

            return View(kampf);
        }

        // POST: Kampfs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kampf = await _context.Kampfs.FindAsync(id);
            _context.Kampfs.Remove(kampf);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KampfExists(int id)
        {
            return _context.Kampfs.Any(e => e.KampfId == id);
        }
    }
}
