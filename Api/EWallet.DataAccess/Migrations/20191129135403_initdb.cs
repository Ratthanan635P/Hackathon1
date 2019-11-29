using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EWallet.DataAccess.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountEWallets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountWallet = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Balance = table.Column<double>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<int>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountEWallets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenrateTopUp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<int>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    RefNo = table.Column<string>(maxLength: 250, nullable: false),
                    IsUsed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenrateTopUp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserOTPs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    OTP = table.Column<string>(maxLength: 50, nullable: false),
                    ExpireDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOTPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agrents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<int>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    ImageProfile = table.Column<byte[]>(nullable: true),
                    NameAgrent = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    Salt = table.Column<string>(maxLength: 50, nullable: false),
                    Active = table.Column<int>(nullable: false),
                    ActiveDateTime = table.Column<DateTime>(nullable: false),
                    AccountEWalletId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agrents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agrents_AccountEWallets_AccountEWalletId",
                        column: x => x.AccountEWalletId,
                        principalTable: "AccountEWallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Marchants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<int>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    ImageProfile = table.Column<byte[]>(nullable: true),
                    NameShop = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    Salt = table.Column<string>(maxLength: 50, nullable: false),
                    Active = table.Column<int>(nullable: false),
                    ActiveDateTime = table.Column<DateTime>(nullable: false),
                    AccountEWalletId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marchants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Marchants_AccountEWallets_AccountEWalletId",
                        column: x => x.AccountEWalletId,
                        principalTable: "AccountEWallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<int>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    RefNo = table.Column<string>(nullable: true),
                    SenderId = table.Column<int>(nullable: true),
                    SenderTransaction = table.Column<int>(nullable: false),
                    ReceiveId = table.Column<int>(nullable: true),
                    ReceiveTransaction = table.Column<int>(nullable: false),
                    Money = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_AccountEWallets_ReceiveId",
                        column: x => x.ReceiveId,
                        principalTable: "AccountEWallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_AccountEWallets_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AccountEWallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<int>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    ImageBackground = table.Column<byte[]>(nullable: true),
                    FristName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    BrithDate = table.Column<DateTime>(nullable: false),
                    Phone = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    Salt = table.Column<string>(maxLength: 50, nullable: false),
                    FingerPrintStattus = table.Column<bool>(nullable: false),
                    AccountEWalletId = table.Column<int>(nullable: true),
                    Active = table.Column<int>(nullable: false),
                    ActiveDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_AccountEWallets_AccountEWalletId",
                        column: x => x.AccountEWalletId,
                        principalTable: "AccountEWallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agrents_AccountEWalletId",
                table: "Agrents",
                column: "AccountEWalletId");

            migrationBuilder.CreateIndex(
                name: "IX_Marchants_AccountEWalletId",
                table: "Marchants",
                column: "AccountEWalletId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ReceiveId",
                table: "Transactions",
                column: "ReceiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SenderId",
                table: "Transactions",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AccountEWalletId",
                table: "Users",
                column: "AccountEWalletId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agrents");

            migrationBuilder.DropTable(
                name: "GenrateTopUp");

            migrationBuilder.DropTable(
                name: "Marchants");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "UserOTPs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AccountEWallets");
        }
    }
}
