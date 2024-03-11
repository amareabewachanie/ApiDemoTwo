using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiDemoSecond.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Births",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Births", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deaths",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfDeath = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deaths", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marriages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HusbandId = table.Column<int>(type: "int", nullable: false),
                    WifeId = table.Column<int>(type: "int", nullable: false),
                    MariageDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marriages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Marriages_Births_HusbandId",
                        column: x => x.HusbandId,
                        principalTable: "Births",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Marriages_Births_WifeId",
                        column: x => x.WifeId,
                        principalTable: "Births",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Marriages_HusbandId",
                table: "Marriages",
                column: "HusbandId");

            migrationBuilder.CreateIndex(
                name: "IX_Marriages_WifeId",
                table: "Marriages",
                column: "WifeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deaths");

            migrationBuilder.DropTable(
                name: "Marriages");

            migrationBuilder.DropTable(
                name: "Births");
        }
    }
}
