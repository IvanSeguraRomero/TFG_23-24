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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         // Relación de Game con Studio y GameShop
        modelBuilder.Entity<Game>()
            .HasOne(g => g.Studio)
            .WithMany(s => s.Games)
            .HasForeignKey(g => g.StudioID);

        modelBuilder.Entity<Game>()
            .HasMany(g => g.StoresAvailableAt)
            .WithMany(gs => gs.Games);

        // Relación de GameShop con Game
        modelBuilder.Entity<GameShop>()
            .HasMany(gs => gs.Games)
            .WithMany(g => g.StoresAvailableAt);

         // Relación de LibraryGameUser con User y Game
        modelBuilder.Entity<LibraryGameUser>()
            .HasKey(lgu => lgu.UserID);

        modelBuilder.Entity<LibraryGameUser>()
            .HasOne(lgu => lgu.User)
            .WithOne(u => u.libraryGameUser)
            .HasForeignKey<LibraryGameUser>(lgu => lgu.UserID);

        // Relación de User con LibraryGameUser
        modelBuilder.Entity<User>()
            .HasOne(u => u.libraryGameUser)
            .WithOne(lgu => lgu.User)
            .HasForeignKey<LibraryGameUser>(lgu => lgu.UserID);
        // Relación entre User y Community
        modelBuilder.Entity<User>()
            .HasOne(u => u.community)
            .WithOne(c => c.User)
            .HasForeignKey<Community>(c => c.UserID);
    // Relación de Studio con Game
    modelBuilder.Entity<Studio>().HasData(
        new Studio
        {
            StudioID = 1,
            Name = "Studio1",
            Fundation = DateTime.Now.AddYears(-10),
            Country = "Country1",
            EmailContact = "studio1@example.com",
            Website = "www.studio1.com",
            Active = true
        },
        new Studio
        {
            StudioID = 2,
            Name = "Studio2",
            Fundation = DateTime.Now.AddYears(-5),
            Country = "Country2",
            EmailContact = "studio2@example.com",
            Website = "www.studio2.com",
            Active = true
        }
    );

    // Relación de GameShop con Game
    modelBuilder.Entity<GameShop>().HasData(
        new GameShop
        {
            StoreID = 1,
            Price = 49.99m,
            Discount = 0.1m,
            Stock = 100,
            AnnualSales = 1000,
            LastUpdated = DateTime.Now.AddDays(-30),
            Categories = "Category1",
            Origin = "Origin1"
        },
        new GameShop
        {
            StoreID = 2,
            Price = 39.99m,
            Discount = 0.05m,
            Stock = 150,
            AnnualSales = 1200,
            LastUpdated = DateTime.Now.AddDays(-20),
            Categories = "Category2",
            Origin = "Origin2"
        }
    );

    // Relación de Game con Studio y GameShop
    modelBuilder.Entity<Game>().HasData(
        new Game
        {
            GameID = 1,
            Name = "Game1",
            Description = "Description1",
            Price = 59.99m,
            ReleaseDate = DateTime.Now.AddYears(-1),
            Available = true,
            StudioID = 1,
            StoreID = 1
        },
        new Game
        {
            GameID = 2,
            Name = "Game2",
            Description = "Description2",
            Price = 49.99m,
            ReleaseDate = DateTime.Now.AddYears(-2),
            Available = true,
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
            Active = true,
            LibraryGameUserID = 1,
            MessageID = 1
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
            Active = true,
            LibraryGameUserID = 2,
            MessageID = 2
        }
    );

    // Relación de LibraryGameUser con User y Game
    modelBuilder.Entity<LibraryGameUser>().HasData(
        new LibraryGameUser
        {
            UserID = 1,
            GameID = 1,
            AddedDate = DateTime.Now.AddMonths(-6),
            Rating = 4,
            HoursPlayed = 50,
            LastPlayed = DateTime.Now.AddDays(-7)
        },
        new LibraryGameUser
        {
            UserID = 2,
            GameID = 2,
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
            Message = "Community1",
            PublicationDate = DateTime.Now.AddYears(-1),
            ActiveMember = true,
            LikesCount = 100
        },
        new Community
        {
            MessageID = 2,
            UserID = 2,
            Message = "Community2",
            PublicationDate = DateTime.Now.AddYears(-2),
            ActiveMember = true,
            LikesCount = 150
        }
    );

        

        base.OnModelCreating(modelBuilder);
    }
 }
}
