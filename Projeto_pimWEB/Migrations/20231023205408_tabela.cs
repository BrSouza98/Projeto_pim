using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_pimWEB.Migrations
{
    public partial class tabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "funcionarios",
                columns: table => new
                {
                    id_cod_func = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Departamento = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Cargo = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Salario = table.Column<double>(type: "REAL", nullable: false),
                    HoraSemanais = table.Column<int>(type: "INTEGER", nullable: false),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    TemAcesso = table.Column<bool>(type: "INTEGER", nullable: false),
                    Formacao = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PIS = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    CTPS = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Genero = table.Column<string>(type: "TEXT", nullable: true),
                    DtNascimento = table.Column<string>(type: "TEXT", nullable: false),
                    CPF = table.Column<string>(type: "TEXT", maxLength: 14, nullable: false),
                    RG = table.Column<string>(type: "TEXT", maxLength: 12, nullable: false),
                    Nacionalidade = table.Column<string>(type: "TEXT", maxLength: 60, nullable: true),
                    EstadoCivil = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    TelefoneR = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Cidade = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Estado = table.Column<string>(type: "TEXT", nullable: false),
                    Rua = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Numero = table.Column<int>(type: "INTEGER", nullable: false),
                    Bairro = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CEP = table.Column<string>(type: "TEXT", maxLength: 9, nullable: false)
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
                    Nome = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    DtNascimento = table.Column<string>(type: "TEXT", nullable: false),
                    Parentesco = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
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
                    DataEmissao = table.Column<string>(type: "TEXT", nullable: false),
                    MesAnoRef = table.Column<string>(type: "TEXT", nullable: false),
                    id_cod_func = table.Column<int>(type: "INTEGER", nullable: false),
                    Salario = table.Column<double>(type: "REAL", nullable: false),
                    SalarioLiquido = table.Column<double>(type: "REAL", nullable: false),
                    Inss = table.Column<double>(type: "REAL", nullable: false),
                    Fgts = table.Column<double>(type: "REAL", nullable: false)
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
                    Folha_Pagamentoid_cod_FP = table.Column<int>(type: "INTEGER", nullable: true),
                    Funcionarioid_cod_func = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_beneficios", x => x.id_cod_Ben);
                    table.ForeignKey(
                        name: "FK_beneficios_folha_pagamento_Folha_Pagamentoid_cod_FP",
                        column: x => x.Folha_Pagamentoid_cod_FP,
                        principalTable: "folha_pagamento",
                        principalColumn: "id_cod_FP");
                    table.ForeignKey(
                        name: "FK_beneficios_funcionarios_Funcionarioid_cod_func",
                        column: x => x.Funcionarioid_cod_func,
                        principalTable: "funcionarios",
                        principalColumn: "id_cod_func");
                });

            migrationBuilder.CreateTable(
                name: "descontos",
                columns: table => new
                {
                    id_cod_des = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Motivo = table.Column<string>(type: "TEXT", nullable: false),
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
