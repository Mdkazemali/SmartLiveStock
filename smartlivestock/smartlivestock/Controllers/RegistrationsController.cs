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
    public class RegistrationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistrationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Registrations
      


        public async Task<IActionResult> Index(string category,string ptid, string phn, DateTime? frmDatesearch, DateTime? ToDatesearch, int pp, int page = 1, int pageSize = 50)
        {
            ViewData["category"] = category;
            var custquery = from x in _context.Registration select x;
            if (!String.IsNullOrEmpty(category))
            {
                custquery = custquery.Where(x => x.ReName.Contains(category));
            }
            ViewData["ptid"] = ptid;
            if (!String.IsNullOrEmpty(ptid))
            {
                custquery = custquery.Where(x => x.PtnId.Contains(ptid));
            }
             
            ViewData["phn"] = phn;
            if (!String.IsNullOrEmpty(phn))
            {
                custquery = custquery.Where(x => x.Phone.Contains(phn));
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
            var pagedQuery = custquery.OrderByDescending(x => x.RegiId).Skip(skip).Take(pageSize).AsNoTracking();

            // Pass the pagination information to the view
            ViewData["Page"] = page;
            ViewData["PageSize"] = pageSize;
            ViewData["TotalPages"] = totalPages;
            ViewData["TotalRecords"] = totalRecords;

            return View(await pagedQuery.ToListAsync());
        }



        // GET: Registrations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Registration == null)
            {
                return NotFound();
            }

            var registration = await _context.Registration
                .FirstOrDefaultAsync(m => m.RegiId == id);
            if (registration == null)
            {
                return NotFound();
            }

            return View(registration);
        }

        // GET: Registrations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Registrations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegiId,ReName,PtnId,Phone,Gender,Ages,CreateDAte,UsrName")] Registration registration)
        {
            if (ModelState.IsValid)
            {
              
                var lastCustomer = _context.Registration.OrderByDescending(t => t.RegiId)?.FirstOrDefault();

                // Check if lastCustomer is not null before accessing its Id property
                var lastId = lastCustomer != null ? lastCustomer.RegiId : 0;

                var wonId = lastId + 1;
                var dt = DateTime.Now.ToString("MMyy");
                var regiNo = "ISLS" + dt + wonId.ToString();

                registration.PtnId= regiNo;
                registration.CreateDAte = DateTime.Now;
                registration.UsrName = User.Identity.Name.Split('@')[0];
                _context.Add(registration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registration);
        }

        // GET: Registrations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Registration == null)
            {
                return NotFound();
            }

            var registration = await _context.Registration.FindAsync(id);
            if (registration == null)
            {
                return NotFound();
            }
            return View(registration);
        }

        // POST: Registrations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RegiId,ReName,PtnId,Phone,Gender,Ages,CreateDAte,UsrName")] Registration registration)
        {
            if (id != registration.RegiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    registration.CreateDAte = DateTime.Now;
                    registration.UsrName = User.Identity.Name.Split('@')[0];
                    _context.Update(registration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistrationExists(registration.RegiId))
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
            return View(registration);
        }

        // GET: Registrations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Registration == null)
            {
                return NotFound();
            }

            var registration = await _context.Registration
                .FirstOrDefaultAsync(m => m.RegiId == id);
            if (registration == null)
            {
                return NotFound();
            }

            return View(registration);
        }

        // POST: Registrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Registration == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Registration'  is null.");
            }
            var registration = await _context.Registration.FindAsync(id);
            if (registration != null)
            {
                _context.Registration.Remove(registration);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistrationExists(int id)
        {
          return _context.Registration.Any(e => e.RegiId == id);
        }
    }
}
