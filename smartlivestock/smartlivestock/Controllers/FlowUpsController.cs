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
    public class FlowUpsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FlowUpsController(ApplicationDbContext context)
        {
            _context = context;
        }

     
        public async Task<IActionResult> Index(string category, DateTime? frmDatesearch, DateTime? ToDatesearch, int pp, int page = 1, int pageSize = 50)
        {
            ViewData["category"] = category;
            var custquery = from x in _context.FlowUp select x;
            if (!String.IsNullOrEmpty(category))
            {
                custquery = custquery.Where(x => x.FloName.Contains(category));
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
            var pagedQuery = custquery.OrderByDescending(x => x.FloId).Skip(skip).Take(pageSize).AsNoTracking();

            // Pass the pagination information to the view
            ViewData["Page"] = page;
            ViewData["PageSize"] = pageSize;
            ViewData["TotalPages"] = totalPages;
            ViewData["TotalRecords"] = totalRecords;

            return View(await pagedQuery.ToListAsync());
        }


        // GET: FlowUps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FlowUp == null)
            {
                return NotFound();
            }

            var flowUp = await _context.FlowUp
                .FirstOrDefaultAsync(m => m.FloId == id);
            if (flowUp == null)
            {
                return NotFound();
            }

            return View(flowUp);
        }

        // GET: FlowUps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FlowUps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FloId,FloName,FloDate,UrName")] FlowUp flowUp)
        {
            if (ModelState.IsValid)
            {
                flowUp.FloDate = DateTime.Now;
                flowUp.UrName = User.Identity.Name.Split('@')[0];
                _context.Add(flowUp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flowUp);
        }

        // GET: FlowUps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FlowUp == null)
            {
                return NotFound();
            }

            var flowUp = await _context.FlowUp.FindAsync(id);
            if (flowUp == null)
            {
                return NotFound();
            }
            return View(flowUp);
        }

        // POST: FlowUps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FloId,FloName,FloDate,UrName")] FlowUp flowUp)
        {
            if (id != flowUp.FloId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    flowUp.FloDate = DateTime.Now;
                    flowUp.UrName = User.Identity.Name.Split('@')[0];
                    _context.Update(flowUp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlowUpExists(flowUp.FloId))
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
            return View(flowUp);
        }

        // GET: FlowUps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FlowUp == null)
            {
                return NotFound();
            }

            var flowUp = await _context.FlowUp
                .FirstOrDefaultAsync(m => m.FloId == id);
            if (flowUp == null)
            {
                return NotFound();
            }

            return View(flowUp);
        }

        // POST: FlowUps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FlowUp == null)
            {
                return Problem("Entity set 'ApplicationDbContext.FlowUp'  is null.");
            }
            var flowUp = await _context.FlowUp.FindAsync(id);
            if (flowUp != null)
            {
                _context.FlowUp.Remove(flowUp);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlowUpExists(int id)
        {
          return _context.FlowUp.Any(e => e.FloId == id);
        }
    }
}
