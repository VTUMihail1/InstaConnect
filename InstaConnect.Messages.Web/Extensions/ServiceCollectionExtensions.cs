using InstaConnect.Messages.Web.Profiles;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Messages.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWebLayer(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSignalR();

            serviceCollection.Configure<ApiBehaviorOptions>(options => options.SuppressInferBindingSourcesForParameters = true);

            serviceCollection.AddAutoMapper(typeof(MessagesWebProfile));

            return serviceCollection;
        }
    }
}
