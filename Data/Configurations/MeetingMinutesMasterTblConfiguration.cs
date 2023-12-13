
using MeetingLogger.Data;
using MeetingLogger.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MeetingLogger.Data.Configurations
{
    public partial class MeetingMinutesMasterTblConfiguration : IEntityTypeConfiguration<MeetingMinutesMasterTbl>
    {
        public void Configure(EntityTypeBuilder<MeetingMinutesMasterTbl> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__Meeting___3214EC079EB138AD");

            entity.ToTable("Meeting_Minutes_Master_Tbl");

            entity.Property(e => e.AttendsFromClientSide)
            .HasMaxLength(100)
            .IsUnicode(false);
            entity.Property(e => e.AttendsFromHostSide)
            .HasMaxLength(100)
            .IsUnicode(false);
            entity.Property(e => e.CustomerName)
            .HasMaxLength(100)
            .IsUnicode(false);
            entity.Property(e => e.CustomerType)
            .HasMaxLength(20)
            .IsUnicode(false);
            entity.Property(e => e.MeetingPlace)
            .HasMaxLength(100)
            .IsUnicode(false);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<MeetingMinutesMasterTbl> entity);
    }
}
