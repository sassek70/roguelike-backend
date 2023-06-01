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
    [Migration("20230601182614_updateHeroColumns")]
    partial class updateHeroColumns
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

                    b.HasKey("ArmorId");

                    b.ToTable("Armors");

                    b.HasData(
                        new
                        {
                            ArmorId = 1,
                            ArmorName = "Fresh Lilipad Helmet",
                            ArmorType = "Helmet",
                            Defense = 2
                        },
                        new
                        {
                            ArmorId = 2,
                            ArmorName = "Fresh Lilipad Breastplate",
                            ArmorType = "Chest",
                            Defense = 2
                        },
                        new
                        {
                            ArmorId = 3,
                            ArmorName = "Fresh Lilipad Shins",
                            ArmorType = "Legs",
                            Defense = 2
                        },
                        new
                        {
                            ArmorId = 4,
                            ArmorName = "Decayed Lilipad Helmet",
                            ArmorType = "Helmet",
                            Defense = 1
                        },
                        new
                        {
                            ArmorId = 5,
                            ArmorName = "Decayed Lilipad Breastplate",
                            ArmorType = "Chest",
                            Defense = 1
                        },
                        new
                        {
                            ArmorId = 6,
                            ArmorName = "Decayed Lilipad Shins",
                            ArmorType = "Legs",
                            Defense = 1
                        },
                        new
                        {
                            ArmorId = 7,
                            ArmorName = "Wood Helmet",
                            ArmorType = "Helmet",
                            Defense = 3
                        },
                        new
                        {
                            ArmorId = 8,
                            ArmorName = "Wood Breatplaste",
                            ArmorType = "Chest",
                            Defense = 3
                        },
                        new
                        {
                            ArmorId = 9,
                            ArmorName = "Wood Shins",
                            ArmorType = "Legs",
                            Defense = 3
                        });
                });

            modelBuilder.Entity("DuckGame.Models.Equipment.Weapon", b =>
                {
                    b.Property<int>("WeaponId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WeaponId"));

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<string>("WeaponName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WeaponType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WeaponId");

                    b.ToTable("Weapons");

                    b.HasData(
                        new
                        {
                            WeaponId = 1,
                            Attack = 2,
                            WeaponName = "Fresh Reed",
                            WeaponType = "Melee"
                        },
                        new
                        {
                            WeaponId = 2,
                            Attack = 1,
                            WeaponName = "Decayed Reed",
                            WeaponType = "Melee"
                        },
                        new
                        {
                            WeaponId = 3,
                            Attack = 2,
                            WeaponName = "Stick",
                            WeaponType = "Melee"
                        },
                        new
                        {
                            WeaponId = 4,
                            Attack = 1,
                            WeaponName = "Stone Slinger",
                            WeaponType = "Ranged"
                        },
                        new
                        {
                            WeaponId = 5,
                            Attack = 2,
                            WeaponName = "Sharp Stick",
                            WeaponType = "Melee"
                        });
                });

            modelBuilder.Entity("DuckGame.Models.Nodes.Enemy", b =>
                {
                    b.Property<int>("EnemyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnemyId"));

                    b.Property<int>("EnemyAttack")
                        .HasColumnType("int");

                    b.Property<int>("EnemyDefense")
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

                    b.HasData(
                        new
                        {
                            EnemyId = 1,
                            EnemyAttack = 1,
                            EnemyDefense = 1,
                            EnemyName = "Tadpole",
                            EnemyType = "Low-tier",
                            IsFlying = false,
                            TotalHealth = 20
                        },
                        new
                        {
                            EnemyId = 2,
                            EnemyAttack = 2,
                            EnemyDefense = 4,
                            EnemyName = "Turtle",
                            EnemyType = "Low-tier",
                            IsFlying = false,
                            TotalHealth = 35
                        },
                        new
                        {
                            EnemyId = 3,
                            EnemyAttack = 2,
                            EnemyDefense = 2,
                            EnemyName = "Gosling",
                            EnemyType = "Low-tier",
                            IsFlying = false,
                            TotalHealth = 25
                        },
                        new
                        {
                            EnemyId = 4,
                            EnemyAttack = 2,
                            EnemyDefense = 5,
                            EnemyName = "Snail",
                            EnemyType = "Low-tier",
                            IsFlying = false,
                            TotalHealth = 45
                        },
                        new
                        {
                            EnemyId = 5,
                            EnemyAttack = 7,
                            EnemyDefense = 8,
                            EnemyName = "Large Snail",
                            EnemyType = "High-tier",
                            IsFlying = false,
                            TotalHealth = 30
                        },
                        new
                        {
                            EnemyId = 6,
                            EnemyAttack = 2,
                            EnemyDefense = 2,
                            EnemyName = "Angry Duck",
                            EnemyType = "High-tier",
                            IsFlying = false,
                            TotalHealth = 30
                        },
                        new
                        {
                            EnemyId = 7,
                            EnemyAttack = 4,
                            EnemyDefense = 6,
                            EnemyName = "Goose",
                            EnemyType = "High-tier",
                            IsFlying = true,
                            TotalHealth = 55
                        },
                        new
                        {
                            EnemyId = 8,
                            EnemyAttack = 7,
                            EnemyDefense = 7,
                            EnemyName = "King Toad",
                            EnemyType = "Boss-tier",
                            IsFlying = false,
                            TotalHealth = 60
                        },
                        new
                        {
                            EnemyId = 9,
                            EnemyAttack = 10,
                            EnemyDefense = 15,
                            EnemyName = "Hawk",
                            EnemyType = "Boss-tier",
                            IsFlying = true,
                            TotalHealth = 90
                        },
                        new
                        {
                            EnemyId = 10,
                            EnemyAttack = 15,
                            EnemyDefense = 13,
                            EnemyName = "Falcon",
                            EnemyType = "Boss-tier",
                            IsFlying = true,
                            TotalHealth = 120
                        });
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
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "battlesWon");

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Coins")
                        .HasColumnType("int");

                    b.Property<int>("CurrentHealth")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "currentHealth");

                    b.Property<int>("CurrentNode")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "currentNode");

                    b.Property<int>("CurrentZone")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "currentZone");

                    b.Property<DateTime>("DateLastPlayed")
                        .HasColumnType("datetime2")
                        .HasAnnotation("Relational:JsonPropertyName", "dateLastPlayed");

                    b.Property<int>("Deaths")
                        .HasColumnType("int");

                    b.Property<int>("EquippedArmorId")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "equipedArmorId");

                    b.Property<int>("EquippedArmorId1")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "equipedArmorId1");

                    b.Property<int>("EquippedArmorId2")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "equipedArmorId2");

                    b.Property<int>("EquippedArmorId3")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "equipedArmorId3");

                    b.Property<int>("EquippedWeaponId")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "equipedWeaponId");

                    b.Property<int>("EquippedWeaponId1")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "equipedWeaponId1");

                    b.Property<int>("EquippedWeaponId2")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "equipedWeaponId2");

                    b.Property<int>("HeroLevel")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "heroLevel");

                    b.Property<string>("HeroName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "heroName");

                    b.Property<int>("TotalAttack")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "totalAttack");

                    b.Property<int>("TotalBattles")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "totalBattles");

                    b.Property<int>("TotalDefense")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "totalDefense");

                    b.Property<int>("TotalEquippedArmorSize")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "totalEquipedArmorSize");

                    b.Property<int>("TotalEquippedWeaponSize")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "totalEquippedWeaponSize");

                    b.Property<int>("TotalHealth")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "totalHealth");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "userId");

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

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "userName");

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
