﻿using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Models.Options;

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
