﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApp.DataAccess.DbContexts;

namespace WebApp.Migrations
{
    [DbContext(typeof(PostgresDbContext))]
    [Migration("20201210220558_AddUniqueConstraintForUsername")]
    partial class AddUniqueConstraintForUsername
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("WebApp.Domain.Core.Petition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int?>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Header")
                        .HasColumnType("text");

                    b.Property<long>("NextGoal")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("text");

                    b.Property<long>("TotalGoal")
                        .HasColumnType("bigint");

                    b.Property<long>("VotersAmount")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Petitions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Eu nislnunc mi ipsum faucibus vitae aliquet nec.",
                            ExpirationDate = new DateTime(2020, 12, 10, 22, 5, 57, 317, DateTimeKind.Utc).AddTicks(7617),
                            Header = "TestPetition",
                            NextGoal = 100L,
                            PublicationDate = new DateTime(2020, 12, 10, 22, 5, 57, 317, DateTimeKind.Utc).AddTicks(6392),
                            ShortDescription = "ShortDescription",
                            TotalGoal = 20000L,
                            VotersAmount = 15L
                        });
                });

            modelBuilder.Entity("WebApp.Domain.Core.PetitionUser", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("PetitionId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "PetitionId");

                    b.HasIndex("PetitionId");

                    b.ToTable("PetitionUser");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            PetitionId = 1
                        },
                        new
                        {
                            UserId = 2,
                            PetitionId = 1
                        },
                        new
                        {
                            UserId = 3,
                            PetitionId = 1
                        });
                });

            modelBuilder.Entity("WebApp.Domain.Core.Poll", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int?>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Header")
                        .HasColumnType("text");

                    b.Property<bool>("IsAnonymous")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("text");

                    b.Property<long>("VotersAmount")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Polls");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Eu nislnunc mi ipsum faucibus vitae aliquet nec.",
                            Header = "TestPetition",
                            IsAnonymous = false,
                            PublicationDate = new DateTime(2020, 12, 10, 22, 5, 57, 318, DateTimeKind.Utc).AddTicks(237),
                            ShortDescription = "ShortDescription",
                            VotersAmount = 15L
                        });
                });

            modelBuilder.Entity("WebApp.Domain.Core.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasAlternateKey("UserName");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            Email = "testuser@mail.ru",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "testUser"
                        },
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            Email = "testuser1@mail.ru",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "testUser1"
                        },
                        new
                        {
                            Id = 3,
                            AccessFailedCount = 0,
                            Email = "testuser2@mail.ru",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "testUser2"
                        });
                });

            modelBuilder.Entity("WebApp.Domain.Core.VotingOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<int?>("PollId")
                        .HasColumnType("integer");

                    b.Property<long>("VotersAmount")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PollId");

                    b.ToTable("Options");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "1",
                            PollId = 1,
                            VotersAmount = 3L
                        },
                        new
                        {
                            Id = 2,
                            Content = "2",
                            PollId = 1,
                            VotersAmount = 2L
                        });
                });

            modelBuilder.Entity("WebApp.Domain.Core.VotingOptionUser", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("VotingOptionId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "VotingOptionId");

                    b.HasIndex("VotingOptionId");

                    b.ToTable("VotingOptionUser");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            VotingOptionId = 1
                        },
                        new
                        {
                            UserId = 2,
                            VotingOptionId = 1
                        },
                        new
                        {
                            UserId = 3,
                            VotingOptionId = 1
                        },
                        new
                        {
                            UserId = 1,
                            VotingOptionId = 2
                        },
                        new
                        {
                            UserId = 2,
                            VotingOptionId = 2
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("WebApp.Domain.Core.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("WebApp.Domain.Core.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp.Domain.Core.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("WebApp.Domain.Core.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApp.Domain.Core.Petition", b =>
                {
                    b.HasOne("WebApp.Domain.Core.User", "Author")
                        .WithMany("UserPetitions")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Author");
                });

            modelBuilder.Entity("WebApp.Domain.Core.PetitionUser", b =>
                {
                    b.HasOne("WebApp.Domain.Core.Petition", "Petition")
                        .WithMany("Voters")
                        .HasForeignKey("PetitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp.Domain.Core.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Petition");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApp.Domain.Core.Poll", b =>
                {
                    b.HasOne("WebApp.Domain.Core.User", "Author")
                        .WithMany("UserPolls")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Author");
                });

            modelBuilder.Entity("WebApp.Domain.Core.VotingOption", b =>
                {
                    b.HasOne("WebApp.Domain.Core.Poll", "Poll")
                        .WithMany("Options")
                        .HasForeignKey("PollId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Poll");
                });

            modelBuilder.Entity("WebApp.Domain.Core.VotingOptionUser", b =>
                {
                    b.HasOne("WebApp.Domain.Core.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp.Domain.Core.VotingOption", "VotingOption")
                        .WithMany("Voters")
                        .HasForeignKey("VotingOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("VotingOption");
                });

            modelBuilder.Entity("WebApp.Domain.Core.Petition", b =>
                {
                    b.Navigation("Voters");
                });

            modelBuilder.Entity("WebApp.Domain.Core.Poll", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("WebApp.Domain.Core.User", b =>
                {
                    b.Navigation("UserPetitions");

                    b.Navigation("UserPolls");
                });

            modelBuilder.Entity("WebApp.Domain.Core.VotingOption", b =>
                {
                    b.Navigation("Voters");
                });
#pragma warning restore 612, 618
        }
    }
}
