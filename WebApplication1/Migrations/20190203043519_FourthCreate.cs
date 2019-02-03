using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication1.Migrations
{
    public partial class FourthCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Behavior_Students_StudentName",
                table: "Behavior");

            migrationBuilder.DropIndex(
                name: "IX_Behavior_StudentName",
                table: "Behavior");

            migrationBuilder.AddColumn<int>(
                name: "CurrentTotal",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LifetimeTotal",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "StudentName",
                table: "Behavior",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentTotal",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LifetimeTotal",
                table: "Students");

            migrationBuilder.AlterColumn<string>(
                name: "StudentName",
                table: "Behavior",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Behavior_StudentName",
                table: "Behavior",
                column: "StudentName");

            migrationBuilder.AddForeignKey(
                name: "FK_Behavior_Students_StudentName",
                table: "Behavior",
                column: "StudentName",
                principalTable: "Students",
                principalColumn: "StudentName",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
