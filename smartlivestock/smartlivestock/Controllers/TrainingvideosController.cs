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
    public class TrainingvideosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrainingvideosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Trainingvideos
        public async Task<IActionResult> Index()
        {
              return View(await _context.Trainingvideo.ToListAsync());
        }

        // GET: Trainingvideos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Trainingvideo == null)
            {
                return NotFound();
            }

            var trainingvideo = await _context.Trainingvideo
                .FirstOrDefaultAsync(m => m.vdoId == id);
            if (trainingvideo == null)
            {
                return NotFound();
            }

            return View(trainingvideo);
        }

        // GET: Trainingvideos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trainingvideos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("vdoId,VideoName,videoLink,CreateDate,Username")] Trainingvideo trainingvideo)
        {
            if (ModelState.IsValid)
            {
                trainingvideo.CreateDate = DateTime.Now;
                trainingvideo.Username = User.Identity.Name.Split('@')[0];
                _context.Add(trainingvideo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trainingvideo);
        }

        // GET: Trainingvideos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Trainingvideo == null)
            {
                return NotFound();
            }

            var trainingvideo = await _context.Trainingvideo.FindAsync(id);
            if (trainingvideo == null)
            {
                return NotFound();
            }
            return View(trainingvideo);
        }

        // POST: Trainingvideos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("vdoId,VideoName,videoLink,CreateDate,Username")] Trainingvideo trainingvideo)
        {
            if (id != trainingvideo.vdoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    trainingvideo.CreateDate = DateTime.Now;
                    trainingvideo.Username = User.Identity.Name.Split('@')[0];
                    _context.Update(trainingvideo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingvideoExists(trainingvideo.vdoId))
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
            return View(trainingvideo);
        }

        // GET: Trainingvideos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Trainingvideo == null)
            {
                return NotFound();
            }

            var trainingvideo = await _context.Trainingvideo
                .FirstOrDefaultAsync(m => m.vdoId == id);
            if (trainingvideo == null)
            {
                return NotFound();
            }

            return View(trainingvideo);
        }

        // POST: Trainingvideos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Trainingvideo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Trainingvideo'  is null.");
            }
            var trainingvideo = await _context.Trainingvideo.FindAsync(id);
            if (trainingvideo != null)
            {
                _context.Trainingvideo.Remove(trainingvideo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingvideoExists(int id)
        {
          return _context.Trainingvideo.Any(e => e.vdoId == id);
        }
    }
}
