
using MeetingLogger.Data;
using MeetingLogger.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MeetingLogger.Data.Configurations
{
    public partial class CorporateCustomerTblConfiguration : IEntityTypeConfiguration<CorporateCustomerTbl>
    {
        public void Configure(EntityTypeBuilder<CorporateCustomerTbl> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__Corporat__3214EC07A9A2ABE1");

            entity.ToTable("Corporate_Customer_Tbl");

            entity.Property(e => e.CustomerName)
            .HasMaxLength(100)
            .IsUnicode(false);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<CorporateCustomerTbl> entity);
    }
}
