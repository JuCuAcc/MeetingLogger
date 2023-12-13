
using MeetingLogger.Data;
using MeetingLogger.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MeetingLogger.Data.Configurations
{
    public partial class ProductsServiceTblConfiguration : IEntityTypeConfiguration<ProductsServiceTbl>
    {
        public void Configure(EntityTypeBuilder<ProductsServiceTbl> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC070F233746");

            entity.ToTable("Products_Service_Tbl");

            entity.Property(e => e.ProductName)
            .HasMaxLength(100)
            .IsUnicode(false);
            entity.Property(e => e.Unit)
            .HasMaxLength(50)
            .IsUnicode(false);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<ProductsServiceTbl> entity);
    }
}
