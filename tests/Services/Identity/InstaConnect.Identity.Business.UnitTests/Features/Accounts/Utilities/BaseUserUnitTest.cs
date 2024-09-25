using AutoMapper;
using InstaConnect.Identity.Business.Features.Accounts.Abstractions;
using InstaConnect.Identity.Business.Features.Accounts.Mappings;
using InstaConnect.Identity.Business.Features.Users.Utilities;
using InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Models.Entitites;
using InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Data.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Data.Features.Users.Abstractions;
using InstaConnect.Identity.Data.Features.Users.Models;
using InstaConnect.Identity.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Business.Models;
using InstaConnect.Shared.Business.UnitTests.Utilities;
using InstaConnect.Shared.Data.Abstractions;
using Microsoft.AspNetCore.Http;
using NSubstitute;

namespace InstaConnect.Identity.Business.UnitTests.Features.Accounts.Utilities;

public abstract class BaseAccountUnitTest : BaseSharedUnitTest
{
    protected readonly string ValidId;
    protected readonly string ValidIdWithUnconfirmedEmail;
    protected readonly string InvalidId;
    protected readonly string ValidName;
    protected readonly string ValidNameWithUnconfirmedEmail;
    protected readonly string InvalidName;
    protected readonly string ValidFirstName;
    protected readonly string ValidEmail;
    protected readonly string ValidEmailWithUnconfirmedEmail;
    protected readonly string InvalidEmail;
    protected readonly string ValidLastName;
    protected readonly string ValidProfileImage;
    protected readonly string ValidEmailConfirmationTokenValue;
    protected readonly string ValidEmailConfirmationTokenValueWithConfirmedUser;
    protected readonly string ValidForgotPasswordTokenValue;
    protected readonly string ValidPassword;
    protected readonly string InvalidPassword;
    protected readonly string ValidPasswordHash;
    protected readonly IFormFile ValidFormFile;
    protected readonly DateTime ValidUntil;
    protected readonly DateTime ValidCreatedAt;
    protected readonly DateTime ValidUpdatedAt;

    protected IImageHandler ImageHandler { get; }

    protected IEventPublisher EventPublisher { get; }

    protected IUserWriteRepository UserWriteRepository { get; }

    protected IEmailConfirmationTokenWriteRepository EmailConfirmationTokenWriteRepository { get; }

    protected IForgotPasswordTokenWriteRepository ForgotPasswordTokenWriteRepository { get; }

    protected IEmailConfirmationTokenPublisher EmailConfirmationTokenPublisher { get; }

    protected IForgotPasswordTokenPublisher ForgotPasswordTokenPublisher { get; }

    protected IUserClaimWriteRepository UserClaimWriteRepository { get; }

    protected IAccessTokenGenerator AccessTokenGenerator { get; }

    protected IPasswordHasher PasswordHasher { get; }

