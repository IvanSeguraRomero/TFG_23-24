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
                    Event = table.Column<string>(type: "nvarchar(80)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    AnnualSales = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    EmailLogin = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(100)", nullable: false),
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
                    LibraryGameUserID = table.Column<int>(type: "int", nullable: false),
                    MessageID = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communities", x => x.MessageID);
                    table.ForeignKey(
                        name: "FK_Communities_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "LibraryGameUsers",
                columns: table => new
                {
                    LibraryGameUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    HoursPlayed = table.Column<int>(type: "int", nullable: false),
                    LastPlayed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    GameID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryGameUsers", x => x.LibraryGameUserId);
                    table.ForeignKey(
                        name: "FK_LibraryGameUsers_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    ShoppingCartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.ShoppingCartID);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Users_UserID",
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
                    Synopsis = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Categories = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    StudioID = table.Column<int>(type: "int", nullable: false),
                    StoreID = table.Column<int>(type: "int", nullable: false),
                    LibraryGameUserId = table.Column<int>(type: "int", nullable: true),
                    ShoppingCartID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameID);
                    table.ForeignKey(
                        name: "FK_Games_LibraryGameUsers_LibraryGameUserId",
                        column: x => x.LibraryGameUserId,
                        principalTable: "LibraryGameUsers",
                        principalColumn: "LibraryGameUserId");
                    table.ForeignKey(
                        name: "FK_Games_ShoppingCarts_ShoppingCartID",
                        column: x => x.ShoppingCartID,
                        principalTable: "ShoppingCarts",
                        principalColumn: "ShoppingCartID");
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
                columns: new[] { "StoreID", "AnnualSales", "Event", "GameID", "LastUpdated", "Origin", "Stock" },
                values: new object[,]
                {
                    { 1, 1000, "", 1, new DateTime(2024, 4, 22, 13, 41, 12, 47, DateTimeKind.Local).AddTicks(9160), "Origin1", 100 },
                    { 2, 1200, "", 2, new DateTime(2024, 5, 2, 13, 41, 12, 47, DateTimeKind.Local).AddTicks(9164), "Origin2", 150 }
                });

            migrationBuilder.InsertData(
                table: "Studios",
                columns: new[] { "StudioID", "Country", "EmailContact", "EmailLogin", "Fundation", "GameID", "Name", "Website" },
                values: new object[,]
                {
                    { 1, "Country1", "studio1@example.com", "studio1login@example.com", new DateTime(2014, 5, 22, 13, 41, 12, 47, DateTimeKind.Local).AddTicks(8941), 1, "Studio1", "www.studio1.com" },
                    { 2, "Country2", "studio2@example.com", "studio2login@example.com", new DateTime(2019, 5, 22, 13, 41, 12, 47, DateTimeKind.Local).AddTicks(8985), 2, "Studio2", "www.studio2.com" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Age", "Email", "LibraryGameUserID", "MessageID", "Name", "Password", "RegisterDate", "Role", "Surname" },
                values: new object[,]
                {
                    { 1, 30, "user1@example.com", 1, 1, "User1", "password1", new DateTime(2022, 5, 22, 13, 41, 12, 47, DateTimeKind.Local).AddTicks(9204), "admin", "Surname1" },
                    { 2, 25, "user2@example.com", 2, 2, "User2", "password2", new DateTime(2023, 5, 22, 13, 41, 12, 47, DateTimeKind.Local).AddTicks(9208), "admin", "Surname2" }
                });

            migrationBuilder.InsertData(
                table: "Communities",
                columns: new[] { "MessageID", "ActiveMember", "LikesCount", "Message", "PublicationDate", "UserID" },
                values: new object[,]
                {
                    { 1, true, 100, "Community1", new DateTime(2023, 5, 22, 13, 41, 12, 47, DateTimeKind.Local).AddTicks(9247), 1 },
                    { 2, true, 150, "Community2", new DateTime(2022, 5, 22, 13, 41, 12, 47, DateTimeKind.Local).AddTicks(9250), 2 }
                });

            migrationBuilder.InsertData(
                table: "LibraryGameUsers",
                columns: new[] { "LibraryGameUserId", "AddedDate", "GameID", "HoursPlayed", "LastPlayed", "Rating", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 22, 13, 41, 12, 47, DateTimeKind.Local).AddTicks(9224), 1, 50, new DateTime(2024, 5, 15, 13, 41, 12, 47, DateTimeKind.Local).AddTicks(9227), 4, 1 },
                    { 2, new DateTime(2024, 2, 22, 13, 41, 12, 47, DateTimeKind.Local).AddTicks(9230), 2, 100, new DateTime(2024, 5, 17, 13, 41, 12, 47, DateTimeKind.Local).AddTicks(9233), 5, 2 }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "ShoppingCartID", "FechaCreacion", "Total", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 22, 13, 41, 12, 47, DateTimeKind.Local).AddTicks(9265), 0m, 1 },
                    { 2, new DateTime(2024, 5, 22, 13, 41, 12, 47, DateTimeKind.Local).AddTicks(9267), 0m, 2 }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameID", "Categories", "Description", "LibraryGameUserId", "Name", "Price", "ReleaseDate", "ShoppingCartID", "StoreID", "StudioID", "Synopsis" },
                values: new object[] { 1, "Races, Multiplayer, One Person", "Description1", 1, "Game1", 59.99m, new DateTime(2023, 5, 22, 13, 41, 12, 47, DateTimeKind.Local).AddTicks(9185), null, 1, 1, "Short description about game's history" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameID", "Categories", "Description", "LibraryGameUserId", "Name", "Price", "ReleaseDate", "ShoppingCartID", "StoreID", "StudioID", "Synopsis" },
                values: new object[] { 2, "Races, Multiplayer, Shooting", "Description2", 2, "Game2", 49.99m, new DateTime(2022, 5, 22, 13, 41, 12, 47, DateTimeKind.Local).AddTicks(9189), null, 2, 2, "Short description about game's history" });

            migrationBuilder.CreateIndex(
                name: "IX_Communities_UserID",
                table: "Communities",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_GameGameShop_GamesGameID",
                table: "GameGameShop",
                column: "GamesGameID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_LibraryGameUserId",
                table: "Games",
                column: "LibraryGameUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_ShoppingCartID",
                table: "Games",
                column: "ShoppingCartID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_StudioID",
                table: "Games",
                column: "StudioID");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryGameUsers_UserID",
                table: "LibraryGameUsers",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_UserID",
                table: "ShoppingCarts",
                column: "UserID",
                unique: true);
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
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "Studios");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
