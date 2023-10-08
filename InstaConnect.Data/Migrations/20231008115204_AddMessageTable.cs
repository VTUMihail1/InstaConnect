using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstaConnect.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMessageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_user_ReceiverId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_user_SenderId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "message");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "message",
                newName: "content");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "message",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "message",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "message",
                newName: "sender_id");

            migrationBuilder.RenameColumn(
                name: "ReceiverId",
                table: "message",
                newName: "receiver_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "message",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_SenderId",
                table: "message",
                newName: "IX_message_sender_id");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ReceiverId",
                table: "message",
                newName: "IX_message_receiver_id");

            migrationBuilder.AlterColumn<string>(
                name: "content",
                table: "message",
                type: "varchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_message",
                table: "message",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_message_user_receiver_id",
                table: "message",
                column: "receiver_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_message_user_sender_id",
                table: "message",
                column: "sender_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_message_user_receiver_id",
                table: "message");

            migrationBuilder.DropForeignKey(
                name: "FK_message_user_sender_id",
                table: "message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_message",
                table: "message");

            migrationBuilder.RenameTable(
                name: "message",
                newName: "Messages");

            migrationBuilder.RenameColumn(
                name: "content",
                table: "Messages",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Messages",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Messages",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "sender_id",
                table: "Messages",
                newName: "SenderId");

            migrationBuilder.RenameColumn(
                name: "receiver_id",
                table: "Messages",
                newName: "ReceiverId");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Messages",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_message_sender_id",
                table: "Messages",
                newName: "IX_Messages_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_message_receiver_id",
                table: "Messages",
                newName: "IX_Messages_ReceiverId");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Messages",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(2000)",
                oldMaxLength: 2000)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_user_ReceiverId",
                table: "Messages",
                column: "ReceiverId",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_user_SenderId",
                table: "Messages",
                column: "SenderId",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
