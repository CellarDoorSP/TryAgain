using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication1.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentName = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentName);
                });

            migrationBuilder.CreateTable(
                name: "Behavior",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BehaviorName = table.Column<string>(nullable: false),
                    StudentName = table.Column<string>(nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Behavior", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Behavior_Students_StudentName",
                        column: x => x.StudentName,
                        principalTable: "Students",
                        principalColumn: "StudentName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Behavior_StudentName",
                table: "Behavior",
                column: "StudentName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Behavior");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
