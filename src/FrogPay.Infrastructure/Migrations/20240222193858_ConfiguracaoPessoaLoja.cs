using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace src.Migrations
{
    /// <inheritdoc />
    public partial class ConfiguracaoPessoaLoja : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lojas",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome_fantasia = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    razao_social = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    cnpj = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    data_abertura = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdPessoa = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lojas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Lojas_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lojas_id",
                table: "Lojas",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lojas_IdPessoa",
                table: "Lojas",
                column: "IdPessoa",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lojas");
        }
    }
}
