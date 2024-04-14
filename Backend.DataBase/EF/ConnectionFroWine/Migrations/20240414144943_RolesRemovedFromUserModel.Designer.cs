﻿// <auto-generated />
using System;
using DataBase.EF.ConnectionFroWine.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataBase.EF.ConnectionFroWine.Migrations
{
    [DbContext(typeof(WineDbContext))]
    [Migration("20240414144943_RolesRemovedFromUserModel")]
    partial class RolesRemovedFromUserModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Core.Models.WineRealizations.AreometrDefaultValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AreometerValue")
                        .HasColumnType("integer");

                    b.Property<double>("SugarValue")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("AreometrDefaultValues");
                });

            modelBuilder.Entity("Core.Models.WineRealizations.DifferenceAreometrDefaultValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DifferenceAreometerValue")
                        .HasColumnType("integer");

                    b.Property<double>("EthanolValue")
                        .HasColumnType("double precision");

                    b.Property<double>("SugarValue")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("DifferenceAreometrDefaultValues");
                });

            modelBuilder.Entity("Core.Models.WineRealizations.GrapeVariety", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("AcidValue")
                        .HasColumnType("double precision");

                    b.Property<string>("GrapeVarietyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("SugarValue")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("GrapeVarieties");
                });

            modelBuilder.Entity("Core.Models.WineRealizations.WineDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CurrentDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("IndicatorId")
                        .HasColumnType("integer");

                    b.Property<int>("TimeLineId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IndicatorId");

                    b.HasIndex("TimeLineId");

                    b.ToTable("WineDays");
                });

            modelBuilder.Entity("Core.Models.WineRealizations.WineEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DayId")
                        .HasColumnType("integer");

                    b.Property<int>("DesiredIndicatorId")
                        .HasColumnType("integer");

                    b.Property<int>("EventType")
                        .HasColumnType("integer");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.Property<int>("TypicalEventId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DayId");

                    b.HasIndex("DesiredIndicatorId");

                    b.HasIndex("TypicalEventId");

                    b.ToTable("WineEvents");
                });

            modelBuilder.Entity("Core.Models.WineRealizations.WineIndicator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("EthanolValue")
                        .HasColumnType("double precision");

                    b.Property<double>("NitrogenValue")
                        .HasColumnType("double precision");

                    b.Property<double>("SugarValue")
                        .HasColumnType("double precision");

                    b.Property<double>("WortValue")
                        .HasColumnType("double precision");

                    b.Property<double>("YeastValue")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("WineIndicators");
                });

            modelBuilder.Entity("Core.Models.WineRealizations.WineReferenceInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Information")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UsedModule")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("WineReferenceInformations");
                });

            modelBuilder.Entity("Core.Models.WineRealizations.WineTimeLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("TimeLineName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("WineTimeLines");
                });

            modelBuilder.Entity("Core.Models.WineRealizations.WineTypicalEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("EventType")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("WineTypicalEvents");
                });

            modelBuilder.Entity("Core.Models.WineRealizations.WineUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("WineUsers");
                });

            modelBuilder.Entity("Core.Models.WineRealizations.WineDay", b =>
                {
                    b.HasOne("Core.Models.WineRealizations.WineIndicator", "Indicator")
                        .WithMany()
                        .HasForeignKey("IndicatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Models.WineRealizations.WineTimeLine", "TimeLine")
                        .WithMany("Days")
                        .HasForeignKey("TimeLineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Indicator");

                    b.Navigation("TimeLine");
                });

            modelBuilder.Entity("Core.Models.WineRealizations.WineEvent", b =>
                {
                    b.HasOne("Core.Models.WineRealizations.WineDay", "Day")
                        .WithMany("Events")
                        .HasForeignKey("DayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Models.WineRealizations.WineIndicator", "DesiredIndicator")
                        .WithMany()
                        .HasForeignKey("DesiredIndicatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Models.WineRealizations.WineTypicalEvent", "TypicalEvent")
                        .WithMany()
                        .HasForeignKey("TypicalEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Day");

                    b.Navigation("DesiredIndicator");

                    b.Navigation("TypicalEvent");
                });

            modelBuilder.Entity("Core.Models.WineRealizations.WineTimeLine", b =>
                {
                    b.HasOne("Core.Models.WineRealizations.WineUser", "User")
                        .WithOne("TimeLines")
                        .HasForeignKey("Core.Models.WineRealizations.WineTimeLine", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Models.WineRealizations.WineDay", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("Core.Models.WineRealizations.WineTimeLine", b =>
                {
                    b.Navigation("Days");
                });

            modelBuilder.Entity("Core.Models.WineRealizations.WineUser", b =>
                {
                    b.Navigation("TimeLines")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
