using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EventBooking.Infrastructure.Migrations
{
    public partial class TransportationFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Cars_CarId",
                table: "Drivers");

            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_Cars_CarId",
                table: "Passengers");

            migrationBuilder.DropIndex(
                name: "IX_Passengers_CarId",
                table: "Passengers");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_CarId",
                table: "Drivers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cars",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "CarRegistrationID",
                table: "Passengers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationId",
                table: "Drivers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationID",
                table: "Cars",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cars",
                table: "Cars",
                column: "RegistrationID");

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_CarRegistrationID",
                table: "Passengers",
                column: "CarRegistrationID");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_RegistrationId",
                table: "Drivers",
                column: "RegistrationId",
                unique: true,
                filter: "[RegistrationId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Cars_RegistrationId",
                table: "Drivers",
                column: "RegistrationId",
                principalTable: "Cars",
                principalColumn: "RegistrationID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_Cars_CarRegistrationID",
                table: "Passengers",
                column: "CarRegistrationID",
                principalTable: "Cars",
                principalColumn: "RegistrationID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Cars_RegistrationId",
                table: "Drivers");

            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_Cars_CarRegistrationID",
                table: "Passengers");

            migrationBuilder.DropIndex(
                name: "IX_Passengers_CarRegistrationID",
                table: "Passengers");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_RegistrationId",
                table: "Drivers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cars",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarRegistrationID",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "RegistrationId",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "RegistrationID",
                table: "Cars");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Cars",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cars",
                table: "Cars",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_CarId",
                table: "Passengers",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_CarId",
                table: "Drivers",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Cars_CarId",
                table: "Drivers",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_Cars_CarId",
                table: "Passengers",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
