﻿// <auto-generated />
using CricketApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CricketApp.Data.Migrations
{
    [DbContext(typeof(CricketContext))]
    [Migration("20180709122101_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CricketApp.Domain.FallOfWicket", b =>
                {
                    b.Property<int>("FallOfWicketId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Eight");

                    b.Property<int>("Fifth");

                    b.Property<int>("First");

                    b.Property<int>("Fourth");

                    b.Property<int>("MatchId");

                    b.Property<int>("Ninth");

                    b.Property<int>("Second");

                    b.Property<int>("Seventh");

                    b.Property<int>("Sixth");

                    b.Property<int>("TeamId");

                    b.Property<int>("Tenth");

                    b.Property<int>("Third");

                    b.HasKey("FallOfWicketId");

                    b.HasIndex("MatchId");

                    b.HasIndex("TeamId");

                    b.ToTable("FallOFWickets");
                });

            modelBuilder.Entity("CricketApp.Domain.Match", b =>
                {
                    b.Property<int>("MatchId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateOfMatch");

                    b.Property<string>("GroundName")
                        .IsRequired();

                    b.Property<int>("HomeTeamId");

                    b.Property<byte[]>("MatchLogo")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("MatchOvers");

                    b.Property<int>("MatchTypeId");

                    b.Property<int>("OppponentTeamId");

                    b.Property<string>("Place")
                        .IsRequired();

                    b.Property<string>("Result")
                        .IsRequired();

                    b.Property<int?>("Season");

                    b.Property<string>("Status")
                        .IsRequired();

                    b.Property<int?>("TournamentId");

                    b.Property<int>("UserId");

                    b.HasKey("MatchId");

                    b.HasIndex("HomeTeamId");

                    b.HasIndex("MatchTypeId");

                    b.HasIndex("OppponentTeamId");

                    b.HasIndex("TournamentId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("CricketApp.Domain.MatchType", b =>
                {
                    b.Property<int>("MatchTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MatchTypeName");

                    b.HasKey("MatchTypeId");

                    b.ToTable("MatchType");
                });

            modelBuilder.Entity("CricketApp.Domain.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("BattingStyle");

                    b.Property<string>("BowlingStyle");

                    b.Property<string>("CNIC");

                    b.Property<string>("Contact");

                    b.Property<DateTime?>("DOB");

                    b.Property<string>("Gender")
                        .IsRequired();

                    b.Property<bool>("IsDeactivated");

                    b.Property<bool>("IsGuestPlayer");

                    b.Property<byte[]>("PlayerLogo")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Player_Name")
                        .IsRequired();

                    b.Property<string>("Role");

                    b.Property<string>("Status");

                    b.Property<int>("TeamId");

                    b.Property<int>("UserId");

                    b.HasKey("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("CricketApp.Domain.PlayerScore", b =>
                {
                    b.Property<int>("PlayerScoreId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Ball_Runs");

                    b.Property<int?>("Bat_Balls");

                    b.Property<int?>("Bat_Runs");

                    b.Property<string>("Bowler");

                    b.Property<int?>("Catches");

                    b.Property<int?>("Four");

                    b.Property<string>("HowOut");

                    b.Property<bool>("IsPlayedInning");

                    b.Property<int?>("Maiden");

                    b.Property<int>("MatchId");

                    b.Property<int?>("Overs");

                    b.Property<int>("PlayerId");

                    b.Property<int>("Position");

                    b.Property<int?>("RunOut");

                    b.Property<int?>("Six");

                    b.Property<int?>("Stump");

                    b.Property<int?>("Wickets");

                    b.HasKey("PlayerScoreId");

                    b.HasIndex("MatchId");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerScores");
                });

            modelBuilder.Entity("CricketApp.Domain.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<int>("ClubUserId");

                    b.Property<string>("Place");

                    b.Property<byte[]>("TeamLogo")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Team_Name")
                        .IsRequired();

                    b.Property<string>("Zone");

                    b.HasKey("TeamId");

                    b.HasIndex("ClubUserId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("CricketApp.Domain.TeamScore", b =>
                {
                    b.Property<int>("TeamScoreId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Byes");

                    b.Property<int>("LegByes");

                    b.Property<int>("MatchId");

                    b.Property<int>("NoBalls");

                    b.Property<int>("TeamId");

                    b.Property<int>("TotalScore");

                    b.Property<int>("Wideballs");

                    b.HasKey("TeamScoreId");

                    b.HasIndex("MatchId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamScores");
                });

            modelBuilder.Entity("CricketApp.Domain.Tournament", b =>
                {
                    b.Property<int>("TournamentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Organizor");

                    b.Property<DateTime>("StartingDate");

                    b.Property<int>("TenantUserId");

                    b.Property<string>("TournamentName")
                        .IsRequired();

                    b.Property<int>("UserId");

                    b.HasKey("TournamentId");

                    b.HasIndex("TenantUserId");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

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

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CricketApp.Domain.FallOfWicket", b =>
                {
                    b.HasOne("CricketApp.Domain.Match", "Match")
                        .WithMany()
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CricketApp.Domain.Team", "Team")
                        .WithMany("FallOfWickets")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CricketApp.Domain.Match", b =>
                {
                    b.HasOne("CricketApp.Domain.Team", "HomeTeam")
                        .WithMany("HomeTeamMatches")
                        .HasForeignKey("HomeTeamId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CricketApp.Domain.MatchType", "MatchType")
                        .WithMany("Matches")
                        .HasForeignKey("MatchTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CricketApp.Domain.Team", "OppponentTeam")
                        .WithMany("OpponentTeamMatches")
                        .HasForeignKey("OppponentTeamId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CricketApp.Domain.Tournament", "Tournament")
                        .WithMany("Matches")
                        .HasForeignKey("TournamentId");
                });

            modelBuilder.Entity("CricketApp.Domain.Player", b =>
                {
                    b.HasOne("CricketApp.Domain.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CricketApp.Domain.PlayerScore", b =>
                {
                    b.HasOne("CricketApp.Domain.Match", "Match")
                        .WithMany("PlayerScores")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CricketApp.Domain.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CricketApp.Domain.Team", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser<int>", "ClubUser")
                        .WithMany()
                        .HasForeignKey("ClubUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CricketApp.Domain.TeamScore", b =>
                {
                    b.HasOne("CricketApp.Domain.Match", "Match")
                        .WithMany("TeamScores")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CricketApp.Domain.Team", "Team")
                        .WithMany("TeamScores")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CricketApp.Domain.Tournament", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser<int>", "TenantUser")
                        .WithMany()
                        .HasForeignKey("TenantUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser<int>")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser<int>")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser<int>")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser<int>")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}