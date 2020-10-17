using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Notify.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "notify");

            migrationBuilder.CreateTable(
                name: "Carriers",
                schema: "notify",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Domain = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carriers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommunicationType",
                schema: "notify",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunicationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "notify",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 25, nullable: false),
                    LastName = table.Column<string>(maxLength: 25, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientConfiguration",
                schema: "notify",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ApplicationName = table.Column<string>(maxLength: 50, nullable: false),
                    CarrierId = table.Column<int>(nullable: false),
                    EmailUserName = table.Column<string>(maxLength: 50, nullable: false),
                    EmailPassword = table.Column<string>(maxLength: 25, nullable: false),
                    Server = table.Column<string>(maxLength: 50, nullable: false),
                    Port = table.Column<int>(nullable: false),
                    RequiresAuthentication = table.Column<bool>(nullable: false),
                    UseSsl = table.Column<bool>(nullable: false),
                    PhoneNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientConfiguration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientConfiguration_Carriers_CarrierId",
                        column: x => x.CarrierId,
                        principalSchema: "notify",
                        principalTable: "Carriers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Communication",
                schema: "notify",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(nullable: false),
                    CommunitcationTypeId = table.Column<int>(nullable: false),
                    DateSent = table.Column<DateTime>(nullable: false),
                    To = table.Column<string>(nullable: false),
                    From = table.Column<string>(nullable: false),
                    CC = table.Column<string>(nullable: false),
                    BCC = table.Column<string>(nullable: false),
                    Subject = table.Column<string>(nullable: false),
                    Body = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Communication_CommunicationType_CommunitcationTypeId",
                        column: x => x.CommunitcationTypeId,
                        principalSchema: "notify",
                        principalTable: "CommunicationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientConfiguration_CarrierId",
                schema: "notify",
                table: "ClientConfiguration",
                column: "CarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_Communication_CommunitcationTypeId",
                schema: "notify",
                table: "Communication",
                column: "CommunitcationTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientConfiguration",
                schema: "notify");

            migrationBuilder.DropTable(
                name: "Communication",
                schema: "notify");

            migrationBuilder.DropTable(
                name: "User",
                schema: "notify");

            migrationBuilder.DropTable(
                name: "Carriers",
                schema: "notify");

            migrationBuilder.DropTable(
                name: "CommunicationType",
                schema: "notify");
        }
    }
}
