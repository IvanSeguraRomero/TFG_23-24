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
                    EmailContact = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    EmailLogin = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(100)", nullable: true)
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
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
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
                    Discount = table.Column<int>(type: "int", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Categories = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    StudioID = table.Column<int>(type: "int", nullable: false),
                    StoreID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameID);
                    table.ForeignKey(
                        name: "FK_Games_GameShops_StoreID",
                        column: x => x.StoreID,
                        principalTable: "GameShops",
                        principalColumn: "StoreID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_Studios_StudioID",
                        column: x => x.StudioID,
                        principalTable: "Studios",
                        principalColumn: "StudioID",
                        onDelete: ReferentialAction.Cascade);
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
                    UserID = table.Column<int>(type: "int", nullable: true)
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
                name: "Communities",
                columns: table => new
                {
                    MessageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActiveMember = table.Column<bool>(type: "bit", nullable: false),
                    LikesCount = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    GameID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communities", x => x.MessageID);
                    table.ForeignKey(
                        name: "FK_Communities_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "GameID");
                    table.ForeignKey(
                        name: "FK_Communities_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "GameLibraryGameUser",
                columns: table => new
                {
                    GamesGameID = table.Column<int>(type: "int", nullable: false),
                    LibraryGameUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameLibraryGameUser", x => new { x.GamesGameID, x.LibraryGameUserId });
                    table.ForeignKey(
                        name: "FK_GameLibraryGameUser_Games_GamesGameID",
                        column: x => x.GamesGameID,
                        principalTable: "Games",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameLibraryGameUser_LibraryGameUsers_LibraryGameUserId",
                        column: x => x.LibraryGameUserId,
                        principalTable: "LibraryGameUsers",
                        principalColumn: "LibraryGameUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameShoppingCart",
                columns: table => new
                {
                    GamesGameID = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameShoppingCart", x => new { x.GamesGameID, x.ShoppingCartID });
                    table.ForeignKey(
                        name: "FK_GameShoppingCart_Games_GamesGameID",
                        column: x => x.GamesGameID,
                        principalTable: "Games",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameShoppingCart_ShoppingCarts_ShoppingCartID",
                        column: x => x.ShoppingCartID,
                        principalTable: "ShoppingCarts",
                        principalColumn: "ShoppingCartID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GameShops",
                columns: new[] { "StoreID", "AnnualSales", "Event", "LastUpdated", "Origin", "Stock" },
                values: new object[] { 1, 0, "Summer Discounts", new DateTime(2024, 4, 28, 20, 30, 2, 875, DateTimeKind.Local).AddTicks(3503), "Europe", 100 });

            migrationBuilder.InsertData(
                table: "Studios",
                columns: new[] { "StudioID", "Country", "EmailContact", "EmailLogin", "Fundation", "Name", "Password", "Website" },
                values: new object[,]
                {
                    { 1, "Japan", "bandaisupport@gmail.com", "bandainamco@gmail.com", new DateTime(2014, 5, 28, 20, 30, 2, 875, DateTimeKind.Local).AddTicks(3374), "Bandai Namco Entertainment", "Dq61uGd16mtsRoJ.", "www.bandai.com" },
                    { 2, "France", "ubisoftsupport@gmail.com", "ubisoft@gmail.com", new DateTime(2019, 5, 28, 20, 30, 2, 875, DateTimeKind.Local).AddTicks(3405), "Ubisoft", "4F1Gb7P72SHlwos", "www.ubisoft.com" },
                    { 3, "Tokyo", "sonysupport@gmail.com", "sony@gmail.com", new DateTime(2019, 5, 28, 20, 30, 2, 875, DateTimeKind.Local).AddTicks(3408), "Sony Interactive Entertainment", "7Z94eudXHZLVYYC", "www.sony.com" },
                    { 4, "USA", "activisionsupport@gmail.com", "activision@gmail.com", new DateTime(2019, 5, 28, 20, 30, 2, 875, DateTimeKind.Local).AddTicks(3411), "Activision", "2z1K7Fjdno23one", "www.activision.com" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Age", "Email", "LibraryGameUserID", "Name", "Password", "RegisterDate", "Role", "Surname" },
                values: new object[,]
                {
                    { 1, 30, "admin@gmail.com", 1, "userAdmin", "L4Mf13z1E7YsU7N", new DateTime(2022, 5, 28, 20, 30, 2, 875, DateTimeKind.Local).AddTicks(3604), "admin", "surnameAdmin" },
                    { 2, 25, "user@gmail.com", 2, "userName", "R0f86GsPcN2tJQ3", new DateTime(2023, 5, 28, 20, 30, 2, 875, DateTimeKind.Local).AddTicks(3608), "user", "userSurname" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameID", "Categories", "Description", "Discount", "Name", "Price", "ReleaseDate", "StoreID", "StudioID", "Synopsis" },
                values: new object[,]
                {
                    { 1, "Fighting, Action, Violent", "32 fighters with next-gen visuals will collide in Tekken 8! Both new and returning characters are stunningly portrayed in high-detailed character models built from the ground up - featuring every drop of sweat and ripped muscles for an immersive experience. The roster includes iconic fighters like Paul Phoenix, King, Marshall Law, and Nina Williams, and sees the return of Raven after last being part of the story of Tekken 6, 15 years ago! Jun Kazama returns to the story for the first time in 25 years since her disappearance in Tekken 2, and Tekken 8 also introduces a new Peruvian character Azucena! Players will be able to challenge their opponents on 16 battle stages with intense destruction and interactive stage elements.", 0, "Tekken 8", 59.99m, new DateTime(2023, 5, 28, 20, 30, 2, 875, DateTimeKind.Local).AddTicks(3566), 1, 1, "TEKKEN 8 continues the tragic saga of the Mishima bloodline and its world-shaking father-and-son grudge matches. After defeating his father, Heihachi Mishima, Kazuya continues his conquest for global domination, using the forces of G Corporation to wage war on the world." },
                    { 2, "Role-Playing (RPG), Open World, Graphic Adventure", "Journey through the Lands Between, a new fantasy world created by Hidetaka Miyazaki, creator of the influential DARK SOULS video game series, and George R. R. Martin, author of The New York Times best-selling fantasy series, A Song of Ice and Fire.Unravel the mysteries of the Elden Ring’s power. Encounter adversaries with profound backgrounds, characters with their own unique motivations for helping or hindering your progress, and fearsome creatures.Create your character in FromSoftware's refined action-RPG and define your playstyle by experimenting with a wide variety of weapons, magical abilities, and skills found throughout the world. Charge into battle, pick off enemies one-by-one using stealth, or even call upon allies for aid. Many options are at your disposal as you decide how to approach exploration and combat.", 0, "Elden Ring", 59.99m, new DateTime(2022, 5, 28, 20, 30, 2, 875, DateTimeKind.Local).AddTicks(3570), 1, 1, "Marika's offspring, demigods all, claimed the shards of the Elden Ring known as the Great Runes, and the mad taint of their newfound strength triggered a war: The Shattering. A war that meant abandonment by the Greater Will." },
                    { 3, "Role-Playing (RPG), Open World, Graphic Adventure, Action", "Cyberpunk 2077 is an open-world, action-adventure RPG set in the megalopolis of Night City, where you play as a cyberpunk mercenary wrapped up in a do-or-die fight for survival. Improved and featuring all-new free additional content, customize your character and playstyle as you take on jobs, build a reputation, and unlock upgrades. The relationships you forge and the choices you make will shape the story and the world around you.", 50, "Ciberpunk 2077", 59.99m, new DateTime(2022, 5, 28, 20, 30, 2, 875, DateTimeKind.Local).AddTicks(3573), 1, 1, "Become an urban outlaw equipped with cybernetic enhancements and build your legend on the streets of Night City. Night City is packed to the brim with things to do, places to see, and people to meet. And it’s up to you where to go, when to go, and how to get there." },
                    { 4, "Role-Playing (RPG), Open World, Graphic Adventure, Fantasy", "Built for endless adventure, the massive open world of The Witcher sets new standards in terms of size, depth, and complexity. - Traverse a fantastical open world: explore forgotten ruins, caves, and shipwrecks, trade with merchants and dwarven smiths in cities, and hunt across the open plains, mountains, and seas. - Deal with treasonous generals, devious witches, and corrupt royalty to provide dark and dangerous services. - Make choices that go beyond good & evil, and face their far-reaching consequences.", 20, "The Witcher 3: The Wild Hunt", 62.97m, new DateTime(2022, 5, 28, 20, 30, 2, 875, DateTimeKind.Local).AddTicks(3576), 1, 1, "You are Geralt of Rivia, mercenary monster slayer. Before you stands a war-torn, monster-infested continent you can explore at will. Your current contract? Tracking down Ciri — the Child of Prophecy, a living weapon that can alter the shape of the world." },
                    { 5, "Action, Open World, Adventure, Anime, Fighting", "Experience the story of DRAGON BALL Z from epic events to light-hearted side quests, including never-before-seen story moments that answer some burning questions of Dragon Ball lore for the first time! Play through iconic DRAGON BALL Z battles on a scale unlike any other. Fight across vast battlefields with destructible environments and experience epic boss battles that will test the limits of your combat abilities. Increase your power level and rise to the challenge!", 40, "Dragon Ball Z: Kakarot", 59.99m, new DateTime(2022, 5, 28, 20, 30, 2, 875, DateTimeKind.Local).AddTicks(3579), 1, 1, "Relive the story of Goku in DRAGON BALL Z: KAKAROT! Beyond the epic battles, experience life in the DRAGON BALL Z world as you fight, fish, eat, and train with Goku. Explore the new areas and adventures as you advance through the story and form powerful bonds with other heroes." },
                    { 6, "Action, Adventure, Violent, Stealth", "FIGHT FOR FREEDOM 1775: The American Colonies are about to revolt. As Connor, a Native American Assassin, secure liberty for your people and your nation. From bustling city streets to the chaotic battlefields, assassinate your foes in a variety of deadly ways with a vast array of weaponry. A NEW VISUAL AND GAMEPLAY EXPERIENCE Play the iconic Assassin's Creed III with enhanced graphics, now featuring 4K resolution, new character models, polished environment rendering and more. The gameplay mechanics have been revamped as well, improving your experience and your immersion.", 7, "Assasins Creed III Remastered", 39.99m, new DateTime(2022, 5, 28, 20, 30, 2, 875, DateTimeKind.Local).AddTicks(3582), 1, 2, "Relive the American Revolution or experience it for the first time in Assassin's Creed III Remastered, with enhanced graphics and improved gameplay mechanics." },
                    { 7, "Action, Violent, Gore, Multiplayer", "When the Cataclysm wreaked havoc on the world, all was lost. The once great order of Knights, whose tales of heroism and gallantry abounded, was razed to the ground. In the wastelands, what survivors remained were hopeless. All scavenged for food and water. And the strong preyed on the weak. But in the gloom of ash, there came a beacon of light: the Unsung Knight. A lone Warden, who made it her mission to help those in need. To use Valor’s Edge, the sword bequeathed unto her, to fight back against pillagers and invaders – and to bring hope to her people. For it was said this legendary sword would one day, in the bleakest of times, unite the Knights once more…", 5, "For Honor", 29.99m, new DateTime(2022, 5, 28, 20, 30, 2, 875, DateTimeKind.Local).AddTicks(3585), 1, 2, "After a great cataclysm, 4 of the fiercest warrior factions in history clash in an epic battle for survival. Join the war as a bold Knight, brutal Viking, deadly Samurai or fearsome Wu Lin and fight for your faction’s honor." },
                    { 8, "Tactical, Shooter, Violent, Multiplayer", "Siege is an entry in the Rainbow Six series and the successor to Tom Clancy's Rainbow 6: Patriots, a tactical shooter that had a larger focus on narrative. After Patriots was eventually cancelled due to its technical shortcomings, Ubisoft decided to reboot the franchise. The team evaluated the core of the Rainbow Six franchise and believed that letting players impersonate the top counter-terrorist operatives around the world suited the game most. To create authentic siege situations, the team consulted actual counter-terrorism units and looked at real-life examples of sieges such as the 1980 Iranian Embassy siege.", 0, "Rainbow Six Siege", 19.99m, new DateTime(2022, 5, 28, 20, 30, 2, 875, DateTimeKind.Local).AddTicks(3588), 1, 2, "Tom Clancy's Rainbow Six® Siege is an elite, realistic, tactical team-based shooter where superior planning and execution triumph. It features 5v5 attack vs." }
                });

            migrationBuilder.InsertData(
                table: "LibraryGameUsers",
                columns: new[] { "LibraryGameUserId", "AddedDate", "HoursPlayed", "LastPlayed", "Rating", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 28, 20, 30, 2, 875, DateTimeKind.Local).AddTicks(3620), 50, new DateTime(2024, 5, 21, 20, 30, 2, 875, DateTimeKind.Local).AddTicks(3623), 4, 1 },
                    { 2, new DateTime(2024, 2, 28, 20, 30, 2, 875, DateTimeKind.Local).AddTicks(3625), 100, new DateTime(2024, 5, 23, 20, 30, 2, 875, DateTimeKind.Local).AddTicks(3628), 5, 2 }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "ShoppingCartID", "FechaCreacion", "Total", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 28, 20, 30, 2, 875, DateTimeKind.Local).AddTicks(3655), 0m, 1 },
                    { 2, new DateTime(2024, 5, 28, 20, 30, 2, 875, DateTimeKind.Local).AddTicks(3657), 0m, 2 }
                });

            migrationBuilder.InsertData(
                table: "Communities",
                columns: new[] { "MessageID", "ActiveMember", "GameID", "LikesCount", "Message", "PublicationDate", "UserID" },
                values: new object[] { 1, true, 1, 100, "Community1", new DateTime(2023, 5, 28, 20, 30, 2, 875, DateTimeKind.Local).AddTicks(3640), 1 });

            migrationBuilder.InsertData(
                table: "Communities",
                columns: new[] { "MessageID", "ActiveMember", "GameID", "LikesCount", "Message", "PublicationDate", "UserID" },
                values: new object[] { 2, true, 1, 150, "Community2", new DateTime(2022, 5, 28, 20, 30, 2, 875, DateTimeKind.Local).AddTicks(3643), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Communities_GameID",
                table: "Communities",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Communities_UserID",
                table: "Communities",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_GameLibraryGameUser_LibraryGameUserId",
                table: "GameLibraryGameUser",
                column: "LibraryGameUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_StoreID",
                table: "Games",
                column: "StoreID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_StudioID",
                table: "Games",
                column: "StudioID");

            migrationBuilder.CreateIndex(
                name: "IX_GameShoppingCart_ShoppingCartID",
                table: "GameShoppingCart",
                column: "ShoppingCartID");

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
                name: "GameLibraryGameUser");

            migrationBuilder.DropTable(
                name: "GameShoppingCart");

            migrationBuilder.DropTable(
                name: "LibraryGameUsers");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "GameShops");

            migrationBuilder.DropTable(
                name: "Studios");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
