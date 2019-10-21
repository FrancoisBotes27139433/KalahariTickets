﻿// <auto-generated />
using System;
using KalahariTickets.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KalahariTickets.API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("KalahariTickets.API.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Email");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<int>("PhoneNumber");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("KalahariTickets.API.Models.Technition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Technitions");
                });

            modelBuilder.Entity("KalahariTickets.API.Models.TechnitionTicketTime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("End");

                    b.Property<DateTime>("Start");

                    b.Property<int>("TechnitionId");

                    b.Property<int>("TicketId");

                    b.Property<int?>("TicketsId");

                    b.HasKey("Id");

                    b.HasIndex("TechnitionId");

                    b.HasIndex("TicketsId");

                    b.ToTable("TechnitionTicketTimes");
                });

            modelBuilder.Entity("KalahariTickets.API.Models.Tickets", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClientId");

                    b.Property<DateTime>("DateClossed");

                    b.Property<DateTime>("DateIssued");

                    b.Property<string>("Description");

                    b.Property<bool>("IsUrgent");

                    b.Property<string>("Notes");

                    b.Property<bool>("Open");

                    b.Property<int>("TechnitionId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("TechnitionId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("KalahariTickets.API.Models.Value", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Values");
                });

            modelBuilder.Entity("KalahariTickets.API.Models.TechnitionTicketTime", b =>
                {
                    b.HasOne("KalahariTickets.API.Models.Technition", "Technition")
                        .WithMany()
                        .HasForeignKey("TechnitionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KalahariTickets.API.Models.Tickets", "Tickets")
                        .WithMany()
                        .HasForeignKey("TicketsId");
                });

            modelBuilder.Entity("KalahariTickets.API.Models.Tickets", b =>
                {
                    b.HasOne("KalahariTickets.API.Models.Client", "Client")
                        .WithMany("Tickets")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KalahariTickets.API.Models.Technition", "Technition")
                        .WithMany("Tickets")
                        .HasForeignKey("TechnitionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
