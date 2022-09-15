using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITHub.Data.Migrations
{
    public partial class jobportaltables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jobs_jobTypes_JobType",
                table: "jobs");

            migrationBuilder.DropIndex(
                name: "IX_jobs_JobType",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "ExperienceLevelId",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "JobFunctionId",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "JobType",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "TechnologiesId",
                table: "jobs");

            migrationBuilder.CreateTable(
                name: "jobWithJobType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    JobTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobWithJobType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_jobWithJobType_jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_jobWithJobType_jobTypes_JobTypeId",
                        column: x => x.JobTypeId,
                        principalTable: "jobTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_jobs_CurrencyTypeId",
                table: "jobs",
                column: "CurrencyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_jobs_RemunerationId",
                table: "jobs",
                column: "RemunerationId");

            migrationBuilder.CreateIndex(
                name: "IX_jobs_WorkmodeId",
                table: "jobs",
                column: "WorkmodeId");

            migrationBuilder.CreateIndex(
                name: "IX_jobWithJobType_JobId",
                table: "jobWithJobType",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_jobWithJobType_JobTypeId",
                table: "jobWithJobType",
                column: "JobTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_jobs_currencyTypes_CurrencyTypeId",
                table: "jobs",
                column: "CurrencyTypeId",
                principalTable: "currencyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_jobs_remuneration_RemunerationId",
                table: "jobs",
                column: "RemunerationId",
                principalTable: "remuneration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_jobs_workModes_WorkmodeId",
                table: "jobs",
                column: "WorkmodeId",
                principalTable: "workModes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jobs_currencyTypes_CurrencyTypeId",
                table: "jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_jobs_remuneration_RemunerationId",
                table: "jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_jobs_workModes_WorkmodeId",
                table: "jobs");

            migrationBuilder.DropTable(
                name: "jobWithJobType");

            migrationBuilder.DropIndex(
                name: "IX_jobs_CurrencyTypeId",
                table: "jobs");

            migrationBuilder.DropIndex(
                name: "IX_jobs_RemunerationId",
                table: "jobs");

            migrationBuilder.DropIndex(
                name: "IX_jobs_WorkmodeId",
                table: "jobs");

            migrationBuilder.AddColumn<int>(
                name: "ExperienceLevelId",
                table: "jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JobFunctionId",
                table: "jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JobType",
                table: "jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TechnologiesId",
                table: "jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_jobs_JobType",
                table: "jobs",
                column: "JobType");

            migrationBuilder.AddForeignKey(
                name: "FK_jobs_jobTypes_JobType",
                table: "jobs",
                column: "JobType",
                principalTable: "jobTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
