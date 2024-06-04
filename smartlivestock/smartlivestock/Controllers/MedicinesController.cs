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
    public class MedicinesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedicinesController(ApplicationDbContext context)
        {
            _context = context;
        }

    

        public async Task<IActionResult> Index(string category, DateTime? frmDatesearch, DateTime? ToDatesearch, int pp, int page = 1, int pageSize = 50)
        {
            ViewData["category"] = category;
            var custquery = from x in _context.Medicines select x;
            if (!String.IsNullOrEmpty(category))
            {
                custquery = custquery.Where(x => x.MedName.Contains(category));
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
            var pagedQuery = custquery.OrderByDescending(x => x.MedId).Skip(skip).Take(pageSize).AsNoTracking();

            // Pass the pagination information to the view
            ViewData["Page"] = page;
            ViewData["PageSize"] = pageSize;
            ViewData["TotalPages"] = totalPages;
            ViewData["TotalRecords"] = totalRecords;

            return View(await pagedQuery.ToListAsync());
        }




        // GET: Medicines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Medicines == null)
            {
                return NotFound();
            }

            var medicine = await _context.Medicines
                .FirstOrDefaultAsync(m => m.MedId == id);
            if (medicine == null)
            {
                return NotFound();
            }

            return View(medicine);
        }

        // GET: Medicines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medicines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedId,MedName,MediType,GenName,MedDate,UrName")] Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                medicine.MedDate = DateTime.Now;
                medicine.UrName = User.Identity.Name.Split('@')[0];
                _context.Add(medicine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicine);
        }

        // GET: Medicines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Medicines == null)
            {
                return NotFound();
            }

            var me = await _context.Medicines.FindAsync(id);
            if (me == null)
            {
                return NotFound();
            }
            return View(me);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MedId,MedName,MediType,GenName,MedDate,UrName")] Medicine medicine)
        {
            if (id != medicine.MedId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    medicine.MedDate = DateTime.Now;
                    medicine.UrName = User.Identity.Name.Split('@')[0];
                    _context.Update(medicine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicineExists(medicine.MedId))
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
            return View(medicine);
        }

        // GET: Medicines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Medicines == null)
            {
                return NotFound();
            }

            var medicine = await _context.Medicines
                .FirstOrDefaultAsync(m => m.MedId == id);
            if (medicine == null)
            {
                return NotFound();
            }

            return View(medicine);
        }

        // POST: Medicines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Medicines == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Medicines'  is null.");
            }
            var medicine = await _context.Medicines.FindAsync(id);
            if (medicine != null)
            {
                _context.Medicines.Remove(medicine);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicineExists(int id)
        {
          return _context.Medicines.Any(e => e.MedId == id);
        }
    }
}
