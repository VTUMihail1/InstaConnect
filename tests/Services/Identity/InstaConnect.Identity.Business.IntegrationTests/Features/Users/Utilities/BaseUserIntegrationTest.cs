using InstaConnect.Identity.Business.Features.Users.Utilities;
using InstaConnect.Identity.Business.IntegrationTests.Utilities;
using InstaConnect.Identity.Data;
using InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Models.Entitites;
using InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Models.Entitites;
using InstaConnect.Identity.Data.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Data.Features.UserClaims.Models.Entitites;
using InstaConnect.Identity.Data.Features.Users.Abstractions;
using InstaConnect.Identity.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Business.IntegrationTests.Utilities;
using InstaConnect.Shared.Data.Abstractions;
using InstaConnect.Shared.Data.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace InstaConnect.Identity.Business.IntegrationTests.Features.Users.Utilities;

public abstract class BaseUserIntegrationTest : BaseSharedIntegrationTest, IClassFixture<IntegrationTestWebAppFactory>, IAsyncLifetime
{
    protected readonly string InvalidId;
    protected readonly string ValidEmail;
    protected readonly string ValidAddEmail;
    protected readonly string ValidName;
    protected readonly string ValidAddName;
    protected readonly string ValidUpdateName;
    protected readonly string ValidFirstName;
    protected readonly string ValidAddFirstName;
    protected readonly string ValidUpdateFirstName;
    protected readonly string ValidLastName;
    protected readonly string ValidAddLastName;
    protected readonly string ValidUpdateLastName;
    protected readonly string ValidProfileImage;
    protected readonly string ValidAddProfileImage;
    protected readonly string ValidUpdateProfileImage;
    protected readonly string ValidPassword;
    protected readonly string InvalidPassword;
    protected readonly string ValidEmailConfirmationTokenValue;
    protected readonly string InvalidEmailConfirmationTokenValue;
    protected readonly string ValidForgotPasswordTokenValue;
    protected readonly string InvalidForgotPasswordTokenValue;
    protected readonly IFormFile ValidAddFormFile;
    protected readonly IFormFile ValidUpdateFormFile;
    protected readonly DateTime ValidUntil;

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

    protected BaseUserIntegrationTest(IntegrationTestWebAppFactory integrationTestWebAppFactory)
        : base(integrationTestWebAppFactory.Services.CreateScope())
    {
        InvalidId = GetAverageString(UserBusinessConfigurations.ID_MAX_LENGTH, UserBusinessConfigurations.ID_MIN_LENGTH);
        ValidEmail = GetAverageString(UserBusinessConfigurations.EMAIL_MAX_LENGTH, UserBusinessConfigurations.EMAIL_MIN_LENGTH);
        ValidAddEmail = GetAverageString(UserBusinessConfigurations.EMAIL_MAX_LENGTH, UserBusinessConfigurations.EMAIL_MIN_LENGTH);
        InvalidPassword = GetAverageString(UserBusinessConfigurations.PASSWORD_MAX_LENGTH, UserBusinessConfigurations.PASSWORD_MIN_LENGTH);
        ValidPassword = GetAverageString(UserBusinessConfigurations.PASSWORD_MAX_LENGTH, UserBusinessConfigurations.PASSWORD_MIN_LENGTH);
        ValidName = GetAverageString(UserBusinessConfigurations.USER_NAME_MAX_LENGTH, UserBusinessConfigurations.USER_NAME_MIN_LENGTH);
        ValidAddName = GetAverageString(UserBusinessConfigurations.USER_NAME_MAX_LENGTH, UserBusinessConfigurations.USER_NAME_MIN_LENGTH);
        ValidUpdateName = GetAverageString(UserBusinessConfigurations.USER_NAME_MAX_LENGTH, UserBusinessConfigurations.USER_NAME_MIN_LENGTH);
        ValidName = GetAverageString(UserBusinessConfigurations.USER_NAME_MAX_LENGTH, UserBusinessConfigurations.USER_NAME_MIN_LENGTH);
        ValidFirstName = GetAverageString(UserBusinessConfigurations.FIRST_NAME_MAX_LENGTH, UserBusinessConfigurations.FIRST_NAME_MIN_LENGTH);
        ValidAddFirstName = GetAverageString(UserBusinessConfigurations.FIRST_NAME_MAX_LENGTH, UserBusinessConfigurations.FIRST_NAME_MIN_LENGTH);
        ValidUpdateFirstName = GetAverageString(UserBusinessConfigurations.FIRST_NAME_MAX_LENGTH, UserBusinessConfigurations.FIRST_NAME_MIN_LENGTH);
        ValidLastName = GetAverageString(UserBusinessConfigurations.LAST_NAME_MAX_LENGTH, UserBusinessConfigurations.LAST_NAME_MIN_LENGTH);
        ValidAddLastName = GetAverageString(UserBusinessConfigurations.LAST_NAME_MAX_LENGTH, UserBusinessConfigurations.LAST_NAME_MIN_LENGTH);
        ValidUpdateLastName = GetAverageString(UserBusinessConfigurations.LAST_NAME_MAX_LENGTH, UserBusinessConfigurations.LAST_NAME_MIN_LENGTH);
        ValidEmailConfirmationTokenValue = Faker.Random.Guid().ToString();
        InvalidEmailConfirmationTokenValue = Faker.Random.Guid().ToString();
        ValidForgotPasswordTokenValue = Faker.Random.Guid().ToString();
        InvalidForgotPasswordTokenValue = Faker.Random.Guid().ToString();
        ValidProfileImage = Faker.Internet.Url();
        ValidAddProfileImage = Faker.Internet.Url();
        ValidUpdateProfileImage = Faker.Internet.Url();
        ValidAddFormFile = Substitute.For<IFormFile>();
        ValidUpdateFormFile = Substitute.For<IFormFile>();
        ValidUntil = DateTime.MaxValue;
    }

    protected async Task<string> CreateUserAsync(bool isEmailConfirmed, CancellationToken cancellationToken)
    {
        var passwordHasher = ServiceScope.ServiceProvider.GetRequiredService<IPasswordHasher>();
        var passwordHash = passwordHasher.Hash(ValidPassword).PasswordHash;

        var user = new User(
            ValidFirstName,
            ValidLastName,
            ValidEmail,
            ValidName,
            passwordHash,
            ValidProfileImage)
        {
            IsEmailConfirmed = isEmailConfirmed,
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
            ValidEmailConfirmationTokenValue,
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
            ValidEmailConfirmationTokenValue,
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
        await EnsureDatabaseIsEmpty();
    }

    public async Task DisposeAsync()
    {
        await EnsureDatabaseIsEmpty();
    }

    private async Task EnsureDatabaseIsEmpty()
    {
        var dbContext = ServiceScope.ServiceProvider.GetRequiredService<IdentityContext>();

        if (dbContext.EmailConfirmationTokens.Any())
        {
            await dbContext.EmailConfirmationTokens.ExecuteDeleteAsync(CancellationToken);
        }

        if (dbContext.ForgotPasswordTokens.Any())
        {
            await dbContext.ForgotPasswordTokens.ExecuteDeleteAsync(CancellationToken);
        }

        if (dbContext.UserClaims.Any())
        {
            await dbContext.UserClaims.ExecuteDeleteAsync(CancellationToken);
        }

        if (dbContext.Users.Any())
        {
            await dbContext.Users.ExecuteDeleteAsync(CancellationToken);
        }
    }
}
