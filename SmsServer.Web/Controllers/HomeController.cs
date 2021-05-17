using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmsServer.Data;
using SmsServer.Web.Models;
using Microsoft.EntityFrameworkCore;
using AspNetCoreCURDMVC_Demo.Models;

namespace SmsServer.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly SmsDbContext _db;

        public HomeController(SmsDbContext db)
        {
            _db = db;
        }

        SmsDBAccessLayer empdb = new SmsDBAccessLayer();

        [HttpGet]
        public IActionResult AddSms()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSms([Bind] NewSmsModel newSmsModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string resp = empdb.AddNewSms(newSmsModel);
                    TempData["msg"] = resp;
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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

        public IActionResult SmsList()
        {
            var list = _db.SmsSet.Select(x => new SmsModel
            {
                Id = x.Id,
                PhoneNumber = x.PhoneNumber,
                CreatedAt = x.CreatedAt,
                SentAt = x.SentAt,
                Status = x.Status
            }).ToList();
            
            return View(list);
        }
    }
}
