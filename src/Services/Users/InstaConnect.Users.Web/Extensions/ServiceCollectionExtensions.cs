using System.Text;
using System.Text.Json.Serialization;
using InstaConnect.Shared.Web.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TokenOptions = InstaConnect.Shared.Data.Models.Options.TokenOptions;

namespace InstaConnect.Users.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWebLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;
        var tokenOptions = configuration.GetSection(nameof(TokenOptions)).Get<TokenOptions>()!;

        serviceCollection
            .AddJwtBearer(configuration)
            .AddApiControllers()
            .AddAutoMapper(currentAssembly)
            .AddAuthorizationPolicies()
            .AddCorsPolicies(configuration)
            .AddSwagger()
            .AddRateLimiterPolicies()
            .AddExceptionHandler();

        serviceCollection.Configure<IdentityOptions>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 8;
        });

        serviceCollection.AddEndpointsApiExplorer();

        serviceCollection
            .Configure<CookieAuthenticationOptions>(options => options.ExpireTimeSpan = TimeSpan.FromSeconds(tokenOptions.AccountTokenLifetimeSeconds));

        serviceCollection.ConfigureApiBehaviorOptions();

        return serviceCollection;
    }
}
