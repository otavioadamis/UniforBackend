using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniforBackend.DAL.Migrations
{
    /// <inheritdoc />
    public partial class aceitatrocadatapostadoevendas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.AddColumn<bool>(
                name: "AceitaTroca",
                table: "Itens",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateOnly>(
                name: "PostadoEm",
                table: "Itens",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    DataVenda = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ItemId",
                table: "Vendas",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_VendedorId",
                table: "Vendas",
                column: "VendedorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropColumn(
                name: "AceitaTroca",
                table: "Itens");

            migrationBuilder.DropColumn(
                name: "PostadoEm",
                table: "Itens");

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    CompradorId = table.Column<string>(type: "varchar(36)", nullable: false),
                    ItemId = table.Column<string>(type: "varchar(36)", nullable: false),
                    VendedorId = table.Column<string>(type: "varchar(36)", nullable: false),
                    DataCompra = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compras_Itens_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Itens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Compras_Users_CompradorId",
                        column: x => x.CompradorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Compras_Users_VendedorId",
                        column: x => x.VendedorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compras_CompradorId",
                table: "Compras",
                column: "CompradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_ItemId",
                table: "Compras",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Compras_VendedorId",
                table: "Compras",
                column: "VendedorId");
        }
    }
}
