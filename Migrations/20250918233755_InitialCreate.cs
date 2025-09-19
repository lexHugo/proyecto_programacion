using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto_programacion.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    categ_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nom_categoria = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.categ_id);
                });

            migrationBuilder.CreateTable(
                name: "Ubicaciones",
                columns: table => new
                {
                    ubic_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nom_ubica = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ubicaciones", x => x.ubic_id);
                });

            migrationBuilder.CreateTable(
                name: "Activos",
                columns: table => new
                {
                    activo_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nom_act = table.Column<string>(type: "TEXT", nullable: false),
                    cod_act = table.Column<string>(type: "TEXT", nullable: false),
                    modelo = table.Column<string>(type: "TEXT", nullable: true),
                    num_serie = table.Column<string>(type: "TEXT", nullable: true),
                    costo = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    fecha_com = table.Column<DateTime>(type: "TEXT", nullable: false),
                    proveedor = table.Column<string>(type: "TEXT", nullable: true),
                    estado = table.Column<string>(type: "TEXT", nullable: false),
                    categ_id = table.Column<int>(type: "INTEGER", nullable: false),
                    Categoriacateg_id = table.Column<int>(type: "INTEGER", nullable: true),
                    ubic_id = table.Column<int>(type: "INTEGER", nullable: false),
                    Ubicacionubic_id = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activos", x => x.activo_id);
                    table.ForeignKey(
                        name: "FK_Activos_Categorias_Categoriacateg_id",
                        column: x => x.Categoriacateg_id,
                        principalTable: "Categorias",
                        principalColumn: "categ_id");
                    table.ForeignKey(
                        name: "FK_Activos_Ubicaciones_Ubicacionubic_id",
                        column: x => x.Ubicacionubic_id,
                        principalTable: "Ubicaciones",
                        principalColumn: "ubic_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activos_Categoriacateg_id",
                table: "Activos",
                column: "Categoriacateg_id");

            migrationBuilder.CreateIndex(
                name: "IX_Activos_Ubicacionubic_id",
                table: "Activos",
                column: "Ubicacionubic_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Ubicaciones");
        }
    }
}
