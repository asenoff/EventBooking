﻿// <auto-generated />
using EventBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace EventBooking.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20171203120747_IdentityAdded")]
    partial class IdentityAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EventBooking.Core.Entities.DatabaseModels.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("IsClubMember");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("RightsAlias")
                        .IsRequired();

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("RightsAlias");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("AppUser");
                });

            modelBuilder.Entity("EventBooking.Core.Entities.DatabaseModels.Car", b =>
                {
                    b.Property<string>("RegistrationID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10);

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("BikeCount");

                    b.Property<string>("Description")
                        .HasMaxLength(250);

                    b.Property<int>("PassengerCount");

                    b.HasKey("RegistrationID");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("EventBooking.Core.Entities.DatabaseModels.Driver", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CarId");

                    b.Property<int>("EventId");

                    b.Property<string>("ParticipantId");

                    b.Property<string>("ParticipantMail");

                    b.Property<string>("RegistrationId");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("ParticipantId");

                    b.HasIndex("RegistrationId")
                        .IsUnique()
                        .HasFilter("[RegistrationId] IS NOT NULL");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("EventBooking.Core.Entities.DatabaseModels.Event", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000);

                    b.Property<DateTime>("EndDateTime");

                    b.Property<bool>("FirstTimerPreference");

                    b.Property<int>("MaxNumberOfParticipants");

                    b.Property<bool>("MembershipPreference");

                    b.Property<int?>("MinNumberOfCars");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1200);

                    b.Property<bool>("OrganizeCarsTransportation");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("StartDateTime");

                    b.HasKey("ID");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("EventBooking.Core.Entities.DatabaseModels.Image", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Data")
                        .IsRequired();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("Height");

                    b.Property<int>("Length");

                    b.Property<byte[]>("Name")
                        .IsRequired();

                    b.Property<int>("Width");

                    b.HasKey("ID");

                    b.ToTable("Images");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Image");
                });

            modelBuilder.Entity("EventBooking.Core.Entities.DatabaseModels.Mails", b =>
                {
                    b.Property<string>("MailAlias")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MailName");

                    b.Property<string>("MailTemplate");

                    b.HasKey("MailAlias");

                    b.ToTable("Mails");
                });

            modelBuilder.Entity("EventBooking.Core.Entities.DatabaseModels.ManyToMany.EventGuide", b =>
                {
                    b.Property<int>("EventId");

                    b.Property<string>("GuideMail");

                    b.HasKey("EventId", "GuideMail");

                    b.HasIndex("GuideMail");

                    b.ToTable("EventGuides");
                });

            modelBuilder.Entity("EventBooking.Core.Entities.DatabaseModels.ManyToMany.EventParticipant", b =>
                {
                    b.Property<int>("EventId");

                    b.Property<string>("ParticipantMail");

                    b.HasKey("EventId", "ParticipantMail");

                    b.HasIndex("ParticipantMail");

                    b.ToTable("EventParticipants");
                });

            modelBuilder.Entity("EventBooking.Core.Entities.DatabaseModels.Passenger", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CarId");

                    b.Property<string>("CarRegistrationID");

                    b.Property<int>("EventId");

                    b.Property<string>("ParticipantId");

                    b.Property<string>("ParticipantMail");

                    b.HasKey("Id");

                    b.HasIndex("CarRegistrationID");

                    b.HasIndex("EventId");

                    b.HasIndex("ParticipantId");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("EventBooking.Core.Entities.DatabaseModels.PreferencesSet", b =>
                {
                    b.Property<string>("UserMail");

                    b.Property<bool>("RecieveFullEventInfo");

                    b.Property<bool>("RecieveMailsFromApp");

                    b.HasKey("UserMail");

                    b.ToTable("Preferences");
                });

            modelBuilder.Entity("EventBooking.Core.Entities.DatabaseModels.RightsSet", b =>
                {
                    b.Property<string>("RightsAlias")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CanChangeRights");

                    b.Property<bool>("CanCreateEvents");

                    b.Property<bool>("CanDeleteEvents");

                    b.Property<bool>("CanDeleteUser");

                    b.Property<bool>("CanSeeUsers");

                    b.Property<bool>("CanUpdateEventDescription");

                    b.Property<bool>("CanUpdateEventParticipants");

                    b.Property<bool>("CanUpdateUser");

                    b.HasKey("RightsAlias");

                    b.ToTable("Rights");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("EventBooking.Core.Entities.DatabaseModels.Participant", b =>
                {
                    b.HasBaseType("EventBooking.Core.Entities.DatabaseModels.AppUser");

                    b.Property<string>("FacebookLink");

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.Property<string>("UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Participant");

                    b.HasDiscriminator().HasValue("Participant");
                });

            modelBuilder.Entity("EventBooking.Core.Entities.DatabaseModels.EventImage", b =>
                {
                    b.HasBaseType("EventBooking.Core.Entities.DatabaseModels.Image");

                    b.Property<int>("EventID");

                    b.HasIndex("EventID")
                        .IsUnique();

                    b.ToTable("EventImage");

                    b.HasDiscriminator().HasValue("EventImage");
                });

            modelBuilder.Entity("EventBooking.Core.Entities.DatabaseModels.UserImage", b =>
                {
                    b.HasBaseType("EventBooking.Core.Entities.DatabaseModels.Image");

                    b.Property<string>("UserMail");

                    b.HasIndex("UserMail")
                        .IsUnique()
                        .HasFilter("[UserMail] IS NOT NULL");

                    b.ToTable("UserImage");

                    b.HasDiscriminator().HasValue("UserImage");
                });

            modelBuilder.Entity("EventBooking.Core.Entities.DatabaseModels.Guide", b =>
                {
                    b.HasBaseType("EventBooking.Core.Entities.DatabaseModels.Participant");

                    b.Property<string>("Resume")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.ToTable("Guide");

                    b.HasDiscriminator().HasValue("Guide");
                });

            modelBuilder.Entity("EventBooking.Core.Entities.DatabaseModels.AppUser", b =>
                {
                    b.HasOne("EventBooking.Core.Entities.DatabaseModels.RightsSet", "Rights")
                        .WithMany("Users")
                        .HasForeignKey("RightsAlias")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EventBooking.Core.Entities.DatabaseModels.Driver", b =>
                {
                    b.HasOne("EventBooking.Core.Entities.DatabaseModels.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EventBooking.Core.Entities.DatabaseModels.Participant", "Participant")
                        .WithMany()
                        .HasForeignKey("ParticipantId");

                    b.HasOne("EventBooking.Core.Entities.DatabaseModels.Car", "Car")
                        .WithOne("Driver")
                        .HasForeignKey("EventBooking.Core.Entities.DatabaseModels.Driver", "RegistrationId");
                });

            modelBuilder.Entity("EventBooking.Core.Entities.DatabaseModels.ManyToMany.EventGuide", b =>
                {
                    b.HasOne("EventBooking.Core.Entities.DatabaseModels.Event", "Event")
                        .WithMany("EventGuides")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EventBooking.Core.Entities.DatabaseModels.Guide", "Guide")
                        .WithMany("GuidedEvents")
                        .HasForeignKey("GuideMail")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EventBooking.Core.Entities.DatabaseModels.ManyToMany.EventParticipant", b =>
                {
                    b.HasOne("EventBooking.Core.Entities.DatabaseModels.Event", "Event")
                        .WithMany("EventParticipants")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EventBooking.Core.Entities.DatabaseModels.Participant", "Participant")
                        .WithMany("AttendedEvents")
                        .HasForeignKey("ParticipantMail")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EventBooking.Core.Entities.DatabaseModels.Passenger", b =>
                {
                    b.HasOne("EventBooking.Core.Entities.DatabaseModels.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarRegistrationID");

                    b.HasOne("EventBooking.Core.Entities.DatabaseModels.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EventBooking.Core.Entities.DatabaseModels.Participant", "Participant")
                        .WithMany()
                        .HasForeignKey("ParticipantId");
                });

            modelBuilder.Entity("EventBooking.Core.Entities.DatabaseModels.PreferencesSet", b =>
                {
                    b.HasOne("EventBooking.Core.Entities.DatabaseModels.AppUser", "User")
                        .WithOne("Preferences")
                        .HasForeignKey("EventBooking.Core.Entities.DatabaseModels.PreferencesSet", "UserMail")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("EventBooking.Core.Entities.DatabaseModels.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("EventBooking.Core.Entities.DatabaseModels.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EventBooking.Core.Entities.DatabaseModels.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("EventBooking.Core.Entities.DatabaseModels.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EventBooking.Core.Entities.DatabaseModels.Participant", b =>
                {
                    b.HasOne("EventBooking.Core.Entities.DatabaseModels.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("EventBooking.Core.Entities.DatabaseModels.EventImage", b =>
                {
                    b.HasOne("EventBooking.Core.Entities.DatabaseModels.Event", "Event")
                        .WithOne("Image")
                        .HasForeignKey("EventBooking.Core.Entities.DatabaseModels.EventImage", "EventID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EventBooking.Core.Entities.DatabaseModels.UserImage", b =>
                {
                    b.HasOne("EventBooking.Core.Entities.DatabaseModels.AppUser", "User")
                        .WithOne("Image")
                        .HasForeignKey("EventBooking.Core.Entities.DatabaseModels.UserImage", "UserMail");
                });
#pragma warning restore 612, 618
        }
    }
}
