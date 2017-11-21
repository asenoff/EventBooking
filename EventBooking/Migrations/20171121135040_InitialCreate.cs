using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EventBooking.Web.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Data = table.Column<byte[]>(nullable: true),
                    Height = table.Column<int>(nullable: false),
                    Length = table.Column<int>(nullable: false),
                    Name = table.Column<byte[]>(nullable: true),
                    Width = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rights",
                columns: table => new
                {
                    RightsModelName = table.Column<string>(nullable: false),
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
                    table.PrimaryKey("PK_Rights", x => x.RightsModelName);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    EndDateTime = table.Column<DateTime>(nullable: false),
                    ImageID = table.Column<Guid>(nullable: true),
                    MaxNumberOfParticipants = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Place = table.Column<string>(nullable: true),
                    StartDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Events_Image_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Image",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    EventID1 = table.Column<Guid>(nullable: true),
                    ImageID = table.Column<Guid>(nullable: true),
                    EventID = table.Column<Guid>(nullable: true),
                    FaceBookLink = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    RightsModelName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Mail);
                    table.ForeignKey(
                        name: "FK_Users_Events_EventID1",
                        column: x => x.EventID1,
                        principalTable: "Events",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Image_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Image",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Rights_RightsModelName",
                        column: x => x.RightsModelName,
                        principalTable: "Rights",
                        principalColumn: "RightsModelName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_ImageID",
                table: "Events",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EventID1",
                table: "Users",
                column: "EventID1");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ImageID",
                table: "Users",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EventID",
                table: "Users",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RightsModelName",
                table: "Users",
                column: "RightsModelName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Rights");

            migrationBuilder.DropTable(
                name: "Image");
        }
    }
}
