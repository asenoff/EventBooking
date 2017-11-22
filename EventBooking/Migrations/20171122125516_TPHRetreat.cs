using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EventBooking.Web.Migrations
{
    public partial class TPHRetreat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Events_EventID",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Images_ImageID",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Events_UserImage_EventID",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_ParticipantMail",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ParticipantMail",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Images_EventID",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_ImageID",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_UserImage_EventID",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ParticipantMail",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EventID",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ImageID",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "UserImage_EventID",
                table: "Images",
                newName: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Images_EventID",
                table: "Images",
                column: "EventID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Events_EventID",
                table: "Images",
                column: "EventID",
                principalTable: "Events",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Events_EventID",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_EventID",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "EventID",
                table: "Images",
                newName: "UserImage_EventID");

            migrationBuilder.AddColumn<string>(
                name: "ParticipantMail",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventID",
                table: "Images",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ImageID",
                table: "Images",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ParticipantMail",
                table: "Users",
                column: "ParticipantMail");

            migrationBuilder.CreateIndex(
                name: "IX_Images_EventID",
                table: "Images",
                column: "EventID",
                unique: true,
                filter: "[EventID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ImageID",
                table: "Images",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserImage_EventID",
                table: "Images",
                column: "UserImage_EventID");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Events_EventID",
                table: "Images",
                column: "EventID",
                principalTable: "Events",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Images_ImageID",
                table: "Images",
                column: "ImageID",
                principalTable: "Images",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Events_UserImage_EventID",
                table: "Images",
                column: "UserImage_EventID",
                principalTable: "Events",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_ParticipantMail",
                table: "Users",
                column: "ParticipantMail",
                principalTable: "Users",
                principalColumn: "Mail",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
