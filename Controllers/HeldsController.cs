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
    public class HeldsController : Controller
    {
        private readonly AuftragDBContext _context;

        public HeldsController(AuftragDBContext context)
        {
            _context = context;
        }

        // GET: Helds
        public async Task<IActionResult> Index()
        {
            return View(await _context.Helds.ToListAsync());
        }

        // GET: Helds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var held = await _context.Helds
                .FirstOrDefaultAsync(m => m.HeldId == id);
            if (held == null)
            {
                return NotFound();
            }

            return View(held);
        }

        // GET: Helds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Helds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HeldId,Vorname,Nachname,Email,Faehigkeit,Volljaehrig")] Held held)
        {
            if (ModelState.IsValid)
            {
                _context.Add(held);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(held);
        }

        // GET: Helds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var held = await _context.Helds.FindAsync(id);
            if (held == null)
            {
                return NotFound();
            }
            return View(held);
        }

        // POST: Helds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HeldId,Vorname,Nachname,Email,Faehigkeit,Volljaehrig")] Held held)
        {
            if (id != held.HeldId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(held);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HeldExists(held.HeldId))
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
            return View(held);
        }

        // GET: Helds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var held = await _context.Helds
                .FirstOrDefaultAsync(m => m.HeldId == id);
            if (held == null)
            {
                return NotFound();
            }

            return View(held);
        }

        // POST: Helds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var held = await _context.Helds.FindAsync(id);
            _context.Helds.Remove(held);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HeldExists(int id)
        {
            return _context.Helds.Any(e => e.HeldId == id);
        }
    }
}
