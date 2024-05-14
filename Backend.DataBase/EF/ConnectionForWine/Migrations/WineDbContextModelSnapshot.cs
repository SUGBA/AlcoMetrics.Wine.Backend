﻿// <auto-generated />
using System;
using DataBase.EF.ConnectionForWine.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataBase.EF.ConnectionForWine.Migrations
{
    [DbContext(typeof(WineDbContext))]
    partial class WineDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityAlwaysColumns(modelBuilder);

            modelBuilder.Entity("Core.Models.WineRealizations.AreometrDefaultValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

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

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

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

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

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

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

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

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<int>("DayId")
                        .HasColumnType("integer");

                    b.Property<int>("DesiredIndicatorId")
                        .HasColumnType("integer");

                    b.Property<int>("EventType")
                        .HasColumnType("integer");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.Property<int?>("ResultIndicatorId")
                        .HasColumnType("integer");

                    b.Property<int>("TypicalEventId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DayId");

                    b.HasIndex("DesiredIndicatorId");

                    b.HasIndex("ResultIndicatorId");

                    b.HasIndex("TypicalEventId");

                    b.ToTable("WineEvents");
                });

            modelBuilder.Entity("Core.Models.WineRealizations.WineIndicator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

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

            modelBuilder.Entity("Core.Models.WineRealizations.WineIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("IngredientName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("IngredientValue")
                        .HasColumnType("double precision");

                    b.Property<int?>("WineEventId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("WineEventId");

                    b.ToTable("WineIngredient");
                });

            modelBuilder.Entity("Core.Models.WineRealizations.WineReferenceInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

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

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<int?>("StartAreometerValue")
                        .HasColumnType("integer");

                    b.Property<string>("TimeLineName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("WineTimeLines");
                });

            modelBuilder.Entity("Core.Models.WineRealizations.WineTypicalEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

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

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

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
                        .WithOne()
                        .HasForeignKey("Core.Models.WineRealizations.WineEvent", "DesiredIndicatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Models.WineRealizations.WineIndicator", "ResultIndicator")
                        .WithOne()
                        .HasForeignKey("Core.Models.WineRealizations.WineEvent", "ResultIndicatorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Core.Models.WineRealizations.WineTypicalEvent", "TypicalEvent")
                        .WithMany()
                        .HasForeignKey("TypicalEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Day");

                    b.Navigation("DesiredIndicator");

                    b.Navigation("ResultIndicator");

                    b.Navigation("TypicalEvent");
                });

            modelBuilder.Entity("Core.Models.WineRealizations.WineIngredient", b =>
                {
                    b.HasOne("Core.Models.WineRealizations.WineEvent", null)
                        .WithMany("Ingridients")
                        .HasForeignKey("WineEventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Core.Models.WineRealizations.WineTimeLine", b =>
                {
                    b.HasOne("Core.Models.WineRealizations.WineUser", "User")
                        .WithMany("TimeLines")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Models.WineRealizations.WineDay", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("Core.Models.WineRealizations.WineEvent", b =>
                {
                    b.Navigation("Ingridients");
                });

            modelBuilder.Entity("Core.Models.WineRealizations.WineTimeLine", b =>
                {
                    b.Navigation("Days");
                });

            modelBuilder.Entity("Core.Models.WineRealizations.WineUser", b =>
                {
                    b.Navigation("TimeLines");
                });
#pragma warning restore 612, 618
        }
    }
}
