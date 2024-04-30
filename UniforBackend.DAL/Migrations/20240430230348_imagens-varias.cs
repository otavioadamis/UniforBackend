using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniforBackend.DAL.Migrations
{
    /// <inheritdoc />
    public partial class imagensvarias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Itens");

            migrationBuilder.AlterColumn<string>(
                name: "AceitaTroca",
                table: "Itens",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

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

            migrationBuilder.CreateIndex(
                name: "IX_Imagens_ItemId",
                table: "Imagens",
                column: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Imagens");

            migrationBuilder.AlterColumn<bool>(
                name: "AceitaTroca",
                table: "Itens",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Itens",
                type: "varchar(255)",
                nullable: true);
        }
    }
}
