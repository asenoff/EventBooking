using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EventBooking.Infrastructure.Migrations
{
    public partial class TransportationAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Resume",
                table: "Users",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Place",
                table: "Events",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Events",
                maxLength: 1200,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Events",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<bool>(
                name: "FirstTimerPreference",
                table: "Events",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MembershipPreference",
                table: "Events",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MinNumberOfCars",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OrganizeCarsTransportation",
                table: "Events",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Alias = table.Column<string>(maxLength: 50, nullable: false),
                    BikeCount = table.Column<int>(nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    PassengerCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CarId = table.Column<Guid>(nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    ParticipantMail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drivers_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Drivers_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Drivers_Users_ParticipantMail",
                        column: x => x.ParticipantMail,
                        principalTable: "Users",
                        principalColumn: "Mail",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CarId = table.Column<Guid>(nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    ParticipantMail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passengers_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Passengers_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Passengers_Users_ParticipantMail",
                        column: x => x.ParticipantMail,
                        principalTable: "Users",
                        principalColumn: "Mail",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_CarId",
                table: "Drivers",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_EventId",
                table: "Drivers",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_ParticipantMail",
                table: "Drivers",
                column: "ParticipantMail");

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_CarId",
                table: "Passengers",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_EventId",
                table: "Passengers",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_ParticipantMail",
                table: "Passengers",
                column: "ParticipantMail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropColumn(
                name: "FirstTimerPreference",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "MembershipPreference",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "MinNumberOfCars",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "OrganizeCarsTransportation",
                table: "Events");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Resume",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Place",
                table: "Events",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Events",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 1200);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Events",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 2000);
        }
    }
}
