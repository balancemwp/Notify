using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Notify.DataAccess.Migrations
{
    public partial class addkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "notify",
                table: "Recipient",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Server",
                schema: "notify",
                table: "ClientConfiguration",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "EmailUserName",
                schema: "notify",
                table: "ClientConfiguration",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "EmailPassword",
                schema: "notify",
                table: "ClientConfiguration",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.CreateTable(
                name: "ClientKey",
                schema: "notify",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(nullable: false),
                    Key = table.Column<string>(maxLength: 250, nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    ClientConfigurationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientKey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientKey_ClientConfiguration_ClientConfigurationId",
                        column: x => x.ClientConfigurationId,
                        principalSchema: "notify",
                        principalTable: "ClientConfiguration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientKey_ClientConfigurationId",
                schema: "notify",
                table: "ClientKey",
                column: "ClientConfigurationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientKey",
                schema: "notify");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "notify",
                table: "Recipient",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Server",
                schema: "notify",
                table: "ClientConfiguration",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "EmailUserName",
                schema: "notify",
                table: "ClientConfiguration",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "EmailPassword",
                schema: "notify",
                table: "ClientConfiguration",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 250);
        }
    }
}
