using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstaConnect.Follows.Read.Data.Migrations;

/// <inheritdoc />
public partial class AddUserTableProfileImage : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "profile_image",
            table: "user",
            type: "nvarchar(max)",
            nullable: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "profile_image",
            table: "user");
    }
}
