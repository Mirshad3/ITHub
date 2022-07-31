using Microsoft.EntityFrameworkCore.Migrations;

namespace ITHub.Data.Migrations
{
    public partial class filterDatas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Value",
                table: "remunerationRanges",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "datePosteds",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[,]
                {
                    { 1, "Past 24 hrs", "Past24hrs" },
                    { 2, "Past Week", "PastWeek" },
                    { 3, "Past Month", "PastMonth" }
                });

            migrationBuilder.InsertData(
                table: "experienceLevels",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[,]
                {
                    { 7, "Lead", "Lead" },
                    { 5, "Senior", "Senior" },
                    { 4, "Mid Level", "MidLevel" },
                    { 6, "Associate Lead", "AssociateLead" },
                    { 2, "Associate ", "Associate " },
                    { 1, "Internship", "Internship" },
                    { 3, "Junior", "Junior" }
                });

            migrationBuilder.InsertData(
                table: "jobFunction",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[,]
                {
                    { 1, "Frontend", "Frontend" },
                    { 2, "Backend", "Backend" },
                    { 3, "IT Support", "ITSupport" }
                });

            migrationBuilder.InsertData(
                table: "jobTechnologies",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[,]
                {
                    { 1, "HTML", "HTML" },
                    { 2, ".Net", ".Net" },
                    { 3, "Node", "Node" }
                });

            migrationBuilder.InsertData(
                table: "jobTypes",
                columns: new[] { "Id", "Description", "Name", "Value" },
                values: new object[,]
                {
                    { 5, null, "Temporary", "Temporary" },
                    { 4, null, "Contract", "Contract" },
                    { 1, null, "Part time", "Part time" },
                    { 2, null, "Full time", "Full time" },
                    { 3, null, "Freelance", "Freelance" }
                });

            migrationBuilder.InsertData(
                table: "remuneration",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[,]
                {
                    { 1, "By Yearly", "ByYearly" },
                    { 2, "By Monthly", "ByMonthly" },
                    { 3, "By Daily", "ByDaily" },
                    { 4, "By Hourly", "ByHourly" },
                    { 5, "By Contract", "ByContract" }
                });

            migrationBuilder.InsertData(
                table: "remunerationRanges",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[,]
                {
                    { 1, "50k - 100k", 1 },
                    { 2, "100k - 150k", 2 },
                    { 3, "150k - 200k", 3 },
                    { 4, "200k+", 4 }
                });

            migrationBuilder.InsertData(
                table: "workModes",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[,]
                {
                    { 2, "On-Premise", "On-Premise" },
                    { 1, "Remote", "Remote" },
                    { 3, "Hybrid", "Hybrid" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "datePosteds",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "datePosteds",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "datePosteds",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "experienceLevels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "experienceLevels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "experienceLevels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "experienceLevels",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "experienceLevels",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "experienceLevels",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "experienceLevels",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "jobFunction",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "jobFunction",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "jobFunction",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "jobTechnologies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "jobTechnologies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "jobTechnologies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "jobTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "jobTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "jobTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "jobTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "jobTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "remuneration",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "remuneration",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "remuneration",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "remuneration",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "remuneration",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "remunerationRanges",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "remunerationRanges",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "remunerationRanges",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "remunerationRanges",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "workModes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "workModes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "workModes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "remunerationRanges",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
