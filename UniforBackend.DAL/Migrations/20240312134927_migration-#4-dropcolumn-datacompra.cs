using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniforBackend.DAL.Migrations
{
    /// <inheritdoc />
    public partial class migration4dropcolumndatacompra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCompra",
                table: "Compras");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Users",
                type: "varchar(60)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Matricula",
                table: "Users",
                type: "varchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Users",
                type: "varchar(36)",
                nullable: false,
                defaultValueSql: "uuid_generate_v4()",
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValueSql: "uuid_generate_v4()");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Itens",
                type: "varchar(36)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Tamanho",
                table: "Itens",
                type: "varchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Itens",
                type: "varchar(60)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Itens",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Cor",
                table: "Itens",
                type: "varchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Itens",
                type: "varchar(36)",
                nullable: false,
                defaultValueSql: "uuid_generate_v4()",
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValueSql: "uuid_generate_v4()");

            migrationBuilder.AlterColumn<string>(
                name: "CompradorId",
                table: "Compras",
                type: "varchar(36)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Compras",
                type: "varchar(36)",
                nullable: false,
                defaultValueSql: "uuid_generate_v4()",
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValueSql: "uuid_generate_v4()");

            migrationBuilder.AlterColumn<string>(
                name: "ItemId",
                table: "CompraItem",
                type: "varchar(36)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "CompraId",
                table: "CompraItem",
                type: "varchar(36)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "CompraItem",
                type: "varchar(36)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Carrinhos",
                type: "varchar(36)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Carrinhos",
                type: "varchar(36)",
                nullable: false,
                defaultValueSql: "uuid_generate_v4()",
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValueSql: "uuid_generate_v4()");

            migrationBuilder.AlterColumn<string>(
                name: "ItemId",
                table: "CarrinhoItem",
                type: "varchar(36)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "CarrinhoId",
                table: "CarrinhoItem",
                type: "varchar(36)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "CarrinhoItem",
                type: "varchar(36)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(60)");

            migrationBuilder.AlterColumn<string>(
                name: "Matricula",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValueSql: "uuid_generate_v4()",
                oldClrType: typeof(string),
                oldType: "varchar(36)",
                oldDefaultValueSql: "uuid_generate_v4()");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Itens",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(36)");

            migrationBuilder.AlterColumn<string>(
                name: "Tamanho",
                table: "Itens",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Itens",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(60)");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Itens",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "Cor",
                table: "Itens",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Itens",
                type: "text",
                nullable: false,
                defaultValueSql: "uuid_generate_v4()",
                oldClrType: typeof(string),
                oldType: "varchar(36)",
                oldDefaultValueSql: "uuid_generate_v4()");

            migrationBuilder.AlterColumn<string>(
                name: "CompradorId",
                table: "Compras",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(36)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Compras",
                type: "text",
                nullable: false,
                defaultValueSql: "uuid_generate_v4()",
                oldClrType: typeof(string),
                oldType: "varchar(36)",
                oldDefaultValueSql: "uuid_generate_v4()");

            migrationBuilder.AddColumn<string>(
                name: "DataCompra",
                table: "Compras",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ItemId",
                table: "CompraItem",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(36)");

            migrationBuilder.AlterColumn<string>(
                name: "CompraId",
                table: "CompraItem",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(36)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "CompraItem",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(36)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Carrinhos",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(36)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Carrinhos",
                type: "text",
                nullable: false,
                defaultValueSql: "uuid_generate_v4()",
                oldClrType: typeof(string),
                oldType: "varchar(36)",
                oldDefaultValueSql: "uuid_generate_v4()");

            migrationBuilder.AlterColumn<string>(
                name: "ItemId",
                table: "CarrinhoItem",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(36)");

            migrationBuilder.AlterColumn<string>(
                name: "CarrinhoId",
                table: "CarrinhoItem",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(36)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "CarrinhoItem",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(36)");
        }
    }
}
