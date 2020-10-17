using Microsoft.EntityFrameworkCore.Migrations;

namespace Notify.DataAccess.Migrations
{
    public partial class changerecipkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipient_ClientConfiguration_Id",
                schema: "notify",
                table: "Recipient");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "notify",
                table: "Recipient",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Recipient_ClientConfigurationId",
                schema: "notify",
                table: "Recipient",
                column: "ClientConfigurationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipient_ClientConfiguration_ClientConfigurationId",
                schema: "notify",
                table: "Recipient",
                column: "ClientConfigurationId",
                principalSchema: "notify",
                principalTable: "ClientConfiguration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipient_ClientConfiguration_ClientConfigurationId",
                schema: "notify",
                table: "Recipient");

            migrationBuilder.DropIndex(
                name: "IX_Recipient_ClientConfigurationId",
                schema: "notify",
                table: "Recipient");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "notify",
                table: "Recipient",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipient_ClientConfiguration_Id",
                schema: "notify",
                table: "Recipient",
                column: "Id",
                principalSchema: "notify",
                principalTable: "ClientConfiguration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
