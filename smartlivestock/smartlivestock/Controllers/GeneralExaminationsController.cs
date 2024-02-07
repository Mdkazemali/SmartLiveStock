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
    public class GeneralExaminationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GeneralExaminationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GeneralExaminations
        public async Task<IActionResult> Index()
        {
              return View(await _context.GeneralExamination.ToListAsync());
        }

        // GET: GeneralExaminations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GeneralExamination == null)
            {
                return NotFound();
            }

            var generalExamination = await _context.GeneralExamination
                .FirstOrDefaultAsync(m => m.GenId == id);
            if (generalExamination == null)
            {
                return NotFound();
            }

            return View(generalExamination);
        }

        // GET: GeneralExaminations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GeneralExaminations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GenId,ExamName,CreateDt,UsrName")] GeneralExamination generalExamination)
        {
            if (ModelState.IsValid)
            {
                _context.Add(generalExamination);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(generalExamination);
        }

        // GET: GeneralExaminations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GeneralExamination == null)
            {
                return NotFound();
            }

            var generalExamination = await _context.GeneralExamination.FindAsync(id);
            if (generalExamination == null)
            {
                return NotFound();
            }
            return View(generalExamination);
        }

        // POST: GeneralExaminations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GenId,ExamName,CreateDt,UsrName")] GeneralExamination generalExamination)
        {
            if (id != generalExamination.GenId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(generalExamination);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeneralExaminationExists(generalExamination.GenId))
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
            return View(generalExamination);
        }

        // GET: GeneralExaminations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GeneralExamination == null)
            {
                return NotFound();
            }

            var generalExamination = await _context.GeneralExamination
                .FirstOrDefaultAsync(m => m.GenId == id);
            if (generalExamination == null)
            {
                return NotFound();
            }

            return View(generalExamination);
        }

        // POST: GeneralExaminations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GeneralExamination == null)
            {
                return Problem("Entity set 'ApplicationDbContext.GeneralExamination'  is null.");
            }
            var generalExamination = await _context.GeneralExamination.FindAsync(id);
            if (generalExamination != null)
            {
                _context.GeneralExamination.Remove(generalExamination);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GeneralExaminationExists(int id)
        {
          return _context.GeneralExamination.Any(e => e.GenId == id);
        }
    }
}
