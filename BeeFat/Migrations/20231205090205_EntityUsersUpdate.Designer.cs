﻿// <auto-generated />
using System;
using BeeFat.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BeeFat.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231205090205_EntityUsersUpdate")]
    partial class EntityUsersUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BeeFat.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("text");

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
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("BeeFatUsers");
                });

            modelBuilder.Entity("BeeFat.Domain.Infrastructure.Food", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Carbohydrates")
                        .HasColumnType("integer");

                    b.Property<int>("Fats")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("Proteins")
                        .HasColumnType("integer");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("BeeFat.Domain.Infrastructure.FoodProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("integer");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("character varying(21)");

                    b.Property<Guid>("FoodId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsEaten")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FoodId")
                        .IsUnique();

                    b.ToTable("FoodProduct");

                    b.HasDiscriminator<string>("Discriminator").HasValue("FoodProduct");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("BeeFat.Domain.Infrastructure.FoodProductGram", b =>
                {
                    b.HasBaseType("BeeFat.Domain.Infrastructure.FoodProduct");

                    b.Property<int>("Grams")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue("FoodProductGram");
                });

            modelBuilder.Entity("BeeFat.Domain.Infrastructure.FoodProductPiece", b =>
                {
                    b.HasBaseType("BeeFat.Domain.Infrastructure.FoodProduct");

                    b.Property<int>("Pieces")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue("FoodProductPiece");
                });

            modelBuilder.Entity("BeeFat.Data.ApplicationUser", b =>
                {
                    b.OwnsOne("BeeFat.Domain.Models.User.PersonName", "PersonName", b1 =>
                        {
                            b1.Property<string>("ApplicationUserId")
                                .HasColumnType("text");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("ApplicationUserId");

                            b1.ToTable("BeeFatUsers");

                            b1.WithOwner()
                                .HasForeignKey("ApplicationUserId");
                        });

                    b.Navigation("PersonName")
                        .IsRequired();
                });

            modelBuilder.Entity("BeeFat.Domain.Infrastructure.FoodProduct", b =>
                {
                    b.HasOne("BeeFat.Domain.Infrastructure.Food", "Food")
                        .WithOne()
                        .HasForeignKey("BeeFat.Domain.Infrastructure.FoodProduct", "FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");
                });
#pragma warning restore 612, 618
        }
    }
}
