using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstaConnect.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPostCommentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_post_comment_Posts_post_id",
                table: "post_comment");

            migrationBuilder.DropForeignKey(
                name: "FK_PostLikes_Posts_PostId",
                table: "PostLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_user_UserId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "post");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "post",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "post",
                newName: "content");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "post",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "post",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "post",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "post",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_UserId",
                table: "post",
                newName: "IX_post_user_id");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "post",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "content",
                table: "post",
                type: "varchar(5000)",
                maxLength: 5000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_post",
                table: "post",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_post_user_user_id",
                table: "post",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_post_comment_post_post_id",
                table: "post_comment",
                column: "post_id",
                principalTable: "post",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostLikes_post_PostId",
                table: "PostLikes",
                column: "PostId",
                principalTable: "post",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_post_user_user_id",
                table: "post");

            migrationBuilder.DropForeignKey(
                name: "FK_post_comment_post_post_id",
                table: "post_comment");

            migrationBuilder.DropForeignKey(
                name: "FK_PostLikes_post_PostId",
                table: "PostLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_post",
                table: "post");

            migrationBuilder.RenameTable(
                name: "post",
                newName: "Posts");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Posts",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "content",
                table: "Posts",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Posts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Posts",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Posts",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Posts",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_post_user_id",
                table: "Posts",
                newName: "IX_Posts_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Posts",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldMaxLength: 5000)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_post_comment_Posts_post_id",
                table: "post_comment",
                column: "post_id",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostLikes_Posts_PostId",
                table: "PostLikes",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_user_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
