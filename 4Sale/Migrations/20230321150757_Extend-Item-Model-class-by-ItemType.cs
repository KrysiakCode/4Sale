using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4Sale.Migrations
{
    /// <inheritdoc />
    public partial class ExtendItemModelclassbyItemType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemType",
                table: "Item",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemType",
                table: "Item");
        }
    }
}
