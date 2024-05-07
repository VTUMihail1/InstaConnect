using InstaConnect.Posts.Web.Profiles;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWebLayer(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddControllers();
        serviceCollection.AddEndpointsApiExplorer();
        serviceCollection.AddSwaggerGen();

        serviceCollection.Configure<ApiBehaviorOptions>(options => options.SuppressInferBindingSourcesForParameters = true);

        serviceCollection.AddAutoMapper(typeof(PostsWebProfile));

        return serviceCollection;
    }
}
