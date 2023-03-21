using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4Sale.Migrations
{
    /// <inheritdoc />
    public partial class AddedfieldEnumtoItemtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Item");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Item",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Item",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
