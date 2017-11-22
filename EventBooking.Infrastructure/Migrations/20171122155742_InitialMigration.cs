using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EventBooking.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: false),
                    EndDateTime = table.Column<DateTime>(nullable: false),
                    MaxNumberOfParticipants = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Place = table.Column<string>(nullable: false),
                    StartDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Mails",
                columns: table => new
                {
                    MailAlias = table.Column<string>(nullable: false),
                    MailName = table.Column<string>(nullable: true),
                    MailTemplate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mails", x => x.MailAlias);
                });

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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Resume = table.Column<string>(nullable: true),
                    FacebookLink = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    UserMail = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    IsClubMember = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    RightsAlias = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Mail);
                    table.ForeignKey(
                        name: "FK_Users_Users_UserMail",
                        column: x => x.UserMail,
                        principalTable: "Users",
                        principalColumn: "Mail",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Rights_RightsAlias",
                        column: x => x.RightsAlias,
                        principalTable: "Rights",
                        principalColumn: "RightsAlias",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventGuides",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false),
                    GuideMail = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventGuides", x => new { x.EventId, x.GuideMail });
                    table.ForeignKey(
                        name: "FK_EventGuides_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventGuides_Users_GuideMail",
                        column: x => x.GuideMail,
                        principalTable: "Users",
                        principalColumn: "Mail",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventParticipants",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false),
                    ParticipantMail = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventParticipants", x => new { x.EventId, x.ParticipantMail });
                    table.ForeignKey(
                        name: "FK_EventParticipants_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventParticipants_Users_ParticipantMail",
                        column: x => x.ParticipantMail,
                        principalTable: "Users",
                        principalColumn: "Mail",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    EventID = table.Column<int>(nullable: true),
                    ID = table.Column<Guid>(nullable: false),
                    Data = table.Column<byte[]>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Length = table.Column<int>(nullable: false),
                    Name = table.Column<byte[]>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    UserMail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Images_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Images_Users_UserMail",
                        column: x => x.UserMail,
                        principalTable: "Users",
                        principalColumn: "Mail",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Preferences",
                columns: table => new
                {
                    UserMail = table.Column<string>(nullable: false),
                    RecieveFullEventInfo = table.Column<bool>(nullable: false),
                    RecieveMailsFromApp = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preferences", x => x.UserMail);
                    table.ForeignKey(
                        name: "FK_Preferences_Users_UserMail",
                        column: x => x.UserMail,
                        principalTable: "Users",
                        principalColumn: "Mail",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventGuides_GuideMail",
                table: "EventGuides",
                column: "GuideMail");

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipants_ParticipantMail",
                table: "EventParticipants",
                column: "ParticipantMail");

            migrationBuilder.CreateIndex(
                name: "IX_Images_EventID",
                table: "Images",
                column: "EventID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserMail",
                table: "Images",
                column: "UserMail",
                unique: true,
                filter: "[UserMail] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserMail",
                table: "Users",
                column: "UserMail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RightsAlias",
                table: "Users",
                column: "RightsAlias");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventGuides");

            migrationBuilder.DropTable(
                name: "EventParticipants");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Mails");

            migrationBuilder.DropTable(
                name: "Preferences");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Rights");
        }
    }
}
