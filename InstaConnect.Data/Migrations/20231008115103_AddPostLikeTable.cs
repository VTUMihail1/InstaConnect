using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstaConnect.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPostLikeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostLikes_post_PostId",
                table: "PostLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_PostLikes_user_UserId",
                table: "PostLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostLikes",
                table: "PostLikes");

            migrationBuilder.RenameTable(
                name: "PostLikes",
                newName: "post_like");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "post_like",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "post_like",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "post_like",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "post_like",
                newName: "post_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "post_like",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_PostLikes_UserId",
                table: "post_like",
                newName: "IX_post_like_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_PostLikes_PostId",
                table: "post_like",
                newName: "IX_post_like_post_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_post_like",
                table: "post_like",
                column: "id");

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
                name: "FK_post_like_post_post_id",
                table: "post_like");

            migrationBuilder.DropForeignKey(
                name: "FK_post_like_user_user_id",
                table: "post_like");

            migrationBuilder.DropPrimaryKey(
                name: "PK_post_like",
                table: "post_like");

            migrationBuilder.RenameTable(
                name: "post_like",
                newName: "PostLikes");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "PostLikes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "PostLikes",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "PostLikes",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "post_id",
                table: "PostLikes",
                newName: "PostId");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "PostLikes",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_post_like_user_id",
                table: "PostLikes",
                newName: "IX_PostLikes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_post_like_post_id",
                table: "PostLikes",
                newName: "IX_PostLikes_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostLikes",
                table: "PostLikes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostLikes_post_PostId",
                table: "PostLikes",
                column: "PostId",
                principalTable: "post",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostLikes_user_UserId",
                table: "PostLikes",
                column: "UserId",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
