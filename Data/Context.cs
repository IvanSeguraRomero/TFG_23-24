namespace FlashGamingHub.Data;

using Microsoft.EntityFrameworkCore;
using FlashGamingHub.Models;
public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options){}

    public DbSet<User> Users { get;set; }
    public DbSet<Game> Games { get;set; }
    public DbSet<Studio> Studios{ get;set; }
    public DbSet<LibraryGameUser> LibraryGameUsers{ get;set; }
    public DbSet<Community> Communities { get;set; }
    public DbSet<GameShop>GameShops{ get; set; }
}
