using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace src.Migrations
{
    /// <inheritdoc />
    public partial class ConfiguracaoPessoaEndereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    uf_estado = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    cidade = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    bairro = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    logradouro = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    numero = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    complemento = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    IdPessoa = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_id",
                table: "Enderecos",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_IdPessoa",
                table: "Enderecos",
                column: "IdPessoa",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enderecos");
        }
    }
}
