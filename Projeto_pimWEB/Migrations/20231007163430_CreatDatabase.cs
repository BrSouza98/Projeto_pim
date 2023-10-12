using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_pimWEB.Migrations
{
    public partial class CreatDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "funcionarios",
                columns: table => new
                {
                    id_cod_func = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Departamento = table.Column<string>(type: "TEXT", nullable: false),
                    Cargo = table.Column<string>(type: "TEXT", nullable: false),
                    SalarioBruto = table.Column<decimal>(type: "TEXT", nullable: false),
                    CargaHoraria = table.Column<float>(type: "REAL", nullable: false),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    TemAcesso = table.Column<bool>(type: "INTEGER", nullable: false),
                    Formacao = table.Column<string>(type: "TEXT", nullable: false),
                    PIS = table.Column<string>(type: "TEXT", nullable: false),
                    CTPS = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Genero = table.Column<string>(type: "TEXT", nullable: false),
                    DtNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CPF = table.Column<string>(type: "TEXT", nullable: false),
                    RG = table.Column<string>(type: "TEXT", nullable: false),
                    EstadoCivil = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    TelefoneR = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Cidade = table.Column<string>(type: "TEXT", nullable: false),
                    Estado = table.Column<string>(type: "TEXT", nullable: false),
                    Pais = table.Column<string>(type: "TEXT", nullable: false),
                    Rua = table.Column<string>(type: "TEXT", nullable: false),
                    Numero = table.Column<int>(type: "INTEGER", nullable: false),
                    Bairro = table.Column<string>(type: "TEXT", nullable: false),
                    CEP = table.Column<string>(type: "TEXT", nullable: false),
                    Complemento = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcionarios", x => x.id_cod_func);
                });

            migrationBuilder.CreateTable(
                name: "dependentes",
                columns: table => new
                {
                    id_cod_dep = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    DtNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Parentesco = table.Column<string>(type: "TEXT", nullable: false),
                    funcionarioid_cod_func = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dependentes", x => x.id_cod_dep);
                    table.ForeignKey(
                        name: "FK_dependentes_funcionarios_funcionarioid_cod_func",
                        column: x => x.funcionarioid_cod_func,
                        principalTable: "funcionarios",
                        principalColumn: "id_cod_func",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "folha_pagamento",
                columns: table => new
                {
                    id_cod_FP = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataEmissao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MesRef = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NomeFunc = table.Column<string>(type: "TEXT", nullable: false),
                    Cargo = table.Column<string>(type: "TEXT", nullable: false),
                    DiasTrabalhados = table.Column<float>(type: "REAL", nullable: false),
                    id_cod_func = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_folha_pagamento", x => x.id_cod_FP);
                    table.ForeignKey(
                        name: "FK_folha_pagamento_funcionarios_id_cod_func",
                        column: x => x.id_cod_func,
                        principalTable: "funcionarios",
                        principalColumn: "id_cod_func",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "beneficios",
                columns: table => new
                {
                    id_cod_Ben = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome_Ben = table.Column<string>(type: "TEXT", nullable: false),
                    valor = table.Column<double>(type: "REAL", nullable: false),
                    Folha_Pagamentoid_cod_FP = table.Column<int>(type: "INTEGER", nullable: false),
                    Funcionarioid_cod_func = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_beneficios", x => x.id_cod_Ben);
                    table.ForeignKey(
                        name: "FK_beneficios_folha_pagamento_Folha_Pagamentoid_cod_FP",
                        column: x => x.Folha_Pagamentoid_cod_FP,
                        principalTable: "folha_pagamento",
                        principalColumn: "id_cod_FP",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_beneficios_funcionarios_Funcionarioid_cod_func",
                        column: x => x.Funcionarioid_cod_func,
                        principalTable: "funcionarios",
                        principalColumn: "id_cod_func",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "descontos",
                columns: table => new
                {
                    id_cod_des = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome_des = table.Column<string>(type: "TEXT", nullable: false),
                    Valor = table.Column<double>(type: "REAL", nullable: false),
                    Folha_Pagamentoid_cod_FP = table.Column<int>(type: "INTEGER", nullable: false),
                    Funcionarioid_cod_func = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_descontos", x => x.id_cod_des);
                    table.ForeignKey(
                        name: "FK_descontos_folha_pagamento_Folha_Pagamentoid_cod_FP",
                        column: x => x.Folha_Pagamentoid_cod_FP,
                        principalTable: "folha_pagamento",
                        principalColumn: "id_cod_FP",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_descontos_funcionarios_Funcionarioid_cod_func",
                        column: x => x.Funcionarioid_cod_func,
                        principalTable: "funcionarios",
                        principalColumn: "id_cod_func",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_beneficios_Folha_Pagamentoid_cod_FP",
                table: "beneficios",
                column: "Folha_Pagamentoid_cod_FP");

            migrationBuilder.CreateIndex(
                name: "IX_beneficios_Funcionarioid_cod_func",
                table: "beneficios",
                column: "Funcionarioid_cod_func");

            migrationBuilder.CreateIndex(
                name: "IX_dependentes_funcionarioid_cod_func",
                table: "dependentes",
                column: "funcionarioid_cod_func");

            migrationBuilder.CreateIndex(
                name: "IX_descontos_Folha_Pagamentoid_cod_FP",
                table: "descontos",
                column: "Folha_Pagamentoid_cod_FP");

            migrationBuilder.CreateIndex(
                name: "IX_descontos_Funcionarioid_cod_func",
                table: "descontos",
                column: "Funcionarioid_cod_func");

            migrationBuilder.CreateIndex(
                name: "IX_folha_pagamento_id_cod_func",
                table: "folha_pagamento",
                column: "id_cod_func");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "beneficios");

            migrationBuilder.DropTable(
                name: "dependentes");

            migrationBuilder.DropTable(
                name: "descontos");

            migrationBuilder.DropTable(
                name: "folha_pagamento");

            migrationBuilder.DropTable(
                name: "funcionarios");
        }
    }
}
