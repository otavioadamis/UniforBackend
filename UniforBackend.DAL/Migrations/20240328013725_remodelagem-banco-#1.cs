using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniforBackend.DAL.Migrations
{
    /// <inheritdoc />
    public partial class remodelagembanco1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cor",
                table: "Itens");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Itens");

            migrationBuilder.DropColumn(
                name: "Tamanho",
                table: "Itens");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isAprovado",
                table: "Itens",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "isAprovado",
                table: "Itens");

            migrationBuilder.AddColumn<string>(
                name: "Cor",
                table: "Itens",
                type: "varchar(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Itens",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Tamanho",
                table: "Itens",
                type: "varchar(30)",
                nullable: false,
                defaultValue: "");
        }
    }
}
