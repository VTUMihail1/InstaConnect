using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstaConnect.Posts.Data.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "post",
            columns: table => new
            {
                id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                content = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                user_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                user_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_post", x => x.id));

        migrationBuilder.CreateTable(
            name: "post_comment",
            columns: table => new
            {
                id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                user_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                user_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                post_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                content = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_post_comment", x => x.id);
                table.ForeignKey(
                    name: "FK_post_comment_post_post_id",
                    column: x => x.post_id,
                    principalTable: "post",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "post_like",
            columns: table => new
            {
                id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                post_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                user_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                user_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_post_like", x => x.id);
                table.ForeignKey(
                    name: "FK_post_like_post_post_id",
                    column: x => x.post_id,
                    principalTable: "post",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "post_comment_like",
            columns: table => new
            {
                id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                comment_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                user_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                user_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_post_comment_like", x => x.id);
                table.ForeignKey(
                    name: "FK_post_comment_like_post_comment_comment_id",
                    column: x => x.comment_id,
                    principalTable: "post_comment",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_post_comment_post_id",
            table: "post_comment",
            column: "post_id");

        migrationBuilder.CreateIndex(
            name: "IX_post_comment_like_comment_id",
            table: "post_comment_like",
            column: "comment_id");

        migrationBuilder.CreateIndex(
            name: "IX_post_like_post_id",
            table: "post_like",
            column: "post_id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "post_comment_like");

        migrationBuilder.DropTable(
            name: "post_like");

        migrationBuilder.DropTable(
            name: "post_comment");

        migrationBuilder.DropTable(
            name: "post");
    }
}
