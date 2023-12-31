﻿using InstaConnect.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InstaConnect.Data.EntityConfigurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("user_role");

            builder.Property(ur => ur.Id).HasColumnName("id");
            builder.Property(ur => ur.RoleId).HasColumnName("role_id");
            builder.Property(ur => ur.UserId).HasColumnName("user_id");
            builder.Property(ur => ur.CreatedAt).HasColumnName("created_at");
            builder.Property(ur => ur.UpdatedAt).HasColumnName("updated_at");
        }
    }
}
