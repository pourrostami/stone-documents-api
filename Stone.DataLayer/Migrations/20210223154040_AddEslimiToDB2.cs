using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stone.DataLayer.Migrations
{
    public partial class AddEslimiToDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EslimiDesigns",
                columns: table => new
                {
                    EslimiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EslimiImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EslimiDesigns", x => x.EslimiId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EslimiDesigns");
        }
    }
}
