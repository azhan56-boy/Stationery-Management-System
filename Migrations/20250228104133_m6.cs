using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stationery_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class m6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_users_userId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_userId",
                table: "Requests");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_superior_id",
                table: "Requests",
                column: "superior_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_users_superior_id",
                table: "Requests",
                column: "superior_id",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_users_superior_id",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_superior_id",
                table: "Requests");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_userId",
                table: "Requests",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_users_userId",
                table: "Requests",
                column: "userId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
