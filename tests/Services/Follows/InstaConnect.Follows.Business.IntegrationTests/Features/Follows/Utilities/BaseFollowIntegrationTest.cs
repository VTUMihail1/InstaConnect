using InstaConnect.Follows.Business.IntegrationTests.Utilities;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Data;
using InstaConnect.Follows.Data.Features.Follows.Abstractions;
using InstaConnect.Follows.Data.Features.Follows.Models.Entities;
using InstaConnect.Follows.Data.Features.Users.Abstractions;
using InstaConnect.Follows.Data.Features.Users.Models.Entities;
using InstaConnect.Shared.Business.IntegrationTests.Utilities;
using InstaConnect.Shared.Data.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Follows.Business.IntegrationTests.Features.Follows.Utilities;

public abstract class BaseFollowIntegrationTest : BaseSharedIntegrationTest, IClassFixture<IntegrationTestWebAppFactory>, IAsyncLifetime
{


    protected IUserWriteRepository UserWriteRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var userWriteRepository = serviceScope.ServiceProvider.GetRequiredService<IUserWriteRepository>();

            return userWriteRepository;
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

    protected BaseFollowIntegrationTest(IntegrationTestWebAppFactory integrationTestWebAppFactory)
        : base(integrationTestWebAppFactory.Services.CreateScope())
    {

    }

    protected async Task<string> CreateFollowAsync(string followerId, string followingId, CancellationToken cancellationToken)
    {
        var follow = new Follow(
            followerId,
            followingId);

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var followWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IFollowWriteRepository>();

        followWriteRepository.Add(follow);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return follow.Id;
    }

    protected async Task<string> CreateUserAsync(CancellationToken cancellationToken)
    {
        var user = new User(
            FollowTestUtilities.ValidUserFirstName,
            FollowTestUtilities.ValidUserLastName,
            FollowTestUtilities.ValidUserEmail,
            FollowTestUtilities.ValidUserName,
            FollowTestUtilities.ValidUserProfileImage);

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var userWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IUserWriteRepository>();

        userWriteRepository.Add(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
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
