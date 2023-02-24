using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketing_System.Migrations
{
    public partial class label : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Label_Issues_issueAssigneeId_issueReporterId",
                table: "Label");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Label",
                table: "Label");

            migrationBuilder.RenameTable(
                name: "Label",
                newName: "Labels");

            migrationBuilder.RenameIndex(
                name: "IX_Label_issueAssigneeId_issueReporterId",
                table: "Labels",
                newName: "IX_Labels_issueAssigneeId_issueReporterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Labels",
                table: "Labels",
                column: "labelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Labels_Issues_issueAssigneeId_issueReporterId",
                table: "Labels",
                columns: new[] { "issueAssigneeId", "issueReporterId" },
                principalTable: "Issues",
                principalColumns: new[] { "AssigneeId", "ReporterId" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Labels_Issues_issueAssigneeId_issueReporterId",
                table: "Labels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Labels",
                table: "Labels");

            migrationBuilder.RenameTable(
                name: "Labels",
                newName: "Label");

            migrationBuilder.RenameIndex(
                name: "IX_Labels_issueAssigneeId_issueReporterId",
                table: "Label",
                newName: "IX_Label_issueAssigneeId_issueReporterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Label",
                table: "Label",
                column: "labelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Label_Issues_issueAssigneeId_issueReporterId",
                table: "Label",
                columns: new[] { "issueAssigneeId", "issueReporterId" },
                principalTable: "Issues",
                principalColumns: new[] { "AssigneeId", "ReporterId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
