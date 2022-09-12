using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebPropia31.Migrations
{
    public partial class EquipoNombre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EquipoNombre",
                table: "Jugador",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EquipoNombre",
                table: "Jugador");
        }
    }
}
