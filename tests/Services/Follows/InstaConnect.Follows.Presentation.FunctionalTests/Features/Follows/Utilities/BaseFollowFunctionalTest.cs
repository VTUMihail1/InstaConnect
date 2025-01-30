﻿using InstaConnect.Follows.Common.Features.Users.Utilities;
using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;
using InstaConnect.Follows.Domain.Features.Users.Abstractions;
using InstaConnect.Follows.Domain.Features.Users.Models.Entities;
using InstaConnect.Follows.Infrastructure;
using InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Abstractions;
using InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Helpers;
using InstaConnect.Follows.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Application.Abstractions;
using MassTransit.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Utilities;

public abstract class BaseFollowFunctionalTest : IClassFixture<FollowsFunctionalTestWebAppFactory>, IAsyncLifetime
{
    protected CancellationToken CancellationToken { get; }

    protected IServiceScope ServiceScope { get; }

    protected IFollowsClient FollowsClient { get; }

    protected ITestHarness TestHarness
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var testHarness = serviceScope.ServiceProvider.GetTestHarness();

            return testHarness;
        }
    }

    protected IFollowWriteRepository FollowWriteRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var followWriteRepository = serviceScope.ServiceProvider.GetRequiredService<IFollowWriteRepository>();

            return followWriteRepository;
        }
    }

    protected IFollowReadRepository FollowReadRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var followReadRepository = serviceScope.ServiceProvider.GetRequiredService<IFollowReadRepository>();

            return followReadRepository;
        }
    }

    protected BaseFollowFunctionalTest(FollowsFunctionalTestWebAppFactory functionalTestWebAppFactory)
    {
        ServiceScope = functionalTestWebAppFactory.Services.CreateScope();
        CancellationToken = new();
        FollowsClient = new FollowsClient(functionalTestWebAppFactory.CreateClient());
    }

    protected async Task<Follow> CreateFollowAsync(CancellationToken cancellationToken)
    {
        var follower = await CreateUserAsync(cancellationToken);
        var following = await CreateUserAsync(cancellationToken);
        var follow = new Follow(
            follower.Id,
            following.Id);

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var followWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IFollowWriteRepository>();

        followWriteRepository.Add(follow);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return follow;
    }

    protected async Task<User> CreateUserAsync(CancellationToken cancellationToken)
    {
        var user = new User(
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidProfileImage);

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var userWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IUserWriteRepository>();

        userWriteRepository.Add(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user;
    }

    public async Task InitializeAsync()
    {
        await EnsureDatabaseIsEmpty();
    }

    public async Task DisposeAsync()
    {
        await EnsureDatabaseIsEmpty();
    }

    private async Task EnsureDatabaseIsEmpty()
    {
        var dbContext = ServiceScope.ServiceProvider.GetRequiredService<FollowsContext>();

        if (dbContext.Follows.Any())
        {
            await dbContext.Follows.ExecuteDeleteAsync(CancellationToken);
        }

        if (dbContext.Users.Any())
        {
            await dbContext.Users.ExecuteDeleteAsync(CancellationToken);
        }
    }
}
