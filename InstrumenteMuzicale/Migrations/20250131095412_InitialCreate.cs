using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstrumenteMuzicale.Migrations
{
    
    public partial class InitialCreate : Migration
    {
        
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instrumente",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descriere = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Pret = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Categorie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Imagine = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instrumente", x => x.ID);
                });
        }

       
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instrumente");
        }
    }
}
