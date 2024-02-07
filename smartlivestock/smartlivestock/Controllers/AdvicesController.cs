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
    public class AdvicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdvicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        //// GET: Advices
        //public async Task<IActionResult> Index()
        //{
        //      return View(await _context.Advices.ToListAsync());
        //}


        // GET: Benificiaries
        public async Task<IActionResult> Index(string category, DateTime? frmDatesearch, DateTime? ToDatesearch, int pp, int page = 1, int pageSize = 50)
        {
            ViewData["category"] = category;
            var custquery = from x in _context.Advices select x;
            if (!String.IsNullOrEmpty(category))
            {
                custquery = custquery.Where(x => x.AdvName.Contains(category));
            }

            // for page setups

            int p;
            if (pp == 0)
            {
                p = 8;

            }
            else
            {
                p = pp;
            }

            ViewData["pp"] = p;
            pageSize = p;



            // Count the total number of records
            var totalRecords = await custquery.CountAsync();

            // Calculate the number of pages
            var totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

            // Validate the current page value
            page = Math.Max(1, Math.Min(totalPages, page));

            // Calculate the number of records to skip
            var skip = (page - 1) * pageSize;

            // Apply pagination and ordering
            var pagedQuery = custquery.OrderByDescending(x => x.AdvId).Skip(skip).Take(pageSize).AsNoTracking();

            // Pass the pagination information to the view
            ViewData["Page"] = page;
            ViewData["PageSize"] = pageSize;
            ViewData["TotalPages"] = totalPages;
            ViewData["TotalRecords"] = totalRecords;

            return View(await pagedQuery.ToListAsync());
        }






        // GET: Advices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Advices == null)
            {
                return NotFound();
            }

            var advice = await _context.Advices
                .FirstOrDefaultAsync(m => m.AdvId == id);
            if (advice == null)
            {
                return NotFound();
            }

            return View(advice);
        }

        // GET: Advices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Advices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdvId,AdvName,AdvDate,UrName")] Advice advice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(advice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(advice);
        }

        // GET: Advices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Advices == null)
            {
                return NotFound();
            }

            var advice = await _context.Advices.FindAsync(id);
            if (advice == null)
            {
                return NotFound();
            }
            return View(advice);
        }

        // POST: Advices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdvId,AdvName,AdvDate,UrName")] Advice advice)
        {
            if (id != advice.AdvId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(advice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdviceExists(advice.AdvId))
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
            return View(advice);
        }

        // GET: Advices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Advices == null)
            {
                return NotFound();
            }

            var advice = await _context.Advices
                .FirstOrDefaultAsync(m => m.AdvId == id);
            if (advice == null)
            {
                return NotFound();
            }

            return View(advice);
        }

        // POST: Advices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Advices == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Advices'  is null.");
            }
            var advice = await _context.Advices.FindAsync(id);
            if (advice != null)
            {
                _context.Advices.Remove(advice);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdviceExists(int id)
        {
          return _context.Advices.Any(e => e.AdvId == id);
        }
    }
}
