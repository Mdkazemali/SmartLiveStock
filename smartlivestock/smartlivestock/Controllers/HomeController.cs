﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using smartlivestock.Data;
using smartlivestock.Models;
using smartlivestock.UserInfoModelView;
using System.Diagnostics;

namespace smartlivestock.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHost;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IWebHostEnvironment webHost)
        {
            _logger = logger;
            _context = context;
            _webHost = webHost;
        }

        public IActionResult Index()
        {
            List<Trainingvideo> trainingvideodata = GetVideoData();

            var model = new UserRoleViewModel
            {
                VideoDataList = trainingvideodata
            };

            // Calculate and set the time difference
            //model.TimeCalculations();

            return View(model);
          
           
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        // for user informatio update


        [HttpGet]  
        public IActionResult UserInformationsUpdated(string loginId)
        {
            var facilityRegistryList = _context.FacilityRegistry
                                      .Select(x => new { x.FacilityId, x.OrganizationName })
                                      .ToList();
            ViewBag.FacilityRegistryId = new SelectList(facilityRegistryList, "FacilityId", "OrganizationName");

            var info = _context.UserInformation.FirstOrDefault(x => x.LoginId == loginId);

            if (info == null)
            {
                return NotFound();
            }

            return View(info);
        }


        [HttpPost]
        public IActionResult UserInformationsUpdated(string loginId, UserInformation userInformation)
        {
            var facilityRegistryList = _context.FacilityRegistry
                                     .Select(x => new { x.FacilityId, x.OrganizationName })
                                     .ToList();
            ViewBag.FacilityRegistryId = new SelectList(facilityRegistryList, "FacilityId", "OrganizationName");




            if (userInformation.ProfilePhoto != null)
            {
                string uniqueFileName = GetProfilePhotoFileName(userInformation);
                userInformation.PhotoUrl = uniqueFileName;
            }

            if (ModelState.IsValid)
            {

                _context.Attach(userInformation);
                _context.Entry(userInformation).State = EntityState.Modified;

                _context.SaveChanges();

                return RedirectToAction(nameof(Index));

            }
           

            return View(userInformation);
        }





        private string GetProfilePhotoFileName(UserInformation customer)
        {
            string uniqueFileName = null;

            if (customer.ProfilePhoto != null)
            {
                string uploadsFolder = Path.Combine(_webHost.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + customer.ProfilePhoto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    customer.ProfilePhoto.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }



        [HttpGet]
        public IActionResult PhotoUrl()
        {
            var loginId = User.Identity.Name;
            var info = _context.UserInformation.FirstOrDefault(x => x.LoginId == loginId);

            var viewModel = new UserInfoViewModel
            {
                Name = User.Identity.Name,
                PhotoUrl = (info != null) ? info.PhotoUrl : null
            };

            return View(viewModel);
        }




       

        public IActionResult Home()
        {
            List<Trainingvideo> trainingvideodata = GetVideoData();

            var model = new UserRoleViewModel
            {
                VideoDataList = trainingvideodata
            };

            // Calculate and set the time difference
            //model.TimeCalculations();

            return View(model);
        }

        private List<Trainingvideo> GetVideoData()
        {
            List<Trainingvideo> videwdata = _context.Trainingvideo.ToList();


            return videwdata;
        }



    }
}
