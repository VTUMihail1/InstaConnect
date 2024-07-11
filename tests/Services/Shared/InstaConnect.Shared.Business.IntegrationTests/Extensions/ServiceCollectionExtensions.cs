using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Users;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace InstaConnect.Shared.Business.IntegrationTests.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTestDbContext<TContext>(this IServiceCollection serviceCollection, Action<DbContextOptionsBuilder>? optionsAction = null)
      where TContext : DbContext
    {
        var efCoreDescriptor = serviceCollection.SingleOrDefault(s => s.ServiceType == typeof(DbContextOptions<TContext>));

        if (efCoreDescriptor != null)
        {
            serviceCollection.Remove(efCoreDescriptor);
        }

        serviceCollection.AddDbContext<TContext>(options => optionsAction?.Invoke(options));

        return serviceCollection;
    }

    public static IServiceCollection AddTestGetUserByIdRequestClient(this IServiceCollection serviceCollection, params GetUserByIdResponse[] getUserByIdResponses)
    {
        var descriptor = serviceCollection.SingleOrDefault(s => s.ServiceType == typeof(IRequestClient<GetUserByIdRequest>));

        if (descriptor != null)
        {
            serviceCollection.Remove(descriptor);
        }

        serviceCollection.AddScoped(_ =>
        {
            var requestClient = Substitute.For<IInstaConnectRequestClient<GetUserByIdRequest>>();

            foreach (var getUserByIdResponse in getUserByIdResponses)
            {
                requestClient.GetResponseMessageAsync<GetUserByIdResponse>(
                Arg.Is<GetUserByIdRequest>(r => r.Id == getUserByIdResponse.Id),
                Arg.Any<CancellationToken>())
                .Returns(getUserByIdResponse);
            }

            return requestClient;
        });

        return serviceCollection;
    }

    public static IServiceCollection AddMockGetUserByIdRequestClient(IServiceCollection serviceCollection, string id, string userName)
    {
        serviceCollection.AddScoped(_ =>
        {
            var requestClient = Substitute.For<IInstaConnectRequestClient<GetUserByIdRequest>>();

            requestClient.GetResponseMessageAsync<GetUserByIdResponse>(
                Arg.Is<GetUserByIdRequest>(r => r.Id == id),
                Arg.Any<CancellationToken>())
                .Returns(new GetUserByIdResponse
                {
                    Id = id,
                    UserName = userName
                });

            return requestClient;
        });

        return serviceCollection;
    }
}
