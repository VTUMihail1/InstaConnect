using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstaConnect.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCommentLikeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentLikes_post_comment_PostCommentId",
                table: "CommentLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentLikes_user_UserId",
                table: "CommentLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentLikes",
                table: "CommentLikes");

            migrationBuilder.RenameTable(
                name: "CommentLikes",
                newName: "comment_like");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "comment_like",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "comment_like",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "comment_like",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "PostCommentId",
                table: "comment_like",
                newName: "comment_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "comment_like",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_CommentLikes_UserId",
                table: "comment_like",
                newName: "IX_comment_like_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_CommentLikes_PostCommentId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "CommentLikes");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CommentLikes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "CommentLikes",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "CommentLikes",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "CommentLikes",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "comment_id",
                table: "CommentLikes",
                newName: "PostCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_comment_like_user_id",
                table: "CommentLikes",
                newName: "IX_CommentLikes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_comment_like_comment_id",
                table: "CommentLikes",
                newName: "IX_CommentLikes_PostCommentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentLikes",
                table: "CommentLikes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentLikes_post_comment_PostCommentId",
                table: "CommentLikes",
                column: "PostCommentId",
                principalTable: "post_comment",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentLikes_user_UserId",
                table: "CommentLikes",
                column: "UserId",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
