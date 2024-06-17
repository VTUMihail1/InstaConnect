using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstaConnect.Follows.Data.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "follow",
            columns: table => new
            {
                id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                following_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                following_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                follower_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                follower_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
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
