using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmsServer.Data.Models
{
    public class Status
    {
        public int Id { get; set; }

        public string Name { get; set; }

        

    }

    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("Status");
            builder.Property(b => b.Id).HasColumnType("int").IsRequired();
            builder.Property(b => b.Name).HasColumnType("varchar(50)").IsRequired().IsUnicode(false);

        }
    }
}
