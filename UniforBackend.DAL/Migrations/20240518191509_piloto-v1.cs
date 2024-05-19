using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniforBackend.DAL.Migrations
{
    /// <inheritdoc />
    public partial class pilotov1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(60)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Nome = table.Column<string>(type: "varchar(60)", nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    Matricula = table.Column<string>(type: "varchar(10)", nullable: false),
                    Password = table.Column<string>(type: "varchar(255)", nullable: false),
                    Contato = table.Column<string>(type: "varchar(30)", nullable: false),
                    Foto = table.Column<byte[]>(type: "bytea", nullable: true),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategorias",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(60)", nullable: false),
                    CategoriaId = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategorias_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Itens",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Nome = table.Column<string>(type: "varchar(60)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(255)", nullable: false),
                    Preco = table.Column<decimal>(type: "numeric", nullable: false),
                    AceitaTroca = table.Column<string>(type: "varchar(255)", nullable: false),
                    MostrarContato = table.Column<bool>(type: "boolean", nullable: false),
                    isAprovado = table.Column<bool>(type: "boolean", nullable: false),
                    IsVendido = table.Column<bool>(type: "boolean", nullable: false),
                    PostadoEm = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "CURRENT_DATE"),
                    UserId = table.Column<string>(type: "varchar(36)", nullable: false),
                    SubCategoriaId = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Itens_SubCategorias_SubCategoriaId",
                        column: x => x.SubCategoriaId,
                        principalTable: "SubCategorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Itens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Imagens",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Extensao = table.Column<string>(type: "varchar(10)", nullable: false),
                    Index = table.Column<int>(type: "integer", nullable: false),
                    ItemId = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Imagens_Itens_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Itens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    DataVenda = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    VendedorId = table.Column<string>(type: "varchar(36)", nullable: false),
                    ItemId = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendas_Itens_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Itens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendas_Users_VendedorId",
                        column: x => x.VendedorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    UserId = table.Column<string>(type: "varchar(36)", nullable: false),
                    UnreadMessages = table.Column<int>(type: "integer", nullable: false)
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
                name: "IX_Imagens_ItemId",
                table: "Imagens",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_SubCategoriaId",
                table: "Itens",
                column: "SubCategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_UserId",
                table: "Itens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagens_ChatId",
                table: "Mensagens",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategorias_CategoriaId",
                table: "SubCategorias",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersChats_ChatId",
                table: "UsersChats",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersChats_UserId",
                table: "UsersChats",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ItemId",
                table: "Vendas",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_VendedorId",
                table: "Vendas",
                column: "VendedorId");

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
                name: "Imagens");

            migrationBuilder.DropTable(
                name: "UsersChats");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Itens");

            migrationBuilder.DropTable(
                name: "SubCategorias");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Mensagens");

            migrationBuilder.DropTable(
                name: "Chats");
        }
    }
}
