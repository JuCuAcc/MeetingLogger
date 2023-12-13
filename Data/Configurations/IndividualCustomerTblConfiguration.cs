
using MeetingLogger.Data;
using MeetingLogger.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MeetingLogger.Data.Configurations
{
    public partial class IndividualCustomerTblConfiguration : IEntityTypeConfiguration<IndividualCustomerTbl>
    {
        public void Configure(EntityTypeBuilder<IndividualCustomerTbl> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__Individu__3214EC07DDB48A4D");

            entity.ToTable("Individual_Customer_Tbl");

            entity.Property(e => e.CustomerName)
            .HasMaxLength(100)
            .IsUnicode(false);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<IndividualCustomerTbl> entity);
    }
}
