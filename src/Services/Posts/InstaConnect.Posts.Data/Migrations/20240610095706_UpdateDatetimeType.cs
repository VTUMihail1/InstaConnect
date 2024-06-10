using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstaConnect.Posts.Data.Migrations;

/// <inheritdoc />
public partial class UpdateDatetimeType : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "user_id",
            table: "post_like",
            type: "character varying(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(255)",
            oldMaxLength: 255);

        migrationBuilder.AlterColumn<DateTime>(
            name: "updated_at",
            table: "post_like",
            type: "timestamp(6) without time zone",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<string>(
            name: "post_id",
            table: "post_like",
            type: "character varying(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(255)",
            oldMaxLength: 255);

        migrationBuilder.AlterColumn<DateTime>(
            name: "created_at",
            table: "post_like",
            type: "timestamp(6) without time zone",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<string>(
            name: "id",
            table: "post_like",
            type: "text",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(255)");

        migrationBuilder.AlterColumn<string>(
            name: "user_id",
            table: "post_comment_like",
            type: "character varying(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(255)",
            oldMaxLength: 255);

        migrationBuilder.AlterColumn<DateTime>(
            name: "updated_at",
            table: "post_comment_like",
            type: "timestamp(6) without time zone",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<DateTime>(
            name: "created_at",
            table: "post_comment_like",
            type: "timestamp(6) without time zone",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<string>(
            name: "comment_id",
            table: "post_comment_like",
            type: "character varying(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(255)",
            oldMaxLength: 255);

        migrationBuilder.AlterColumn<string>(
            name: "id",
            table: "post_comment_like",
            type: "text",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(255)");

        migrationBuilder.AlterColumn<string>(
            name: "user_id",
            table: "post_comment",
            type: "character varying(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(255)",
            oldMaxLength: 255);

        migrationBuilder.AlterColumn<DateTime>(
            name: "updated_at",
            table: "post_comment",
            type: "timestamp(6) without time zone",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<string>(
            name: "post_id",
            table: "post_comment",
            type: "character varying(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(255)",
            oldMaxLength: 255);

        migrationBuilder.AlterColumn<DateTime>(
            name: "created_at",
            table: "post_comment",
            type: "timestamp(6) without time zone",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<string>(
            name: "content",
            table: "post_comment",
            type: "character varying(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(255)",
            oldMaxLength: 255);

        migrationBuilder.AlterColumn<string>(
            name: "comment_id",
            table: "post_comment",
            type: "character varying(255)",
            maxLength: 255,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "varchar(255)",
            oldMaxLength: 255,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "id",
            table: "post_comment",
            type: "text",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(255)");

        migrationBuilder.AlterColumn<string>(
            name: "user_id",
            table: "post",
            type: "character varying(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(255)",
            oldMaxLength: 255);

        migrationBuilder.AlterColumn<DateTime>(
            name: "updated_at",
            table: "post",
            type: "timestamp(6) without time zone",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<string>(
            name: "title",
            table: "post",
            type: "character varying(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(255)",
            oldMaxLength: 255);

        migrationBuilder.AlterColumn<DateTime>(
            name: "created_at",
            table: "post",
            type: "timestamp(6) without time zone",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<string>(
            name: "content",
            table: "post",
            type: "character varying(5000)",
            maxLength: 5000,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(5000)",
            oldMaxLength: 5000);

        migrationBuilder.AlterColumn<string>(
            name: "id",
            table: "post",
            type: "character varying(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(255)",
            oldMaxLength: 255);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "user_id",
            table: "post_like",
            type: "varchar(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "character varying(255)",
            oldMaxLength: 255);

        migrationBuilder.AlterColumn<DateTime>(
            name: "updated_at",
            table: "post_like",
            type: "datetime(6)",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamp(6) without time zone");

        migrationBuilder.AlterColumn<string>(
            name: "post_id",
            table: "post_like",
            type: "varchar(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "character varying(255)",
            oldMaxLength: 255);

        migrationBuilder.AlterColumn<DateTime>(
            name: "created_at",
            table: "post_like",
            type: "datetime(6)",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamp(6) without time zone");

        migrationBuilder.AlterColumn<string>(
            name: "id",
            table: "post_like",
            type: "varchar(255)",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<string>(
            name: "user_id",
            table: "post_comment_like",
            type: "varchar(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "character varying(255)",
            oldMaxLength: 255);

        migrationBuilder.AlterColumn<DateTime>(
            name: "updated_at",
            table: "post_comment_like",
            type: "datetime(6)",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamp(6) without time zone");

        migrationBuilder.AlterColumn<DateTime>(
            name: "created_at",
            table: "post_comment_like",
            type: "datetime(6)",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamp(6) without time zone");

        migrationBuilder.AlterColumn<string>(
            name: "comment_id",
            table: "post_comment_like",
            type: "varchar(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "character varying(255)",
            oldMaxLength: 255);

        migrationBuilder.AlterColumn<string>(
            name: "id",
            table: "post_comment_like",
            type: "varchar(255)",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<string>(
            name: "user_id",
            table: "post_comment",
            type: "varchar(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "character varying(255)",
            oldMaxLength: 255);

        migrationBuilder.AlterColumn<DateTime>(
            name: "updated_at",
            table: "post_comment",
            type: "datetime(6)",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamp(6) without time zone");

        migrationBuilder.AlterColumn<string>(
            name: "post_id",
            table: "post_comment",
            type: "varchar(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "character varying(255)",
            oldMaxLength: 255);

        migrationBuilder.AlterColumn<DateTime>(
            name: "created_at",
            table: "post_comment",
            type: "datetime(6)",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamp(6) without time zone");

        migrationBuilder.AlterColumn<string>(
            name: "content",
            table: "post_comment",
            type: "varchar(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "character varying(255)",
            oldMaxLength: 255);

        migrationBuilder.AlterColumn<string>(
            name: "comment_id",
            table: "post_comment",
            type: "varchar(255)",
            maxLength: 255,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "character varying(255)",
            oldMaxLength: 255,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "id",
            table: "post_comment",
            type: "varchar(255)",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<string>(
            name: "user_id",
            table: "post",
            type: "varchar(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "character varying(255)",
            oldMaxLength: 255);

        migrationBuilder.AlterColumn<DateTime>(
            name: "updated_at",
            table: "post",
            type: "datetime(6)",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamp(6) without time zone");

        migrationBuilder.AlterColumn<string>(
            name: "title",
            table: "post",
            type: "varchar(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "character varying(255)",
            oldMaxLength: 255);

        migrationBuilder.AlterColumn<DateTime>(
            name: "created_at",
            table: "post",
            type: "datetime(6)",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamp(6) without time zone");

        migrationBuilder.AlterColumn<string>(
            name: "content",
            table: "post",
            type: "varchar(5000)",
            maxLength: 5000,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "character varying(5000)",
            oldMaxLength: 5000);

        migrationBuilder.AlterColumn<string>(
            name: "id",
            table: "post",
            type: "varchar(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "character varying(255)",
            oldMaxLength: 255);
    }
}
