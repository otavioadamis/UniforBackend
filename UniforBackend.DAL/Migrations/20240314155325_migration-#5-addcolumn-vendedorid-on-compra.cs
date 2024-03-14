using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniforBackend.DAL.Migrations
{
    /// <inheritdoc />
    public partial class migration5addcolumnvendedoridoncompra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VendedorId",
                table: "Compras",
                type: "varchar(36)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_VendedorId",
                table: "Compras",
                column: "VendedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Users_VendedorId",
                table: "Compras",
                column: "VendedorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Users_VendedorId",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_VendedorId",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "VendedorId",
                table: "Compras");
        }
    }
}
