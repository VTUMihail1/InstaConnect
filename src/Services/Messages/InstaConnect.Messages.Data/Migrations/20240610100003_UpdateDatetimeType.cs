using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstaConnect.Messages.Data.Migrations;

/// <inheritdoc />
public partial class UpdateDatetimeType : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "message",
            columns: table => new
            {
                id = table.Column<string>(type: "text", nullable: false),
                sender_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                receiver_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                content = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                created_at = table.Column<DateTime>(type: "timestamp(6) without time zone", nullable: false),
                updated_at = table.Column<DateTime>(type: "timestamp(6) without time zone", nullable: false)
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
