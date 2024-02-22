using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace src.Migrations
{
    /// <inheritdoc />
    public partial class ConfiguracaoPessoaDadosBancarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DadosBancarios",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    codigo_banco = table.Column<string>(type: "text", nullable: false),
                    agencia = table.Column<string>(type: "text", nullable: false),
                    conta = table.Column<string>(type: "text", nullable: false),
                    digito_conta = table.Column<string>(type: "text", nullable: false),
                    IdPessoa = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosBancarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_DadosBancarios_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DadosBancarios_id",
                table: "DadosBancarios",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DadosBancarios_IdPessoa",
                table: "DadosBancarios",
                column: "IdPessoa",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DadosBancarios");
        }
    }
}
