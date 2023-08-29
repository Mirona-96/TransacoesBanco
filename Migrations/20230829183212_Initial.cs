using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace TransacoesBanco.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Transaccoes",
                columns: table => new
                {
                    TransaccaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NumeroConta = table.Column<string>(type: "nvarchar(12)", nullable: false),
                    TitularConta = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    NomeBanco = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CodigoSWIFT = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    Montante = table.Column<int>(type: "int", nullable: false),
                    DataTransaccao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaccoes", x => x.TransaccaoId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaccoes");
        }
    }
}
