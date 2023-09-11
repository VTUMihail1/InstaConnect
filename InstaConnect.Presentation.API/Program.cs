using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Helpers;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.AutoMapper;
using InstaConnect.Business.Factories;
using InstaConnect.Business.Helpers;
using InstaConnect.Business.Models.Options;
using InstaConnect.Business.Services;
using InstaConnect.Data;
using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;
using InstaConnect.Data.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SendGrid;
using System.Text;
using System.Text.Json.Serialization;
using TokenHandler = InstaConnect.Business.Helpers.TokenHandler;
using TokenOptions = InstaConnect.Business.Models.Options.TokenOptions;

var builder = WebApplication.CreateBuilder(args);

var tokenOptions = builder.Configuration.GetSection(nameof(TokenOptions)).Get<TokenOptions>();
var emailOptions = builder.Configuration.GetSection(nameof(EmailSenderOptions)).Get<EmailSenderOptions>();
var emailTemplateOptions = builder.Configuration.GetSection(nameof(EmailTemplateOptions)).Get<EmailTemplateOptions>();

builder.Services
    .AddDbContext<InstaConnectContext>(options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        var serverVersion = ServerVersion.AutoDetect(connectionString);
        options.UseMySql(connectionString, serverVersion);
    });

builder.Services.AddSingleton(tokenOptions);
builder.Services.AddSingleton(emailOptions);
builder.Services.AddSingleton(emailTemplateOptions);
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<IEmailFactory, EmailFactory>();
builder.Services.AddScoped<IEmailHandler, EmailHandler>();
builder.Services.AddScoped<IEmailTemplateGenerator, EmailTemplateGenerator>();
builder.Services.AddScoped<ISendGridClient>(_ => new SendGridClient(emailOptions.APIKey));
builder.Services.AddScoped<ITokenRepository, TokenRepository>();
builder.Services.AddScoped<ITokenHandler, TokenHandler>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IResultFactory, ResultFactory>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddAutoMapper(typeof(InstaConnectProfile));

builder.Services
    .AddIdentity<User, Role>()
    .AddEntityFrameworkStores<InstaConnectContext>()
    .AddDefaultTokenProviders();

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
    .AddJwtBearer(configuration =>
    {
        configuration.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey)),
            ValidateAudience = true,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuer = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero
        };
    }
);

builder.Services
    .AddSwaggerGen(c =>
    {
        c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = JwtBearerDefaults.AuthenticationScheme
                    }
                },
                Array.Empty<string>()
            }
        });
    }
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<CookieAuthenticationOptions>(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromHours(tokenOptions.UserTokenLifetimeSeconds);
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
