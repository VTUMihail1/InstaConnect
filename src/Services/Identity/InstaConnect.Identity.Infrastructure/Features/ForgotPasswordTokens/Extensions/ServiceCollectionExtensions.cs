using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Helpers;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Models.Options;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddForgotPasswordTokenServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddOptions<ForgotPasswordOptions>()
            .BindConfiguration(nameof(ForgotPasswordOptions))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        return serviceCollection;
    }
}
