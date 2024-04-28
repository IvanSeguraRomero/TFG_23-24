using FlashGamingHub.Data;
using FlashGamingHub.Business;
using Microsoft.EntityFrameworkCore;
using FlashGamingHub.common;

    var builder = WebApplication.CreateBuilder(args);
    var connectionString = builder.Configuration.GetConnectionString("ServerDB");

    builder.Services.AddDbContext<Context>(options =>
        options.UseSqlServer(connectionString));

    // Scoped Services
    //Community
    builder.Services.AddScoped<ICommunityService, CommunityService>(); 
    builder.Services.AddScoped<ICommunityRepository, CommunityEFRepository>();

    //Game
    builder.Services.AddScoped<IGameService, GameService>(); 
    builder.Services.AddScoped<IGameRepository, GameEFRepository>();
    
    //GameShop
    builder.Services.AddScoped<IGameShopService, GameShopService>(); 
    builder.Services.AddScoped<IGameShopRepository, GameShopEFRepository>();

    //Library
    builder.Services.AddScoped<ILibraryGameUserService, LibraryGameUserService>(); 
    builder.Services.AddScoped<ILibraryGameUserRepository, LibraryGameUserEFRepository>();

    //Studio
    builder.Services.AddScoped<IStudioService, StudioService>(); 
    builder.Services.AddScoped<IStudioRepository, StudioEFRepository>();

    //User
    builder.Services.AddScoped<IUserService, UserService>(); 
    builder.Services.AddScoped<IUserRepository, UserEFRepository>();

    //Logs
    builder.Services.AddScoped<IlogError,LogErrorClass>();




// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors(options =>
    {
    options.WithOrigins("http://localhost:5173")
           .AllowAnyMethod()
           .AllowAnyHeader()
           .AllowCredentials();
    });

app.MapControllers();

app.Run();
