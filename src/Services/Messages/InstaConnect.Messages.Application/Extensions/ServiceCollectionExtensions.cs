using InstaConnect.Common.Application.Extensions;
using InstaConnect.Common.Extensions;
using InstaConnect.Messages.Application.Features.Messages.Extensions;

namespace InstaConnect.Messages.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddMessageServices();

        serviceCollection
            .AddValidators(ApplicationReference.Assembly)
            .AddMediatR(ApplicationReference.Assembly)
            .AddMapper(ApplicationReference.Assembly);

        return serviceCollection;
    }
}
