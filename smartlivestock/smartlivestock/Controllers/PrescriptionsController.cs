using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinkToPdf.Contracts;
using DinkToPdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using smartlivestock.Data;
using smartlivestock.Data.Migrations;
using smartlivestock.Models;
using System.IO;

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



        [Authorize]
        public IActionResult Index(string name, string nidsearch, string frname, string Regino, DateTime? frmDatesearch, DateTime? ToDatesearch, int pp, int page = 1, int pageSize = 50)
        {
            List<PrescriptionViewModel> totalprescriptionlist = GetTotalPrescriptionlist(name, nidsearch, frname, Regino, frmDatesearch, ToDatesearch, pp, page, pageSize);

            var model = new PrescriptionViewModel
            {
                TotalPrescriptionview = totalprescriptionlist,
            };

            return View(model);
        }

        private List<PrescriptionViewModel> GetTotalPrescriptionlist(string name, string nidsearch, string frname, string Regino, DateTime? frmDatesearch, DateTime? ToDatesearch, int pp, int page = 1, int pageSize = 50)
        {
            var query = from A in _context.Prescription
                        join D in _context.Registration on A.RegistrationId equals D.RegiId

                        group A by new { D.ReName, D.Phone, D.Gender, D.Ages, A.PresName, A.PresDate.Date, } into grouped
                        select new PrescriptionViewModel
                        {


                            PresName = grouped.Key.PresName,
                            ReName = grouped.Key.ReName,
                            Phone = grouped.Key.Phone,
                            Gender = grouped.Key.Gender,
                            Ages = grouped.Key.Ages,
                            PresDate = grouped.Key.Date,



                        };

            // Apply filters

            ViewData["name"] = name;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.ReName.Contains(name));
            }
            ViewData["frname"] = frname;
            if (!string.IsNullOrEmpty(frname))
            {
                query = query.Where(x => x.PresName.Contains(frname));
            }
            ViewData["Regino"] = Regino;
            if (!string.IsNullOrEmpty(Regino))
            {
                query = query.Where(x => x.Phone.Contains(Regino));
            }

            ViewData["frmDatesearch"] = frmDatesearch;
            if (frmDatesearch.HasValue)
            {
                query = query.Where(x =>
                    x.PresDate.Date >= frmDatesearch.Value.Date);
            }
            ViewData["ToDatesearch"] = ToDatesearch;
            if (ToDatesearch.HasValue)
            {
                query = query.Where(x =>
                    x.PresDate.Date <= ToDatesearch.Value.Date);
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
            var totalRecords = query.Count();

            // Calculate the number of pages
            var totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

            // Validate the current page value
            page = Math.Max(1, Math.Min(totalPages, page));

            // Calculate the number of records to skip
            var skip = (page - 1) * pageSize;

            // Apply pagination and ordering
            var pagedQuery = query.OrderByDescending(x => x.PresName).Skip(skip).Take(pageSize).AsNoTracking();

            // Pass the pagination information to the view
            ViewData["Page"] = page;
            ViewData["PageSize"] = pageSize;
            ViewData["TotalPages"] = totalPages;
            ViewData["TotalRecords"] = totalRecords;

            return pagedQuery.ToList();


        }



        //Prescription/Create/Get
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {


            var viewModel = new PrescriptionViewModel
            {
                Prescriptions = new List<Prescription> { new Prescription() },
                SinglePrescrip = new Prescription()
            };
            ViewData["ChiefComplaintId"] = new SelectList(_context.ChiefComplaint, "ChiId", "ChiName");
            ViewData["AdviceId"] = new SelectList(_context.Advices, "AdvId", "AdvName");
            ViewData["DiagnosisId"] = new SelectList(_context.Diagnosis, "DiagId", "DiagName");
            ViewData["DosesId"] = new SelectList(_context.Doses, "DosesId", "DosesName");
            ViewData["FlowUpId"] = new SelectList(_context.FlowUp, "FloId", "FloName");
            ViewData["GeneralExaminationId"] = new SelectList(_context.GeneralExamination, "GenId", "ExamName");
            ViewData["InvastigationId"] = new SelectList(_context.Invastigations, "InvId", "InvName");
            ViewData["MedicineId"] = new SelectList(_context.Medicines, "MedId", "MedName");
            ViewData["ReferredId"] = new SelectList(_context.ReferredTo, "ReferredId", "ReferredName");




            ViewData["RegistraId"] = new SelectList(_context.Registration.Select(c => new
            {
                RegiId = c.RegiId,
                PtnId = c.PtnId,
                Name = c.ReName,
                Phone = c.Phone,

                ConcatenatedNames = $"{c.PtnId}-{c.ReName} - {c.Phone}"
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
                return RedirectToAction("PresPrint", new { id = prsname });

              
            }

            ViewData["ChiefComplaintId"] = new SelectList(_context.ChiefComplaint, "ChiId", "ChiName");
            ViewData["AdviceId"] = new SelectList(_context.Advices, "AdvId", "AdvName");
            ViewData["DiagnosisId"] = new SelectList(_context.Diagnosis, "DiagId", "DiagName");
            ViewData["DosesId"] = new SelectList(_context.Doses, "DosesId", "DosesName");
            ViewData["FlowUpId"] = new SelectList(_context.FlowUp, "FloId", "FloName");
            ViewData["GeneralExaminationId"] = new SelectList(_context.GeneralExamination, "GenId", "ExamName");
            ViewData["InvastigationId"] = new SelectList(_context.Invastigations, "InvId", "InvName");
            ViewData["MedicineId"] = new SelectList(_context.Medicines, "MedId", "MedName");
            ViewData["RegistraId"] = new SelectList(_context.Registration.Select(c => new
            {
                RegiId = c.RegiId,
                PtnId = c.PtnId,
                Name = c.ReName,
                Phone = c.Phone,

                ConcatenatedNames = $"{c.PtnId}-{c.ReName} - {c.Phone}"
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



        //[Authorize]
        //public IActionResult PresPrint(string Id)
        //{
        //    var DrInformation = _context.UserInformation.Where(x=>x.LoginId == User.Identity.Name).FirstOrDefault();

        //    List<Prescription> prescriptions = _context.Prescription
        //        .Include(p => p.Advice)
        //        .Include(p => p.ChiefComplaint)
        //        .Include(p => p.Diagnosis)
        //        .Include(p => p.Doses)
        //        .Include(p => p.FlowUp)
        //        .Include(p => p.GeneralExamination)
        //        .Include(p => p.Invastigation)
        //        .Include(p => p.Medicine)
        //        .Include(p => p.Registration)
        //        .Include(p => p.ReferredTo)
        //        .Where(c => c.PresName == Id)
        //        .ToList();

        //    var model = prescriptions.Select(p => new PrescriptionViewModel
        //    {
        //        // for Dor Information 
        //        UserFullName = DrInformation.UserFullName,
        //        Gender=DrInformation.Gender,           
        //        Address =DrInformation.Address,
        //        PhoneNumber =DrInformation.PhoneNumber,




        //        // for Patient Information


        //        // for  

        //        ChiName = p.ChiefComplaint?.ChiName,
        //        ExamName = p.GeneralExamination?.ExamName,
        //        DiagName = p.Diagnosis?.DiagName,
        //        InvName = p.Invastigation?.InvName,

        //        MedName = p.Medicine?.MedName,
        //        AdvName = p.Advice?.AdvName,
        //        FloName = p.FlowUp?.FloName,
        //        ReferredName = p.ReferredTo?.ReferredName,
        //        Sokal = p.Sokal,
        //        Duput = p.Duput,
        //        Rat = p.Rat,


        //    }).ToList();

        //    return View(model);
        //}



        public IActionResult PresPrint(string Id)
        {
            var userInformation = _context.UserInformation
                .Where(x => x.LoginId == User.Identity.Name)
                .GroupBy(x => new
                {
                    x.UserFullName,
                    x.Gender,
                    x.Address,
                    x.PhoneNumber
                })
                .Select(g => new
                {
                    UserFullName = g.Key.UserFullName,
                    Gender = g.Key.Gender,
                    Address = g.Key.Address,
                    PhoneNumber = g.Key.PhoneNumber
                })
                .FirstOrDefault();

            if (userInformation == null)
            {
                return NotFound(); // Or handle this scenario as needed
            }

            List<Prescription> prescriptions = _context.Prescription
                .Include(p => p.Advice)
                .Include(p => p.ChiefComplaint)
                .Include(p => p.Diagnosis)
                .Include(p => p.Doses)
                .Include(p => p.FlowUp)
                .Include(p => p.GeneralExamination)
                .Include(p => p.Invastigation)
                .Include(p => p.Medicine)
                .Include(p => p.Registration)
                .Include(p => p.ReferredTo)
                .Where(c => c.PresName == Id)
                .ToList();

            var model = prescriptions.Select(p => new PrescriptionViewModel
            {
                // Dr. Information Information
                UserFullName = userInformation.UserFullName,
                Gender = userInformation.Gender,
                Address = userInformation.Address,
                PhoneNumber = userInformation.PhoneNumber,

                // Patient Informations
                ReName=p.Registration?.ReName,
                PtnId=p.Registration?.PtnId,
                GenderRe=p.Registration?.Gender,
                Phone =p.Registration?.Phone,
                Ages=p.Registration?.Ages,

                

                // Prescription Information
                ChiName = p.ChiefComplaint?.ChiName,
                ExamName = p.GeneralExamination?.ExamName,
                DiagName = p.Diagnosis?.DiagName,
                InvName = p.Invastigation?.InvName,
                MedName = p.Medicine?.MedName,
                AdvName = p.Advice?.AdvName,
                FloName = p.FlowUp?.FloName,
                ReferredName = p.ReferredTo?.ReferredName,
                Sokal = p.Sokal,
                Duput = p.Duput,
                Rat = p.Rat,
            }).ToList();

            return View(model);
        }





    }
}


