using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestLog.Migrations
{
    /// <inheritdoc />
    public partial class NovaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Noticias_Category_CategoryId",
                table: "Noticias");

            migrationBuilder.DropForeignKey(
                name: "FK_Noticias_Game_GameId",
                table: "Noticias");

            migrationBuilder.DropForeignKey(
                name: "FK_Noticias_Users_UserId",
                table: "Noticias");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Noticias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Noticias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Noticias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Noticias_Category_CategoryId",
                table: "Noticias",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Noticias_Game_GameId",
                table: "Noticias",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Noticias_Users_UserId",
                table: "Noticias",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Noticias_Category_CategoryId",
                table: "Noticias");

            migrationBuilder.DropForeignKey(
                name: "FK_Noticias_Game_GameId",
                table: "Noticias");

            migrationBuilder.DropForeignKey(
                name: "FK_Noticias_Users_UserId",
                table: "Noticias");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Noticias",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Noticias",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Noticias",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Noticias_Category_CategoryId",
                table: "Noticias",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Noticias_Game_GameId",
                table: "Noticias",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Noticias_Users_UserId",
                table: "Noticias",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
