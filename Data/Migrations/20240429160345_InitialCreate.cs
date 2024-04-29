using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlashGamingHub.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameShops",
                columns: table => new
                {
                    StoreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    AnnualSales = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Categories = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(80)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameShops", x => x.StoreID);
                });

            migrationBuilder.CreateTable(
                name: "Studios",
                columns: table => new
                {
                    StudioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Fundation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    EmailContact = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    GameID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studios", x => x.StudioID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    LibraryGameUserID = table.Column<int>(type: "int", nullable: false),
                    MessageID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Communities",
                columns: table => new
                {
                    MessageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActiveMember = table.Column<bool>(type: "bit", nullable: false),
                    LikesCount = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communities", x => x.MessageID);
                    table.ForeignKey(
                        name: "FK_Communities_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LibraryGameUsers",
                columns: table => new
                {
                    LibraryGameUserId = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    HoursPlayed = table.Column<int>(type: "int", nullable: false),
                    LastPlayed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GameID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryGameUsers", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_LibraryGameUsers_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    StudioID = table.Column<int>(type: "int", nullable: false),
                    StoreID = table.Column<int>(type: "int", nullable: false),
                    LibraryGameUserUserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameID);
                    table.ForeignKey(
                        name: "FK_Games_LibraryGameUsers_LibraryGameUserUserID",
                        column: x => x.LibraryGameUserUserID,
                        principalTable: "LibraryGameUsers",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_Games_Studios_StudioID",
                        column: x => x.StudioID,
                        principalTable: "Studios",
                        principalColumn: "StudioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameGameShop",
                columns: table => new
                {
                    GameID = table.Column<int>(type: "int", nullable: false),
                    GamesGameID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGameShop", x => new { x.GameID, x.GamesGameID });
                    table.ForeignKey(
                        name: "FK_GameGameShop_Games_GamesGameID",
                        column: x => x.GamesGameID,
                        principalTable: "Games",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameGameShop_GameShops_GameID",
                        column: x => x.GameID,
                        principalTable: "GameShops",
                        principalColumn: "StoreID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GameShops",
                columns: new[] { "StoreID", "AnnualSales", "Categories", "Discount", "GameID", "LastUpdated", "Origin", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1000, "Category1", 0.1m, 0, new DateTime(2024, 3, 30, 18, 3, 45, 514, DateTimeKind.Local).AddTicks(7636), "Origin1", 49.99m, 100 },
                    { 2, 1200, "Category2", 0.05m, 0, new DateTime(2024, 4, 9, 18, 3, 45, 514, DateTimeKind.Local).AddTicks(7640), "Origin2", 39.99m, 150 }
                });

            migrationBuilder.InsertData(
                table: "Studios",
                columns: new[] { "StudioID", "Active", "Country", "EmailContact", "Fundation", "GameID", "Name", "Website" },
                values: new object[,]
                {
                    { 1, true, "Country1", "studio1@example.com", new DateTime(2014, 4, 29, 18, 3, 45, 514, DateTimeKind.Local).AddTicks(7484), 0, "Studio1", "www.studio1.com" },
                    { 2, true, "Country2", "studio2@example.com", new DateTime(2019, 4, 29, 18, 3, 45, 514, DateTimeKind.Local).AddTicks(7522), 0, "Studio2", "www.studio2.com" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Active", "Age", "Email", "LibraryGameUserID", "MessageID", "Name", "Password", "RegisterDate", "Surname" },
                values: new object[,]
                {
                    { 1, true, 30, "user1@example.com", 1, 1, "User1", "password1", new DateTime(2022, 4, 29, 18, 3, 45, 514, DateTimeKind.Local).AddTicks(7669), "Surname1" },
                    { 2, true, 25, "user2@example.com", 2, 2, "User2", "password2", new DateTime(2023, 4, 29, 18, 3, 45, 514, DateTimeKind.Local).AddTicks(7673), "Surname2" }
                });

            migrationBuilder.InsertData(
                table: "Communities",
                columns: new[] { "MessageID", "ActiveMember", "LikesCount", "Message", "PublicationDate", "UserID" },
                values: new object[,]
                {
                    { 1, true, 100, "Community1", new DateTime(2023, 4, 29, 18, 3, 45, 514, DateTimeKind.Local).AddTicks(7704), 1 },
                    { 2, true, 150, "Community2", new DateTime(2022, 4, 29, 18, 3, 45, 514, DateTimeKind.Local).AddTicks(7707), 2 }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameID", "Available", "Description", "LibraryGameUserUserID", "Name", "Price", "ReleaseDate", "StoreID", "StudioID" },
                values: new object[,]
                {
                    { 1, true, "Description1", null, "Game1", 59.99m, new DateTime(2023, 4, 29, 18, 3, 45, 514, DateTimeKind.Local).AddTicks(7652), 1, 1 },
                    { 2, true, "Description2", null, "Game2", 49.99m, new DateTime(2022, 4, 29, 18, 3, 45, 514, DateTimeKind.Local).AddTicks(7656), 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "LibraryGameUsers",
                columns: new[] { "UserID", "AddedDate", "GameID", "HoursPlayed", "LastPlayed", "LibraryGameUserId", "Rating" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 29, 18, 3, 45, 514, DateTimeKind.Local).AddTicks(7684), 1, 50, new DateTime(2024, 4, 22, 18, 3, 45, 514, DateTimeKind.Local).AddTicks(7688), 0, 4 },
                    { 2, new DateTime(2024, 1, 29, 18, 3, 45, 514, DateTimeKind.Local).AddTicks(7690), 2, 100, new DateTime(2024, 4, 24, 18, 3, 45, 514, DateTimeKind.Local).AddTicks(7692), 0, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Communities_UserID",
                table: "Communities",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_GameGameShop_GamesGameID",
                table: "GameGameShop",
                column: "GamesGameID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_LibraryGameUserUserID",
                table: "Games",
                column: "LibraryGameUserUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_StudioID",
                table: "Games",
                column: "StudioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Communities");

            migrationBuilder.DropTable(
                name: "GameGameShop");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "GameShops");

            migrationBuilder.DropTable(
                name: "LibraryGameUsers");

            migrationBuilder.DropTable(
                name: "Studios");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
