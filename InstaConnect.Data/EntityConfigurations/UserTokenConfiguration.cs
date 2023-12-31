﻿using InstaConnect.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InstaConnect.Data.EntityConfigurations
{
    public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.ToTable("user_token");

            builder.Property(ut => ut.Id).HasColumnName("id");
            builder.Property(ut => ut.UserId).HasColumnName("user_id");
            builder.Property(ut => ut.LoginProvider).HasColumnName("login_provider");
            builder.Property(ut => ut.Name).HasColumnName("name");
            builder.Property(ut => ut.Value).HasColumnName("value");
            builder.Property(ut => ut.CreatedAt).HasColumnName("created_at");
            builder.Property(ut => ut.UpdatedAt).HasColumnName("updated_at");
        }
    }
}
