﻿// <auto-generated />
using System;
using InstaConnect.Users.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InstaConnect.Users.Data.Migrations
{
    [DbContext(typeof(UsersContext))]
    partial class UsersContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("InstaConnect.Users.Data.Models.Entities.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("id");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext")
                        .HasColumnName("concurrency_stamp");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("longtext")
                        .HasColumnName("normalized_name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("role", (string)null);
                });

            modelBuilder.Entity("InstaConnect.Users.Data.Models.Entities.RoleClaim", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("id");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext")
                        .HasColumnName("claim_value");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("role_id");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("role_claim", (string)null);
                });

            modelBuilder.Entity("InstaConnect.Users.Data.Models.Entities.Token", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("type");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("user_id");

                    b.Property<DateTime>("ValidUntil")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("is_valid_until");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("token", (string)null);
                });

            modelBuilder.Entity("InstaConnect.Users.Data.Models.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("id");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int")
                        .HasColumnName("access_failed_count");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext")
                        .HasColumnName("concurrency_stamp");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("email_is_confirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("last_name");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("lockout_is_enabled");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("lockout_end");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("longtext")
                        .HasColumnName("normalized_email");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("longtext")
                        .HasColumnName("normalized_username");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext")
                        .HasColumnName("password_hash");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext")
                        .HasColumnName("phone_number");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("phone_number_is_confirmed");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext")
                        .HasColumnName("security_stamp");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("two_factor_is_enabled");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("InstaConnect.Users.Data.Models.Entities.UserClaim", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("id");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext")
                        .HasColumnName("claim_value");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("role_id");

                    b.HasKey("Id");

                    b.ToTable("user_claim", (string)null);
                });

            modelBuilder.Entity("InstaConnect.Users.Data.Models.Entities.UserLogin", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("LoginProvider")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("login_provider");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext")
                        .HasColumnName("provider_display_name");

                    b.Property<string>("ProviderKey")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("provider_key");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("user_login", (string)null);
                });

            modelBuilder.Entity("InstaConnect.Users.Data.Models.Entities.UserRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("role_id");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("user_role", (string)null);
                });

            modelBuilder.Entity("InstaConnect.Users.Data.Models.Entities.UserToken", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("LoginProvider")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("login_provider");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("user_id");

                    b.Property<string>("Value")
                        .HasColumnType("longtext")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.ToTable("user_token", (string)null);
                });

            modelBuilder.Entity("InstaConnect.Users.Data.Models.Entities.Token", b =>
                {
                    b.HasOne("InstaConnect.Users.Data.Models.Entities.User", "User")
                        .WithMany("Tokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("InstaConnect.Users.Data.Models.Entities.User", b =>
                {
                    b.Navigation("Tokens");
                });
#pragma warning restore 612, 618
        }
    }
}