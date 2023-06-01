using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace duck_roguelike_backend.Migrations
{
    /// <inheritdoc />
    public partial class updateHeroColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquippedArmorId",
                table: "Heroes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EquippedWeaponId",
                table: "Heroes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EquippedArmorId",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "EquippedWeaponId",
                table: "Heroes");
        }
    }
}
