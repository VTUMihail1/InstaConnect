﻿using InstaConnect.Users.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InstaConnect.Users.Data.EntityConfigurations;

public class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
{
    public void Configure(EntityTypeBuilder<RoleClaim> builder)
    {
        builder
            .ToTable("role_claim");

        builder
            .Property(rc => rc.Id)
            .HasColumnName("id");

        builder
            .Property(rc => rc.RoleId)
            .HasColumnName("role_id");

        builder
            .Property(rc => rc.ClaimType)
            .HasColumnName("claim_type");

        builder
            .Property(rc => rc.ClaimValue)
            .HasColumnName("claim_value");

        builder
            .Property(t => t.CreatedAt)
            .HasColumnType("timestamp(6)")
            .HasColumnName("created_at");

        builder
            .Property(t => t.UpdatedAt)
            .HasColumnType("timestamp(6)")
            .HasColumnName("updated_at");
    }
}