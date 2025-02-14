using InstaConnect.Messages.Application.Features.Messages.Extensions;
using InstaConnect.Shared.Application.Extensions;
using InstaConnect.Shared.Common.Extensions;
using Microsoft.Extensions.DependencyInjection;

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
