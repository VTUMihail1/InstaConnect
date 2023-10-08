using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstaConnect.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTokenTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tokens_user_UserId",
                table: "Tokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tokens",
                table: "Tokens");

            migrationBuilder.RenameTable(
                name: "Tokens",
                newName: "token");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "token",
                newName: "value");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "token",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "token",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ValidUntil",
                table: "token",
                newName: "is_valid_until");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "token",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "token",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "token",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_Tokens_UserId",
                table: "token",
                newName: "IX_token_user_id");

            migrationBuilder.AlterColumn<string>(
                name: "value",
                table: "token",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "type",
                table: "token",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_token",
                table: "token",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_token_user_user_id",
                table: "token",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_token_user_user_id",
                table: "token");

            migrationBuilder.DropPrimaryKey(
                name: "PK_token",
                table: "token");

            migrationBuilder.RenameTable(
                name: "token",
                newName: "Tokens");

            migrationBuilder.RenameColumn(
                name: "value",
                table: "Tokens",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Tokens",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Tokens",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Tokens",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Tokens",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "is_valid_until",
                table: "Tokens",
                newName: "ValidUntil");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Tokens",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_token_user_id",
                table: "Tokens",
                newName: "IX_Tokens_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Tokens",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldMaxLength: 1000)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Tokens",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tokens",
                table: "Tokens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tokens_user_UserId",
                table: "Tokens",
                column: "UserId",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
