using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Etar.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class initial2Mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_addresses_users_UserId",
                table: "addresses");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "addresses",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_addresses_UserId",
                table: "addresses",
                newName: "IX_addresses_ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_addresses_users_ClientId",
                table: "addresses",
                column: "ClientId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_addresses_users_ClientId",
                table: "addresses");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "addresses",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_addresses_ClientId",
                table: "addresses",
                newName: "IX_addresses_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_addresses_users_UserId",
                table: "addresses",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
