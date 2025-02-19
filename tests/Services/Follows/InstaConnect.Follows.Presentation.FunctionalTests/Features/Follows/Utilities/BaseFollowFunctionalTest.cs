using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Domain.Features.Users.Abstractions;
using InstaConnect.Follows.Infrastructure;
using InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Abstractions;
using InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Helpers;
using InstaConnect.Shared.Application.Abstractions;

using MassTransit.Testing;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Utilities;

public abstract class BaseFollowFunctionalTest : IClassFixture<FollowsWebApplicationFactory>, IAsyncLifetime
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

    protected BaseFollowFunctionalTest(FollowsWebApplicationFactory messagesWebApplicationFactory)
    {
        ServiceScope = messagesWebApplicationFactory.Services.CreateScope();
        CancellationToken = new();
        FollowsClient = new FollowsClient(messagesWebApplicationFactory.CreateClient());
    }

    private async Task<User> CreateUserUtilAsync(CancellationToken cancellationToken)
    {
        var user = new User(
            SharedTestUtilities.GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.ProfileImageMaxLength, UserConfigurations.ProfileImageMinLength));

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var userWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IUserWriteRepository>();

        userWriteRepository.Add(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user;
    }

    protected async Task<User> CreateUserAsync(CancellationToken cancellationToken)
    {
        var user = await CreateUserUtilAsync(cancellationToken);

        return user;
    }

    private async Task<Follow> CreateFollowUtilAsync(
        User follower,
        User following,
        CancellationToken cancellationToken)
    {
        var id = SharedTestUtilities.GetGuid();
        var utcNow = SharedTestUtilities.GetMaxDate();
        var follow = new Follow(
            id,
            follower,
            following,
            utcNow,
            utcNow);

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var followWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IFollowWriteRepository>();

        followWriteRepository.Add(follow);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return follow;
    }

    protected async Task<Follow> CreateFollowAsync(CancellationToken cancellationToken)
    {
        var follower = await CreateUserAsync(cancellationToken);
        var following = await CreateUserAsync(cancellationToken);
        var follow = await CreateFollowUtilAsync(follower, following, cancellationToken);

        return follow;
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

        if (await dbContext.Follows.AnyAsync(CancellationToken))
        {
            await dbContext.Follows.ExecuteDeleteAsync(CancellationToken);
        }

        if (await dbContext.Users.AnyAsync(CancellationToken))
        {
            await dbContext.Users.ExecuteDeleteAsync(CancellationToken);
        }
    }
}
