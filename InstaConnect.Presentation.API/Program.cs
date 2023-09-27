using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Helpers;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.AutoMapper;
using InstaConnect.Business.Factories;
using InstaConnect.Business.Helpers;
using InstaConnect.Business.Helpers.Hubs;
using InstaConnect.Business.Models.Options;
using InstaConnect.Business.Services;
using InstaConnect.Data;
using InstaConnect.Data.Abstraction.Factories;
using InstaConnect.Data.Abstraction.Helpers;
using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Factories;
using InstaConnect.Data.Helpers;
using InstaConnect.Data.Models.Entities;
using InstaConnect.Data.Models.Options;
using InstaConnect.Data.Repositories;
using InstaConnect.Presentation.API.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SendGrid;
using System.Text;
using System.Text.Json.Serialization;
using TokenGenerator = InstaConnect.Data.Helpers.TokenGenerator;
using TokenOptions = InstaConnect.Data.Models.Options.TokenOptions;

var builder = WebApplication.CreateBuilder(args);

var corsOptions = builder.Configuration.GetSection("CorsOptions");
var adminOptions = builder.Configuration.GetSection(nameof(AdminOptions));
var tokenOptions = builder.Configuration.GetSection(nameof(TokenOptions));
var emailOptions = builder.Configuration.GetSection(nameof(EmailOptions));

builder.Services.Configure<AdminOptions>(adminOptions)
                .Configure<TokenOptions>(tokenOptions)
                .Configure<EmailOptions>(emailOptions);

builder.Services
    .AddDbContext<InstaConnectContext>(options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        var serverVersion = ServerVersion.AutoDetect(connectionString);
        options.UseMySql(connectionString, serverVersion);
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowedOrigins",
             p => p.WithOrigins(corsOptions["Hosts"])
                   .AllowAnyMethod()
                   .AllowAnyHeader());
});

builder.Services
    .AddScoped<IDbSeeder, DbSeeder>()
    .AddScoped<IResultFactory, ResultFactory>()
    .AddScoped<ISendGridClient>(_ => new SendGridClient(emailOptions["APIKey"]))
    .AddScoped<IEmailFactory, EmailFactory>()
    .AddScoped<IEmailSender, EmailSender>()
    .AddScoped<IEmailManager, EmailManager>()
    .AddScoped<IEmailTemplateGenerator, EmailTemplateGenerator>()
    .AddScoped<ITokenFactory, TokenFactory>()
    .AddScoped<ITokenGenerator, TokenGenerator>()
    .AddScoped<ITokenRepository, TokenRepository>()
    .AddScoped<ITokenManager, TokenManager>()
    .AddScoped<IPostRepository, PostRepository>()
    .AddScoped<IPostService, PostService>()
    .AddScoped<IPostCommentRepository, PostCommentRepository>()
    .AddScoped<IPostCommentService, PostCommentService>()
    .AddScoped<IPostLikeRepository, PostLikeRepository>()
    .AddScoped<IPostLikeService, PostLikeService>()
    .AddScoped<ICommentLikeRepository, CommentLikeRepository>()
    .AddScoped<ICommentLikeService, CommentLikeService>()
    .AddScoped<IFollowRepository, FollowRepository>()
    .AddScoped<IFollowService, FollowService>()
    .AddScoped<IMessageRepository, MessageRepository>()
    .AddScoped<IMessageSender, MessageSender>()
    .AddScoped<IMessageService, MessageService>()
    .AddScoped<IUserRepository, UserRepository>()
    .AddScoped<IUserService, UserService>()
    .AddScoped<IAccountService, AccountService>()
    .AddAutoMapper(typeof(InstaConnectProfile));

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

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;
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
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions["SecurityKey"])),
            ValidateAudience = true,
            ValidAudience = tokenOptions["Audience"],
            ValidateIssuer = true,
            ValidIssuer = tokenOptions["Issuer"],
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
            Type = SecuritySchemeType.ApiKey,
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
builder.Services.AddSignalR();

builder.Services
    .Configure<CookieAuthenticationOptions>(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromHours(int.Parse(tokenOptions["UserTokenLifetimeSeconds"]));
    });

var app = builder.Build();

await app.SeedDb();

app.UseSwagger();
app.UseSwaggerUI();

app.MapHub<ChatHub>("/chat-hub");

app.UseHttpsRedirection();

app.UseCors("AllowedOrigins");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
