﻿// <auto-generated />
using System;
using InstaConnect.Follows.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InstaConnect.Follows.Data.Migrations
{
    [DbContext(typeof(FollowsContext))]
    [Migration("20240610100314_UpdateDatetimeType")]
    partial class UpdateDatetimeType
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("InstaConnect.Follows.Data.Models.Entities.Follow", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("FollowerId")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("follower_id");

                    b.Property<string>("FollowingId")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("following_id");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp(6)")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("follow", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
