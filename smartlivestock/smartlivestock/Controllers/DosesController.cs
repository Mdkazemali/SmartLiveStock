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
    public class DosesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DosesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Doses
        public async Task<IActionResult> Index()
        {
              return View(await _context.Doses.ToListAsync());
        }

        // GET: Doses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Doses == null)
            {
                return NotFound();
            }

            var doses = await _context.Doses
                .FirstOrDefaultAsync(m => m.DosesId == id);
            if (doses == null)
            {
                return NotFound();
            }

            return View(doses);
        }

        // GET: Doses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DosesId,Morning,Afternoon,Evening,Days,DosesName,DosesDate,UrName")] Doses doses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doses);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doses);
        }

        // GET: Doses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Doses == null)
            {
                return NotFound();
            }

            var doses = await _context.Doses.FindAsync(id);
            if (doses == null)
            {
                return NotFound();
            }
            return View(doses);
        }

        // POST: Doses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DosesId,Morning,Afternoon,Evening,Days,DosesName,DosesDate,UrName")] Doses doses)
        {
            if (id != doses.DosesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DosesExists(doses.DosesId))
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
            return View(doses);
        }

        // GET: Doses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Doses == null)
            {
                return NotFound();
            }

            var doses = await _context.Doses
                .FirstOrDefaultAsync(m => m.DosesId == id);
            if (doses == null)
            {
                return NotFound();
            }

            return View(doses);
        }

        // POST: Doses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Doses == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Doses'  is null.");
            }
            var doses = await _context.Doses.FindAsync(id);
            if (doses != null)
            {
                _context.Doses.Remove(doses);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DosesExists(int id)
        {
          return _context.Doses.Any(e => e.DosesId == id);
        }
    }
}
