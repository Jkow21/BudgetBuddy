using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetBuddy.Migrations
{
    /// <inheritdoc />
    public partial class MakeAccountIdNullableInUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AccountId1",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AccountId1",
                table: "AspNetUsers",
                column: "AccountId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Accounts_AccountId1",
                table: "AspNetUsers",
                column: "AccountId1",
                principalTable: "Accounts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Accounts_AccountId1",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AccountId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AccountId1",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
