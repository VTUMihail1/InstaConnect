using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstaConnect.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFollowTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follows_user_FollowerId",
                table: "Follows");

            migrationBuilder.DropForeignKey(
                name: "FK_Follows_user_FollowingId",
                table: "Follows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Follows",
                table: "Follows");

            migrationBuilder.RenameTable(
                name: "Follows",
                newName: "follow");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "follow",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "follow",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "FollowingId",
                table: "follow",
                newName: "following_id");

            migrationBuilder.RenameColumn(
                name: "FollowerId",
                table: "follow",
                newName: "follower_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "follow",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_Follows_FollowingId",
                table: "follow",
                newName: "IX_follow_following_id");

            migrationBuilder.RenameIndex(
                name: "IX_Follows_FollowerId",
                table: "follow",
                newName: "IX_follow_follower_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_follow",
                table: "follow",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_follow_user_follower_id",
                table: "follow",
                column: "follower_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_follow_user_following_id",
                table: "follow",
                column: "following_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_follow_user_follower_id",
                table: "follow");

            migrationBuilder.DropForeignKey(
                name: "FK_follow_user_following_id",
                table: "follow");

            migrationBuilder.DropPrimaryKey(
                name: "PK_follow",
                table: "follow");

            migrationBuilder.RenameTable(
                name: "follow",
                newName: "Follows");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Follows",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Follows",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "following_id",
                table: "Follows",
                newName: "FollowingId");

            migrationBuilder.RenameColumn(
                name: "follower_id",
                table: "Follows",
                newName: "FollowerId");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Follows",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_follow_following_id",
                table: "Follows",
                newName: "IX_Follows_FollowingId");

            migrationBuilder.RenameIndex(
                name: "IX_follow_follower_id",
                table: "Follows",
                newName: "IX_Follows_FollowerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Follows",
                table: "Follows",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_user_FollowerId",
                table: "Follows",
                column: "FollowerId",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_user_FollowingId",
                table: "Follows",
                column: "FollowingId",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
