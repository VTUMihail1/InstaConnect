using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstaConnect.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCommentFkAndCommentLikeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_like_post_post_id",
                table: "like");

            migrationBuilder.DropForeignKey(
                name: "FK_like_user_user_id",
                table: "like");

            migrationBuilder.DropPrimaryKey(
                name: "PK_like",
                table: "like");

            migrationBuilder.RenameTable(
                name: "like",
                newName: "post_like");

            migrationBuilder.RenameIndex(
                name: "IX_like_post_id",
                table: "post_like",
                newName: "IX_post_like_post_id");

            migrationBuilder.AddColumn<string>(
                name: "comment_id",
                table: "comment",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_post_like",
                table: "post_like",
                columns: new[] { "user_id", "post_id" });

            migrationBuilder.CreateTable(
                name: "comment_like",
                columns: table => new
                {
                    comment_id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    user_id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment_like", x => new { x.user_id, x.comment_id });
                    table.ForeignKey(
                        name: "FK_comment_like_comment_comment_id",
                        column: x => x.comment_id,
                        principalTable: "comment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comment_like_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_comment_comment_id",
                table: "comment",
                column: "comment_id");

            migrationBuilder.CreateIndex(
                name: "IX_comment_like_comment_id",
                table: "comment_like",
                column: "comment_id");

            migrationBuilder.AddForeignKey(
                name: "FK_comment_comment_comment_id",
                table: "comment",
                column: "comment_id",
                principalTable: "comment",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_post_like_post_post_id",
                table: "post_like",
                column: "post_id",
                principalTable: "post",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_post_like_user_user_id",
                table: "post_like",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comment_comment_comment_id",
                table: "comment");

            migrationBuilder.DropForeignKey(
                name: "FK_post_like_post_post_id",
                table: "post_like");

            migrationBuilder.DropForeignKey(
                name: "FK_post_like_user_user_id",
                table: "post_like");

            migrationBuilder.DropTable(
                name: "comment_like");

            migrationBuilder.DropIndex(
                name: "IX_comment_comment_id",
                table: "comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_post_like",
                table: "post_like");

            migrationBuilder.DropColumn(
                name: "comment_id",
                table: "comment");

            migrationBuilder.RenameTable(
                name: "post_like",
                newName: "like");

            migrationBuilder.RenameIndex(
                name: "IX_post_like_post_id",
                table: "like",
                newName: "IX_like_post_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_like",
                table: "like",
                columns: new[] { "user_id", "post_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_like_post_post_id",
                table: "like",
                column: "post_id",
                principalTable: "post",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_like_user_user_id",
                table: "like",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
