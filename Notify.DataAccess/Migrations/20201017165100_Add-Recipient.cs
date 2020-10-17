using Microsoft.EntityFrameworkCore.Migrations;

namespace Notify.DataAccess.Migrations
{
    public partial class AddRecipient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientConfiguration_Carriers_CarrierId",
                schema: "notify",
                table: "ClientConfiguration");

            migrationBuilder.DropIndex(
                name: "IX_ClientConfiguration_CarrierId",
                schema: "notify",
                table: "ClientConfiguration");

            migrationBuilder.DropColumn(
                name: "CarrierId",
                schema: "notify",
                table: "ClientConfiguration");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                schema: "notify",
                table: "ClientConfiguration");

            migrationBuilder.CreateTable(
                name: "Recipient",
                schema: "notify",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ClientConfigurationId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    SendEmail = table.Column<bool>(nullable: false),
                    SendText = table.Column<bool>(nullable: false),
                    CarrierId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipient_Carriers_CarrierId",
                        column: x => x.CarrierId,
                        principalSchema: "notify",
                        principalTable: "Carriers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipient_ClientConfiguration_Id",
                        column: x => x.Id,
                        principalSchema: "notify",
                        principalTable: "ClientConfiguration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipient_CarrierId",
                schema: "notify",
                table: "Recipient",
                column: "CarrierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipient",
                schema: "notify");

            migrationBuilder.AddColumn<int>(
                name: "CarrierId",
                schema: "notify",
                table: "ClientConfiguration",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                schema: "notify",
                table: "ClientConfiguration",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientConfiguration_CarrierId",
                schema: "notify",
                table: "ClientConfiguration",
                column: "CarrierId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientConfiguration_Carriers_CarrierId",
                schema: "notify",
                table: "ClientConfiguration",
                column: "CarrierId",
                principalSchema: "notify",
                principalTable: "Carriers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
