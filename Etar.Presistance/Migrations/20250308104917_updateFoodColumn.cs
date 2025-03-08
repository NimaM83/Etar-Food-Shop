using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Etar.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class updateFoodColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_foods_foodCategories_CaategoryId",
                table: "foods");

            migrationBuilder.RenameColumn(
                name: "CaategoryId",
                table: "foods",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_foods_CaategoryId",
                table: "foods",
                newName: "IX_foods_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_foods_foodCategories_CategoryId",
                table: "foods",
                column: "CategoryId",
                principalTable: "foodCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_foods_foodCategories_CategoryId",
                table: "foods");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "foods",
                newName: "CaategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_foods_CategoryId",
                table: "foods",
                newName: "IX_foods_CaategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_foods_foodCategories_CaategoryId",
                table: "foods",
                column: "CaategoryId",
                principalTable: "foodCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
