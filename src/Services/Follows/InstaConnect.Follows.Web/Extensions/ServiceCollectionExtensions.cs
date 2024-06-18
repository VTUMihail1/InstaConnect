using System.Text;
using InstaConnect.Users.Data.Models.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace InstaConnect.Follows.Web.Extensions;

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

        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection.AddControllers();
        serviceCollection.AddEndpointsApiExplorer();
        serviceCollection.AddSwaggerGen();

        serviceCollection.Configure<ApiBehaviorOptions>(options => options.SuppressInferBindingSourcesForParameters = true);

        serviceCollection.AddAutoMapper(currentAssembly);

        return serviceCollection;
    }
}
