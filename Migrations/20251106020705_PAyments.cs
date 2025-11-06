using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniShop.API.Migrations
{
    /// <inheritdoc />
    public partial class PAyments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    CardHolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Last4Digits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardPayment_Provider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExternalPaymentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Provider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalletAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TxHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalletProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalletPayment_ExternalPaymentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");
        }
    }
}
