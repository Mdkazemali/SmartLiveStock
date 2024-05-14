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
    public class ReferredToesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReferredToesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReferredToes
        public async Task<IActionResult> Index(string category, DateTime? frmDatesearch, DateTime? ToDatesearch, int pp, int page = 1, int pageSize = 50)
        {
            ViewData["category"] = category;
            var custquery = from x in _context.ReferredTo select x;
            if (!String.IsNullOrEmpty(category))
            {
                custquery = custquery.Where(x => x.ReferredName.Contains(category));
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
            var pagedQuery = custquery.OrderByDescending(x => x.ReferredId).Skip(skip).Take(pageSize).AsNoTracking();

            // Pass the pagination information to the view
            ViewData["Page"] = page;
            ViewData["PageSize"] = pageSize;
            ViewData["TotalPages"] = totalPages;
            ViewData["TotalRecords"] = totalRecords;

            return View(await pagedQuery.ToListAsync());
        }





        // GET: ReferredToes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ReferredTo == null)
            {
                return NotFound();
            }

            var referredTo = await _context.ReferredTo
                .FirstOrDefaultAsync(m => m.ReferredId == id);
            if (referredTo == null)
            {
                return NotFound();
            }

            return View(referredTo);
        }

        // GET: ReferredToes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReferredToes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReferredId,ReferredName,createDate,UserName")] ReferredTo referredTo)
        {
            if (ModelState.IsValid)
            {

                referredTo.createDate = DateTime.Now;
                referredTo.UserName = User.Identity.Name.Split('@')[0];
                _context.Add(referredTo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(referredTo);
        }

        // GET: ReferredToes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ReferredTo == null)
            {
                return NotFound();
            }

            var referredTo = await _context.ReferredTo.FindAsync(id);
            if (referredTo == null)
            {
                return NotFound();
            }
            return View(referredTo);
        }

        // POST: ReferredToes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReferredId,ReferredName,createDate,UserName")] ReferredTo referredTo)
        {
            if (id != referredTo.ReferredId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    referredTo.createDate = DateTime.Now;
                    referredTo.UserName = User.Identity.Name.Split('@')[0];
                    _context.Update(referredTo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReferredToExists(referredTo.ReferredId))
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
            return View(referredTo);
        }

        // GET: ReferredToes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ReferredTo == null)
            {
                return NotFound();
            }

            var referredTo = await _context.ReferredTo
                .FirstOrDefaultAsync(m => m.ReferredId == id);
            if (referredTo == null)
            {
                return NotFound();
            }

            return View(referredTo);
        }

        // POST: ReferredToes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ReferredTo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ReferredTo'  is null.");
            }
            var referredTo = await _context.ReferredTo.FindAsync(id);
            if (referredTo != null)
            {
                _context.ReferredTo.Remove(referredTo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReferredToExists(int id)
        {
          return _context.ReferredTo.Any(e => e.ReferredId == id);
        }
    }
}
