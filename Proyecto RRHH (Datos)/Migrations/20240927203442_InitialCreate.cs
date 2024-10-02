using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto_RRHH__Datos_.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Estados candidato",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados candidato", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Niveles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Estado = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Niveles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Niveles_Habilidad",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Estado = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Niveles_Habilidad", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Puestos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Nivelderiesgo = table.Column<string>(name: "Nivel de riesgo", unicode: false, maxLength: 50, nullable: true),
                    Salario = table.Column<decimal>(type: "money", nullable: false),
                    Departamento = table.Column<int>(nullable: false),
                    Estado = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puestos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Dapartamento_Puestos",
                        column: x => x.Departamento,
                        principalTable: "Departamentos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estados_Puestos",
                        column: x => x.Estado,
                        principalTable: "Estados",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Competencias",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Nivel = table.Column<int>(nullable: true),
                    Comentario = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competencias", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Competencias_Niveles_Habilidad",
                        column: x => x.Nivel,
                        principalTable: "Niveles_Habilidad",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Idiomas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Nivel = table.Column<int>(nullable: true),
                    Estado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idiomas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Idiomas_Estados",
                        column: x => x.Estado,
                        principalTable: "Estados",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Idiomas_Niveles_Habilidad",
                        column: x => x.Nivel,
                        principalTable: "Niveles_Habilidad",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Candidatos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Cedula = table.Column<string>(unicode: false, maxLength: 11, nullable: false),
                    Nombre = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Aspiracionpuesto = table.Column<int>(name: "Aspiracion puesto", nullable: false),
                    AspiracionSalarial = table.Column<decimal>(name: "Aspiracion Salarial", type: "money", nullable: false),
                    Estado = table.Column<int>(nullable: true),
                    Recomendado = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Puesto_Candidato",
                        column: x => x.Aspiracionpuesto,
                        principalTable: "Puestos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estado_Candidatos",
                        column: x => x.Estado,
                        principalTable: "Estados candidato",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Codigo_empleador = table.Column<int>(nullable: false),
                    Cedula = table.Column<string>(unicode: false, maxLength: 11, nullable: false),
                    Nombre = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Fecha_Ingreso = table.Column<DateTime>(type: "date", nullable: false),
                    Puesto = table.Column<int>(nullable: false),
                    Estado = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Codigo_empleador);
                    table.ForeignKey(
                        name: "FK_Empleados_Estados",
                        column: x => x.Estado,
                        principalTable: "Estados",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Empleados_Puestos",
                        column: x => x.Puesto,
                        principalTable: "Puestos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Candidato_Competencias",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Candidato = table.Column<int>(nullable: true),
                    Competencia = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidato_Competencias", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Candidato_Competencias_Candidatos",
                        column: x => x.Candidato,
                        principalTable: "Candidatos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Candidato_Competencias_Competencias",
                        column: x => x.Competencia,
                        principalTable: "Competencias",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Capacitaciones",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Nivel = table.Column<int>(nullable: false),
                    Fecha_inicio = table.Column<DateTime>(type: "date", nullable: false),
                    Fecha_final = table.Column<DateTime>(type: "date", nullable: false),
                    Institucion = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Candidato = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capacitaciones", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Candidatos_Capacitaciones",
                        column: x => x.Candidato,
                        principalTable: "Candidatos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Nivel_Candidatos",
                        column: x => x.Nivel,
                        principalTable: "Niveles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Experiencia Laboral",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Empresa = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Puesto = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Fecha_inicio = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Fecha_final = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Salario = table.Column<decimal>(type: "money", nullable: false),
                    Candidato = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiencia Laboral", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Experiencia Laboral_Candidatos",
                        column: x => x.Candidato,
                        principalTable: "Candidatos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Idiomas_Candidatos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Candidato = table.Column<int>(nullable: false),
                    Idiomas = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idiomas_Candidatos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Idiomas_Candidatos_Candidatos",
                        column: x => x.Candidato,
                        principalTable: "Candidatos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Idiomas_Candidatos_Idiomas",
                        column: x => x.Idiomas,
                        principalTable: "Idiomas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Usuario = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Contrasena = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    Rol = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Estado = table.Column<int>(nullable: true),
                    Candidato = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Usuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Candidatos",
                        column: x => x.Candidato,
                        principalTable: "Candidatos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_Estados",
                        column: x => x.Estado,
                        principalTable: "Estados",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidato_Competencias_Candidato",
                table: "Candidato_Competencias",
                column: "Candidato");

            migrationBuilder.CreateIndex(
                name: "IX_Candidato_Competencias_Competencia",
                table: "Candidato_Competencias",
                column: "Competencia");

            migrationBuilder.CreateIndex(
                name: "IX_Candidatos_Aspiracion puesto",
                table: "Candidatos",
                column: "Aspiracion puesto");

            migrationBuilder.CreateIndex(
                name: "IX_Candidatos_Estado",
                table: "Candidatos",
                column: "Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Capacitaciones_Candidato",
                table: "Capacitaciones",
                column: "Candidato");

            migrationBuilder.CreateIndex(
                name: "IX_Capacitaciones_Nivel",
                table: "Capacitaciones",
                column: "Nivel");

            migrationBuilder.CreateIndex(
                name: "IX_Competencias_Nivel",
                table: "Competencias",
                column: "Nivel");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_Estado",
                table: "Empleados",
                column: "Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_Puesto",
                table: "Empleados",
                column: "Puesto");

            migrationBuilder.CreateIndex(
                name: "IX_Experiencia Laboral_Candidato",
                table: "Experiencia Laboral",
                column: "Candidato");

            migrationBuilder.CreateIndex(
                name: "IX_Idiomas_Estado",
                table: "Idiomas",
                column: "Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Idiomas_Nivel",
                table: "Idiomas",
                column: "Nivel");

            migrationBuilder.CreateIndex(
                name: "IX_Idiomas_Candidatos_Candidato",
                table: "Idiomas_Candidatos",
                column: "Candidato");

            migrationBuilder.CreateIndex(
                name: "IX_Idiomas_Candidatos_Idiomas",
                table: "Idiomas_Candidatos",
                column: "Idiomas");

            migrationBuilder.CreateIndex(
                name: "IX_Puestos_Departamento",
                table: "Puestos",
                column: "Departamento");

            migrationBuilder.CreateIndex(
                name: "IX_Puestos_Estado",
                table: "Puestos",
                column: "Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Candidato",
                table: "Usuarios",
                column: "Candidato");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Estado",
                table: "Usuarios",
                column: "Estado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidato_Competencias");

            migrationBuilder.DropTable(
                name: "Capacitaciones");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Experiencia Laboral");

            migrationBuilder.DropTable(
                name: "Idiomas_Candidatos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Competencias");

            migrationBuilder.DropTable(
                name: "Niveles");

            migrationBuilder.DropTable(
                name: "Idiomas");

            migrationBuilder.DropTable(
                name: "Candidatos");

            migrationBuilder.DropTable(
                name: "Niveles_Habilidad");

            migrationBuilder.DropTable(
                name: "Puestos");

            migrationBuilder.DropTable(
                name: "Estados candidato");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Estados");
        }
    }
}
