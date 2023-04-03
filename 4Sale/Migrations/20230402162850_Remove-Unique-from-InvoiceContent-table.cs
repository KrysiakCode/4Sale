using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4Sale.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUniquefromInvoiceContenttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InvoiceContent_ItemId",
                table: "InvoiceContent");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceContent_ItemId",
                table: "InvoiceContent",
                column: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InvoiceContent_ItemId",
                table: "InvoiceContent");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceContent_ItemId",
                table: "InvoiceContent",
                column: "ItemId",
                unique: true);
        }
    }
}
