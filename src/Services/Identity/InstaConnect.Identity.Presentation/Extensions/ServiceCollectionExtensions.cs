﻿using InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Extensions;
using InstaConnect.Identity.Presentation.Features.Users.Extensions;
using InstaConnect.Shared.Common.Extensions;
using InstaConnect.Shared.Presentation.Extensions;

namespace InstaConnect.Identity.Presentation.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentation(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddUserServices(configuration)
            .AddForgotPasswordTokenServices()
            .AddEmailConfirmationTokenServices();

        serviceCollection
            .AddServicesWithMatchingInterfaces(PresentationReference.Assembly)
            .AddApiControllers()
            .AddMapper(PresentationReference.Assembly)
            .AddAuthorizationPolicies()
            .AddCorsPolicies(configuration)
            .AddSwagger()
            .AddRateLimiterPolicies()
            .AddExceptionHandler();

        serviceCollection.AddEndpointsApiExplorer();

        return serviceCollection;
    }
}
