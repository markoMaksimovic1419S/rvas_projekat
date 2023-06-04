using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rvas_projekat.Migrations
{
    public partial class ChatSobaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatSoba",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv_sobe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mail_kretora = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatSoba", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatSoba");
        }
    }
}
