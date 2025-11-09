using InstaConnect.Common.Tests.Events;

using MassTransit;

using Microsoft.Extensions.DependencyInjection;

using WebMotions.Fake.Authentication.JwtBearer;

namespace InstaConnect.Common.Tests.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTestEventHarness(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMassTransitTestHarness();
        serviceCollection.AddScoped<IEventHarness, EventHarness>();

        return serviceCollection;
    }

    public static IServiceCollection AddTestJwtAuth(this IServiceCollection serviceCollection)
    {
        serviceCollection
                .AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = FakeJwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = FakeJwtBearerDefaults.AuthenticationScheme;
                })
                .AddFakeJwtBearer(opt => opt.BearerValueType = FakeJwtBearerBearerValueType.Jwt);

        return serviceCollection;
    }
}
