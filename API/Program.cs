using FlashGamingHub.Data;
using FlashGamingHub.Business;
using Microsoft.EntityFrameworkCore;

    var builder = WebApplication.CreateBuilder(args);
    var connectionString = builder.Configuration.GetConnectionString("ServerDB");

    builder.Services.AddDbContext<Context>(options =>
        options.UseSqlServer(connectionString));

    // Scoped Services
    //Community
    //  builder.Services.AddScoped<ICommunityRepository, C>(); 
    // builder.Services.AddScoped<ITicketRepository, TicketEFRepository>();





// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
