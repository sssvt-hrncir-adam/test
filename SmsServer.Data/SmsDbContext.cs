using Microsoft.EntityFrameworkCore;
using SmsServer.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmsServer.Data
{
    public class SmsDbContext : DbContext
    {
        public SmsDbContext(DbContextOptions options)
            :base(options)
        {
        }

        public DbSet<Sms> SmsSet { get; set; }
        public DbSet<Status> StatusSet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new SmsConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
        }
    }
    

}
