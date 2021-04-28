using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmsServer.Data.Models
{
    public class Sms
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; }

        public string Text { get; set; }

        public int Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? SentAt { get; set; }

        public string StatusText { get; set; }

        public virtual Status SmsStatus { get; set; }

    }
    public class SmsConfiguration : IEntityTypeConfiguration<Sms>
    {
        public void Configure(EntityTypeBuilder<Sms> builder)
        {
            builder.ToTable("Sms");
            builder.Property(b => b.Id).HasColumnType("int").IsRequired();
            builder.Property(b => b.PhoneNumber).HasColumnType("varchar(15)").IsRequired().IsUnicode(false);
            builder.Property(b => b.Text).HasColumnType("nvarchar(max)").IsUnicode();
            builder.Property(b => b.Status).HasColumnType("int").IsRequired();
            builder.Property(b => b.CreatedAt).HasColumnType("datetime2(4)").IsRequired();
            builder.Property(b => b.SentAt).HasColumnType("datetime2(4)");
            builder.Property(b => b.StatusText).HasColumnType("varchar(max)").IsUnicode(false);
            builder.HasOne(x => x.SmsStatus).WithMany().HasForeignKey(x => x.Status);
        }
    }

}
