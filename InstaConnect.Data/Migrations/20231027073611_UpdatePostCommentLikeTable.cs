using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstaConnect.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePostCommentLikeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comment_like_post_comment_comment_id",
                table: "comment_like");

            migrationBuilder.DropForeignKey(
                name: "FK_comment_like_user_user_id",
                table: "comment_like");

            migrationBuilder.DropPrimaryKey(
                name: "PK_comment_like",
                table: "comment_like");

            migrationBuilder.RenameTable(
                name: "comment_like",
                newName: "post_comment_like");

            migrationBuilder.RenameIndex(
                name: "IX_comment_like_user_id",
                table: "post_comment_like",
                newName: "IX_post_comment_like_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_comment_like_comment_id",
                table: "post_comment_like",
                newName: "IX_post_comment_like_comment_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_post_comment_like",
                table: "post_comment_like",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_post_comment_like_post_comment_comment_id",
                table: "post_comment_like",
                column: "comment_id",
                principalTable: "post_comment",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_post_comment_like_user_user_id",
                table: "post_comment_like",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_post_comment_like_post_comment_comment_id",
                table: "post_comment_like");

            migrationBuilder.DropForeignKey(
                name: "FK_post_comment_like_user_user_id",
                table: "post_comment_like");

            migrationBuilder.DropPrimaryKey(
                name: "PK_post_comment_like",
                table: "post_comment_like");

            migrationBuilder.RenameTable(
                name: "post_comment_like",
                newName: "comment_like");

            migrationBuilder.RenameIndex(
                name: "IX_post_comment_like_user_id",
                table: "comment_like",
                newName: "IX_comment_like_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_post_comment_like_comment_id",
                table: "comment_like",
                newName: "IX_comment_like_comment_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_comment_like",
                table: "comment_like",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_comment_like_post_comment_comment_id",
                table: "comment_like",
                column: "comment_id",
                principalTable: "post_comment",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comment_like_user_user_id",
                table: "comment_like",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
