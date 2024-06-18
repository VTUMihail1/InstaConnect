using System.Text;
using InstaConnect.Users.Data.Models.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace InstaConnect.Gateway.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWebLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddEndpointsApiExplorer();
        serviceCollection.AddSwaggerGen();

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

        serviceCollection
            .AddReverseProxy()
            .LoadFromConfig(configuration.GetSection("ReverseProxy"));

        return serviceCollection;
    }
}
