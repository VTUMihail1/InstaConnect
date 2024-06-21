using System.Text;
using InstaConnect.Messages.Web.Profiles;
using InstaConnect.Shared.Data.Models.Options;
using InstaConnect.Shared.Web.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace InstaConnect.Messages.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWebLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection
            .AddJwtBearer(configuration)
            .AddApiControllers()
            .AddAutoMapper(currentAssembly);

        serviceCollection.AddEndpointsApiExplorer();
        serviceCollection.AddSwaggerGen();

        serviceCollection.AddSignalR();

        serviceCollection.ConfigureApiBehaviorOptions();

        return serviceCollection;
    }
}
