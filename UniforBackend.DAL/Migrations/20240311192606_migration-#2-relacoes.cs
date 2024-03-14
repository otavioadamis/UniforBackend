using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniforBackend.DAL.Migrations
{
    /// <inheritdoc />
    public partial class migration2relacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Carrinhos",
                table: "Carrinhos");

            migrationBuilder.AddColumn<bool>(
                name: "IsVendido",
                table: "Itens",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Itens",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Itens",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompradorId",
                table: "Compras",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompradorId1",
                table: "Compras",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Carrinhos",
                type: "text",
                nullable: false,
                defaultValueSql: "uuid_generate_v4()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carrinhos",
                table: "Carrinhos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CarrinhoItem",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CarrinhoId = table.Column<string>(type: "text", nullable: false),
                    ItemId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarrinhoItem_Carrinhos_CarrinhoId",
                        column: x => x.CarrinhoId,
                        principalTable: "Carrinhos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarrinhoItem_Itens_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Itens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompraItem",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ItemId = table.Column<string>(type: "text", nullable: false),
                    CompraId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompraItem_Compras_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompraItem_Itens_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Itens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Itens_UserId",
                table: "Itens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_UserId1",
                table: "Itens",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_CompradorId",
                table: "Compras",
                column: "CompradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_CompradorId1",
                table: "Compras",
                column: "CompradorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Carrinhos_UserId",
                table: "Carrinhos",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoItem_CarrinhoId",
                table: "CarrinhoItem",
                column: "CarrinhoId");

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoItem_ItemId",
                table: "CarrinhoItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CompraItem_CompraId",
                table: "CompraItem",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_CompraItem_ItemId",
                table: "CompraItem",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Users_CompradorId",
                table: "Compras",
                column: "CompradorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Users_CompradorId1",
                table: "Compras",
                column: "CompradorId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Itens_Users_UserId",
                table: "Itens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Itens_Users_UserId1",
                table: "Itens",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Users_CompradorId",
                table: "Compras");

            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Users_CompradorId1",
                table: "Compras");

            migrationBuilder.DropForeignKey(
                name: "FK_Itens_Users_UserId",
                table: "Itens");

            migrationBuilder.DropForeignKey(
                name: "FK_Itens_Users_UserId1",
                table: "Itens");

            migrationBuilder.DropTable(
                name: "CarrinhoItem");

            migrationBuilder.DropTable(
                name: "CompraItem");

            migrationBuilder.DropIndex(
                name: "IX_Itens_UserId",
                table: "Itens");

            migrationBuilder.DropIndex(
                name: "IX_Itens_UserId1",
                table: "Itens");

            migrationBuilder.DropIndex(
                name: "IX_Compras_CompradorId",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_CompradorId1",
                table: "Compras");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carrinhos",
                table: "Carrinhos");

            migrationBuilder.DropIndex(
                name: "IX_Carrinhos_UserId",
                table: "Carrinhos");

            migrationBuilder.DropColumn(
                name: "IsVendido",
                table: "Itens");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Itens");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Itens");

            migrationBuilder.DropColumn(
                name: "CompradorId",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "CompradorId1",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Carrinhos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carrinhos",
                table: "Carrinhos",
                column: "UserId");
        }
    }
}
