using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EWallet.DataAccess.Migrations
{
    public partial class gentopup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgrentId",
                table: "GenrateTopUp",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireDate",
                table: "GenrateTopUp",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "money",
                table: "GenrateTopUp",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_GenrateTopUp_AgrentId",
                table: "GenrateTopUp",
                column: "AgrentId");

            migrationBuilder.AddForeignKey(
                name: "FK_GenrateTopUp_Agrents_AgrentId",
                table: "GenrateTopUp",
                column: "AgrentId",
                principalTable: "Agrents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenrateTopUp_Agrents_AgrentId",
                table: "GenrateTopUp");

            migrationBuilder.DropIndex(
                name: "IX_GenrateTopUp_AgrentId",
                table: "GenrateTopUp");

            migrationBuilder.DropColumn(
                name: "AgrentId",
                table: "GenrateTopUp");

            migrationBuilder.DropColumn(
                name: "ExpireDate",
                table: "GenrateTopUp");

            migrationBuilder.DropColumn(
                name: "money",
                table: "GenrateTopUp");
        }
    }
}
