﻿using System;
using IoTomatoes.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IoTomatoes.Persistence.Configurations
{
    public class PlantConfiguration : IEntityTypeConfiguration<Plant>
    {
        public void Configure(EntityTypeBuilder<Plant> builder)
        {
            builder.Property(e => e.Code)
                    .HasMaxLength(3)
                    .IsUnicode(false);

            builder.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

            builder.Property(e => e.DateModified).HasDefaultValueSql("(getdate())");

            builder.Property(e => e.Description).HasMaxLength(3000);

            builder.Property(e => e.Name).HasMaxLength(255);

            builder.Property(e => e.Version).HasDefaultValueSql("((1))");

            builder.HasOne(d => d.PlantType)
                .WithMany(p => p.Plants)
                .HasForeignKey(d => d.PlantTypeId)
                .HasConstraintName("FK__Plants__PlantTyp__48CFD27E");
        }
    }
}
