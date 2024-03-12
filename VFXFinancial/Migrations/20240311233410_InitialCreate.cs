using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VFXFinancial.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrencyPairs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromCurrencyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromCurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToCurrencyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToCurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyPairs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExchangeRates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrencyPairId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Bid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ask = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExchangeRates_CurrencyPairs_CurrencyPairId",
                        column: x => x.CurrencyPairId,
                        principalTable: "CurrencyPairs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_CurrencyPairId",
                table: "ExchangeRates",
                column: "CurrencyPairId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExchangeRates");

            migrationBuilder.DropTable(
                name: "CurrencyPairs");
        }
    }
}
