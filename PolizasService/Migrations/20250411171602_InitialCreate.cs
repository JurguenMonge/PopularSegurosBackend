using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PolizasService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coberturas",
                columns: table => new
                {
                    IdCobertura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coberturas", x => x.IdCobertura);
                });

            migrationBuilder.CreateTable(
                name: "EstadoPolizas",
                columns: table => new
                {
                    IdEstadoPoliza = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoPolizas", x => x.IdEstadoPoliza);
                });

            migrationBuilder.CreateTable(
                name: "TipoPolizas",
                columns: table => new
                {
                    TipoPolizaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPolizas", x => x.TipoPolizaId);
                });

            migrationBuilder.CreateTable(
                name: "Polizas",
                columns: table => new
                {
                    IdPoliza = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroPoliza = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CedulaAsegurado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TipoPolizaId = table.Column<int>(type: "int", nullable: false),
                    CoberturaId = table.Column<int>(type: "int", nullable: false),
                    EstadoPolizaId = table.Column<int>(type: "int", nullable: false),
                    MontoAsegurado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaVencimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaEmision = table.Column<DateOnly>(type: "date", nullable: false),
                    Prima = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Periodo = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaInclusion = table.Column<DateOnly>(type: "date", nullable: false),
                    Aseguradora = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EstaEliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polizas", x => x.IdPoliza);
                    table.ForeignKey(
                        name: "FK_Polizas_Coberturas_CoberturaId",
                        column: x => x.CoberturaId,
                        principalTable: "Coberturas",
                        principalColumn: "IdCobertura",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Polizas_EstadoPolizas_EstadoPolizaId",
                        column: x => x.EstadoPolizaId,
                        principalTable: "EstadoPolizas",
                        principalColumn: "IdEstadoPoliza",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Polizas_TipoPolizas_TipoPolizaId",
                        column: x => x.TipoPolizaId,
                        principalTable: "TipoPolizas",
                        principalColumn: "TipoPolizaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Polizas_CoberturaId",
                table: "Polizas",
                column: "CoberturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Polizas_EstadoPolizaId",
                table: "Polizas",
                column: "EstadoPolizaId");

            migrationBuilder.CreateIndex(
                name: "IX_Polizas_TipoPolizaId",
                table: "Polizas",
                column: "TipoPolizaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Polizas");

            migrationBuilder.DropTable(
                name: "Coberturas");

            migrationBuilder.DropTable(
                name: "EstadoPolizas");

            migrationBuilder.DropTable(
                name: "TipoPolizas");
        }
    }
}
