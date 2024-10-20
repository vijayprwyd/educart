using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace educart.Migrations
{
    /// <inheritdoc />
    public partial class CreateCoursePillar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "course",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    language = table.Column<string>(type: "text", nullable: false),
                    duration = table.Column<int>(type: "integer", nullable: false),
                    duration_unit = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pillar",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pillar", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "course_pillar",
                columns: table => new
                {
                    course_id = table.Column<Guid>(type: "uuid", nullable: false),
                    pillar_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course_pillar", x => new { x.course_id, x.pillar_id });
                    table.ForeignKey(
                        name: "FK_course_pillar_course_course_id",
                        column: x => x.course_id,
                        principalTable: "course",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_course_pillar_pillar_pillar_id",
                        column: x => x.pillar_id,
                        principalTable: "pillar",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_course_pillar_pillar_id",
                table: "course_pillar",
                column: "pillar_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "course_pillar");

            migrationBuilder.DropTable(
                name: "course");

            migrationBuilder.DropTable(
                name: "pillar");
        }
    }
}
