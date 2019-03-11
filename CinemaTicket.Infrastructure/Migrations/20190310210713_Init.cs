using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaTickets.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Movies",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    SeanceTime = table.Column<int>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Movies", x => x.Id); });

            migrationBuilder.CreateTable(
                "Rooms",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RoomNumber = table.Column<int>(nullable: false),
                    Seats = table.Column<int>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Rooms", x => x.Id); });

            migrationBuilder.CreateTable(
                "Tickets",
                table => new
                {
                    Email = table.Column<string>(nullable: true),
                    Id = table.Column<Guid>(nullable: false),
                    PeopleCount = table.Column<int>(nullable: false),
                    PurchesDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Tickets", x => x.Id); });

            migrationBuilder.CreateTable(
                "Seances",
                table => new
                {
                    Date = table.Column<DateTime>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    RoomId = table.Column<Guid>(nullable: true),
                    MovieId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seances", x => x.Id);
                    table.ForeignKey(
                        "FK_Seances_Movies_MovieId",
                        x => x.MovieId,
                        "Movies",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Seances_Rooms_RoomId",
                        x => x.RoomId,
                        "Rooms",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                "Movies",
                new[] {"Id", "Name", "SeanceTime", "Year"},
                new object[,]
                {
                    {new Guid("10f49274-7c65-478d-b5c9-e43395b6169f"), "Harry Potter i Czara Ognia", 150, 2010},
                    {new Guid("408e83b0-9f63-46d5-8721-6426577d5f9c"), "Szybcy i wściekli 8", 180, 2018},
                    {new Guid("d622f2ee-a361-458c-ba01-04246bbe9547"), "Alita", 120, 2019}
                });

            migrationBuilder.InsertData(
                "Rooms",
                new[] {"Id", "RoomNumber", "Seats"},
                new object[,]
                {
                    {new Guid("b837f013-9d92-4ec1-8a33-00f1fe15b14a"), 1, 50},
                    {new Guid("772e49b0-099e-4db7-956c-6c545e4fd2fb"), 2, 50},
                    {new Guid("ca035fa8-afc6-4118-83f0-ca151746354b"), 3, 50}
                });

            migrationBuilder.InsertData(
                "Seances",
                new[] {"Id", "Date", "MovieId", "RoomId"},
                new object[]
                {
                    new Guid("dbf18a4f-753e-492c-8854-098606d3a007"),
                    new DateTime(2019, 3, 10, 18, 30, 0, 0, DateTimeKind.Unspecified),
                    new Guid("10f49274-7c65-478d-b5c9-e43395b6169f"), new Guid("b837f013-9d92-4ec1-8a33-00f1fe15b14a")
                });

            migrationBuilder.InsertData(
                "Seances",
                new[] {"Id", "Date", "MovieId", "RoomId"},
                new object[]
                {
                    new Guid("7def3843-86a2-48f4-ba56-8c84d97c8ef5"),
                    new DateTime(2019, 3, 10, 22, 30, 0, 0, DateTimeKind.Unspecified),
                    new Guid("408e83b0-9f63-46d5-8721-6426577d5f9c"), new Guid("772e49b0-099e-4db7-956c-6c545e4fd2fb")
                });

            migrationBuilder.InsertData(
                "Seances",
                new[] {"Id", "Date", "MovieId", "RoomId"},
                new object[]
                {
                    new Guid("bcfc5140-9812-4367-85ef-15ab0d9b4b6f"),
                    new DateTime(2019, 4, 10, 18, 30, 0, 0, DateTimeKind.Unspecified),
                    new Guid("d622f2ee-a361-458c-ba01-04246bbe9547"), new Guid("ca035fa8-afc6-4118-83f0-ca151746354b")
                });

            migrationBuilder.CreateIndex(
                "IX_Seances_MovieId",
                "Seances",
                "MovieId");

            migrationBuilder.CreateIndex(
                "IX_Seances_RoomId",
                "Seances",
                "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Seances");

            migrationBuilder.DropTable(
                "Tickets");

            migrationBuilder.DropTable(
                "Movies");

            migrationBuilder.DropTable(
                "Rooms");
        }
    }
}