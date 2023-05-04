using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace duck_roguelike_backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armor",
                columns: table => new
                {
                    ArmorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArmorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    ArmorType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armor", x => x.ArmorId);
                });

            migrationBuilder.CreateTable(
                name: "Enemy",
                columns: table => new
                {
                    EnemyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnemyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalHealth = table.Column<int>(type: "int", nullable: false),
                    Attack = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    EnemyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFlying = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enemy", x => x.EnemyId);
                });

            migrationBuilder.CreateTable(
                name: "Shop",
                columns: table => new
                {
                    ShopId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopLevel = table.Column<int>(type: "int", nullable: false),
                    ShopCoinsAvailable = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop", x => x.ShopId);
                });

            migrationBuilder.CreateTable(
                name: "Treasure",
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
                    table.PrimaryKey("PK_Treasure", x => x.TreasureId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SavedHeroId1 = table.Column<int>(type: "int", nullable: false),
                    SavedHeroId2 = table.Column<int>(type: "int", nullable: false),
                    SavedHeroId3 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Weapon",
                columns: table => new
                {
                    WeaponId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeaponName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Attack = table.Column<int>(type: "int", nullable: false),
                    WeaponType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapon", x => x.WeaponId);
                });

            migrationBuilder.CreateTable(
                name: "Hero",
                columns: table => new
                {
                    HeroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    HeroName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeroLevel = table.Column<int>(type: "int", nullable: false),
                    TotalHealth = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Hero", x => x.HeroId);
                    table.ForeignKey(
                        name: "FK_Hero_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hero_UserId",
                table: "Hero",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Armor");

            migrationBuilder.DropTable(
                name: "Enemy");

            migrationBuilder.DropTable(
                name: "Hero");

            migrationBuilder.DropTable(
                name: "Shop");

            migrationBuilder.DropTable(
                name: "Treasure");

            migrationBuilder.DropTable(
                name: "Weapon");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
