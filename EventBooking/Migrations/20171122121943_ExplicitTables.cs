using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EventBooking.Web.Migrations
{
    public partial class ExplicitTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Images_UserMail",
                table: "Images");

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserMail",
                table: "Images",
                column: "UserMail",
                unique: true,
                filter: "[UserMail] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Images_UserMail",
                table: "Images");

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserMail",
                table: "Images",
                column: "UserMail");
        }
    }
}
