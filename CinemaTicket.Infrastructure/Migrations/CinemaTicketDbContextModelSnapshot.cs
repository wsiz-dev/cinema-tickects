﻿// <auto-generated />
using System;
using CinemaTickets.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CinemaTickets.Infrastructure.Migrations
{
    [DbContext(typeof(CinemaTicketDbContext))]
    partial class CinemaTicketDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CinemaTickets.Domain.Entities.Movie", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("Name");

                    b.Property<int>("SeanceTime");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4d5170d4-f534-46ee-a997-8aaa208a25d4"),
                            Name = "Harry Potter i Czara Ognia",
                            SeanceTime = 150,
                            Year = 2010
                        },
                        new
                        {
                            Id = new Guid("3770b3bc-e1e6-4601-bdf6-8bda0d4e42ad"),
                            Name = "Szybcy i wściekli 8",
                            SeanceTime = 180,
                            Year = 2018
                        },
                        new
                        {
                            Id = new Guid("9b9aec2a-18b8-410f-a70f-f2b3c3527e10"),
                            Name = "Alita",
                            SeanceTime = 120,
                            Year = 2019
                        });
                });

            modelBuilder.Entity("CinemaTickets.Domain.Entities.Seance", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<DateTime>("Date");

                    b.Property<Guid?>("MovieId");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Seances");

                    b.HasData(
                        new
                        {
                            Id = new Guid("758192f9-36e6-414a-8522-f8443b5efae2"),
                            Date = new DateTime(2019, 3, 10, 18, 30, 0, 0, DateTimeKind.Unspecified),
                            MovieId = new Guid("4d5170d4-f534-46ee-a997-8aaa208a25d4")
                        },
                        new
                        {
                            Id = new Guid("420ee07c-de24-4b3f-b2b6-aae2361dbac1"),
                            Date = new DateTime(2019, 3, 10, 22, 30, 0, 0, DateTimeKind.Unspecified),
                            MovieId = new Guid("3770b3bc-e1e6-4601-bdf6-8bda0d4e42ad")
                        },
                        new
                        {
                            Id = new Guid("56fd3014-e1b0-4f6c-b9ec-bd76f7e200b7"),
                            Date = new DateTime(2019, 4, 10, 18, 30, 0, 0, DateTimeKind.Unspecified),
                            MovieId = new Guid("9b9aec2a-18b8-410f-a70f-f2b3c3527e10")
                        });
                });

            modelBuilder.Entity("CinemaTickets.Domain.Entities.Ticket", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("Email");

                    b.Property<int>("PeopleCount");

                    b.Property<DateTime>("PurchesDate");

                    b.Property<Guid?>("SeanceId");

                    b.HasKey("Id");

                    b.HasIndex("SeanceId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("CinemaTickets.Domain.Entities.Seance", b =>
                {
                    b.HasOne("CinemaTickets.Domain.Entities.Movie")
                        .WithMany("Seances")
                        .HasForeignKey("MovieId");
                });

            modelBuilder.Entity("CinemaTickets.Domain.Entities.Ticket", b =>
                {
                    b.HasOne("CinemaTickets.Domain.Entities.Seance")
                        .WithMany("Tickets")
                        .HasForeignKey("SeanceId");
                });
#pragma warning restore 612, 618
        }
    }
}
