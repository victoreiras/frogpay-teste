using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace src.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    cpf = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    data_nascimento = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_id",
                table: "Pessoas",
                column: "id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pessoas");
        }
    }
}
