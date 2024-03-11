using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniforBackend.DAL.Migrations
{
    /// <inheritdoc />
    public partial class migration3relacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Users_CompradorId1",
                table: "Compras");

            migrationBuilder.DropForeignKey(
                name: "FK_Itens_Users_UserId1",
                table: "Itens");

            migrationBuilder.DropIndex(
                name: "IX_Itens_UserId1",
                table: "Itens");

            migrationBuilder.DropIndex(
                name: "IX_Compras_CompradorId1",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Itens");

            migrationBuilder.DropColumn(
                name: "CompradorId1",
                table: "Compras");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Itens",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompradorId1",
                table: "Compras",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_UserId1",
                table: "Itens",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_CompradorId1",
                table: "Compras",
                column: "CompradorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Users_CompradorId1",
                table: "Compras",
                column: "CompradorId1",
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
    }
}
