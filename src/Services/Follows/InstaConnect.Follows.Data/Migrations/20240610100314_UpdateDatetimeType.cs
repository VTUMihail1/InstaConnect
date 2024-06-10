using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstaConnect.Follows.Data.Migrations;

/// <inheritdoc />
public partial class UpdateDatetimeType : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "follow",
            columns: table => new
            {
                id = table.Column<string>(type: "text", nullable: false),
                following_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                follower_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                created_at = table.Column<DateTime>(type: "timestamp(6) without time zone", nullable: false),
                updated_at = table.Column<DateTime>(type: "timestamp(6) without time zone", nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_follow", x => x.id));
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "follow");
    }
}
