using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using smartlivestock.Data;
using smartlivestock.Models;

namespace smartlivestock.Controllers
{
    public class InvastigationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InvastigationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Invastigations
        public async Task<IActionResult> Index()
        {
              return View(await _context.Invastigations.ToListAsync());
        }

        // GET: Invastigations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Invastigations == null)
            {
                return NotFound();
            }

            var invastigation = await _context.Invastigations
                .FirstOrDefaultAsync(m => m.InvId == id);
            if (invastigation == null)
            {
                return NotFound();
            }

            return View(invastigation);
        }

        // GET: Invastigations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Invastigations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InvId,InvName,InvDate,UrName")] Invastigation invastigation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invastigation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invastigation);
        }

        // GET: Invastigations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Invastigations == null)
            {
                return NotFound();
            }

            var invastigation = await _context.Invastigations.FindAsync(id);
            if (invastigation == null)
            {
                return NotFound();
            }
            return View(invastigation);
        }

        // POST: Invastigations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InvId,InvName,InvDate,UrName")] Invastigation invastigation)
        {
            if (id != invastigation.InvId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invastigation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvastigationExists(invastigation.InvId))
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
            return View(invastigation);
        }

        // GET: Invastigations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Invastigations == null)
            {
                return NotFound();
            }

            var invastigation = await _context.Invastigations
                .FirstOrDefaultAsync(m => m.InvId == id);
            if (invastigation == null)
            {
                return NotFound();
            }

            return View(invastigation);
        }

        // POST: Invastigations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Invastigations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Invastigations'  is null.");
            }
            var invastigation = await _context.Invastigations.FindAsync(id);
            if (invastigation != null)
            {
                _context.Invastigations.Remove(invastigation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvastigationExists(int id)
        {
          return _context.Invastigations.Any(e => e.InvId == id);
        }
    }
}
