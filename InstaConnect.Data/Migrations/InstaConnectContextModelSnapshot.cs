﻿// <auto-generated />
using System;
using InstaConnect.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InstaConnect.Data.Migrations
{
    [DbContext(typeof(InstaConnectContext))]
    partial class InstaConnectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("InstaConnect.Data.Models.Entities.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext")
                        .HasColumnName("concurrency_stamp");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("name");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("normalized_name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("role", (string)null);
                });

            modelBuilder.Entity("InstaConnect.Data.Models.Entities.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
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
                        .HasColumnType("varchar(255)")
                        .HasColumnName("role_id");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("role_claim", (string)null);
                });

            modelBuilder.Entity("InstaConnect.Data.Models.Entities.Token", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("type");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("ValidUntil")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("is_valid_until");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("token", (string)null);
                });

            modelBuilder.Entity("InstaConnect.Data.Models.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("id");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int")
                        .HasColumnName("access_failed_count");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext")
                        .HasColumnName("concurrency_stamp");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("email");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("email_is_confirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("last_name");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("lockout_is_enabled");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("lockout_end");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("normalized_email");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
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
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("InstaConnect.Data.Models.Entities.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
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
                        .HasColumnType("varchar(255)")
                        .HasColumnName("role_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("user_claim", (string)null);
                });

            modelBuilder.Entity("InstaConnect.Data.Models.Entities.UserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("login_provider");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("provider_key");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext")
                        .HasColumnName("provider_display_name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("user_id");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("user_login", (string)null);
                });

            modelBuilder.Entity("InstaConnect.Data.Models.Entities.UserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("user_id");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("role_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("user_role", (string)null);
                });

            modelBuilder.Entity("InstaConnect.Data.Models.Entities.UserToken", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("user_id");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("login_provider");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.Property<string>("Value")
                        .HasColumnType("longtext")
                        .HasColumnName("value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("user_token", (string)null);
                });

            modelBuilder.Entity("InstaConnect.Data.Models.Entities.RoleClaim", b =>
                {
                    b.HasOne("InstaConnect.Data.Models.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InstaConnect.Data.Models.Entities.Token", b =>
                {
                    b.HasOne("InstaConnect.Data.Models.Entities.User", "User")
                        .WithMany("Tokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("InstaConnect.Data.Models.Entities.UserClaim", b =>
                {
                    b.HasOne("InstaConnect.Data.Models.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InstaConnect.Data.Models.Entities.UserLogin", b =>
                {
                    b.HasOne("InstaConnect.Data.Models.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InstaConnect.Data.Models.Entities.UserRole", b =>
                {
                    b.HasOne("InstaConnect.Data.Models.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InstaConnect.Data.Models.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InstaConnect.Data.Models.Entities.UserToken", b =>
                {
                    b.HasOne("InstaConnect.Data.Models.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InstaConnect.Data.Models.Entities.User", b =>
                {
                    b.Navigation("Tokens");
                });
#pragma warning restore 612, 618
        }
    }
}
