using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TccForum.Migrations
{
    /// <inheritdoc />
    public partial class EscopoDoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Escopo",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Escopo",
                table: "Usuarios");
        }
    }
}
