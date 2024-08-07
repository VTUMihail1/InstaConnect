using InstaConnect.Follows.Business.Features.Follows.Utilities;
using InstaConnect.Follows.Business.IntegrationTests.Utilities;
using InstaConnect.Follows.Data;
using InstaConnect.Follows.Data.Features.Users.Abstractions;
using InstaConnect.Follows.Data.Features.Users.Models.Entities;
using InstaConnect.Shared.Business.IntegrationTests.Utilities;
using InstaConnect.Shared.Data.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Follows.Business.IntegrationTests.Features.Users.Utilities;

public abstract class BaseUserIntegrationTest : BaseSharedIntegrationTest, IClassFixture<IntegrationTestWebAppFactory>, IAsyncLifetime
{
    protected readonly string InvalidUserId;
    protected readonly string ValidUserName;
    protected readonly string ValidAddUserName;
    protected readonly string ValidUpdateUserName;
    protected readonly string ValidUserFirstName;
    protected readonly string ValidUserEmail;
    protected readonly string ValidUserLastName;
    protected readonly string ValidUserProfileImage;

    protected IUserReadRepository UserReadRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var userReadRepository = serviceScope.ServiceProvider.GetRequiredService<IUserReadRepository>();

            return userReadRepository;
        }
    }

    protected IUserWriteRepository UserWriteRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var userWriteRepository = serviceScope.ServiceProvider.GetRequiredService<IUserWriteRepository>();

            return userWriteRepository;
        }
    }

    protected BaseUserIntegrationTest(IntegrationTestWebAppFactory integrationTestWebAppFactory)
        : base(integrationTestWebAppFactory.Services.CreateScope())
    {
        InvalidUserId = GetAverageString(FollowBusinessConfigurations.FOLLOWING_ID_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_ID_MIN_LENGTH);
        ValidUserName = GetAverageString(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH);
        ValidAddUserName = GetAverageString(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH);
        ValidUpdateUserName = GetAverageString(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH);
        ValidUserFirstName = GetAverageString(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH);
        ValidUserLastName = GetAverageString(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH);
        ValidUserEmail = GetAverageString(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH);
        ValidUserProfileImage = GetAverageString(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH);
    }

    protected async Task<string> CreateUserAsync(CancellationToken cancellationToken)
    {
        var user = new User(
            ValidUserFirstName,
            ValidUserLastName,
            ValidUserEmail,
            ValidUserName,
            ValidUserProfileImage);

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

        if (dbContext.Users.Any())
        {
            await dbContext.Users.ExecuteDeleteAsync(CancellationToken);
        }
    }
}
