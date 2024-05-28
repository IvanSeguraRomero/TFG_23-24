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
            Name = "Game1",
            Description = "Description1",
            Synopsis = "Short description about game's history",
            Price = 59.99m,
            ReleaseDate = DateTime.Now.AddYears(-1),
            Categories = "Races, Multiplayer, One Person",
            StudioID = 1,
            StoreID = 1
        },
        new Game
        {
            GameID = 2,
            Name = "Game2",
            Description = "Description2",
            Synopsis = "Short description about game's history",
            Price = 49.99m,
            ReleaseDate = DateTime.Now.AddYears(-2),
            Categories = "Races, Multiplayer, Shooting",
            StudioID = 2,
            StoreID = 2
        }
    );

    // Relación de User con LibraryGameUser
    modelBuilder.Entity<User>().HasData(
        new User
        {
            UserID = 1,
            Name = "User1",
            Surname = "Surname1",
            Password = "password1",
            Age = 30,
            Email = "user1@example.com",
            RegisterDate = DateTime.Now.AddYears(-2),
            LibraryGameUserID = 1,
            Role=Roles.Admin
        },
        new User
        {
            UserID = 2,
            Name = "User2",
            Surname = "Surname2",
            Password = "password2",
            Age = 25,
            Email = "user2@example.com",
            RegisterDate = DateTime.Now.AddYears(-1),
            LibraryGameUserID = 2,
            Role=Roles.Admin
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
