using DocConnect.Business.Helpers;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.AutoMapper;
using InstaConnect.Business.Factories;
using InstaConnect.Business.Services;
using InstaConnect.Data;
using InstaConnect.Data.Models.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TokenOptions = DocConnect.Business.Models.Options.TokenOptions;
using System.Text.Json.Serialization;
using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddDbContext<InstaConnectContext>(options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnect");
        var serverVersion = ServerVersion.AutoDetect(connectionString);
        options.UseMySql(connectionString, serverVersion);
    });

builder.Services
    .AddIdentity<User, Role>()
    .AddEntityFrameworkStores<InstaConnectContext>()
    .AddDefaultTokenProviders();

builder.Services
    .Configure<CookieAuthenticationOptions>(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromHours(1);
    });

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

    
var tokenOptions = builder.Configuration.GetSection(nameof(TokenOptions)).Get<TokenOptions>();

builder.Services.Configure<CookieAuthenticationOptions>(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromHours(tokenOptions.EmailConfirmationTokenLifetimeSeconds);
});

builder.Services.AddSingleton(tokenOptions);
builder.Services.AddScoped<ITokenRepository, TokenRepository>();
builder.Services.AddScoped<ITokenHandler, TokenHandler>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IResultFactory, ResultFactory>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddAutoMapper(typeof(InstaConnectProfile));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
