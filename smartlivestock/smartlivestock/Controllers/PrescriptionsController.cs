using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using smartlivestock.Data;
using smartlivestock.Models;

namespace smartlivestock.Controllers
{
    [Authorize]
    public class PrescriptionsController : Controller
    {
       
        private readonly ApplicationDbContext _context;

        public PrescriptionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Prescriptions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Prescription.Include(p => p.Advice).Include(p => p.ChiefComplaint).Include(p => p.Diagnosis).Include(p => p.Doses).Include(p => p.FlowUp).Include(p => p.GeneralExamination).Include(p => p.Invastigation).Include(p => p.Medicine).Include(p => p.Registration);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Prescriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Prescription == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescription
                .Include(p => p.Advice)
                .Include(p => p.ChiefComplaint)
                .Include(p => p.Diagnosis)
                .Include(p => p.Doses)
                .Include(p => p.FlowUp)
                .Include(p => p.GeneralExamination)
                .Include(p => p.Invastigation)
                .Include(p => p.Medicine)
                .Include(p => p.Registration)
                .FirstOrDefaultAsync(m => m.PresId == id);
            if (prescription == null)
            {
                return NotFound();
            }

            return View(prescription);
        }


        //Orision/Create/Get
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {

            var viewModel = new PrescriptionViewModel
            {
                Prescriptions = new List<Prescription> { new Prescription() },
                SinglePrescrip = new Prescription()
            };
            ViewData["ChiefComplaintId"] = new SelectList(_context.ChiefComplaint, "ChiId", "ChiId");
            ViewData["RegistraId"] = new SelectList(_context.Registration.Select(c => new
            {
                RegiId = c.RegiId,
                PtnId = c.PtnId,
                Name = c.Name,
                Phone = c.Phone,
       
                ConcatenatedNames = $"{c.PtnId}-{c.Name} - {c.Phone}"
            })
              .OrderByDescending(c => c.RegiId), "RegiId", "ConcatenatedNames", viewModel.SinglePrescrip.RegistrationId);


            return View(viewModel);
        }


   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PrescriptionViewModel viewModel)
        {
            if (IsOriNameTaken(viewModel.PresName) && IsIdTaken(viewModel.RegistrationId))
            {
                ModelState.AddModelError("RegistrationId", "Registration Name and RegistrationId already exist!");
            }

            var lastCustomer = _context.Prescription.OrderByDescending(t => t.PresId)?.FirstOrDefault();

            // Check if lastCustomer is not null before accessing its Id property
            var lastId = lastCustomer != null ? lastCustomer.PresId : 0;

            var wonId = lastId + 1;
            var dt = DateTime.Now.ToString("MMyy");
            var prsname = "RX" + dt + wonId.ToString();


            if (ModelState.IsValid)
            {
                foreach (var presc in viewModel.Prescriptions)
                {
                    presc.PresName = prsname;
                    presc.RegistrationId = viewModel.SinglePrescrip.RegistrationId;
                    presc.UrName = User.Identity.Name.Split('@')[0];
                    presc.PresDate = DateTime.Now;
                
                   
                }

                _context.Prescription.AddRange(viewModel.Prescriptions);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewData["ChiefComplaintId"] = new SelectList(_context.ChiefComplaint, "ChiId", "ChiId");

            ViewData["RegistraId"] = new SelectList(_context.Registration.Select(c => new
            {
                RegiId = c.RegiId,
                PtnId = c.PtnId,
                Name = c.Name,
                Phone = c.Phone,

                ConcatenatedNames = $"{c.PtnId}-{c.Name} - {c.Phone}"
            })
              .OrderByDescending(c => c.RegiId), "RegiId", "ConcatenatedNames", viewModel.SinglePrescrip.RegistrationId);


            return View(viewModel);
        }


        private bool IsOriNameTaken(String ornm)
        {
            return _context.Prescription.Any(x => x.PresName == ornm);
        }
        private bool IsIdTaken(int idd)
        {
            return _context.Prescription.Any(x => x.RegistrationId == idd);
        }







        //// GET: Prescriptions/Create
        //public IActionResult Create()
        //{
        //    ViewData["AdviceId"] = new SelectList(_context.Advices, "AdvId", "AdvId");
        //    ViewData["ChiefComplaintId"] = new SelectList(_context.ChiefComplaint, "ChiId", "ChiId");
        //    ViewData["DiagnosisId"] = new SelectList(_context.Diagnosis, "DiagId", "DiagId");
        //    ViewData["DosesId"] = new SelectList(_context.Doses, "DosesId", "DosesId");
        //    ViewData["FlowUpId"] = new SelectList(_context.FlowUp, "FloId", "FloId");
        //    ViewData["GeneralExaminationId"] = new SelectList(_context.GeneralExamination, "GenId", "GenId");
        //    ViewData["InvastigationId"] = new SelectList(_context.Invastigations, "InvId", "InvId");
        //    ViewData["MedicineId"] = new SelectList(_context.Medicines, "MedId", "MedId");
        //    ViewData["RegistrationId"] = new SelectList(_context.Registration, "RegiId", "RegiId");
        //    return View();
        //}

        ////POST: Prescriptions/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("PresId,PresName,PresDate,UrName,RegistrationId,ChiefComplaintId,GeneralExaminationId,DiagnosisId,InvastigationId,MedicineId,DosesId,AdviceId,FlowUpId")] Prescription prescription)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.AddRange(prescription);

        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["AdviceId"] = new SelectList(_context.Advices, "AdvId", "AdvId", prescription.AdviceId);
        //    ViewData["ChiefComplaintId"] = new SelectList(_context.ChiefComplaint, "ChiId", "ChiId", prescription.ChiefComplaintId);
        //    ViewData["DiagnosisId"] = new SelectList(_context.Diagnosis, "DiagId", "DiagId", prescription.DiagnosisId);
        //    ViewData["DosesId"] = new SelectList(_context.Doses, "DosesId", "DosesId", prescription.DosesId);
        //    ViewData["FlowUpId"] = new SelectList(_context.FlowUp, "FloId", "FloId", prescription.FlowUpId);
        //    ViewData["GeneralExaminationId"] = new SelectList(_context.GeneralExamination, "GenId", "GenId", prescription.GeneralExaminationId);
        //    ViewData["InvastigationId"] = new SelectList(_context.Invastigations, "InvId", "InvId", prescription.InvastigationId);
        //    ViewData["MedicineId"] = new SelectList(_context.Medicines, "MedId", "MedId", prescription.MedicineId);
        //    ViewData["RegistrationId"] = new SelectList(_context.Registration, "RegiId", "RegiId", prescription.RegistrationId);
        //    return View(prescription);
        //}





        // GET: Prescriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Prescription == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescription.FindAsync(id);
            if (prescription == null)
            {
                return NotFound();
            }
            ViewData["AdviceId"] = new SelectList(_context.Advices, "AdvId", "AdvId", prescription.AdviceId);
            ViewData["ChiefComplaintId"] = new SelectList(_context.ChiefComplaint, "ChiId", "ChiId", prescription.ChiefComplaintId);
            ViewData["DiagnosisId"] = new SelectList(_context.Diagnosis, "DiagId", "DiagId", prescription.DiagnosisId);
            ViewData["DosesId"] = new SelectList(_context.Doses, "DosesId", "DosesId", prescription.DosesId);
            ViewData["FlowUpId"] = new SelectList(_context.FlowUp, "FloId", "FloId", prescription.FlowUpId);
            ViewData["GeneralExaminationId"] = new SelectList(_context.GeneralExamination, "GenId", "GenId", prescription.GeneralExaminationId);
            ViewData["InvastigationId"] = new SelectList(_context.Invastigations, "InvId", "InvId", prescription.InvastigationId);
            ViewData["MedicineId"] = new SelectList(_context.Medicines, "MedId", "MedId", prescription.MedicineId);
            ViewData["RegistrationId"] = new SelectList(_context.Registration, "RegiId", "RegiId", prescription.RegistrationId);
            return View(prescription);
        }

        // POST: Prescriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PresId,PresName,PresDate,UrName,RegistrationId,ChiefComplaintId,GeneralExaminationId,DiagnosisId,InvastigationId,MedicineId,DosesId,AdviceId,FlowUpId")] Prescription prescription)
        {
            if (id != prescription.PresId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prescription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrescriptionExists(prescription.PresId))
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
            ViewData["AdviceId"] = new SelectList(_context.Advices, "AdvId", "AdvId", prescription.AdviceId);
            ViewData["ChiefComplaintId"] = new SelectList(_context.ChiefComplaint, "ChiId", "ChiId", prescription.ChiefComplaintId);
            ViewData["DiagnosisId"] = new SelectList(_context.Diagnosis, "DiagId", "DiagId", prescription.DiagnosisId);
            ViewData["DosesId"] = new SelectList(_context.Doses, "DosesId", "DosesId", prescription.DosesId);
            ViewData["FlowUpId"] = new SelectList(_context.FlowUp, "FloId", "FloId", prescription.FlowUpId);
            ViewData["GeneralExaminationId"] = new SelectList(_context.GeneralExamination, "GenId", "GenId", prescription.GeneralExaminationId);
            ViewData["InvastigationId"] = new SelectList(_context.Invastigations, "InvId", "InvId", prescription.InvastigationId);
            ViewData["MedicineId"] = new SelectList(_context.Medicines, "MedId", "MedId", prescription.MedicineId);
            ViewData["RegistrationId"] = new SelectList(_context.Registration, "RegiId", "RegiId", prescription.RegistrationId);
            return View(prescription);
        }

        // GET: Prescriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Prescription == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescription
                .Include(p => p.Advice)
                .Include(p => p.ChiefComplaint)
                .Include(p => p.Diagnosis)
                .Include(p => p.Doses)
                .Include(p => p.FlowUp)
                .Include(p => p.GeneralExamination)
                .Include(p => p.Invastigation)
                .Include(p => p.Medicine)
                .Include(p => p.Registration)
                .FirstOrDefaultAsync(m => m.PresId == id);
            if (prescription == null)
            {
                return NotFound();
            }

            return View(prescription);
        }

        // POST: Prescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Prescription == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Prescription'  is null.");
            }
            var prescription = await _context.Prescription.FindAsync(id);
            if (prescription != null)
            {
                _context.Prescription.Remove(prescription);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrescriptionExists(int id)
        {
          return _context.Prescription.Any(e => e.PresId == id);
        }


        // Prescription for 





    }
}
