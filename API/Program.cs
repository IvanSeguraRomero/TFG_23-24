using FlashGamingHub.Data;
using FlashGamingHub.Business;
using Microsoft.EntityFrameworkCore;
using FlashGamingHub.common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            ValidAudience = builder.Configuration["JWT:ValidAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecretKey"]))
        };
    });
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

    //AuthService
    builder.Services.AddScoped<IAuthService, AuthService>();


    //Logs
    builder.Services.AddScoped<IlogError,LogErrorClass>();





    var connectionString = builder.Configuration.GetConnectionString("ServerDB");

    builder.Services.AddDbContext<Context>(options =>
        options.UseSqlServer(connectionString));

    




    // Add services to the container.
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddSwaggerGen(opt =>
    {
        opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
        opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });

        opt.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type=ReferenceType.SecurityScheme,
                        Id="Bearer"
                    }
                },
                new string[]{}
            }
        });
    });

    // builder.Services.AddAuthorization();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    // if (app.Environment.IsDevelopment())
    // {
        app.UseSwagger();
        app.UseSwaggerUI();
    // }

    // app.UseHttpsRedirection();
    
    app.UseCors(options =>
        {
        options.WithOrigins("http://localhost:5173")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
        });

    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
