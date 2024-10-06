using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Data;
using InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Models.Entitites;
using InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Models.Options;
using InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Models.Entitites;
using InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Models.Options;
using InstaConnect.Identity.Data.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Data.Features.UserClaims.Models.Entitites;
using InstaConnect.Identity.Data.Features.Users.Abstractions;
using InstaConnect.Identity.Data.Features.Users.Models.Entitites;
using InstaConnect.Identity.Web.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Utilities;
using InstaConnect.Shared.Data.Abstractions;
using InstaConnect.Shared.Web.FunctionalTests.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Web.FunctionalTests.Features.Users.Utilities;

public abstract class BaseUserFunctionalTest : BaseSharedFunctionalTest, IClassFixture<FunctionalTestWebAppFactory>, IAsyncLifetime
{
    private const string API_ROUTE = "api/v1/users";


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

    protected EmailConfirmationOptions EmailConfirmationOptions { get; }

    protected ForgotPasswordOptions ForgotPasswordOptions { get; }

    protected BaseUserFunctionalTest(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(
        functionalTestWebAppFactory.CreateClient(),
        functionalTestWebAppFactory.Services.CreateScope(),
        API_ROUTE)
    {
        PasswordHasher = ServiceScope.ServiceProvider.GetRequiredService<IPasswordHasher>();
        JsonConverter = ServiceScope.ServiceProvider.GetRequiredService<IJsonConverter>();
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
