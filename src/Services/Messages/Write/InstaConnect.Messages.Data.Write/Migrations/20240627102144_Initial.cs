using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstaConnect.Messages.Data.Write.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "message",
            columns: table => new
            {
                id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                sender_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                receiver_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                content = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_message", x => x.id));
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "message");
    }
}
