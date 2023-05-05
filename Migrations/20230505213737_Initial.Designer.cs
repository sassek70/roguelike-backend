﻿// <auto-generated />
using System;
using DuckGame.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace duck_roguelike_backend.Migrations
{
    [DbContext(typeof(DataContextEntity))]
    [Migration("20230505213737_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DuckGame.Models.Equipment.Armor", b =>
                {
                    b.Property<int>("ArmorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArmorId"));

                    b.Property<string>("ArmorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArmorType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("ArmorId");

                    b.ToTable("Armors");
                });

            modelBuilder.Entity("DuckGame.Models.Equipment.Weapon", b =>
                {
                    b.Property<int>("WeaponId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WeaponId"));

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<string>("WeaponName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WeaponType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WeaponId");

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("DuckGame.Models.Nodes.Enemy", b =>
                {
                    b.Property<int>("EnemyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnemyId"));

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<string>("EnemyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnemyType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsFlying")
                        .HasColumnType("bit");

                    b.Property<int>("TotalHealth")
                        .HasColumnType("int");

                    b.HasKey("EnemyId");

                    b.ToTable("Enemies");
                });

            modelBuilder.Entity("DuckGame.Models.Nodes.Shop", b =>
                {
                    b.Property<int>("ShopId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShopId"));

                    b.Property<int>("ShopCoinsAvailable")
                        .HasColumnType("int");

                    b.Property<int>("ShopLevel")
                        .HasColumnType("int");

                    b.HasKey("ShopId");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("DuckGame.Models.Nodes.Treasure", b =>
                {
                    b.Property<int>("TreasureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TreasureId"));

                    b.Property<int?>("ArmorId")
                        .HasColumnType("int");

                    b.Property<int?>("CoinTotal")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfItems")
                        .HasColumnType("int");

                    b.Property<int?>("WeaponId")
                        .HasColumnType("int");

                    b.HasKey("TreasureId");

                    b.ToTable("Treasures");
                });

            modelBuilder.Entity("DuckGame.Models.PlayerInfo.Hero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BattlesWon")
                        .HasColumnType("int");

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Coins")
                        .HasColumnType("int");

                    b.Property<int>("CurrentNode")
                        .HasColumnType("int");

                    b.Property<int>("CurrentZone")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateLastPlayed")
                        .HasColumnType("datetime2");

                    b.Property<int>("Deaths")
                        .HasColumnType("int");

                    b.Property<int>("EquippedArmorId1")
                        .HasColumnType("int");

                    b.Property<int>("EquippedArmorId2")
                        .HasColumnType("int");

                    b.Property<int>("EquippedArmorId3")
                        .HasColumnType("int");

                    b.Property<int>("EquippedWeaponId1")
                        .HasColumnType("int");

                    b.Property<int>("EquippedWeaponId2")
                        .HasColumnType("int");

                    b.Property<int>("HeroLevel")
                        .HasColumnType("int");

                    b.Property<string>("HeroName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalAttack")
                        .HasColumnType("int");

                    b.Property<int>("TotalBattles")
                        .HasColumnType("int");

                    b.Property<int>("TotalDefense")
                        .HasColumnType("int");

                    b.Property<int>("TotalEquippedArmorSize")
                        .HasColumnType("int");

                    b.Property<int>("TotalEquippedWeaponSize")
                        .HasColumnType("int");

                    b.Property<int>("TotalHealth")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Heroes");
                });

            modelBuilder.Entity("DuckGame.Models.PlayerInfo.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DuckGame.Models.PlayerInfo.Hero", b =>
                {
                    b.HasOne("DuckGame.Models.PlayerInfo.User", "User")
                        .WithMany("Heroes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DuckGame.Models.PlayerInfo.User", b =>
                {
                    b.Navigation("Heroes");
                });
#pragma warning restore 612, 618
        }
    }
}