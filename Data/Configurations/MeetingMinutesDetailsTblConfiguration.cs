
using MeetingLogger.Data;
using MeetingLogger.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MeetingLogger.Data.Configurations
{
    public partial class MeetingMinutesDetailsTblConfiguration : IEntityTypeConfiguration<MeetingMinutesDetailsTbl>
    {
        public void Configure(EntityTypeBuilder<MeetingMinutesDetailsTbl> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__Meeting___3214EC07EC02481F");

            entity.ToTable("Meeting_Minutes_Details_Tbl");

            entity.HasOne(d => d.Meeting).WithMany(p => p.MeetingMinutesDetailsTbls)
            .HasForeignKey(d => d.MeetingId)
            .HasConstraintName("FK__Meeting_M__Meeti__2C3393D0");

            entity.HasOne(d => d.Product).WithMany(p => p.MeetingMinutesDetailsTbls)
            .HasForeignKey(d => d.ProductId)
            .HasConstraintName("FK__Meeting_M__Produ__2D27B809");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<MeetingMinutesDetailsTbl> entity);
    }
}
