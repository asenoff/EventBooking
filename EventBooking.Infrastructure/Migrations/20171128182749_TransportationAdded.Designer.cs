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
    [Migration("20171128182749_TransportationAdded")]
    partial class TransportationAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EventBooking.Core.Entities.DatabaseModels.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("BikeCount");

                    b.Property<string>("Description")
                        .HasMaxLength(250);

                    b.Property<int>("PassengerCount");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("EventBooking.Core.Entities.DatabaseModels.Driver", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CarId");

                    b.Property<int>("EventId");

                    b.Property<string>("ParticipantMail");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("EventId");

                    b.HasIndex("ParticipantMail");

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

                    b.Property<int>("EventId");

                    b.Property<string>("ParticipantMail");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("EventId");

                    b.HasIndex("ParticipantMail");

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

            modelBuilder.Entity("EventBooking.Core.Entities.DatabaseModels.User", b =>
                {
                    b.Property<string>("Mail")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("IsClubMember");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("RightsAlias")
                        .IsRequired();

                    b.HasKey("Mail");

                    b.HasIndex("RightsAlias");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
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

            modelBuilder.Entity("EventBooking.Core.Entities.DatabaseModels.Participant", b =>
                {
                    b.HasBaseType("EventBooking.Core.Entities.DatabaseModels.User");

                    b.Property<string>("FacebookLink");

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.Property<string>("UserMail");

                    b.HasIndex("UserMail");

                    b.ToTable("Users");

                    b.HasDiscriminator().HasValue("Participant");
                });

            modelBuilder.Entity("EventBooking.Core.Entities.DatabaseModels.Guide", b =>
                {
                    b.HasBaseType("EventBooking.Core.Entities.DatabaseModels.Participant");

                    b.Property<string>("Resume")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.ToTable("Users");

                    b.HasDiscriminator().HasValue("Guide");
                });

            modelBuilder.Entity("EventBooking.Core.Entities.DatabaseModels.Driver", b =>
                {
                    b.HasOne("EventBooking.Core.Entities.DatabaseModels.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EventBooking.Core.Entities.DatabaseModels.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EventBooking.Core.Entities.DatabaseModels.Participant", "Participant")
                        .WithMany()
                        .HasForeignKey("ParticipantMail");
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
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EventBooking.Core.Entities.DatabaseModels.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EventBooking.Core.Entities.DatabaseModels.Participant", "Participant")
                        .WithMany()
                        .HasForeignKey("ParticipantMail");
                });

            modelBuilder.Entity("EventBooking.Core.Entities.DatabaseModels.PreferencesSet", b =>
                {
                    b.HasOne("EventBooking.Core.Entities.DatabaseModels.User", "User")
                        .WithOne("Preferences")
                        .HasForeignKey("EventBooking.Core.Entities.DatabaseModels.PreferencesSet", "UserMail")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EventBooking.Core.Entities.DatabaseModels.User", b =>
                {
                    b.HasOne("EventBooking.Core.Entities.DatabaseModels.RightsSet", "Rights")
                        .WithMany("Users")
                        .HasForeignKey("RightsAlias")
                        .OnDelete(DeleteBehavior.Cascade);
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
                    b.HasOne("EventBooking.Core.Entities.DatabaseModels.User", "User")
                        .WithOne("Image")
                        .HasForeignKey("EventBooking.Core.Entities.DatabaseModels.UserImage", "UserMail");
                });

            modelBuilder.Entity("EventBooking.Core.Entities.DatabaseModels.Participant", b =>
                {
                    b.HasOne("EventBooking.Core.Entities.DatabaseModels.User", "User")
                        .WithMany()
                        .HasForeignKey("UserMail");
                });
#pragma warning restore 612, 618
        }
    }
}
