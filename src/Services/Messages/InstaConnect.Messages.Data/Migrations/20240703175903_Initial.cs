using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstaConnect.Messages.Read.Data.Migrations;

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
            name: "message",
            columns: table => new
            {
                id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                content = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                sender_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                receiver_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_message", x => x.id);
                table.ForeignKey(
                    name: "FK_message_user_receiver_id",
                    column: x => x.receiver_id,
                    principalTable: "user",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_message_user_sender_id",
                    column: x => x.sender_id,
                    principalTable: "user",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateIndex(
            name: "IX_message_receiver_id",
            table: "message",
            column: "receiver_id");

        migrationBuilder.CreateIndex(
            name: "IX_message_sender_id",
            table: "message",
            column: "sender_id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "message");

        migrationBuilder.DropTable(
            name: "user");
    }
}
