using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketing_System.Migrations
{
    public partial class assigneadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Projects_creatorprojectId",
                table: "Issues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Issues",
                table: "Issues");

            migrationBuilder.RenameColumn(
                name: "creatorprojectId",
                table: "Issues",
                newName: "projectId");

            migrationBuilder.RenameIndex(
                name: "IX_Issues_creatorprojectId",
                table: "Issues",
                newName: "IX_Issues_projectId");

            migrationBuilder.AlterColumn<int>(
                name: "issueId",
                table: "Issues",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "AssigneeId",
                table: "Issues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReporterId",
                table: "Issues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Issues",
                table: "Issues",
                columns: new[] { "AssigneeId", "ReporterId" });

            migrationBuilder.CreateTable(
                name: "Label",
                columns: table => new
                {
                    labelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    issueAssigneeId = table.Column<int>(type: "int", nullable: false),
                    issueReporterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Label", x => x.labelId);
                    table.ForeignKey(
                        name: "FK_Label_Issues_issueAssigneeId_issueReporterId",
                        columns: x => new { x.issueAssigneeId, x.issueReporterId },
                        principalTable: "Issues",
                        principalColumns: new[] { "AssigneeId", "ReporterId" },
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_AssigneeId",
                table: "Issues",
                column: "AssigneeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Issues_ReporterId",
                table: "Issues",
                column: "ReporterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Label_issueAssigneeId_issueReporterId",
                table: "Label",
                columns: new[] { "issueAssigneeId", "issueReporterId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Projects_projectId",
                table: "Issues",
                column: "projectId",
                principalTable: "Projects",
                principalColumn: "projectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Users_AssigneeId",
                table: "Issues",
                column: "AssigneeId",
                principalTable: "Users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Users_ReporterId",
                table: "Issues",
                column: "ReporterId",
                principalTable: "Users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Projects_projectId",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Users_AssigneeId",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Users_ReporterId",
                table: "Issues");

            migrationBuilder.DropTable(
                name: "Label");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Issues",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_AssigneeId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_ReporterId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "AssigneeId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "ReporterId",
                table: "Issues");

            migrationBuilder.RenameColumn(
                name: "projectId",
                table: "Issues",
                newName: "creatorprojectId");

            migrationBuilder.RenameIndex(
                name: "IX_Issues_projectId",
                table: "Issues",
                newName: "IX_Issues_creatorprojectId");

            migrationBuilder.AlterColumn<int>(
                name: "issueId",
                table: "Issues",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Issues",
                table: "Issues",
                column: "issueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Projects_creatorprojectId",
                table: "Issues",
                column: "creatorprojectId",
                principalTable: "Projects",
                principalColumn: "projectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
