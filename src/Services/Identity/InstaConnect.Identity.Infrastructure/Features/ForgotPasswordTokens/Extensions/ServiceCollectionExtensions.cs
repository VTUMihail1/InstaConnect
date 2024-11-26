using InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Models.Options;
using InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddForgotPasswordTokenServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddOptions<ForgotPasswordOptions>()
            .BindConfiguration(nameof(ForgotPasswordOptions))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        serviceCollection
            .AddTransient<IForgotPasswordTokenWriteRepository, ForgotPasswordTokenWriteRepository>();

        return serviceCollection;
    }
}
