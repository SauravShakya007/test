using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeCheckIn.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainPages",
                columns: table => new
                {
                    CodeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Synopsis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImpactAnalysis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeploymentDocument = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitTest = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilesAdded = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilesModified = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilesDeleted = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GitBranch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GitRevision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PullRequest = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeReviewedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TargetVersion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecificationDoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechnicalDoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Scenarios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainPages", x => x.CodeId);
                });

            migrationBuilder.CreateTable(
                name: "Receivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SendTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receivers_MainPages_SenderId",
                        column: x => x.SenderId,
                        principalTable: "MainPages",
                        principalColumn: "CodeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receivers_SenderId",
                table: "Receivers",
                column: "SenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Receivers");

            migrationBuilder.DropTable(
                name: "MainPages");
        }
    }
}
