using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstaConnect.Users.Data.Migrations;

/// <inheritdoc />
public partial class UpdateDatetimeType : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "value",
            table: "user_token",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "longtext",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "user_id",
            table: "user_token",
            type: "text",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "longtext");

        migrationBuilder.AlterColumn<DateTime>(
            name: "updated_at",
            table: "user_token",
            type: "timestamp(6) without time zone",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<string>(
            name: "name",
            table: "user_token",
            type: "text",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "longtext");

        migrationBuilder.AlterColumn<string>(
            name: "login_provider",
            table: "user_token",
            type: "text",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "longtext");

        migrationBuilder.AlterColumn<DateTime>(
            name: "created_at",
            table: "user_token",
            type: "timestamp(6) without time zone",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<string>(
            name: "id",
            table: "user_token",
            type: "text",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(255)");

        migrationBuilder.AlterColumn<string>(
            name: "user_id",
            table: "user_role",
            type: "text",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "longtext");

        migrationBuilder.AlterColumn<DateTime>(
            name: "updated_at",
            table: "user_role",
            type: "timestamp(6) without time zone",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<string>(
            name: "role_id",
            table: "user_role",
            type: "text",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "longtext");

        migrationBuilder.AlterColumn<DateTime>(
            name: "created_at",
            table: "user_role",
            type: "timestamp(6) without time zone",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<string>(
            name: "id",
            table: "user_role",
            type: "text",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(255)");

        migrationBuilder.AlterColumn<string>(
            name: "user_id",
            table: "user_login",
            type: "text",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "longtext");

        migrationBuilder.AlterColumn<DateTime>(
            name: "updated_at",
            table: "user_login",
            type: "timestamp(6) without time zone",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<string>(
            name: "provider_key",
            table: "user_login",
            type: "text",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "longtext");

        migrationBuilder.AlterColumn<string>(
            name: "provider_display_name",
            table: "user_login",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "longtext",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "login_provider",
            table: "user_login",
            type: "text",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "longtext");

        migrationBuilder.AlterColumn<DateTime>(
            name: "created_at",
            table: "user_login",
            type: "timestamp(6) without time zone",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<string>(
            name: "id",
            table: "user_login",
            type: "text",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(255)");

        migrationBuilder.AlterColumn<DateTime>(
            name: "updated_at",
            table: "user_claim",
            type: "timestamp(6) without time zone",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<string>(
            name: "role_id",
            table: "user_claim",
            type: "text",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "longtext");

        migrationBuilder.AlterColumn<DateTime>(
            name: "created_at",
            table: "user_claim",
            type: "timestamp(6) without time zone",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<string>(
            name: "claim_value",
            table: "user_claim",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "longtext",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "claim_type",
            table: "user_claim",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "longtext",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "id",
            table: "user_claim",
            type: "text",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(255)");

        migrationBuilder.AlterColumn<string>(
            name: "username",
            table: "user",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "longtext",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "updated_at",
            table: "user",
            type: "timestamp(6) without time zone",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<bool>(
            name: "two_factor_is_enabled",
            table: "user",
            type: "boolean",
            nullable: false,
            oldClrType: typeof(bool),
            oldType: "tinyint(1)");

        migrationBuilder.AlterColumn<string>(
            name: "security_stamp",
            table: "user",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "longtext",
            oldNullable: true);

        migrationBuilder.AlterColumn<bool>(
            name: "phone_number_is_confirmed",
            table: "user",
            type: "boolean",
            nullable: false,
            oldClrType: typeof(bool),
            oldType: "tinyint(1)");

        migrationBuilder.AlterColumn<string>(
            name: "phone_number",
            table: "user",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "longtext",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "password_hash",
            table: "user",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "longtext",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "normalized_username",
            table: "user",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "longtext",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "normalized_email",
            table: "user",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "longtext",
            oldNullable: true);

        migrationBuilder.AlterColumn<bool>(
            name: "lockout_is_enabled",
            table: "user",
            type: "boolean",
            nullable: false,
            oldClrType: typeof(bool),
            oldType: "tinyint(1)");

        migrationBuilder.AlterColumn<DateTimeOffset>(
            name: "lockout_end",
            table: "user",
            type: "timestamp with time zone",
            nullable: true,
            oldClrType: typeof(DateTimeOffset),
            oldType: "datetime(6)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "last_name",
            table: "user",
            type: "character varying(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(255)",
            oldMaxLength: 255);

        migrationBuilder.AlterColumn<string>(
            name: "first_name",
            table: "user",
            type: "character varying(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(255)",
            oldMaxLength: 255);

        migrationBuilder.AlterColumn<bool>(
            name: "email_is_confirmed",
            table: "user",
            type: "boolean",
            nullable: false,
            oldClrType: typeof(bool),
            oldType: "tinyint(1)");

        migrationBuilder.AlterColumn<string>(
            name: "email",
            table: "user",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "longtext",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "created_at",
            table: "user",
            type: "timestamp(6) without time zone",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<string>(
            name: "concurrency_stamp",
            table: "user",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "longtext",
            oldNullable: true);

        migrationBuilder.AlterColumn<int>(
            name: "access_failed_count",
            table: "user",
            type: "integer",
            nullable: false,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.AlterColumn<string>(
            name: "id",
            table: "user",
            type: "text",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(255)");

        migrationBuilder.AlterColumn<string>(
            name: "value",
            table: "token",
            type: "character varying(1000)",
            maxLength: 1000,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(1000)",
            oldMaxLength: 1000);

        migrationBuilder.AlterColumn<string>(
            name: "user_id",
            table: "token",
            type: "character varying(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(255)",
            oldMaxLength: 255);

        migrationBuilder.AlterColumn<DateTime>(
            name: "updated_at",
            table: "token",
            type: "timestamp(6) without time zone",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<string>(
            name: "type",
            table: "token",
            type: "character varying(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(255)",
            oldMaxLength: 255);

        migrationBuilder.AlterColumn<DateTime>(
            name: "is_valid_until",
            table: "token",
            type: "timestamp with time zone",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<DateTime>(
            name: "created_at",
            table: "token",
            type: "timestamp(6) without time zone",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<string>(
            name: "id",
            table: "token",
            type: "character varying(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(255)",
            oldMaxLength: 255);

        migrationBuilder.AlterColumn<DateTime>(
            name: "updated_at",
            table: "role_claim",
            type: "timestamp(6) without time zone",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<string>(
            name: "role_id",
            table: "role_claim",
            type: "text",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "longtext");

        migrationBuilder.AlterColumn<DateTime>(
            name: "created_at",
            table: "role_claim",
            type: "timestamp(6) without time zone",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<string>(
            name: "claim_value",
            table: "role_claim",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "longtext",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "claim_type",
            table: "role_claim",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "longtext",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "id",
            table: "role_claim",
            type: "text",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(255)");

        migrationBuilder.AlterColumn<DateTime>(
            name: "updated_at",
            table: "role",
            type: "timestamp(6) without time zone",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<string>(
            name: "normalized_name",
            table: "role",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "longtext",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "name",
            table: "role",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "longtext",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "created_at",
            table: "role",
            type: "timestamp(6) without time zone",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "datetime(6)");

        migrationBuilder.AlterColumn<string>(
            name: "concurrency_stamp",
            table: "role",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "longtext",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "id",
            table: "role",
            type: "text",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(255)");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "value",
            table: "user_token",
            type: "longtext",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "user_id",
            table: "user_token",
            type: "longtext",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<DateTime>(
            name: "updated_at",
            table: "user_token",
            type: "datetime(6)",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamp(6) without time zone");

        migrationBuilder.AlterColumn<string>(
            name: "name",
            table: "user_token",
            type: "longtext",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<string>(
            name: "login_provider",
            table: "user_token",
            type: "longtext",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<DateTime>(
            name: "created_at",
            table: "user_token",
            type: "datetime(6)",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamp(6) without time zone");

        migrationBuilder.AlterColumn<string>(
            name: "id",
            table: "user_token",
            type: "varchar(255)",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<string>(
            name: "user_id",
            table: "user_role",
            type: "longtext",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<DateTime>(
            name: "updated_at",
            table: "user_role",
            type: "datetime(6)",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamp(6) without time zone");

        migrationBuilder.AlterColumn<string>(
            name: "role_id",
            table: "user_role",
            type: "longtext",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<DateTime>(
            name: "created_at",
            table: "user_role",
            type: "datetime(6)",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamp(6) without time zone");

        migrationBuilder.AlterColumn<string>(
            name: "id",
            table: "user_role",
            type: "varchar(255)",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<string>(
            name: "user_id",
            table: "user_login",
            type: "longtext",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<DateTime>(
            name: "updated_at",
            table: "user_login",
            type: "datetime(6)",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamp(6) without time zone");

        migrationBuilder.AlterColumn<string>(
            name: "provider_key",
            table: "user_login",
            type: "longtext",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<string>(
            name: "provider_display_name",
            table: "user_login",
            type: "longtext",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "login_provider",
            table: "user_login",
            type: "longtext",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<DateTime>(
            name: "created_at",
            table: "user_login",
            type: "datetime(6)",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamp(6) without time zone");

        migrationBuilder.AlterColumn<string>(
            name: "id",
            table: "user_login",
            type: "varchar(255)",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<DateTime>(
            name: "updated_at",
            table: "user_claim",
            type: "datetime(6)",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamp(6) without time zone");

        migrationBuilder.AlterColumn<string>(
            name: "role_id",
            table: "user_claim",
            type: "longtext",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<DateTime>(
            name: "created_at",
            table: "user_claim",
            type: "datetime(6)",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamp(6) without time zone");

        migrationBuilder.AlterColumn<string>(
            name: "claim_value",
            table: "user_claim",
            type: "longtext",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "claim_type",
            table: "user_claim",
            type: "longtext",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "id",
            table: "user_claim",
            type: "varchar(255)",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<string>(
            name: "username",
            table: "user",
            type: "longtext",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "updated_at",
            table: "user",
            type: "datetime(6)",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamp(6) without time zone");

        migrationBuilder.AlterColumn<bool>(
            name: "two_factor_is_enabled",
            table: "user",
            type: "tinyint(1)",
            nullable: false,
            oldClrType: typeof(bool),
            oldType: "boolean");

        migrationBuilder.AlterColumn<string>(
            name: "security_stamp",
            table: "user",
            type: "longtext",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<bool>(
            name: "phone_number_is_confirmed",
            table: "user",
            type: "tinyint(1)",
            nullable: false,
            oldClrType: typeof(bool),
            oldType: "boolean");

        migrationBuilder.AlterColumn<string>(
            name: "phone_number",
            table: "user",
            type: "longtext",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "password_hash",
            table: "user",
            type: "longtext",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "normalized_username",
            table: "user",
            type: "longtext",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "normalized_email",
            table: "user",
            type: "longtext",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<bool>(
            name: "lockout_is_enabled",
            table: "user",
            type: "tinyint(1)",
            nullable: false,
            oldClrType: typeof(bool),
            oldType: "boolean");

        migrationBuilder.AlterColumn<DateTimeOffset>(
            name: "lockout_end",
            table: "user",
            type: "datetime(6)",
            nullable: true,
            oldClrType: typeof(DateTimeOffset),
            oldType: "timestamp with time zone",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "last_name",
            table: "user",
            type: "varchar(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "character varying(255)",
            oldMaxLength: 255);

        migrationBuilder.AlterColumn<string>(
            name: "first_name",
            table: "user",
            type: "varchar(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "character varying(255)",
            oldMaxLength: 255);

        migrationBuilder.AlterColumn<bool>(
            name: "email_is_confirmed",
            table: "user",
            type: "tinyint(1)",
            nullable: false,
            oldClrType: typeof(bool),
            oldType: "boolean");

        migrationBuilder.AlterColumn<string>(
            name: "email",
            table: "user",
            type: "longtext",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "created_at",
            table: "user",
            type: "datetime(6)",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamp(6) without time zone");

        migrationBuilder.AlterColumn<string>(
            name: "concurrency_stamp",
            table: "user",
            type: "longtext",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<int>(
            name: "access_failed_count",
            table: "user",
            type: "int",
            nullable: false,
            oldClrType: typeof(int),
            oldType: "integer");

        migrationBuilder.AlterColumn<string>(
            name: "id",
            table: "user",
            type: "varchar(255)",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<string>(
            name: "value",
            table: "token",
            type: "varchar(1000)",
            maxLength: 1000,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "character varying(1000)",
            oldMaxLength: 1000);

        migrationBuilder.AlterColumn<string>(
            name: "user_id",
            table: "token",
            type: "varchar(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "character varying(255)",
            oldMaxLength: 255);

        migrationBuilder.AlterColumn<DateTime>(
            name: "updated_at",
            table: "token",
            type: "datetime(6)",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamp(6) without time zone");

        migrationBuilder.AlterColumn<string>(
            name: "type",
            table: "token",
            type: "varchar(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "character varying(255)",
            oldMaxLength: 255);

        migrationBuilder.AlterColumn<DateTime>(
            name: "is_valid_until",
            table: "token",
            type: "datetime(6)",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamp with time zone");

        migrationBuilder.AlterColumn<DateTime>(
            name: "created_at",
            table: "token",
            type: "datetime(6)",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamp(6) without time zone");

        migrationBuilder.AlterColumn<string>(
            name: "id",
            table: "token",
            type: "varchar(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "character varying(255)",
            oldMaxLength: 255);

        migrationBuilder.AlterColumn<DateTime>(
            name: "updated_at",
            table: "role_claim",
            type: "datetime(6)",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamp(6) without time zone");

        migrationBuilder.AlterColumn<string>(
            name: "role_id",
            table: "role_claim",
            type: "longtext",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<DateTime>(
            name: "created_at",
            table: "role_claim",
            type: "datetime(6)",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamp(6) without time zone");

        migrationBuilder.AlterColumn<string>(
            name: "claim_value",
            table: "role_claim",
            type: "longtext",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "claim_type",
            table: "role_claim",
            type: "longtext",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "id",
            table: "role_claim",
            type: "varchar(255)",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<DateTime>(
            name: "updated_at",
            table: "role",
            type: "datetime(6)",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamp(6) without time zone");

        migrationBuilder.AlterColumn<string>(
            name: "normalized_name",
            table: "role",
            type: "longtext",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "name",
            table: "role",
            type: "longtext",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "created_at",
            table: "role",
            type: "datetime(6)",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamp(6) without time zone");

        migrationBuilder.AlterColumn<string>(
            name: "concurrency_stamp",
            table: "role",
            type: "longtext",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "id",
            table: "role",
            type: "varchar(255)",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "text");
    }
}
