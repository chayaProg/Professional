using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataContext.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professionals_Categories_CategoryId",
                table: "Professionals");

            migrationBuilder.DropIndex(
                name: "IX_Professionals_CategoryId",
                table: "Professionals");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Professionals");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Professionals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Professionals_CategoryId",
                table: "Professionals",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Professionals_Categories_CategoryId",
                table: "Professionals",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
