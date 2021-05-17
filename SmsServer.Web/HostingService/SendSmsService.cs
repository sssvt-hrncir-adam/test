using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SmsServer.Data;
using SmsServer.Data.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmsServer.Web.HostingService
{
    public class SendSmsService : BackgroundService
    {
        private readonly SmsDbContext _db;
        private readonly ILogger<SendSmsService> _logger;

        public SendSmsService(SmsDbContext db, ILogger<SendSmsService> logger)
        {
            this._db = db;
            this._logger = logger;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            const int delay = 1000; // = 1 sec
            while (!stoppingToken.IsCancellationRequested)
            {
                Debug.WriteLine("A loop started");

                try
                {
                    var newSmsList = await this._db.SmsSet
                        .Where(x => x.Status == (int)SmsStatusEnum.New)
                        .ToListAsync();

                    foreach(var sms in newSmsList)
                    {
                        // send SMS
                        // TODO: save it to a temporary folder?
                        try
                        {
                            sms.Status = 2;
                            sms.SentAt = DateTime.Now;

                            string status = "";
                            switch (sms.Status)
                            {
                                case 1: status = "New"; break;
                                case 2: status = "Sent"; break;
                                case 3: status = "Send Error"; break;
                                case 4: status = "Server Error"; break;
                            }
                            
                            using (StreamWriter sw = File.AppendText(@"C:\Sms\SmsList.txt"))
                            {
                                sw.WriteLine(sms.Id);
                                sw.WriteLine(sms.PhoneNumber);
                                sw.WriteLine(sms.Text);
                                sw.WriteLine(status);
                                sw.WriteLine(sms.CreatedAt);
                                sw.WriteLine(sms.SentAt);
                                sw.WriteLine("---------------------------------------");
                            }
                            await this._db.SaveChangesAsync();
                        }
                        catch(Exception ex)
                        {
                            this._logger.LogError(ex, "Error while sending new SMS.");
                        }
                        
                    }
                }
                catch(Exception ex)
                {
                    this._logger.LogError(ex, "Error while sending new SMS messages.");
                }

                await Task.Delay(delay, stoppingToken);
            }
        }
    }
}
