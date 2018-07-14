using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AndroidManagerServices.Migrations
{
    public partial class JobAndroid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Androids",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AndroidName = table.Column<string>(nullable: true),
                    AvatarImage = table.Column<string>(nullable: true),
                    Skills = table.Column<string>(nullable: true),
                    Reliability = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Androids", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JobName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ComplexityLevel = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AndroidJob",
                columns: table => new
                {
                    AndroidId = table.Column<int>(nullable: false),
                    JobId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AndroidJob", x => new { x.AndroidId, x.JobId });
                    table.ForeignKey(
                        name: "FK_AndroidJob_Androids_AndroidId",
                        column: x => x.AndroidId,
                        principalTable: "Androids",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AndroidJob_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AndroidJob_JobId",
                table: "AndroidJob",
                column: "JobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AndroidJob");

            migrationBuilder.DropTable(
                name: "Androids");

            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
