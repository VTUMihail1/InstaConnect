using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstaConnect.Identity.Data.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "InboxState",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                MessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                ConsumerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                LockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                Received = table.Column<DateTime>(type: "datetime2", nullable: false),
                ReceiveCount = table.Column<int>(type: "int", nullable: false),
                ExpirationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                Consumed = table.Column<DateTime>(type: "datetime2", nullable: true),
                Delivered = table.Column<DateTime>(type: "datetime2", nullable: true),
                LastSequenceNumber = table.Column<long>(type: "bigint", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_InboxState", x => x.Id);
                table.UniqueConstraint("AK_InboxState_MessageId_ConsumerId", x => new { x.MessageId, x.ConsumerId });
            });

        migrationBuilder.CreateTable(
            name: "OutboxMessage",
            columns: table => new
            {
                SequenceNumber = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                EnqueueTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                SentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                Headers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Properties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                InboxMessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                InboxConsumerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                OutboxId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                MessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                ContentType = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                MessageType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                CorrelationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                InitiatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                RequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                SourceAddress = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                DestinationAddress = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                ResponseAddress = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                FaultAddress = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                ExpirationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
            },
            constraints: table => table.PrimaryKey("PK_OutboxMessage", x => x.SequenceNumber));

        migrationBuilder.CreateTable(
            name: "OutboxState",
            columns: table => new
            {
                OutboxId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                LockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                Delivered = table.Column<DateTime>(type: "datetime2", nullable: true),
                LastSequenceNumber = table.Column<long>(type: "bigint", nullable: true)
            },
            constraints: table => table.PrimaryKey("PK_OutboxState", x => x.OutboxId));

        migrationBuilder.CreateTable(
            name: "user",
            columns: table => new
            {
                id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                first_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                last_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                user_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                password_hash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                profile_image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                is_email_confirmed = table.Column<bool>(type: "bit", nullable: false),
                created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_user", x => x.id));

        migrationBuilder.CreateTable(
            name: "email_confirmation_token",
            columns: table => new
            {
                id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                value = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                is_valid_until = table.Column<DateTime>(type: "datetime2", nullable: false),
                user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_email_confirmation_token", x => x.id);
                table.ForeignKey(
                    name: "FK_email_confirmation_token_user_user_id",
                    column: x => x.user_id,
                    principalTable: "user",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "forgot_password_token",
            columns: table => new
            {
                id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                value = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                is_valid_until = table.Column<DateTime>(type: "datetime2", nullable: false),
                user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_forgot_password_token", x => x.id);
                table.ForeignKey(
                    name: "FK_forgot_password_token_user_user_id",
                    column: x => x.user_id,
                    principalTable: "user",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "user_claim",
            columns: table => new
            {
                id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                claim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_user_claim", x => x.id);
                table.ForeignKey(
                    name: "FK_user_claim_user_user_id",
                    column: x => x.user_id,
                    principalTable: "user",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateIndex(
            name: "IX_email_confirmation_token_user_id",
            table: "email_confirmation_token",
            column: "user_id");

        migrationBuilder.CreateIndex(
            name: "IX_forgot_password_token_user_id",
            table: "forgot_password_token",
            column: "user_id");

        migrationBuilder.CreateIndex(
            name: "IX_InboxState_Delivered",
            table: "InboxState",
            column: "Delivered");

        migrationBuilder.CreateIndex(
            name: "IX_OutboxMessage_EnqueueTime",
            table: "OutboxMessage",
            column: "EnqueueTime");

        migrationBuilder.CreateIndex(
            name: "IX_OutboxMessage_ExpirationTime",
            table: "OutboxMessage",
            column: "ExpirationTime");

        migrationBuilder.CreateIndex(
            name: "IX_OutboxMessage_InboxMessageId_InboxConsumerId_SequenceNumber",
            table: "OutboxMessage",
            columns: ["InboxMessageId", "InboxConsumerId", "SequenceNumber"],
            unique: true,
            filter: "[InboxMessageId] IS NOT NULL AND [InboxConsumerId] IS NOT NULL");

        migrationBuilder.CreateIndex(
            name: "IX_OutboxMessage_OutboxId_SequenceNumber",
            table: "OutboxMessage",
            columns: ["OutboxId", "SequenceNumber"],
            unique: true,
            filter: "[OutboxId] IS NOT NULL");

        migrationBuilder.CreateIndex(
            name: "IX_OutboxState_Created",
            table: "OutboxState",
            column: "Created");

        migrationBuilder.CreateIndex(
            name: "IX_user_claim_user_id",
            table: "user_claim",
            column: "user_id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "email_confirmation_token");

        migrationBuilder.DropTable(
            name: "forgot_password_token");

        migrationBuilder.DropTable(
            name: "InboxState");

        migrationBuilder.DropTable(
            name: "OutboxMessage");

        migrationBuilder.DropTable(
            name: "OutboxState");

        migrationBuilder.DropTable(
            name: "user_claim");

        migrationBuilder.DropTable(
            name: "user");
    }
}
