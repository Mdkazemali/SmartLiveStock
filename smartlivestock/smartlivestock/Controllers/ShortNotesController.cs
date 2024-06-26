﻿using System;
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
    public class ShortNotesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShortNotesController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: ShortNotes
        public async Task<IActionResult> Index(string category, DateTime? frmDatesearch, DateTime? ToDatesearch, int pp, int page = 1, int pageSize = 50)
        {
            ViewData["category"] = category;
            var custquery = from x in _context.ShortNotes select x;
            if (!String.IsNullOrEmpty(category))
            {
                custquery = custquery.Where(x => x.ShortNoteName.Contains(category));
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
            var pagedQuery = custquery.OrderByDescending(x => x.ShortId).Skip(skip).Take(pageSize).AsNoTracking();

            // Pass the pagination information to the view
            ViewData["Page"] = page;
            ViewData["PageSize"] = pageSize;
            ViewData["TotalPages"] = totalPages;
            ViewData["TotalRecords"] = totalRecords;

            return View(await pagedQuery.ToListAsync());
        }


        // GET: ShortNotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ShortNotes == null)
            {
                return NotFound();
            }

            var shortNote = await _context.ShortNotes
                .FirstOrDefaultAsync(m => m.ShortId == id);
            if (shortNote == null)
            {
                return NotFound();
            }

            return View(shortNote);
        }

        // GET: ShortNotes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShortNotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShortId,ShortNoteName,SrUser,ShortDt")] ShortNote shortNote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shortNote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shortNote);
        }

        // GET: ShortNotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ShortNotes == null)
            {
                return NotFound();
            }

            var shortNote = await _context.ShortNotes.FindAsync(id);
            if (shortNote == null)
            {
                return NotFound();
            }
            return View(shortNote);
        }

        // POST: ShortNotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShortId,ShortNoteName,SrUser,ShortDt")] ShortNote shortNote)
        {
            if (id != shortNote.ShortId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shortNote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShortNoteExists(shortNote.ShortId))
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
            return View(shortNote);
        }

        // GET: ShortNotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ShortNotes == null)
            {
                return NotFound();
            }

            var shortNote = await _context.ShortNotes
                .FirstOrDefaultAsync(m => m.ShortId == id);
            if (shortNote == null)
            {
                return NotFound();
            }

            return View(shortNote);
        }

        // POST: ShortNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ShortNotes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ShortNotes'  is null.");
            }
            var shortNote = await _context.ShortNotes.FindAsync(id);
            if (shortNote != null)
            {
                _context.ShortNotes.Remove(shortNote);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShortNoteExists(int id)
        {
          return _context.ShortNotes.Any(e => e.ShortId == id);
        }
    }
}
