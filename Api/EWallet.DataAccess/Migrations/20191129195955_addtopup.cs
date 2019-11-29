using Microsoft.EntityFrameworkCore.Migrations;

namespace EWallet.DataAccess.Migrations
{
    public partial class addtopup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "money",
                table: "GenrateTopUp",
                newName: "Money");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Money",
                table: "GenrateTopUp",
                newName: "money");
        }
    }
}
