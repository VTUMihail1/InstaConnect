﻿using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Users;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using WebMotions.Fake.Authentication.JwtBearer;

namespace InstaConnect.Shared.Web.FunctionalTests.Extensions;

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