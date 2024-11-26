using InstaConnect.Identity.Application.IntegrationTests.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entitites;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Entitites;
using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Entitites;
using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Identity.Domain.Features.Users.Models.Entitites;
using InstaConnect.Identity.Infrastructure;
using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Models.Options;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Models.Options;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.IntegrationTests.Utilities;
using InstaConnect.Shared.Common.Utilities;
using MassTransit.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Application.IntegrationTests.Features.Users.Utilities;

public abstract class BaseUserIntegrationTest : BaseSharedIntegrationTest, IClassFixture<IntegrationTestWebAppFactory>, IAsyncLifetime
{
    protected ITestHarness TestHarness
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var testHarness = serviceScope.ServiceProvider.GetTestHarness();

            return testHarness;
        }
    }

    protected IEmailConfirmationTokenWriteRepository EmailConfirmationTokenWriteRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var emailConfirmationTokenWriteRepository = serviceScope.ServiceProvider.GetRequiredService<IEmailConfirmationTokenWriteRepository>();

            return emailConfirmationTokenWriteRepository;
        }
    }

    protected IForgotPasswordTokenWriteRepository ForgotPasswordTokenWriteRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var forgotPasswordTokenWriteRepository = serviceScope.ServiceProvider.GetRequiredService<IForgotPasswordTokenWriteRepository>();

            return forgotPasswordTokenWriteRepository;
        }
    }

    protected IUserClaimWriteRepository UserClaimWriteRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var userClaimWriteRepository = serviceScope.ServiceProvider.GetRequiredService<IUserClaimWriteRepository>();

            return userClaimWriteRepository;
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

    protected IUserReadRepository UserReadRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var userReadRepository = serviceScope.ServiceProvider.GetRequiredService<IUserReadRepository>();

            return userReadRepository;
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

    protected IPasswordHasher PasswordHasher { get; }

    protected EmailConfirmationOptions EmailConfirmationOptions { get; }

    protected ForgotPasswordOptions ForgotPasswordOptions { get; }


    protected BaseUserIntegrationTest(IntegrationTestWebAppFactory integrationTestWebAppFactory)
        : base(integrationTestWebAppFactory.Services.CreateScope())
    {
        PasswordHasher = ServiceScope.ServiceProvider.GetRequiredService<IPasswordHasher>();
        EmailConfirmationOptions = ServiceScope.ServiceProvider.GetRequiredService<IOptions<EmailConfirmationOptions>>().Value;
        ForgotPasswordOptions = ServiceScope.ServiceProvider.GetRequiredService<IOptions<ForgotPasswordOptions>>().Value;
    }

    protected async Task<string> CreateUserAsync(bool isEmailConfirmed, CancellationToken cancellationToken)
    {
        var passwordHasher = ServiceScope.ServiceProvider.GetRequiredService<IPasswordHasher>();
        var passwordHash = passwordHasher.Hash(UserTestUtilities.ValidPassword).PasswordHash;

        var user = new User(
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidName,
            passwordHash,
            UserTestUtilities.ValidProfileImage)
        {
            IsEmailConfirmed = isEmailConfirmed,
        };

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var userWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IUserWriteRepository>();

        userWriteRepository.Add(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }

    protected async Task<string> CreateUserAsync(string email, string name, bool isEmailConfirmed, CancellationToken cancellationToken)
    {
        var passwordHasher = ServiceScope.ServiceProvider.GetRequiredService<IPasswordHasher>();
        var passwordHash = passwordHasher.Hash(UserTestUtilities.ValidPassword).PasswordHash;

        var user = new User(
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            email,
            name,
            passwordHash,
            UserTestUtilities.ValidProfileImage)
        {
            IsEmailConfirmed = isEmailConfirmed,
        };

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var userWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IUserWriteRepository>();

        userWriteRepository.Add(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }

    protected async Task<string> CreateUserAsync(CancellationToken cancellationToken)
    {
        var passwordHasher = ServiceScope.ServiceProvider.GetRequiredService<IPasswordHasher>();
        var passwordHash = passwordHasher.Hash(UserTestUtilities.ValidPassword).PasswordHash;

        var user = new User(
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidName,
            passwordHash,
            UserTestUtilities.ValidProfileImage)
        {
            IsEmailConfirmed = true,
        };

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var userWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IUserWriteRepository>();

        userWriteRepository.Add(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }

    protected async Task<string> CreateEmailConfirmationTokenAsync(string userId, DateTime validUntil, CancellationToken cancellationToken)
    {
        var emailConfirmationToken = new EmailConfirmationToken(
            UserTestUtilities.ValidEmailConfirmationTokenValue,
            validUntil,
            userId);

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var emailConfirmationTokenWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IEmailConfirmationTokenWriteRepository>();

        emailConfirmationTokenWriteRepository.Add(emailConfirmationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return emailConfirmationToken.Value;
    }

    protected async Task<string> CreateForgotPasswordTokenAsync(string userId, DateTime validUntil, CancellationToken cancellationToken)
    {
        var forgotPasswordToken = new ForgotPasswordToken(
            UserTestUtilities.ValidEmailConfirmationTokenValue,
            validUntil,
            userId);

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var forgotPasswordTokenWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IForgotPasswordTokenWriteRepository>();

        forgotPasswordTokenWriteRepository.Add(forgotPasswordToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return forgotPasswordToken.Value;
    }

    protected async Task<string> CreateUserClaimAsync(string userId, CancellationToken cancellationToken)
    {
        var userClaim = new UserClaim(
            AppClaims.Admin,
            AppClaims.Admin,
            userId);

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var userClaimWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IUserClaimWriteRepository>();

        userClaimWriteRepository.Add(userClaim);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return userClaim.Value;
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
    }
}
