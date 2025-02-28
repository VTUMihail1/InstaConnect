using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Identity.Application.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Entities;
using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Identity.Infrastructure;
using InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Abstractions;
using InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Helpers;

using MassTransit.Testing;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Utilities;

public abstract class BaseUserFunctionalTest : IClassFixture<IdentityWebApplicationFactory>, IAsyncLifetime
{
    protected CancellationToken CancellationToken { get; }

    protected IServiceScope ServiceScope { get; }

    protected IUsersClient UsersClient { get; }

    protected ITestHarness TestHarness
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var testHarness = serviceScope.ServiceProvider.GetTestHarness();

            return testHarness;
        }
    }

    protected ICacheHandler CacheHandler
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var cacheHandlerRepository = serviceScope.ServiceProvider.GetRequiredService<ICacheHandler>();

            return cacheHandlerRepository;
        }
    }

    protected IUserWriteRepository UserWriteRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var userRepository = serviceScope.ServiceProvider.GetRequiredService<IUserWriteRepository>();

            return userRepository;
        }
    }

    protected IUserReadRepository UserReadRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var userReadRepository = serviceScope.ServiceProvider.GetRequiredService<IUserReadRepository>();

            return userReadRepository;
        }
    }

    protected IPasswordHasher PasswordHasher { get; }

    protected IJsonConverter JsonConverter { get; }

    protected BaseUserFunctionalTest(IdentityWebApplicationFactory functionalTestWebAppFactory)
    {
        ServiceScope = functionalTestWebAppFactory.Services.CreateScope();
        CancellationToken = new();
        UsersClient = new UsersClient(functionalTestWebAppFactory.CreateClient());
        PasswordHasher = ServiceScope.ServiceProvider.GetRequiredService<IPasswordHasher>();
        JsonConverter = ServiceScope.ServiceProvider.GetRequiredService<IJsonConverter>();
    }

    private async Task<UserClaim> CreateUserClaimUtilAsync(
        User user,
        CancellationToken cancellationToken)
    {
        var userClaim = new UserClaim(
            AppClaims.Admin,
            AppClaims.Admin,
            user);

        var userClaimWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IUserClaimWriteRepository>();
        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();

        userClaimWriteRepository.Add(userClaim);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return userClaim;
    }

    protected async Task<UserClaim> CreateUserClaimAsync(CancellationToken cancellationToken)
    {
        var user = await CreateUserAsync(cancellationToken);
        var userClaim = await CreateUserClaimUtilAsync(user, cancellationToken);

        return userClaim;
    }

    protected async Task<UserClaim> CreateUserClaimWithUnconfirmedUserEmailAsync(CancellationToken cancellationToken)
    {
        var user = await CreateUserWithUnconfirmedEmailAsync(cancellationToken);
        var userClaim = await CreateUserClaimUtilAsync(user, cancellationToken);

        return userClaim;
    }

    private async Task<User> CreateUserUtilAsync(bool isEmailConfirmed, CancellationToken cancellationToken)
    {
        var passwordHasher = ServiceScope.ServiceProvider.GetRequiredService<IPasswordHasher>();
        var passwordHash = passwordHasher.Hash(UserTestUtilities.ValidPassword).PasswordHash;

        var user = new User(
            SharedTestUtilities.GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength),
            passwordHash,
            UserTestUtilities.ValidProfileImage)
        {
            IsEmailConfirmed = isEmailConfirmed
        };

        var userWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IUserWriteRepository>();
        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();

        userWriteRepository.Add(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user;
    }

    protected async Task<User> CreateUserAsync(CancellationToken cancellationToken)
    {
        var user = await CreateUserUtilAsync(true, cancellationToken);

        return user;
    }

    protected async Task<User> CreateUserWithUnconfirmedEmailAsync(CancellationToken cancellationToken)
    {
        var user = await CreateUserUtilAsync(false, cancellationToken);

        return user;
    }

    public async Task InitializeAsync()
    {
        await EnsureDatabaseIsEmptyAsync();
    }

    public async Task DisposeAsync()
    {
        await EnsureDatabaseIsEmptyAsync();
    }

    private async Task EnsureDatabaseIsEmptyAsync()
    {
        var dbContext = ServiceScope.ServiceProvider.GetRequiredService<IdentityContext>();
        var distibutedCache = ServiceScope.ServiceProvider.GetRequiredService<IDistributedCache>();

        if (await dbContext.EmailConfirmationTokens.AnyAsync(CancellationToken))
        {
            await dbContext.EmailConfirmationTokens.ExecuteDeleteAsync(CancellationToken);
        }

        if (await dbContext.ForgotPasswordTokens.AnyAsync(CancellationToken))
        {
            await dbContext.ForgotPasswordTokens.ExecuteDeleteAsync(CancellationToken);
        }

        if (await dbContext.UserClaims.AnyAsync(CancellationToken))
        {
            await dbContext.UserClaims.ExecuteDeleteAsync(CancellationToken);
        }

        if (await dbContext.Users.AnyAsync(CancellationToken))
        {
            await dbContext.Users.ExecuteDeleteAsync(CancellationToken);
        }

        if (await distibutedCache.GetAsync(UserCacheKeys.GetCurrentUser, CancellationToken) != null)
        {
            await distibutedCache.RemoveAsync(UserCacheKeys.GetCurrentUser);
        }

        if (await distibutedCache.GetAsync(UserCacheKeys.GetCurrentDetailedUser, CancellationToken) != null)
        {
            await distibutedCache.RemoveAsync(UserCacheKeys.GetCurrentDetailedUser);
        }
    }
}
