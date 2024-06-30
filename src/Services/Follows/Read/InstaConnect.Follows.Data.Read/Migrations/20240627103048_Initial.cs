using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstaConnect.Follows.Data.Read.Migrations;

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
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_user", x => x.id));

        migrationBuilder.CreateTable(
            name: "follow",
            columns: table => new
            {
                id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                following_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                follower_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_follow", x => x.id);
                table.ForeignKey(
                    name: "FK_follow_user_follower_id",
                    column: x => x.follower_id,
                    principalTable: "user",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_follow_user_following_id",
                    column: x => x.following_id,
                    principalTable: "user",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateIndex(
            name: "IX_follow_follower_id",
            table: "follow",
            column: "follower_id");

        migrationBuilder.CreateIndex(
            name: "IX_follow_following_id",
            table: "follow",
            column: "following_id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "follow");

        migrationBuilder.DropTable(
            name: "user");
    }
}
