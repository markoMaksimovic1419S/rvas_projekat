using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rvas_projekat.Migrations
{
    public partial class PorukeMigracije : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Poruka",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    poruku_poslao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    text_poruke = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_sobe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poruka", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Poruka");
        }
    }
}
