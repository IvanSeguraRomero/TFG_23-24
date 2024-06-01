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
                    AnnualSales = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(80)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: false)
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
                    Edited = table.Column<bool>(type: "bit", nullable: false),
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
                columns: new[] { "StoreID", "AnnualSales", "ContactNumber", "Email", "Event", "LastUpdated", "Location", "Origin" },
                values: new object[] { 1, 0, "+44 20 7946 0958", "flashGamingHubSupport@gmail.com", "Summer Discounts", new DateTime(2024, 5, 2, 12, 19, 30, 981, DateTimeKind.Local).AddTicks(7521), "45 High Street, London, EC1A 1BB, United Kingdom", "Europe" });

            migrationBuilder.InsertData(
                table: "Studios",
                columns: new[] { "StudioID", "Country", "EmailContact", "EmailLogin", "Fundation", "Name", "Password", "Website" },
                values: new object[,]
                {
                    { 1, "Japan", "bandaisupport@gmail.com", "bandainamco@gmail.com", new DateTime(2014, 6, 1, 12, 19, 30, 981, DateTimeKind.Local).AddTicks(7270), "Bandai Namco Entertainment", "Dq61uGd16mtsRoJ.", "www.bandai.com" },
                    { 2, "France", "ubisoftsupport@gmail.com", "ubisoft@gmail.com", new DateTime(2019, 6, 1, 12, 19, 30, 981, DateTimeKind.Local).AddTicks(7304), "Ubisoft", "4F1Gb7P72SHlwos", "www.ubisoft.com" },
                    { 3, "Tokyo", "sonysupport@gmail.com", "sony@gmail.com", new DateTime(2019, 6, 1, 12, 19, 30, 981, DateTimeKind.Local).AddTicks(7337), "Sony Interactive Entertainment", "7Z94eudXHZLVYYC", "www.sony.com" },
                    { 4, "USA", "activisionsupport@gmail.com", "activision@gmail.com", new DateTime(2019, 6, 1, 12, 19, 30, 981, DateTimeKind.Local).AddTicks(7340), "Activision", "2z1K7Fjdno23one", "www.activision.com" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Age", "Email", "LibraryGameUserID", "Name", "Password", "RegisterDate", "Role", "Surname" },
                values: new object[,]
                {
                    { 1, 30, "admin@gmail.com", 1, "userAdmin", "L4Mf13z1E7YsU7N", new DateTime(2022, 6, 1, 12, 19, 30, 981, DateTimeKind.Local).AddTicks(7616), "admin", "surnameAdmin" },
                    { 2, 25, "user@gmail.com", 2, "userName", "R0f86GsPcN2tJQ3", new DateTime(2023, 6, 1, 12, 19, 30, 981, DateTimeKind.Local).AddTicks(7620), "user", "userSurname" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameID", "Categories", "Description", "Discount", "Name", "Price", "ReleaseDate", "StoreID", "StudioID", "Synopsis" },
                values: new object[,]
                {
                    { 1, "Fighting, Action, Violent", "32 fighters with next-gen visuals will collide in Tekken 8! Both new and returning characters are stunningly portrayed in high-detailed character models built from the ground up - featuring every drop of sweat and ripped muscles for an immersive experience. The roster includes iconic fighters like Paul Phoenix, King, Marshall Law, and Nina Williams, and sees the return of Raven after last being part of the story of Tekken 6, 15 years ago! Jun Kazama returns to the story for the first time in 25 years since her disappearance in Tekken 2, and Tekken 8 also introduces a new Peruvian character Azucena! Players will be able to challenge their opponents on 16 battle stages with intense destruction and interactive stage elements.", 0, "Tekken 8", 59.99m, new DateTime(2023, 6, 1, 12, 19, 30, 981, DateTimeKind.Local).AddTicks(7538), 1, 1, "TEKKEN 8 continues the tragic saga of the Mishima bloodline and its world-shaking father-and-son grudge matches. After defeating his father, Heihachi Mishima, Kazuya continues his conquest for global domination, using the forces of G Corporation to wage war on the world." },
                    { 2, "Role-Playing (RPG), Open World, Graphic Adventure", "Journey through the Lands Between, a new fantasy world created by Hidetaka Miyazaki, creator of the influential DARK SOULS video game series, and George R. R. Martin, author of The New York Times best-selling fantasy series, A Song of Ice and Fire.Unravel the mysteries of the Elden Ring’s power. Encounter adversaries with profound backgrounds, characters with their own unique motivations for helping or hindering your progress, and fearsome creatures.Create your character in FromSoftware's refined action-RPG and define your playstyle by experimenting with a wide variety of weapons, magical abilities, and skills found throughout the world. Charge into battle, pick off enemies one-by-one using stealth, or even call upon allies for aid. Many options are at your disposal as you decide how to approach exploration and combat.", 0, "Elden Ring", 59.99m, new DateTime(2022, 6, 1, 12, 19, 30, 981, DateTimeKind.Local).AddTicks(7542), 1, 1, "Marika's offspring, demigods all, claimed the shards of the Elden Ring known as the Great Runes, and the mad taint of their newfound strength triggered a war: The Shattering. A war that meant abandonment by the Greater Will." },
                    { 3, "Role-Playing (RPG), Open World, Graphic Adventure, Action", "Cyberpunk 2077 is an open-world, action-adventure RPG set in the megalopolis of Night City, where you play as a cyberpunk mercenary wrapped up in a do-or-die fight for survival. Improved and featuring all-new free additional content, customize your character and playstyle as you take on jobs, build a reputation, and unlock upgrades. The relationships you forge and the choices you make will shape the story and the world around you.", 50, "Ciberpunk 2077", 59.99m, new DateTime(2022, 6, 1, 12, 19, 30, 981, DateTimeKind.Local).AddTicks(7546), 1, 1, "Become an urban outlaw equipped with cybernetic enhancements and build your legend on the streets of Night City. Night City is packed to the brim with things to do, places to see, and people to meet. And it’s up to you where to go, when to go, and how to get there." },
                    { 4, "Role-Playing (RPG), Open World, Graphic Adventure, Fantasy", "Built for endless adventure, the massive open world of The Witcher sets new standards in terms of size, depth, and complexity. - Traverse a fantastical open world: explore forgotten ruins, caves, and shipwrecks, trade with merchants and dwarven smiths in cities, and hunt across the open plains, mountains, and seas. - Deal with treasonous generals, devious witches, and corrupt royalty to provide dark and dangerous services. - Make choices that go beyond good & evil, and face their far-reaching consequences.", 20, "The Witcher 3: The Wild Hunt", 62.97m, new DateTime(2022, 6, 1, 12, 19, 30, 981, DateTimeKind.Local).AddTicks(7548), 1, 1, "You are Geralt of Rivia, mercenary monster slayer. Before you stands a war-torn, monster-infested continent you can explore at will. Your current contract? Tracking down Ciri — the Child of Prophecy, a living weapon that can alter the shape of the world." },
                    { 5, "Action, Open World, Adventure, Anime, Fighting", "Experience the story of DRAGON BALL Z from epic events to light-hearted side quests, including never-before-seen story moments that answer some burning questions of Dragon Ball lore for the first time! Play through iconic DRAGON BALL Z battles on a scale unlike any other. Fight across vast battlefields with destructible environments and experience epic boss battles that will test the limits of your combat abilities. Increase your power level and rise to the challenge!", 40, "Dragon Ball Z: Kakarot", 59.99m, new DateTime(2022, 6, 1, 12, 19, 30, 981, DateTimeKind.Local).AddTicks(7552), 1, 1, "Relive the story of Goku in DRAGON BALL Z: KAKAROT! Beyond the epic battles, experience life in the DRAGON BALL Z world as you fight, fish, eat, and train with Goku. Explore the new areas and adventures as you advance through the story and form powerful bonds with other heroes." },
                    { 6, "Action, Adventure, Violent, Stealth", "FIGHT FOR FREEDOM 1775: The American Colonies are about to revolt. As Connor, a Native American Assassin, secure liberty for your people and your nation. From bustling city streets to the chaotic battlefields, assassinate your foes in a variety of deadly ways with a vast array of weaponry. A NEW VISUAL AND GAMEPLAY EXPERIENCE Play the iconic Assassin's Creed III with enhanced graphics, now featuring 4K resolution, new character models, polished environment rendering and more. The gameplay mechanics have been revamped as well, improving your experience and your immersion.", 7, "Assasins Creed III Remastered", 39.99m, new DateTime(2022, 6, 1, 12, 19, 30, 981, DateTimeKind.Local).AddTicks(7555), 1, 2, "Relive the American Revolution or experience it for the first time in Assassin's Creed III Remastered, with enhanced graphics and improved gameplay mechanics." },
                    { 7, "Action, Violent, Gore, Multiplayer", "When the Cataclysm wreaked havoc on the world, all was lost. The once great order of Knights, whose tales of heroism and gallantry abounded, was razed to the ground. In the wastelands, what survivors remained were hopeless. All scavenged for food and water. And the strong preyed on the weak. But in the gloom of ash, there came a beacon of light: the Unsung Knight. A lone Warden, who made it her mission to help those in need. To use Valor’s Edge, the sword bequeathed unto her, to fight back against pillagers and invaders – and to bring hope to her people. For it was said this legendary sword would one day, in the bleakest of times, unite the Knights once more…", 5, "For Honor", 29.99m, new DateTime(2022, 6, 1, 12, 19, 30, 981, DateTimeKind.Local).AddTicks(7558), 1, 2, "After a great cataclysm, 4 of the fiercest warrior factions in history clash in an epic battle for survival. Join the war as a bold Knight, brutal Viking, deadly Samurai or fearsome Wu Lin and fight for your faction’s honor." },
                    { 8, "Tactical, Shooter, Violent, Multiplayer", "Siege is an entry in the Rainbow Six series and the successor to Tom Clancy's Rainbow 6: Patriots, a tactical shooter that had a larger focus on narrative. After Patriots was eventually cancelled due to its technical shortcomings, Ubisoft decided to reboot the franchise. The team evaluated the core of the Rainbow Six franchise and believed that letting players impersonate the top counter-terrorist operatives around the world suited the game most. To create authentic siege situations, the team consulted actual counter-terrorism units and looked at real-life examples of sieges such as the 1980 Iranian Embassy siege.", 0, "Rainbow Six Siege", 19.99m, new DateTime(2022, 6, 1, 12, 19, 30, 981, DateTimeKind.Local).AddTicks(7561), 1, 2, "Tom Clancy's Rainbow Six® Siege is an elite, realistic, tactical team-based shooter where superior planning and execution triumph. It features 5v5 attack vs." },
                    { 9, "Action, Violent, Open World, Shooter", "Antón will even sacrifice his own people to forge his paradise, DO NOT TRUST HIM. We fight to liberate our nation from the oppression of a ruthless tyrant. Growing up in Yara, Dani has experienced the brutality of Antón's rule firsthand. After barely escaping the regime forces with her life, she joins forces with Libertad, a rag tag group of guerrilla fighters, to liberate her home from Antón's grip and corrupt regime.", 10, "FarCry 6", 59.99m, new DateTime(2022, 6, 1, 12, 19, 30, 981, DateTimeKind.Local).AddTicks(7564), 1, 2, "WELCOME TO YARA Embrace the gritty experience of an improvised modern-day guerrilla and take down a Dictator and his son to free Yara." },
                    { 10, "Action, Violent, Open World, Shooter, Multiplayer", "Mass surveillance, private militaries controlling the streets, organised crime... Enough! It's time to end oppression. Recruit a well-rounded resistance to overthrow the opportunists ruining this once-great city. The fate of London lies with you. Every Londoner has a reason to fight back. Explore the open world to find your next recruit. Each character is fully playable, has their own backstory, personality, and skill set — all of which comes into play as you personalise your team and choose the right operatives to best confront the challenges ahead.", 15, "Watch Dogs Legion", 59.99m, new DateTime(2022, 6, 1, 12, 19, 30, 981, DateTimeKind.Local).AddTicks(7567), 1, 2, "The story of Watch Dogs: Legion is just the beginning of The Resistance. Find out about the new game modes, events, characters, storyline, and more coming to London in the year ahead." },
                    { 11, "Action, Violent, Open World, Gore, Fantasy", "Kratos, the God of War, has defeated the Gods of Olympus and has started his life anew, in one of the Nine Realms of Norse Mythology: Midgard; he now has a son named Atreus, whom he had with his late wife Faye. Together, Kratos and Atreus travel across The Realms to scatter Faye's ashes from the highest peak in all the land.", 5, "God of War", 49.99m, new DateTime(2022, 6, 1, 12, 19, 30, 981, DateTimeKind.Local).AddTicks(7570), 1, 3, "After wiping out the gods of Mount Olympus, Kratos moves on to the frigid lands of Scandinavia, where he and his son must embark on an odyssey across a dangerous world of gods and monsters." },
                    { 12, "Action, Open World, Adventure", "When iconic Marvel villains threaten Marvel’s New York, Peter Parker and Spider-Man’s worlds collide. To save the city and those he loves, he must rise up and be greater. After eight years behind the mask, Peter Parker is a crime-fighting master. Feel the full power of a more experienced Spider-Man with improvisational combat, dynamic acrobatics, fluid urban traversal and environmental interactions. The worlds of Peter Parker and Spider-Man collide in an original action-packed story. In this new Spider-Man universe, iconic characters from Peter and Spider-Man’s lives have been reimagined, placing familiar characters in unique roles.", 20, "Marvel's Spider-Man Remastered", 59.99m, new DateTime(2022, 6, 1, 12, 19, 30, 981, DateTimeKind.Local).AddTicks(7573), 1, 3, "In Marvel’s Spider-Man Remastered, the worlds of Peter Parker and Spider-Man collide in an original, action-packed story. Play as an experienced Peter Parker, fighting big crime and iconic villains in Marvel’s New York. Web-swing through vibrant neighborhoods." },
                    { 13, "Horror, Adventure, Action", "In a ravaged civilization, where infected and hardened survivors run rampant, Joel, a weary protagonist, is hired to smuggle 14-year-old Ellie out of a military quarantine zone. However, what starts as a small job soon transforms into a brutal cross-country journey. Includes the complete The Last of Us single-player story and celebrated prequel chapter, Left Behind, which explores the events that changed the lives of Ellie and her best friend Riley forever.", 15, "The Last of Us Part I", 69.99m, new DateTime(2022, 6, 1, 12, 19, 30, 981, DateTimeKind.Local).AddTicks(7575), 1, 3, "Experience the emotional storytelling and unforgettable characters in The Last of Us™, winner of over 200 Game of the Year awards." },
                    { 14, "Shooter, Multiplager, Indie", "Helldivers 2 takes place in a satirical, futuristic setting in which mankind is ruled by the managed democracy of Super Earth, approximately a century after the events of the first game. Players take the roles of Helldivers, expendable elite soldiers who fight and die to protect the rest of humanity from various enemy factions.", 12, "Helldivers 2", 39.99m, new DateTime(2022, 6, 1, 12, 19, 30, 981, DateTimeKind.Local).AddTicks(7578), 1, 3, "HELLDIVERS 2 is a 3rd person squad-based shooter that sees the elite forces of the Helldivers battling to win an intergalactic struggle to rid the galaxy of the rising alien threats" },
                    { 15, "Open World, Graphic Adventure", "Uncharted 4: A Thief's End is an action-adventure game played from a third-person perspective, with platforming elements. Players traverse several environments, moving through locations including towns, buildings, and wilderness to advance through the game's story.", 25, "UNCHARTED 4: A Thief's End", 49.99m, new DateTime(2022, 6, 1, 12, 19, 30, 981, DateTimeKind.Local).AddTicks(7581), 1, 3, "Nathan Drake ,retired from fortune-hunting, Drake is suddenly forced back into the world of thieves. With the stakes much more personal, he embarks on a globe-trotting journey in pursuit of a historical conspiracy behind a fabled pirate treasure" },
                    { 16, "Role-Playing (RPG), Violent", "In Sekiro: Shadows Die Twice you are the “one-armed wolf”, a disgraced and disfigured warrior rescued from the brink of death. Bound to protect a young lord who is the descendant of an ancient bloodline, you become the target of many vicious enemies, including the dangerous Ashina clan. When the young lord is captured, nothing will stop you on a perilous quest to regain your honor, not even death itself. Explore late 1500s Sengoku Japan, a brutal period of constant life and death conflict, as you come face to face with larger than life foes in a dark and twisted world. Unleash an arsenal of deadly prosthetic tools and powerful ninja abilities while you blend stealth, vertical traversal, and visceral head to head combat in a bloody confrontation.", 0, "Sekiro Shadows Die Twice", 59.99m, new DateTime(2022, 6, 1, 12, 19, 30, 981, DateTimeKind.Local).AddTicks(7584), 1, 4, "Carve your own clever path to vengeance in the award-winning adventure from developer FromSoftware, creators of Elden Ring, Bloodborne, and the Dark Souls series." },
                    { 17, "Shooter, Action , Multiplayer, Violent", "Vladimir Makarov is a familiar enemy with a terrifying mission. He is meticulous, cold, calculating, and a soldier to his core. The web he weaves is vast, already influencing the events of Modern Warfare II and beyond through his pawns such as the PMC Konni Group, and others– whether they know it or not. Combat means making choices — different loadouts, different paths through the mission. In addition to the signature, cinematic Call of Duty® campaign missions, Modern Warfare® III introduces open combat missions that provide more player choice. There is no one-size-fits-all solution it is your choice whether to take the stealthy approach or go loud taking on any and all foes.", 0, "Call of Duty: MWIII", 69.99m, new DateTime(2022, 6, 1, 12, 19, 30, 981, DateTimeKind.Local).AddTicks(7587), 1, 4, "In the direct sequel to the record-breaking Call of Duty: Modern Warfare II, Captain Price and Task Force 141 face off against the ultimate threat. The ultranationalist war criminal Vladimir Makarov is extending his grasp across the world causing Task Force 141 to fight like never before." },
                    { 18, "Shooter, Action , Multiplayer, Violent", "Set in 2025, US Navy Seal Commander David 'Section' Mason, the son of former CIA Operative Alex Mason, fights to take out Raul Menendez , a Nicaraguan narco-terrorist and his organization, Cordis Die, after Menendez manages to gain control of the entire Unmanned US Drone Fleet in order to launch attacks on cities across the world. Meanwhile, Sergeant Frank Woods, now retired, recalls his experiences in the 1980s with Alex Mason on why Menendez became a terrorist.", 0, "Call of Duty: Black Ops II", 59.99m, new DateTime(2022, 6, 1, 12, 19, 30, 981, DateTimeKind.Local).AddTicks(7591), 1, 4, "Taken place ten years after the first black ops, Alex mason, Sgt.Frank Woods and Jason Hudson are back in the biggest call of duty event. Later on the creators take you to 2025 where the military technology is being hacked by a notorious villain." },
                    { 19, "Shooter, Action , Multiplayer, Violent", "The definitive Multiplayer experience returns bigger and better than ever, loaded with new maps, modes and features. Co-Op play has evolved with all-new Spec-Ops missions and leaderboards, as well as Survival Mode, an action-packed combat progression unlike any other.", 30, "Call of Duty: MW3", 59.99m, new DateTime(2022, 6, 1, 12, 19, 30, 981, DateTimeKind.Local).AddTicks(7593), 1, 4, "Prepare yourself for a cinematic thrill-ride as only Call of Duty can deliver. Engage enemy forces in New York, Paris, Berlin and other attack sites across the globe. The world stands on the brink, and Makarov is intent on bringing civilization to its knees." },
                    { 20, "Shooter, Action , Multiplayer, Violent", "Call of Duty: Black Ops 3 deploys its players into a future where bio-technology has enabled a new breed of Black Ops soldier. Players are connected to the intelligence grid and their fellow operatives during battle. In a world more divided than ever, this elite squad consists of men and women who have enhanced their combat capabilities to fight faster, stronger, and smarter. Every soldier has to make difficult decisions and visit dark places in this engaging, gritty narrative.", 0, "Call of Duty: Black Ops III", 59.99m, new DateTime(2022, 6, 1, 12, 19, 30, 981, DateTimeKind.Local).AddTicks(7596), 1, 4, "Call of Duty: Black Ops III deploys players into a dark, twisted future where a new breed of Black Ops soldiers emerges and the lines are blurred between our own humanity and the technology we created to stay ahead, in a world where cutting-edge military robotics define warfare." }
                });

            migrationBuilder.InsertData(
                table: "LibraryGameUsers",
                columns: new[] { "LibraryGameUserId", "AddedDate", "HoursPlayed", "LastPlayed", "Rating", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 1, 12, 19, 30, 981, DateTimeKind.Local).AddTicks(7632), 50, new DateTime(2024, 5, 25, 12, 19, 30, 981, DateTimeKind.Local).AddTicks(7635), 4, 1 },
                    { 2, new DateTime(2024, 3, 1, 12, 19, 30, 981, DateTimeKind.Local).AddTicks(7638), 100, new DateTime(2024, 5, 27, 12, 19, 30, 981, DateTimeKind.Local).AddTicks(7640), 5, 2 }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "ShoppingCartID", "FechaCreacion", "Total", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 1, 12, 19, 30, 981, DateTimeKind.Local).AddTicks(7669), 0m, 1 },
                    { 2, new DateTime(2024, 6, 1, 12, 19, 30, 981, DateTimeKind.Local).AddTicks(7671), 0m, 2 }
                });

            migrationBuilder.InsertData(
                table: "Communities",
                columns: new[] { "MessageID", "Edited", "GameID", "LikesCount", "Message", "PublicationDate", "UserID" },
                values: new object[] { 1, false, 1, 100, "This game is amazing.", new DateTime(2023, 6, 1, 12, 19, 30, 981, DateTimeKind.Local).AddTicks(7653), 1 });

            migrationBuilder.InsertData(
                table: "Communities",
                columns: new[] { "MessageID", "Edited", "GameID", "LikesCount", "Message", "PublicationDate", "UserID" },
                values: new object[] { 2, false, 1, 150, "I personally recommend this piece of art.", new DateTime(2022, 6, 1, 12, 19, 30, 981, DateTimeKind.Local).AddTicks(7656), 2 });

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
