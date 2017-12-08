using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EventBooking.Infrastructure.Migrations
{
    public partial class RoleAuthorizationPrep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Rights_RightsAlias",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Rights");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RightsAlias",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RightsAlias",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RightsAlias",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Rights",
                columns: table => new
                {
                    RightsAlias = table.Column<string>(nullable: false),
                    CanChangeRights = table.Column<bool>(nullable: false),
                    CanCreateEvents = table.Column<bool>(nullable: false),
                    CanDeleteEvents = table.Column<bool>(nullable: false),
                    CanDeleteUser = table.Column<bool>(nullable: false),
                    CanSeeUsers = table.Column<bool>(nullable: false),
                    CanUpdateEventDescription = table.Column<bool>(nullable: false),
                    CanUpdateEventParticipants = table.Column<bool>(nullable: false),
                    CanUpdateUser = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rights", x => x.RightsAlias);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RightsAlias",
                table: "AspNetUsers",
                column: "RightsAlias");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Rights_RightsAlias",
                table: "AspNetUsers",
                column: "RightsAlias",
                principalTable: "Rights",
                principalColumn: "RightsAlias",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
