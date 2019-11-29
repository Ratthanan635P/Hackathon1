using Microsoft.EntityFrameworkCore.Migrations;

namespace EWallet.DataAccess.Migrations
{
    public partial class revise01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameShop",
                table: "Agrents");

            migrationBuilder.AddColumn<string>(
                name: "NameAgrent",
                table: "Agrents",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameAgrent",
                table: "Agrents");

            migrationBuilder.AddColumn<string>(
                name: "NameShop",
                table: "Agrents",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
