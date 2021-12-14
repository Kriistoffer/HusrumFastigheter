using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OOAPInlämningsuppgift2.Migrations
{
    public partial class TryingCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Tags_TagId",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_TagId",
                table: "Tenants");

            migrationBuilder.AlterColumn<string>(
                name: "TagId",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TagId",
                table: "Tenants",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_TagId",
                table: "Tenants",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Tags_TagId",
                table: "Tenants",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
