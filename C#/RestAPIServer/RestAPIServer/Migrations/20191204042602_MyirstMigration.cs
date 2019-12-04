using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestAPIServer.Migrations
{
    public partial class MyirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommonCode",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    CodeType = table.Column<string>(nullable: false),
                    DspSeq = table.Column<string>(nullable: true),
                    CodeName = table.Column<string>(nullable: true),
                    CodeDescription = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    UseYn = table.Column<string>(nullable: true),
                    UpDate = table.Column<DateTime>(nullable: true),
                    UpUser = table.Column<string>(nullable: true),
                    RegDate = table.Column<DateTime>(nullable: true),
                    RegUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonCode", x => new { x.Code, x.CodeType });
                });

            migrationBuilder.CreateTable(
                name: "FileManager",
                columns: table => new
                {
                    FileCode = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginalFileName = table.Column<string>(nullable: true),
                    SaveFileName = table.Column<string>(nullable: true),
                    FileSize = table.Column<string>(nullable: true),
                    FileType = table.Column<string>(nullable: true),
                    FileExtension = table.Column<string>(nullable: true),
                    WindowName = table.Column<string>(nullable: true),
                    RegDate = table.Column<string>(nullable: true),
                    WindowUniqueCode = table.Column<string>(nullable: true),
                    RegUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileManager", x => x.FileCode);
                });

            migrationBuilder.CreateTable(
                name: "LanguageInfo",
                columns: table => new
                {
                    LanguageCode = table.Column<string>(nullable: false),
                    LanguageValue1 = table.Column<string>(nullable: true),
                    LanguageValue2 = table.Column<string>(nullable: true),
                    LanguageValue3 = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageInfo", x => x.LanguageCode);
                });

            migrationBuilder.CreateTable(
                name: "SensorCurrentData",
                columns: table => new
                {
                    SensorCode = table.Column<string>(nullable: true),
                    ValueOccurTime = table.Column<long>(nullable: false),
                    ValueSaveTime = table.Column<long>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SensorRawData",
                columns: table => new
                {
                    SensorCode = table.Column<string>(nullable: true),
                    ValueOccurTime = table.Column<long>(nullable: false),
                    ValueSaveTime = table.Column<long>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SensorStatisticsDay",
                columns: table => new
                {
                    SensorCode = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    StartTime = table.Column<long>(nullable: false),
                    EndTime = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SensorStatisticsHour",
                columns: table => new
                {
                    SensorCode = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    StartTime = table.Column<long>(nullable: false),
                    EndTime = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SensorStatisticsMinute",
                columns: table => new
                {
                    SensorCode = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    StartTime = table.Column<long>(nullable: false),
                    EndTime = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SensorStatisticsMonth",
                columns: table => new
                {
                    SensorCode = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    StartTime = table.Column<long>(nullable: false),
                    EndTime = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommonCode");

            migrationBuilder.DropTable(
                name: "FileManager");

            migrationBuilder.DropTable(
                name: "LanguageInfo");

            migrationBuilder.DropTable(
                name: "SensorCurrentData");

            migrationBuilder.DropTable(
                name: "SensorRawData");

            migrationBuilder.DropTable(
                name: "SensorStatisticsDay");

            migrationBuilder.DropTable(
                name: "SensorStatisticsHour");

            migrationBuilder.DropTable(
                name: "SensorStatisticsMinute");

            migrationBuilder.DropTable(
                name: "SensorStatisticsMonth");
        }
    }
}
