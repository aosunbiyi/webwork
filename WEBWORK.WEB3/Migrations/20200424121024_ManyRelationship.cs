using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WEBWORK.WEB3.Migrations
{
    public partial class ManyRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AcademicSetId",
                table: "Students",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "AcademicSets",
                columns: table => new
                {
                    AcademicSetId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Entry = table.Column<DateTime>(nullable: false),
                    Exit = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicSets", x => x.AcademicSetId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_AcademicSetId",
                table: "Students",
                column: "AcademicSetId");

            migrationBuilder.AddForeignKey(
                name: "academic_set_student_key",
                table: "Students",
                column: "AcademicSetId",
                principalTable: "AcademicSets",
                principalColumn: "AcademicSetId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "academic_set_student_key",
                table: "Students");

            migrationBuilder.DropTable(
                name: "AcademicSets");

            migrationBuilder.DropIndex(
                name: "IX_Students_AcademicSetId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "AcademicSetId",
                table: "Students");
        }
    }
}
