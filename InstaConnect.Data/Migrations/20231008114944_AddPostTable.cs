using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstaConnect.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPostTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentLikes_PostComments_PostCommentId",
                table: "PostCommentLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_PostComments_PostCommentId",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_Posts_PostId",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_user_UserId",
                table: "PostComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostComments",
                table: "PostComments");

            migrationBuilder.RenameTable(
                name: "PostComments",
                newName: "post_comment");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "post_comment",
                newName: "content");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "post_comment",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "post_comment",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "post_comment",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "post_comment",
                newName: "post_id");

            migrationBuilder.RenameColumn(
                name: "PostCommentId",
                table: "post_comment",
                newName: "comment_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "post_comment",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_PostComments_UserId",
                table: "post_comment",
                newName: "IX_post_comment_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_PostComments_PostId",
                table: "post_comment",
                newName: "IX_post_comment_post_id");

            migrationBuilder.RenameIndex(
                name: "IX_PostComments_PostCommentId",
                table: "post_comment",
                newName: "IX_post_comment_comment_id");

            migrationBuilder.AlterColumn<string>(
                name: "content",
                table: "post_comment",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_post_comment",
                table: "post_comment",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentLikes_post_comment_PostCommentId",
                table: "PostCommentLikes",
                column: "PostCommentId",
                principalTable: "post_comment",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_post_comment_Posts_post_id",
                table: "post_comment",
                column: "post_id",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_post_comment_post_comment_comment_id",
                table: "post_comment",
                column: "comment_id",
                principalTable: "post_comment",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_post_comment_user_user_id",
                table: "post_comment",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentLikes_post_comment_PostCommentId",
                table: "PostCommentLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_post_comment_Posts_post_id",
                table: "post_comment");

            migrationBuilder.DropForeignKey(
                name: "FK_post_comment_post_comment_comment_id",
                table: "post_comment");

            migrationBuilder.DropForeignKey(
                name: "FK_post_comment_user_user_id",
                table: "post_comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_post_comment",
                table: "post_comment");

            migrationBuilder.RenameTable(
                name: "post_comment",
                newName: "PostComments");

            migrationBuilder.RenameColumn(
                name: "content",
                table: "PostComments",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "PostComments",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "PostComments",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "PostComments",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "post_id",
                table: "PostComments",
                newName: "PostId");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "PostComments",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "comment_id",
                table: "PostComments",
                newName: "PostCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_post_comment_user_id",
                table: "PostComments",
                newName: "IX_PostComments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_post_comment_post_id",
                table: "PostComments",
                newName: "IX_PostComments_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_post_comment_comment_id",
                table: "PostComments",
                newName: "IX_PostComments_PostCommentId");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "PostComments",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostComments",
                table: "PostComments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentLikes_PostComments_PostCommentId",
                table: "PostCommentLikes",
                column: "PostCommentId",
                principalTable: "PostComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_PostComments_PostCommentId",
                table: "PostComments",
                column: "PostCommentId",
                principalTable: "PostComments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_Posts_PostId",
                table: "PostComments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_user_UserId",
                table: "PostComments",
                column: "UserId",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
