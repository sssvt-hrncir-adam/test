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
using Microsoft.Extensions.Logging;
using SmsServer.Data.Enums;
using SmsServer.Data.Models;

namespace SmsServer.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly SmsDbContext _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(SmsDbContext db, ILogger<HomeController> logger)
        {
            _db = db;
            _logger = logger;
        }

        //SmsDBAccessLayer empdb = new SmsDBAccessLayer();

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

        [HttpGet]
        public IActionResult AddSms()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSms(NewSmsModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                //    string resp = empdb.AddNewSms(model);
                //    TempData["msg"] = resp;
                //}

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var smsModel = new Sms
                {
                    PhoneNumber = model.PhoneNumber,
                    Text = model.Text,
                    Status = (int)SmsStatusEnum.New,
                    CreatedAt = DateTime.UtcNow
                };
                await this._db.SmsSet.AddAsync(smsModel);
                await this._db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "Cannot save new sms.");
                TempData["msg"] = "Cannot save new sms";
            }
            return RedirectToAction(nameof(SmsList));
        }

        [HttpGet]
        public IActionResult SmsDetails(int id)
        {
            return View();
        }
    }
}
