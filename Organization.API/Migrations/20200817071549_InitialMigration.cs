using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organization.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    DepartmentHeadName = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    ContactNumber = table.Column<string>(maxLength: 10, nullable: true),
                    Salary = table.Column<int>(nullable: true),
                    DepartmentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentHeadName", "Name" },
                values: new object[,]
                {
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "Alisha", "H.R." },
                    { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "Anika", "Sales" },
                    { new Guid("24810dfc-2d94-4cc7-aab5-cdf98b83f0c9"), "Aayan", "Accounts" },
                    { new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), "Bhuvan", "Marketing" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "ContactNumber", "DepartmentId", "Name", "Salary" },
                values: new object[,]
                {
                    { new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), "9999988888", new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "Zara", 80000 },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"), "7777788888", new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "Alex", 70000 },
                    { new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"), "9898989898", new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "Tanvi", 75000 },
                    { new Guid("493c3228-3444-4a49-9cc0-e8532edc59b2"), "9396939693", new Guid("24810dfc-2d94-4cc7-aab5-cdf98b83f0c9"), "Shrishti", 65000 },
                    { new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"), "8787898985", new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), "Anant", 74000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
