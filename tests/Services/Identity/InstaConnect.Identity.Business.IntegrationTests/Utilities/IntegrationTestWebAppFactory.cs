﻿using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Data;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.IntegrationTests.Extensions;
using InstaConnect.Shared.Business.Models;
using MassTransit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Testcontainers.MsSql;
using Testcontainers.Redis;

namespace InstaConnect.Identity.Business.IntegrationTests.Utilities;

public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly MsSqlContainer _msSqlContainer;
    private readonly RedisContainer _redisContainer;

    public IntegrationTestWebAppFactory()
    {
        _msSqlContainer = new MsSqlBuilder()
        .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
        .WithPassword("Password123!")
        .Build();

        _redisContainer = new RedisBuilder()
            .WithImage("redis:7.0")
            .WithCleanUp(true)
            .Build();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(serviceCollection =>
        {
            serviceCollection.AddTestDbContext<IdentityContext>(opt => opt.UseSqlServer(_msSqlContainer.GetConnectionString()));

            serviceCollection.AddTestRedisCache(rc => rc.Configuration = _redisContainer.GetConnectionString());

            serviceCollection.AddMassTransitTestHarness();

            var descriptor = serviceCollection.SingleOrDefault(s => s.ServiceType == typeof(IImageHandler));

            if (descriptor != null)
            {
                serviceCollection.Remove(descriptor);
            }

            var imageHandler = Substitute.For<IImageHandler>();
            var imageUploadResult = new ImageResult(UserTestUtilities.ValidProfileImage);
            var imageUploadAddResult = new ImageResult(UserTestUtilities.ValidAddProfileImage);
            var imageUploadUpdateResult = new ImageResult(UserTestUtilities.ValidUpdateProfileImage);

            imageHandler
               .UploadAsync(Arg.Is<ImageUploadModel>(iu => iu.FormFile == UserTestUtilities.ValidFormFile), Arg.Any<CancellationToken>())
               .Returns(imageUploadResult);

            imageHandler
               .UploadAsync(Arg.Is<ImageUploadModel>(iu => iu.FormFile == UserTestUtilities.ValidAddFormFile), Arg.Any<CancellationToken>())
               .Returns(imageUploadAddResult);

            imageHandler
               .UploadAsync(Arg.Is<ImageUploadModel>(iu => iu.FormFile == UserTestUtilities.ValidUpdateFormFile), Arg.Any<CancellationToken>())
               .Returns(imageUploadUpdateResult);

            serviceCollection.AddScoped(_ => imageHandler);
        });
    }

    public Task InitializeAsync()
    {
        _redisContainer.StartAsync();
        return _msSqlContainer.StartAsync();
    }

    public new Task DisposeAsync()
    {
        _redisContainer.DisposeAsync().AsTask();
        return _msSqlContainer.DisposeAsync().AsTask();
    }
}
