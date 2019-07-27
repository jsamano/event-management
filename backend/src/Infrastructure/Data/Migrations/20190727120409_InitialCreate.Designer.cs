﻿// <auto-generated />
using System;
using EventManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EventManagement.Infrastructure.Data.Migrations
{
    [DbContext(typeof(EventsDbContext))]
    [Migration("20190727120409_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EventManagement.ApplicationCore.Models.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndTime");

                    b.Property<DateTime?>("EntranceTime");

                    b.Property<string>("Location")
                        .HasMaxLength(300);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<DateTime>("StartTime");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("EventManagement.ApplicationCore.Models.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasMaxLength(1000);

                    b.Property<int?>("Age");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid?>("CreatorId");

                    b.Property<DateTime?>("EditedAt");

                    b.Property<Guid?>("EditorId");

                    b.Property<Guid>("EventId");

                    b.Property<string>("FirstName")
                        .HasMaxLength(300);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName")
                        .HasMaxLength(300);

                    b.Property<string>("Mail")
                        .HasMaxLength(254);

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Phone")
                        .HasMaxLength(100);

                    b.Property<string>("RoomNumber")
                        .HasMaxLength(300);

                    b.Property<bool?>("TermsAccepted");

                    b.Property<string>("TicketNumber")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("TicketSecret")
                        .IsRequired();

                    b.Property<Guid>("TicketTypeId");

                    b.Property<bool>("Validated");

                    b.HasKey("Id");

                    b.HasAlternateKey("TicketNumber");

                    b.HasAlternateKey("TicketSecret");

                    b.HasIndex("CreatorId");

                    b.HasIndex("EditorId");

                    b.HasIndex("EventId");

                    b.HasIndex("TicketTypeId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("EventManagement.ApplicationCore.Models.TicketType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("EventId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(5, 2)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("TicketTypes");
                });

            modelBuilder.Entity("EventManagement.ApplicationCore.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<bool>("Enabled");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<string>("Password");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.HasIndex("EmailAddress")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EventManagement.ApplicationCore.Models.Ticket", b =>
                {
                    b.HasOne("EventManagement.ApplicationCore.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("EventManagement.ApplicationCore.Models.User", "Editor")
                        .WithMany()
                        .HasForeignKey("EditorId");

                    b.HasOne("EventManagement.ApplicationCore.Models.Event", "Event")
                        .WithMany("Tickets")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EventManagement.ApplicationCore.Models.TicketType", "TicketType")
                        .WithMany("Tickets")
                        .HasForeignKey("TicketTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EventManagement.ApplicationCore.Models.TicketType", b =>
                {
                    b.HasOne("EventManagement.ApplicationCore.Models.Event", "Event")
                        .WithMany("TicketTypes")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}