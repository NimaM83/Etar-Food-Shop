using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Etar.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class cartAndOrderMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFinished",
                table: "adminCarts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    User = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropColumn(
                name: "IsFinished",
                table: "adminCarts");
        }
    }
}
