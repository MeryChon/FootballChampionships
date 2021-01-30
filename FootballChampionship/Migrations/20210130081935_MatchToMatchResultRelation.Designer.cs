﻿// <auto-generated />
using System;
using FootballChampionship.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FootballChampionship.Migrations
{
    [DbContext(typeof(FootballChampionshipDbContext))]
    [Migration("20210130081935_MatchToMatchResultRelation")]
    partial class MatchToMatchResultRelation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("FootballChampionship.Domain.Model.Championship", b =>
                {
                    b.Property<int>("ChampionshipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Desciprtion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ChampionshipId");

                    b.ToTable("Championship");
                });

            modelBuilder.Entity("FootballChampionship.Domain.Model.Match", b =>
                {
                    b.Property<int>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ChampionshipId")
                        .HasColumnType("int");

                    b.Property<int>("FirstTeamId")
                        .HasColumnType("int");

                    b.Property<int?>("MatchResultId")
                        .HasColumnType("int");

                    b.Property<int>("SecondTeamId")
                        .HasColumnType("int");

                    b.HasKey("MatchId");

                    b.HasIndex("ChampionshipId");

                    b.HasIndex("FirstTeamId");

                    b.HasIndex("MatchResultId")
                        .IsUnique()
                        .HasFilter("[MatchResultId] IS NOT NULL");

                    b.HasIndex("SecondTeamId");

                    b.ToTable("Match");
                });

            modelBuilder.Entity("FootballChampionship.Domain.Model.MatchResult", b =>
                {
                    b.Property<int>("MatchResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<int>("ResultType")
                        .HasColumnType("int");

                    b.Property<int?>("WinningTeamId")
                        .HasColumnType("int");

                    b.HasKey("MatchResultId");

                    b.HasIndex("WinningTeamId");

                    b.ToTable("MatchResult");
                });

            modelBuilder.Entity("FootballChampionship.Domain.Model.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TeamId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Team");
                });

            modelBuilder.Entity("FootballChampionship.Domain.Model.TeamChampionshipScore", b =>
                {
                    b.Property<int>("TeamChampionshipScoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ChampionshipId")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("TeamChampionshipScoreId");

                    b.HasIndex("ChampionshipId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamChampionshipScore");
                });

            modelBuilder.Entity("FootballChampionship.Domain.Model.Match", b =>
                {
                    b.HasOne("FootballChampionship.Domain.Model.Championship", "Championship")
                        .WithMany("Matches")
                        .HasForeignKey("ChampionshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FootballChampionship.Domain.Model.Team", "FirstTeam")
                        .WithMany("MatchesAsFirst")
                        .HasForeignKey("FirstTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FootballChampionship.Domain.Model.MatchResult", "MatchResult")
                        .WithOne("Match")
                        .HasForeignKey("FootballChampionship.Domain.Model.Match", "MatchResultId")
                        .OnDelete(DeleteBehavior.ClientNoAction);

                    b.HasOne("FootballChampionship.Domain.Model.Team", "SecondTeam")
                        .WithMany("MatchesAsSecond")
                        .HasForeignKey("SecondTeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Championship");

                    b.Navigation("FirstTeam");

                    b.Navigation("MatchResult");

                    b.Navigation("SecondTeam");
                });

            modelBuilder.Entity("FootballChampionship.Domain.Model.MatchResult", b =>
                {
                    b.HasOne("FootballChampionship.Domain.Model.Team", "WinningTeam")
                        .WithMany("MatchResultVictories")
                        .HasForeignKey("WinningTeamId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("WinningTeam");
                });

            modelBuilder.Entity("FootballChampionship.Domain.Model.TeamChampionshipScore", b =>
                {
                    b.HasOne("FootballChampionship.Domain.Model.Championship", "Championship")
                        .WithMany("TeamScores")
                        .HasForeignKey("ChampionshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FootballChampionship.Domain.Model.Team", "Team")
                        .WithMany("ChampionshipScores")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Championship");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("FootballChampionship.Domain.Model.Championship", b =>
                {
                    b.Navigation("Matches");

                    b.Navigation("TeamScores");
                });

            modelBuilder.Entity("FootballChampionship.Domain.Model.MatchResult", b =>
                {
                    b.Navigation("Match");
                });

            modelBuilder.Entity("FootballChampionship.Domain.Model.Team", b =>
                {
                    b.Navigation("ChampionshipScores");

                    b.Navigation("MatchesAsFirst");

                    b.Navigation("MatchesAsSecond");

                    b.Navigation("MatchResultVictories");
                });
#pragma warning restore 612, 618
        }
    }
}
