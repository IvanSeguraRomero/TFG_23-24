using Microsoft.EntityFrameworkCore;
using FlashGamingHub.Models;

namespace FlashGamingHub.Data{
public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) 
    : base(options)
    {     
    }

    public DbSet<User> Users { get;set; }
    public DbSet<Game> Games { get;set; }
    public DbSet<Studio> Studios{ get;set; }
    public DbSet<LibraryGameUser> LibraryGameUsers{ get;set; }
    public DbSet<Community> Communities { get;set; }
    public DbSet<GameShop>GameShops{ get; set; }
    public DbSet<ShoppingCart>ShoppingCarts{ get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         // Relación de Game con Studio muchos juegos a un estudio
        modelBuilder.Entity<Game>()
            .HasOne(g => g.Studio)
            .WithMany(s => s.Games)
            .HasForeignKey(g => g.StudioID);

        //GameShop con Game una a muchos
        modelBuilder.Entity<Game>()
            .HasOne(g => g.StoreAvaidable)
            .WithMany(gs => gs.Games);

            //GameShop con Game una a muchos
        modelBuilder.Entity<GameShop>()
            .HasMany(g => g.Games)
            .WithOne(gs => gs.StoreAvaidable)
            .HasForeignKey(g=>g.StoreID);

        // Relación de LibraryGameUser con User uno a uno
        modelBuilder.Entity<LibraryGameUser>()
            .HasOne(lgu => lgu.User)
            .WithOne(u => u.libraryGameUser)
            .HasForeignKey<User>(u => u.LibraryGameUserID);

        // LibraryGameUser con Game una a muchos
        modelBuilder.Entity<Game>()
            .HasMany(lgu => lgu.libraryGameUser)
            .WithMany(g => g.Games);
   

        // Relación de User con LibraryGameUser un usuario a una biblioteca
        modelBuilder.Entity<User>()
            .HasOne(u => u.libraryGameUser)
            .WithOne(lgu => lgu.User)
            .HasForeignKey<LibraryGameUser>(lgu => lgu.UserID);
        
        
        // Relación entre User y Community un usuario muchos mensajes
        modelBuilder.Entity<User>()
            .HasMany(u => u.messages)
            .WithOne(m => m.User)
            .HasForeignKey(m => m.UserID);

        //Relacion entre Game y Community
        modelBuilder.Entity<Game>()
            .HasMany(u => u.messages)
            .WithOne(m => m.Game)
            .HasForeignKey(m => m.GameID);




        // Relación entre User y ShoppingCart
            modelBuilder.Entity<User>()
                .HasOne(u => u.ShoppingCart)
                .WithOne(sc => sc.User)
                .HasForeignKey<ShoppingCart>(sc => sc.UserID);

        // Relación entre ShoppingCart y Game
            modelBuilder.Entity<ShoppingCart>()
                .HasMany(sc => sc.Games)
                .WithMany(g => g.shoppingCart);
            

    // Relación de Studio con Game
    modelBuilder.Entity<Studio>().HasData(
        new Studio
        {
            StudioID = 1,
            Name = "Bandai Namco Entertainment",
            Fundation = DateTime.Now.AddYears(-10),
            Country = "Japan",
            EmailContact = "bandaisupport@gmail.com",
            EmailLogin = "bandainamco@gmail.com",
            Password = "Dq61uGd16mtsRoJ.",
            Website = "www.bandai.com"
        },
        new Studio
        {
            StudioID = 2,
            Name = "Ubisoft",
            Fundation = DateTime.Now.AddYears(-5),
            Country = "France",
            EmailContact = "ubisoftsupport@gmail.com",
            EmailLogin = "ubisoft@gmail.com",
            Password = "4F1Gb7P72SHlwos",
            Website = "www.ubisoft.com"
        },
        new Studio
        {
            StudioID = 3,
            Name = "Sony Interactive Entertainment",
            Fundation = DateTime.Now.AddYears(-5),
            Country = "Tokyo",
            EmailContact = "sonysupport@gmail.com",
            EmailLogin = "sony@gmail.com",
            Password = "7Z94eudXHZLVYYC",
            Website = "www.sony.com"
        },
        new Studio
        {
            StudioID = 4,
            Name = "Activision",
            Fundation = DateTime.Now.AddYears(-5),
            Country = "USA",
            EmailContact = "activisionsupport@gmail.com",
            EmailLogin = "activision@gmail.com",
            Password = "2z1K7Fjdno23one",
            Website = "www.activision.com"
        }
        
    );

    // Relación de GameShop con Game
    modelBuilder.Entity<GameShop>().HasData(
        new GameShop
        {
            StoreID = 1,
            Event = "Summer Discounts",
            Stock = 100,
            AnnualSales = 0,
            LastUpdated = DateTime.Now.AddDays(-30),
            Origin = "Europe"
        }
    );

    // Relación de Game con Studio y GameShop
    modelBuilder.Entity<Game>().HasData(
        new Game
        {
            GameID = 1,
            Name = "Tekken 8",
            Description = "32 fighters with next-gen visuals will collide in Tekken 8! Both new and returning characters are stunningly portrayed in high-detailed character models built from the ground up - featuring every drop of sweat and ripped muscles for an immersive experience. The roster includes iconic fighters like Paul Phoenix, King, Marshall Law, and Nina Williams, and sees the return of Raven after last being part of the story of Tekken 6, 15 years ago! Jun Kazama returns to the story for the first time in 25 years since her disappearance in Tekken 2, and Tekken 8 also introduces a new Peruvian character Azucena! Players will be able to challenge their opponents on 16 battle stages with intense destruction and interactive stage elements.",
            Synopsis = "TEKKEN 8 continues the tragic saga of the Mishima bloodline and its world-shaking father-and-son grudge matches. After defeating his father, Heihachi Mishima, Kazuya continues his conquest for global domination, using the forces of G Corporation to wage war on the world.",
            Price = 59.99m,
            Discount = 0,
            ReleaseDate = DateTime.Now.AddYears(-1),
            Categories = "Fighting, Action, Violent",
            StudioID = 1,
            StoreID = 1
        },
        new Game
        {
            GameID = 2,
            Name = "Elden Ring",
            Description = "Journey through the Lands Between, a new fantasy world created by Hidetaka Miyazaki, creator of the influential DARK SOULS video game series, and George R. R. Martin, author of The New York Times best-selling fantasy series, A Song of Ice and Fire.Unravel the mysteries of the Elden Ring’s power. Encounter adversaries with profound backgrounds, characters with their own unique motivations for helping or hindering your progress, and fearsome creatures.Create your character in FromSoftware's refined action-RPG and define your playstyle by experimenting with a wide variety of weapons, magical abilities, and skills found throughout the world. Charge into battle, pick off enemies one-by-one using stealth, or even call upon allies for aid. Many options are at your disposal as you decide how to approach exploration and combat.",
            Synopsis = "Marika's offspring, demigods all, claimed the shards of the Elden Ring known as the Great Runes, and the mad taint of their newfound strength triggered a war: The Shattering. A war that meant abandonment by the Greater Will.",
            Price = 59.99m,
            Discount = 0,
            ReleaseDate = DateTime.Now.AddYears(-2),
            Categories = "Role-Playing (RPG), Open World, Graphic Adventure",
            StudioID = 1,
            StoreID = 1
        },
        new Game
        {
            GameID = 3,
            Name = "Ciberpunk 2077",
            Description = "Cyberpunk 2077 is an open-world, action-adventure RPG set in the megalopolis of Night City, where you play as a cyberpunk mercenary wrapped up in a do-or-die fight for survival. Improved and featuring all-new free additional content, customize your character and playstyle as you take on jobs, build a reputation, and unlock upgrades. The relationships you forge and the choices you make will shape the story and the world around you.",
            Synopsis = "Become an urban outlaw equipped with cybernetic enhancements and build your legend on the streets of Night City. Night City is packed to the brim with things to do, places to see, and people to meet. And it’s up to you where to go, when to go, and how to get there.",
            Price = 59.99m,
            Discount = 50,
            ReleaseDate = DateTime.Now.AddYears(-2),
            Categories = "Role-Playing (RPG), Open World, Graphic Adventure, Action",
            StudioID = 1,
            StoreID = 1
        },
        new Game
        {
            GameID = 4,
            Name = "The Witcher 3: The Wild Hunt",
            Description = "Built for endless adventure, the massive open world of The Witcher sets new standards in terms of size, depth, and complexity. - Traverse a fantastical open world: explore forgotten ruins, caves, and shipwrecks, trade with merchants and dwarven smiths in cities, and hunt across the open plains, mountains, and seas. - Deal with treasonous generals, devious witches, and corrupt royalty to provide dark and dangerous services. - Make choices that go beyond good & evil, and face their far-reaching consequences.",
            Synopsis = "You are Geralt of Rivia, mercenary monster slayer. Before you stands a war-torn, monster-infested continent you can explore at will. Your current contract? Tracking down Ciri — the Child of Prophecy, a living weapon that can alter the shape of the world.",
            Price = 62.97m,
            Discount = 20,
            ReleaseDate = DateTime.Now.AddYears(-2),
            Categories = "Role-Playing (RPG), Open World, Graphic Adventure, Fantasy",
            StudioID = 1,
            StoreID = 1
        },
        new Game
        {
            GameID = 5,
            Name = "Dragon Ball Z: Kakarot",
            Description = "Experience the story of DRAGON BALL Z from epic events to light-hearted side quests, including never-before-seen story moments that answer some burning questions of Dragon Ball lore for the first time! Play through iconic DRAGON BALL Z battles on a scale unlike any other. Fight across vast battlefields with destructible environments and experience epic boss battles that will test the limits of your combat abilities. Increase your power level and rise to the challenge!",
            Synopsis = "Relive the story of Goku in DRAGON BALL Z: KAKAROT! Beyond the epic battles, experience life in the DRAGON BALL Z world as you fight, fish, eat, and train with Goku. Explore the new areas and adventures as you advance through the story and form powerful bonds with other heroes.",
            Price = 59.99m,
            Discount = 40,
            ReleaseDate = DateTime.Now.AddYears(-2),
            Categories = "Action, Open World, Adventure, Anime, Fighting",
            StudioID = 1,
            StoreID = 1
        },
        new Game
        {
            GameID = 6,
            Name = "Assasins Creed III Remastered",
            Description = "FIGHT FOR FREEDOM 1775: The American Colonies are about to revolt. As Connor, a Native American Assassin, secure liberty for your people and your nation. From bustling city streets to the chaotic battlefields, assassinate your foes in a variety of deadly ways with a vast array of weaponry. A NEW VISUAL AND GAMEPLAY EXPERIENCE Play the iconic Assassin's Creed III with enhanced graphics, now featuring 4K resolution, new character models, polished environment rendering and more. The gameplay mechanics have been revamped as well, improving your experience and your immersion.",
            Synopsis = "Relive the American Revolution or experience it for the first time in Assassin's Creed III Remastered, with enhanced graphics and improved gameplay mechanics.",
            Price = 39.99m,
            Discount = 7,
            ReleaseDate = DateTime.Now.AddYears(-2),
            Categories = "Action, Adventure, Violent, Stealth",
            StudioID = 2,
            StoreID = 1
        },
        new Game
        {
            GameID = 7,
            Name = "For Honor",
            Description = "When the Cataclysm wreaked havoc on the world, all was lost. The once great order of Knights, whose tales of heroism and gallantry abounded, was razed to the ground. In the wastelands, what survivors remained were hopeless. All scavenged for food and water. And the strong preyed on the weak. But in the gloom of ash, there came a beacon of light: the Unsung Knight. A lone Warden, who made it her mission to help those in need. To use Valor’s Edge, the sword bequeathed unto her, to fight back against pillagers and invaders – and to bring hope to her people. For it was said this legendary sword would one day, in the bleakest of times, unite the Knights once more…",
            Synopsis = "After a great cataclysm, 4 of the fiercest warrior factions in history clash in an epic battle for survival. Join the war as a bold Knight, brutal Viking, deadly Samurai or fearsome Wu Lin and fight for your faction’s honor.",
            Price = 29.99m,
            Discount = 5,
            ReleaseDate = DateTime.Now.AddYears(-2),
            Categories = "Action, Violent, Gore, Multiplayer",
            StudioID = 2,
            StoreID = 1
        },
        new Game
        {
            GameID = 8,
            Name = "Rainbow Six Siege",
            Description = "Siege is an entry in the Rainbow Six series and the successor to Tom Clancy's Rainbow 6: Patriots, a tactical shooter that had a larger focus on narrative. After Patriots was eventually cancelled due to its technical shortcomings, Ubisoft decided to reboot the franchise. The team evaluated the core of the Rainbow Six franchise and believed that letting players impersonate the top counter-terrorist operatives around the world suited the game most. To create authentic siege situations, the team consulted actual counter-terrorism units and looked at real-life examples of sieges such as the 1980 Iranian Embassy siege.",
            Synopsis = "Tom Clancy's Rainbow Six® Siege is an elite, realistic, tactical team-based shooter where superior planning and execution triumph. It features 5v5 attack vs.",
            Price = 19.99m,
            Discount = 0,
            ReleaseDate = DateTime.Now.AddYears(-2),
            Categories = "Tactical, Shooter, Violent, Multiplayer",
            StudioID = 2,
            StoreID = 1
        }
        
    );

    // Relación de User con LibraryGameUser
    modelBuilder.Entity<User>().HasData(
        new User
        {
            UserID = 1,
            Name = "userAdmin",
            Surname = "surnameAdmin",
            Password = "L4Mf13z1E7YsU7N",
            Age = 30,
            Email = "admin@gmail.com",
            RegisterDate = DateTime.Now.AddYears(-2),
            LibraryGameUserID = 1,
            Role=Roles.Admin
        },
        new User
        {
            UserID = 2,
            Name = "userName",
            Surname = "userSurname",
            Password = "R0f86GsPcN2tJQ3",
            Age = 25,
            Email = "user@gmail.com",
            RegisterDate = DateTime.Now.AddYears(-1),
            LibraryGameUserID = 2,
            Role=Roles.User
        }
    );

    // Relación de LibraryGameUser con User y Game
    modelBuilder.Entity<LibraryGameUser>().HasData(
        new LibraryGameUser
        {
            LibraryGameUserId=1,
            UserID = 1,
            AddedDate = DateTime.Now.AddMonths(-6),
            Rating = 4,
            HoursPlayed = 50,
            LastPlayed = DateTime.Now.AddDays(-7)
        },
        new LibraryGameUser
        {
            LibraryGameUserId=2,
            UserID = 2,
            AddedDate = DateTime.Now.AddMonths(-3),
            Rating = 5,
            HoursPlayed = 100,
            LastPlayed = DateTime.Now.AddDays(-5)
        }
    );

        // Relación entre User y Community
    modelBuilder.Entity<Community>().HasData(
        new Community
        {
            MessageID = 1,
            UserID = 1,
            GameID = 1,
            Message = "Community1",
            PublicationDate = DateTime.Now.AddYears(-1),
            ActiveMember = true,
            LikesCount = 100
        },
        new Community
        {
            MessageID = 2,
            UserID = 2,
            GameID = 1,
            Message = "Community2",
            PublicationDate = DateTime.Now.AddYears(-2),
            ActiveMember = true,
            LikesCount = 150
        }
    );

    modelBuilder.Entity<ShoppingCart>().HasData(
        new ShoppingCart
        {
            ShoppingCartID = 1,
            UserID = 1,
            Total = 0,
            FechaCreacion = DateTime.Now
        },
        new ShoppingCart
        {
            ShoppingCartID = 2,
            UserID = 2,
            Total = 0,
            FechaCreacion = DateTime.Now
        }
    );
        base.OnModelCreating(modelBuilder);
    }
 }
}
