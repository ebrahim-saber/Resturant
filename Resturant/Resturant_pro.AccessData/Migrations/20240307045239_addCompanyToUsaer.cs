using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_pro.AccessData.Migrations
{
    /// <inheritdoc />
    public partial class addCompanyToUsaer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompnayId",
                table: "Companys",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Companys",
                keyColumn: "Id",
                keyValue: 2,
                column: "CompnayId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Companys",
                keyColumn: "Id",
                keyValue: 3,
                column: "CompnayId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Companys",
                keyColumn: "Id",
                keyValue: 4,
                column: "CompnayId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Companys_CompnayId",
                table: "Companys",
                column: "CompnayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companys_Companys_CompnayId",
                table: "Companys",
                column: "CompnayId",
                principalTable: "Companys",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companys_Companys_CompnayId",
                table: "Companys");

            migrationBuilder.DropIndex(
                name: "IX_Companys_CompnayId",
                table: "Companys");

            migrationBuilder.DropColumn(
                name: "CompnayId",
                table: "Companys");
        }
    }
}
