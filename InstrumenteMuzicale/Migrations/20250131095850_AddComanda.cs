using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstrumenteMuzicale.Migrations
{
    
    public partial class AddComanda : Migration
    {
       
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comenzi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeClient = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AdresaLivrare = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    InstrumentID = table.Column<int>(type: "int", nullable: false),
                    DataComanda = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comenzi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comenzi_Instrumente_InstrumentID",
                        column: x => x.InstrumentID,
                        principalTable: "Instrumente",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comenzi_InstrumentID",
                table: "Comenzi",
                column: "InstrumentID");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comenzi");
        }
    }
}
