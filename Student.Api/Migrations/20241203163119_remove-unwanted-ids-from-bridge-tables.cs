using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student.Api.Migrations
{
    /// <inheritdoc />
    public partial class removeunwantedidsfrombridgetables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "TeacherSubjects");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TeacherClassrooms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TeacherSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TeacherClassrooms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
