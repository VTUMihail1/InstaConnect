﻿// <auto-generated />
using System;
using InstaConnect.Follows.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InstaConnect.Follows.Read.Data.Migrations
{
    [DbContext(typeof(FollowsContext))]
    partial class FollowsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InstaConnect.Follows.Read.Data.Models.Entities.Follow", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FollowerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("follower_id");

                    b.Property<string>("FollowingId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("following_id");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FollowerId");

                    b.HasIndex("FollowingId");

                    b.ToTable("follow", (string)null);
                });

            modelBuilder.Entity("InstaConnect.Follows.Read.Data.Models.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("last_name");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("profile_image");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_name");

                    b.HasKey("Id");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("InstaConnect.Follows.Read.Data.Models.Entities.Follow", b =>
                {
                    b.HasOne("InstaConnect.Follows.Read.Data.Models.Entities.User", "Follower")
                        .WithMany("Followers")
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("InstaConnect.Follows.Read.Data.Models.Entities.User", "Following")
                        .WithMany("Followings")
                        .HasForeignKey("FollowingId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Follower");

                    b.Navigation("Following");
                });

            modelBuilder.Entity("InstaConnect.Follows.Read.Data.Models.Entities.User", b =>
                {
                    b.Navigation("Followers");

                    b.Navigation("Followings");
                });
#pragma warning restore 612, 618
        }
    }
}
