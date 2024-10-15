using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Common.Features.Users.Utilities;
using InstaConnect.Follows.Data;
using InstaConnect.Follows.Data.Features.Follows.Abstractions;
using InstaConnect.Follows.Data.Features.Follows.Models.Entities;
using InstaConnect.Follows.Data.Features.Users.Abstractions;
using InstaConnect.Follows.Data.Features.Users.Models.Entities;
using InstaConnect.Follows.Web.Features.Follows.Utilities;
using InstaConnect.Follows.Web.FunctionalTests.Features.Follows.Abstractions;
using InstaConnect.Follows.Web.FunctionalTests.Features.Follows.Helpers;
using InstaConnect.Follows.Web.FunctionalTests.Utilities;
using InstaConnect.Shared.Data.Abstractions;
using InstaConnect.Shared.Web.FunctionalTests.Utilities;
using MassTransit.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Follows.Web.FunctionalTests.Features.Follows.Utilities;

public abstract class BaseFollowFunctionalTest : IClassFixture<FollowsFunctionalTestWebAppFactory>, IAsyncLifetime
{
    protected CancellationToken CancellationToken { get; }

    protected Dictionary<string, object> ValidJwtConfig { get; }

    protected IServiceScope ServiceScope { get; }

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

    protected IFollowsClient FollowsClient { get; }

    protected BaseFollowFunctionalTest(FollowsFunctionalTestWebAppFactory functionalTestWebAppFactory)
    {
        ServiceScope = functionalTestWebAppFactory.Services.CreateScope();
        CancellationToken = new();
        ValidJwtConfig = [];
        FollowsClient = new FollowsClient(functionalTestWebAppFactory.CreateClient());
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
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidProfileImage);

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
