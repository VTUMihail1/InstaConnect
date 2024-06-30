using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstaConnect.Identity.Data.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "user",
            columns: table => new
            {
                id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                first_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                last_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                user_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                password_hash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                is_email_confirmed = table.Column<bool>(type: "bit", nullable: false),
                created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_user", x => x.id));

        migrationBuilder.CreateTable(
            name: "token",
            columns: table => new
            {
                id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                value = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                is_valid_until = table.Column<DateTime>(type: "datetime2", nullable: false),
                user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_token", x => x.id);
                table.ForeignKey(
                    name: "FK_token_user_user_id",
                    column: x => x.user_id,
                    principalTable: "user",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "user_claim",
            columns: table => new
            {
                id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                claim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_user_claim", x => x.id);
                table.ForeignKey(
                    name: "FK_user_claim_user_user_id",
                    column: x => x.user_id,
                    principalTable: "user",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_token_user_id",
            table: "token",
            column: "user_id");

        migrationBuilder.CreateIndex(
            name: "IX_user_claim_user_id",
            table: "user_claim",
            column: "user_id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "token");

        migrationBuilder.DropTable(
            name: "user_claim");

        migrationBuilder.DropTable(
            name: "user");
    }
}
