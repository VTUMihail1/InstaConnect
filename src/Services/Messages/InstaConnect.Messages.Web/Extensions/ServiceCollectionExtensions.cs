using System.Text;
using InstaConnect.Messages.Web.Profiles;
using InstaConnect.Users.Data.Models.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace InstaConnect.Messages.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWebLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddOptions<TokenOptions>()
            .BindConfiguration(nameof(TokenOptions))
            .ValidateDataAnnotations()
        .ValidateOnStart();

        var tokenOptions = configuration
            .GetSection(nameof(TokenOptions))
            .Get<TokenOptions>();

        serviceCollection
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(configuration => configuration.TokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions!.AccountTokenSecurityKey)),
                ValidateAudience = true,
                ValidAudience = tokenOptions.Audience,
                ValidateIssuer = true,
                ValidIssuer = tokenOptions.Issuer,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero
            });

        serviceCollection.AddControllers();
        serviceCollection.AddEndpointsApiExplorer();
        serviceCollection.AddSwaggerGen();

        serviceCollection.AddSignalR();

        serviceCollection.Configure<ApiBehaviorOptions>(options => options.SuppressInferBindingSourcesForParameters = true);

        serviceCollection.AddAutoMapper(typeof(MessagesWebProfile));

        return serviceCollection;
    }
}
