﻿using System.Text;
using InstaConnect.Shared.Data.Models.Options;
using InstaConnect.Shared.Web.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace InstaConnect.Gateway.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWebLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddJwtBearer(configuration);

        serviceCollection.AddEndpointsApiExplorer();
        serviceCollection.AddSwaggerGen();

        serviceCollection
            .AddReverseProxy()
            .LoadFromConfig(configuration.GetSection("ReverseProxy"));

        return serviceCollection;
    }
}
