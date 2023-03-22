using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4Sale.Migrations
{
    /// <inheritdoc />
    public partial class CreateInvoicetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNo = table.Column<string>(type: "varchar(20)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Vendor = table.Column<string>(type: "varchar(200)", nullable: false),
                    TotalGross = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    TotalVat = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    TotalNet = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoice");
        }
    }
}
