using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaTickets.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    SeanceTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seances",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    MovieId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seances_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    PeopleCount = table.Column<int>(nullable: false),
                    PurchesDate = table.Column<DateTime>(nullable: false),
                    SeanceId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Seances_SeanceId",
                        column: x => x.SeanceId,
                        principalTable: "Seances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Name", "SeanceTime", "Year" },
                values: new object[] { new Guid("4d5170d4-f534-46ee-a997-8aaa208a25d4"), "Harry Potter i Czara Ognia", 150, 2010 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Name", "SeanceTime", "Year" },
                values: new object[] { new Guid("3770b3bc-e1e6-4601-bdf6-8bda0d4e42ad"), "Szybcy i wściekli 8", 180, 2018 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Name", "SeanceTime", "Year" },
                values: new object[] { new Guid("9b9aec2a-18b8-410f-a70f-f2b3c3527e10"), "Alita", 120, 2019 });

            migrationBuilder.InsertData(
                table: "Seances",
                columns: new[] { "Id", "Date", "MovieId" },
                values: new object[] { new Guid("758192f9-36e6-414a-8522-f8443b5efae2"), new DateTime(2019, 3, 10, 18, 30, 0, 0, DateTimeKind.Unspecified), new Guid("4d5170d4-f534-46ee-a997-8aaa208a25d4") });

            migrationBuilder.InsertData(
                table: "Seances",
                columns: new[] { "Id", "Date", "MovieId" },
                values: new object[] { new Guid("420ee07c-de24-4b3f-b2b6-aae2361dbac1"), new DateTime(2019, 3, 10, 22, 30, 0, 0, DateTimeKind.Unspecified), new Guid("3770b3bc-e1e6-4601-bdf6-8bda0d4e42ad") });

            migrationBuilder.InsertData(
                table: "Seances",
                columns: new[] { "Id", "Date", "MovieId" },
                values: new object[] { new Guid("56fd3014-e1b0-4f6c-b9ec-bd76f7e200b7"), new DateTime(2019, 4, 10, 18, 30, 0, 0, DateTimeKind.Unspecified), new Guid("9b9aec2a-18b8-410f-a70f-f2b3c3527e10") });

            migrationBuilder.CreateIndex(
                name: "IX_Seances_MovieId",
                table: "Seances",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SeanceId",
                table: "Tickets",
                column: "SeanceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Seances");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
