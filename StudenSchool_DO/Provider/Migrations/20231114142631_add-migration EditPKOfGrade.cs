using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Provider.Migrations
{
    /// <inheritdoc />
    public partial class addmigrationEditPKOfGrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Grades",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_StudentId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Grades");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grades",
                table: "Grades",
                columns: new[] { "StudentId", "CourseId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Grades",
                table: "Grades");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Grades",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grades",
                table: "Grades",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentId",
                table: "Grades",
                column: "StudentId");
        }
    }
}