    public BaseAccountUnitTest() : base(
        Substitute.For<IUnitOfWork>(),
        new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg => cfg.AddProfile<AccountCommandProfile>()))),
        new EntityPropertyValidator())
    {
        ValidId = GetAverageString(UserBusinessConfigurations.ID_MAX_LENGTH, UserBusinessConfigurations.ID_MIN_LENGTH);
        ValidIdWithUnconfirmedEmail = GetAverageString(UserBusinessConfigurations.ID_MAX_LENGTH, UserBusinessConfigurations.ID_MIN_LENGTH);
        InvalidId = GetAverageString(UserBusinessConfigurations.ID_MAX_LENGTH, UserBusinessConfigurations.ID_MIN_LENGTH);
        ValidEmail = GetAverageString(UserBusinessConfigurations.EMAIL_MAX_LENGTH, UserBusinessConfigurations.EMAIL_MIN_LENGTH);
        ValidEmailWithUnconfirmedEmail = GetAverageString(UserBusinessConfigurations.EMAIL_MAX_LENGTH, UserBusinessConfigurations.EMAIL_MIN_LENGTH);
        InvalidEmail = GetAverageString(UserBusinessConfigurations.EMAIL_MAX_LENGTH, UserBusinessConfigurations.EMAIL_MIN_LENGTH);
        ValidName = GetAverageString(UserBusinessConfigurations.USER_NAME_MAX_LENGTH, UserBusinessConfigurations.USER_NAME_MIN_LENGTH);
        ValidNameWithUnconfirmedEmail = GetAverageString(UserBusinessConfigurations.USER_NAME_MAX_LENGTH, UserBusinessConfigurations.USER_NAME_MIN_LENGTH);
        InvalidName = GetAverageString(UserBusinessConfigurations.USER_NAME_MAX_LENGTH, UserBusinessConfigurations.USER_NAME_MIN_LENGTH);
        ValidProfileImage = Faker.Internet.Url();
        ValidFirstName = GetAverageString(UserBusinessConfigurations.FIRST_NAME_MAX_LENGTH, UserBusinessConfigurations.FIRST_NAME_MIN_LENGTH);
        ValidLastName = GetAverageString(UserBusinessConfigurations.LAST_NAME_MAX_LENGTH, UserBusinessConfigurations.LAST_NAME_MIN_LENGTH);
        ValidPassword = Faker.Internet.Password();
        InvalidPassword = Faker.Internet.Password();
        ValidPasswordHash = Faker.Internet.Password();
        ValidEmailConfirmationTokenValue = Faker.Random.Guid().ToString();
        ValidEmailConfirmationTokenValueWithConfirmedUser = Faker.Random.Guid().ToString();
        ValidForgotPasswordTokenValue = Faker.Random.Guid().ToString();
        ValidFormFile = Substitute.For<IFormFile>();

        ImageHandler = Substitute.For<IImageHandler>();
        EventPublisher = Substitute.For<IEventPublisher>();
        UserWriteRepository = Substitute.For<IUserWriteRepository>();
        EmailConfirmationTokenWriteRepository = Substitute.For<IEmailConfirmationTokenWriteRepository>();
        ForgotPasswordTokenWriteRepository = Substitute.For<IForgotPasswordTokenWriteRepository>();
        EmailConfirmationTokenPublisher = Substitute.For<IEmailConfirmationTokenPublisher>();
        ForgotPasswordTokenPublisher = Substitute.For<IForgotPasswordTokenPublisher>();
        PasswordHasher = Substitute.For<IPasswordHasher>();
        AccessTokenGenerator = Substitute.For<IAccessTokenGenerator>();
        UserClaimWriteRepository = Substitute.For<IUserClaimWriteRepository>();

        var existingUser = new User(
            ValidFirstName,
            ValidLastName,
            ValidEmail,
            ValidName,
            ValidPasswordHash,
            ValidProfileImage)
        {
            Id = ValidId,
            IsEmailConfirmed = true
        };

        var existingUnconfirmedEmailUser = new User(
            ValidFirstName,
            ValidLastName,
            ValidEmailWithUnconfirmedEmail,
            ValidNameWithUnconfirmedEmail,
            ValidPasswordHash,
            ValidProfileImage)
        {
            Id = ValidIdWithUnconfirmedEmail,
            IsEmailConfirmed = false
        };

        var existingEmailConfirmationToken = new EmailConfirmationToken(
            ValidEmailConfirmationTokenValue,
            ValidUntil,
            ValidIdWithUnconfirmedEmail);

        var existingEmailConfirmationTokenWithConfirmedUser = new EmailConfirmationToken(
            ValidEmailConfirmationTokenValueWithConfirmedUser,
            ValidUntil,
            ValidId);

        var existingPasswordHashResultModel = new PasswordHashResultModel(ValidPasswordHash);

        var existingImageResult = new ImageResult(ValidProfileImage);

        UserWriteRepository.GetByIdAsync(ValidId, CancellationToken)
            .Returns(existingUser);

        UserWriteRepository.GetByNameAsync(ValidName, CancellationToken)
            .Returns(existingUser);

        UserWriteRepository.GetByEmailAsync(ValidEmail, CancellationToken)
            .Returns(existingUser);

        UserWriteRepository.GetByIdAsync(ValidIdWithUnconfirmedEmail, CancellationToken)
            .Returns(existingUnconfirmedEmailUser);

        UserWriteRepository.GetByNameAsync(ValidNameWithUnconfirmedEmail, CancellationToken)
            .Returns(existingUnconfirmedEmailUser);

        UserWriteRepository.GetByEmailAsync(ValidEmailWithUnconfirmedEmail, CancellationToken)
            .Returns(existingUnconfirmedEmailUser);

        EmailConfirmationTokenWriteRepository.GetByValueAsync(ValidEmailConfirmationTokenValue, CancellationToken)
            .Returns(existingEmailConfirmationToken);

        EmailConfirmationTokenWriteRepository.GetByValueAsync(ValidEmailConfirmationTokenValueWithConfirmedUser, CancellationToken)
            .Returns(existingEmailConfirmationTokenWithConfirmedUser);

        PasswordHasher.Hash(ValidPassword)
            .Returns(existingPasswordHashResultModel);

        PasswordHasher.Verify(ValidPassword, ValidPasswordHash)
            .Returns(true);

        ImageHandler.UploadAsync(Arg.Is<ImageUploadModel>(i => i.FormFile == ValidFormFile), CancellationToken)
            .Returns(existingImageResult);
    }
}
