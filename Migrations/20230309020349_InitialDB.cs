using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Funcionarios.API.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    cdMatricula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dsNome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    dsFuncao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    cdFuncao = table.Column<int>(type: "int", maxLength: 8, nullable: false),
                    dtInicio = table.Column<DateTime>(type: "datetime2", maxLength: 200, nullable: false),
                    UO = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.cdMatricula);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
