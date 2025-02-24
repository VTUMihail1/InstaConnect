﻿// <auto-generated />
using System;
using InstaConnect.Messages.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InstaConnect.Messages.Read.Data.Migrations
{
    [DbContext(typeof(MessagesContext))]
    [Migration("20240703175903_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InstaConnect.Messages.Read.Data.Models.Entities.Message", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasColumnName("content");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<string>("ReceiverId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("receiver_id");

                    b.Property<string>("SenderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("sender_id");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("message", (string)null);
                });

            modelBuilder.Entity("InstaConnect.Messages.Read.Data.Models.Entities.User", b =>
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

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_name");

                    b.HasKey("Id");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("InstaConnect.Messages.Read.Data.Models.Entities.Message", b =>
                {
                    b.HasOne("InstaConnect.Messages.Read.Data.Models.Entities.User", "Receiver")
                        .WithMany("ReceiverMessages")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("InstaConnect.Messages.Read.Data.Models.Entities.User", "Sender")
                        .WithMany("SenderMessages")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("InstaConnect.Messages.Read.Data.Models.Entities.User", b =>
                {
                    b.Navigation("ReceiverMessages");

                    b.Navigation("SenderMessages");
                });
#pragma warning restore 612, 618
        }
    }
}
