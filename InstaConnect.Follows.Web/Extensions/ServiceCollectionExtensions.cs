using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Follows.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWebLayer(this IServiceCollection serviceCollection)
    {
        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection.AddControllers();
        serviceCollection.AddEndpointsApiExplorer();
        serviceCollection.AddSwaggerGen();

        serviceCollection.Configure<ApiBehaviorOptions>(options => options.SuppressInferBindingSourcesForParameters = true);

        serviceCollection.AddAutoMapper(currentAssembly);

        return serviceCollection;
    }
}
