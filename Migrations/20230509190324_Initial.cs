﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace duck_roguelike_backend.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armors",
                columns: table => new
                {
                    ArmorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArmorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    ArmorType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armors", x => x.ArmorId);
                });

            migrationBuilder.CreateTable(
                name: "Enemies",
                columns: table => new
                {
                    EnemyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnemyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalHealth = table.Column<int>(type: "int", nullable: false),
                    EnemyAttack = table.Column<int>(type: "int", nullable: false),
                    EnemyDefense = table.Column<int>(type: "int", nullable: false),
                    EnemyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFlying = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enemies", x => x.EnemyId);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    ShopId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopLevel = table.Column<int>(type: "int", nullable: false),
                    ShopCoinsAvailable = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.ShopId);
                });

            migrationBuilder.CreateTable(
                name: "Treasures",
                columns: table => new
                {
                    TreasureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeaponId = table.Column<int>(type: "int", nullable: true),
                    ArmorId = table.Column<int>(type: "int", nullable: true),
                    NumberOfItems = table.Column<int>(type: "int", nullable: false),
                    CoinTotal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treasures", x => x.TreasureId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    WeaponId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeaponName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attack = table.Column<int>(type: "int", nullable: false),
                    WeaponType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.WeaponId);
                });

            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    HeroName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeroLevel = table.Column<int>(type: "int", nullable: false),
                    TotalHealth = table.Column<int>(type: "int", nullable: false),
                    CurrentHealth = table.Column<int>(type: "int", nullable: false),
                    TotalAttack = table.Column<int>(type: "int", nullable: false),
                    TotalDefense = table.Column<int>(type: "int", nullable: false),
                    TotalBattles = table.Column<int>(type: "int", nullable: false),
                    BattlesWon = table.Column<int>(type: "int", nullable: false),
                    Deaths = table.Column<int>(type: "int", nullable: false),
                    Coins = table.Column<int>(type: "int", nullable: false),
                    TotalEquippedWeaponSize = table.Column<int>(type: "int", nullable: false),
                    TotalEquippedArmorSize = table.Column<int>(type: "int", nullable: false),
                    EquippedWeaponId1 = table.Column<int>(type: "int", nullable: false),
                    EquippedWeaponId2 = table.Column<int>(type: "int", nullable: false),
                    EquippedArmorId1 = table.Column<int>(type: "int", nullable: false),
                    EquippedArmorId2 = table.Column<int>(type: "int", nullable: false),
                    EquippedArmorId3 = table.Column<int>(type: "int", nullable: false),
                    CurrentZone = table.Column<int>(type: "int", nullable: false),
                    CurrentNode = table.Column<int>(type: "int", nullable: false),
                    DateLastPlayed = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Heroes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Armors",
                columns: new[] { "ArmorId", "ArmorName", "ArmorType", "Defense" },
                values: new object[,]
                {
                    { 1, "Fresh Lilipad Helmet", "Helmet", 2 },
                    { 2, "Fresh Lilipad Breastplate", "Chest", 2 },
                    { 3, "Fresh Lilipad Shins", "Legs", 2 },
                    { 4, "Decayed Lilipad Helmet", "Helmet", 1 },
                    { 5, "Decayed Lilipad Breastplate", "Chest", 1 },
                    { 6, "Decayed Lilipad Shins", "Legs", 1 },
                    { 7, "Wood Helmet", "Helmet", 3 },
                    { 8, "Wood Breatplaste", "Chest", 3 },
                    { 9, "Wood Shins", "Legs", 3 }
                });

            migrationBuilder.InsertData(
                table: "Enemies",
                columns: new[] { "EnemyId", "EnemyAttack", "EnemyDefense", "EnemyName", "EnemyType", "IsFlying", "TotalHealth" },
                values: new object[,]
                {
                    { 1, 1, 1, "Tadpole", "Low-tier", false, 20 },
                    { 2, 2, 4, "Turtle", "Low-tier", false, 35 },
                    { 3, 2, 2, "Gosling", "Low-tier", false, 25 },
                    { 4, 2, 5, "Snail", "Low-tier", false, 45 },
                    { 5, 7, 8, "Large Snail", "High-tier", false, 30 },
                    { 6, 2, 2, "Angry Duck", "High-tier", false, 30 },
                    { 7, 4, 6, "Goose", "High-tier", true, 55 },
                    { 8, 7, 7, "King Toad", "Boss-tier", false, 60 },
                    { 9, 10, 15, "Hawk", "Boss-tier", true, 90 },
                    { 10, 15, 13, "Falcon", "Boss-tier", true, 120 }
                });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "WeaponId", "Attack", "WeaponName", "WeaponType" },
                values: new object[,]
                {
                    { 1, 2, "Fresh Reed", "Melee" },
                    { 2, 1, "Decayed Reed", "Melee" },
                    { 3, 2, "Stick", "Melee" },
                    { 4, 1, "Stone Slinger", "Ranged" },
                    { 5, 2, "Sharp Stick", "Melee" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_UserId",
                table: "Heroes",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Armors");

            migrationBuilder.DropTable(
                name: "Enemies");

            migrationBuilder.DropTable(
                name: "Heroes");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "Treasures");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
