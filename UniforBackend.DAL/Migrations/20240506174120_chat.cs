using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniforBackend.DAL.Migrations
{
    /// <inheritdoc />
    public partial class chat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    UpdatedAt = table.Column<string>(type: "varchar(60)", nullable: false),
                    LatestMessageId = table.Column<string>(type: "varchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mensagens",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Sender = table.Column<string>(type: "varchar(60)", nullable: false),
                    Content = table.Column<string>(type: "varchar(500)", nullable: false),
                    ChatId = table.Column<string>(type: "varchar(36)", nullable: false),
                    SendedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mensagens_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersChats",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    ChatId = table.Column<string>(type: "varchar(36)", nullable: false),
                    UserId = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersChats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersChats_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersChats_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chats_LatestMessageId",
                table: "Chats",
                column: "LatestMessageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mensagens_ChatId",
                table: "Mensagens",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersChats_ChatId",
                table: "UsersChats",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersChats_UserId",
                table: "UsersChats",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Mensagens_LatestMessageId",
                table: "Chats",
                column: "LatestMessageId",
                principalTable: "Mensagens",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Mensagens_LatestMessageId",
                table: "Chats");

            migrationBuilder.DropTable(
                name: "UsersChats");

            migrationBuilder.DropTable(
                name: "Mensagens");

            migrationBuilder.DropTable(
                name: "Chats");
        }
    }
}
