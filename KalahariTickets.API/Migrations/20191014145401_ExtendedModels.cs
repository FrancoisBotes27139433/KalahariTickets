using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KalahariTickets.API.Migrations
{
    public partial class ExtendedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    PhoneNumber = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Technitions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsUrgent = table.Column<bool>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    DateIssued = table.Column<DateTime>(nullable: false),
                    DateClossed = table.Column<DateTime>(nullable: false),
                    Open = table.Column<bool>(nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    TechnitionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Technitions_TechnitionId",
                        column: x => x.TechnitionId,
                        principalTable: "Technitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TechnitionTicketTimes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    TechnitionId = table.Column<int>(nullable: false),
                    TicketsId = table.Column<int>(nullable: true),
                    TicketId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnitionTicketTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechnitionTicketTimes_Technitions_TechnitionId",
                        column: x => x.TechnitionId,
                        principalTable: "Technitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TechnitionTicketTimes_Tickets_TicketsId",
                        column: x => x.TicketsId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TechnitionTicketTimes_TechnitionId",
                table: "TechnitionTicketTimes",
                column: "TechnitionId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnitionTicketTimes_TicketsId",
                table: "TechnitionTicketTimes",
                column: "TicketsId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ClientId",
                table: "Tickets",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TechnitionId",
                table: "Tickets",
                column: "TechnitionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TechnitionTicketTimes");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Technitions");
        }
    }
}
