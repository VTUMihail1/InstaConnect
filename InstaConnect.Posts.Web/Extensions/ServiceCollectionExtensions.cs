using InstaConnect.Posts.Web.Profiles;
using InstaConnect.Users.Business.Abstractions;
using InstaConnect.Users.Business.Profiles;
using InstaConnect.Users.Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace InstaConnect.Posts.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWebLayer(this IServiceCollection serviceCollection)
    {
        serviceCollection.Configure<ApiBehaviorOptions>(options => options.SuppressInferBindingSourcesForParameters = true);

        serviceCollection.AddAutoMapper(typeof(PostsWebProfile));

        return serviceCollection;
    }
}
