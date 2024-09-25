using AutoMapper;
using InstaConnect.Identity.Business.Features.Accounts.Abstractions;
using InstaConnect.Identity.Business.Features.Accounts.Mappings;
using InstaConnect.Identity.Business.Features.Accounts.Models;
using InstaConnect.Identity.Business.Features.Users.Mappings;
using InstaConnect.Identity.Business.Features.Users.Utilities;
using InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Models.Entitites;
using InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Models.Entitites;
using InstaConnect.Identity.Data.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Data.Features.UserClaims.Models.Entitites;
using InstaConnect.Identity.Data.Features.UserClaims.Models.Filters;
using InstaConnect.Identity.Data.Features.Users.Abstractions;
using InstaConnect.Identity.Data.Features.Users.Models;
using InstaConnect.Identity.Data.Features.Users.Models.Entitites;
using InstaConnect.Identity.Data.Features.Users.Models.Filters;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Business.Models;
using InstaConnect.Shared.Business.UnitTests.Utilities;
using InstaConnect.Shared.Data.Abstractions;
using InstaConnect.Shared.Data.Models.Pagination;
using InstaConnect.Shared.Data.Utilities;
using Microsoft.AspNetCore.Http;
using NSubstitute;

namespace InstaConnect.Identity.Business.UnitTests.Features.Accounts.Utilities;

public abstract class BaseAccountUnitTest : BaseSharedUnitTest
{
    protected readonly string ValidId;
    protected readonly string ValidTakenId;
    protected readonly string ValidIdWithUnconfirmedEmail;
    protected readonly string InvalidId;
    protected readonly string ValidName;
    protected readonly string ValidTakenName;
    protected readonly string ValidNameWithUnconfirmedEmail;
    protected readonly string InvalidName;
    protected readonly string ValidFirstName;
    protected readonly string ValidEmail;
    protected readonly string ValidTakenEmail;
    protected readonly string ValidEmailWithUnconfirmedEmail;
    protected readonly string InvalidEmail;
    protected readonly string ValidLastName;
    protected readonly string ValidProfileImage;
    protected readonly string ValidEmailConfirmationTokenValue;
    protected readonly string ValidEmailConfirmationTokenValueWithConfirmedUser;
    protected readonly string ValidEmailConfirmationTokenValueWithTokenUser;
    protected readonly string InvalidEmailConfirmationTokenValue;
    protected readonly string ValidForgotPasswordTokenValue;
    protected readonly string ValidForgotPasswordTokenValueWithTokenUser;
    protected readonly string InvalidForgotPasswordTokenValue;
    protected readonly string ValidAccessTokenValue;
    protected readonly string ValidPassword;
    protected readonly string InvalidPassword;
    protected readonly string ValidPasswordHash;
    protected readonly IFormFile ValidFormFile;
    protected readonly DateTime ValidUntil;

    protected IImageHandler ImageHandler { get; }

    protected IEventPublisher EventPublisher { get; }

    protected IUserReadRepository UserReadRepository { get; }

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
                new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<AccountCommandProfile>();
                    cfg.AddProfile<UserQueryProfile>();
                }))),
        new EntityPropertyValidator())
    {
        ValidId = GetAverageString(UserBusinessConfigurations.ID_MAX_LENGTH, UserBusinessConfigurations.ID_MIN_LENGTH);
        ValidTakenId = GetAverageString(UserBusinessConfigurations.ID_MAX_LENGTH, UserBusinessConfigurations.ID_MIN_LENGTH);
        ValidIdWithUnconfirmedEmail = GetAverageString(UserBusinessConfigurations.ID_MAX_LENGTH, UserBusinessConfigurations.ID_MIN_LENGTH);
        InvalidId = GetAverageString(UserBusinessConfigurations.ID_MAX_LENGTH, UserBusinessConfigurations.ID_MIN_LENGTH);
        ValidEmail = GetAverageString(UserBusinessConfigurations.EMAIL_MAX_LENGTH, UserBusinessConfigurations.EMAIL_MIN_LENGTH);
        ValidTakenEmail = GetAverageString(UserBusinessConfigurations.EMAIL_MAX_LENGTH, UserBusinessConfigurations.EMAIL_MIN_LENGTH);
        ValidEmailWithUnconfirmedEmail = GetAverageString(UserBusinessConfigurations.EMAIL_MAX_LENGTH, UserBusinessConfigurations.EMAIL_MIN_LENGTH);
        InvalidEmail = GetAverageString(UserBusinessConfigurations.EMAIL_MAX_LENGTH, UserBusinessConfigurations.EMAIL_MIN_LENGTH);
        ValidName = GetAverageString(UserBusinessConfigurations.USER_NAME_MAX_LENGTH, UserBusinessConfigurations.USER_NAME_MIN_LENGTH);
        ValidTakenName = GetAverageString(UserBusinessConfigurations.USER_NAME_MAX_LENGTH, UserBusinessConfigurations.USER_NAME_MIN_LENGTH);
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
        ValidEmailConfirmationTokenValueWithTokenUser = Faker.Random.Guid().ToString();
        InvalidEmailConfirmationTokenValue = Faker.Random.Guid().ToString();
        ValidForgotPasswordTokenValue = Faker.Random.Guid().ToString();
        ValidForgotPasswordTokenValueWithTokenUser = Faker.Random.Guid().ToString();
        InvalidForgotPasswordTokenValue = Faker.Random.Guid().ToString();
        ValidFormFile = Substitute.For<IFormFile>();
        ValidUntil = Faker.Date.Recent();
        ValidAccessTokenValue = Faker.Random.Guid().ToString();

        ImageHandler = Substitute.For<IImageHandler>();
        EventPublisher = Substitute.For<IEventPublisher>();
        UserReadRepository = Substitute.For<IUserReadRepository>();
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

        var existingTakenUser = new User(
            ValidFirstName,
            ValidLastName,
            ValidTakenEmail,
            ValidTakenName,
            ValidPasswordHash,
            ValidProfileImage)
        {
            Id = ValidTakenId,
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

        var existingEmailConfirmationTokenWithTokenUser = new EmailConfirmationToken(
            ValidEmailConfirmationTokenValueWithTokenUser,
            ValidUntil,
            ValidTakenId);

        var existingForgotPasswordToken = new ForgotPasswordToken(
            ValidForgotPasswordTokenValue,
            ValidUntil,
            ValidId);

        var existingForgotPasswordTokenWithTokenUser = new ForgotPasswordToken(
            ValidForgotPasswordTokenValueWithTokenUser,
            ValidUntil,
            ValidTakenId);

        var existingPasswordHashResultModel = new PasswordHashResultModel(ValidPasswordHash);

        var existingImageResult = new ImageResult(ValidProfileImage);

        var existingAccessTokenResult = new AccessTokenResult(ValidAccessTokenValue, ValidUntil);

        var existingUserClaim = new UserClaim(AppClaims.Admin, AppClaims.Admin, ValidId);

        var existingUserPaginationList = new PaginationList<User>(
            [existingUser],
            ValidPageValue,
            ValidPageSizeValue,
            ValidTotalCountValue);

        UserWriteRepository.GetByIdAsync(ValidId, CancellationToken)
            .Returns(existingUser);

        UserWriteRepository.GetByNameAsync(ValidName, CancellationToken)
            .Returns(existingUser);

        UserReadRepository.GetByIdAsync(ValidId, CancellationToken)
            .Returns(existingUser);

        UserReadRepository.GetByNameAsync(ValidName, CancellationToken)
            .Returns(existingUser);

        UserWriteRepository.GetByEmailAsync(ValidEmail, CancellationToken)
            .Returns(existingUser);

        UserWriteRepository.GetByIdAsync(ValidTakenId, CancellationToken)
            .Returns(existingTakenUser);

        UserWriteRepository.GetByNameAsync(ValidTakenName, CancellationToken)
            .Returns(existingTakenUser);

        UserWriteRepository.GetByEmailAsync(ValidTakenEmail, CancellationToken)
            .Returns(existingTakenUser);

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

        EmailConfirmationTokenWriteRepository.GetByValueAsync(ValidEmailConfirmationTokenValueWithTokenUser, CancellationToken)
            .Returns(existingEmailConfirmationTokenWithTokenUser);

        ForgotPasswordTokenWriteRepository.GetByValueAsync(ValidForgotPasswordTokenValue, CancellationToken)
            .Returns(existingForgotPasswordToken);

        ForgotPasswordTokenWriteRepository.GetByValueAsync(ValidForgotPasswordTokenValueWithTokenUser, CancellationToken)
            .Returns(existingForgotPasswordTokenWithTokenUser);

        PasswordHasher.Hash(ValidPassword)
            .Returns(existingPasswordHashResultModel);

        PasswordHasher.Verify(ValidPassword, ValidPasswordHash)
            .Returns(true);

        ImageHandler.UploadAsync(Arg.Is<ImageUploadModel>(i => i.FormFile == ValidFormFile), CancellationToken)
            .Returns(existingImageResult);

        UserClaimWriteRepository.GetAllAsync(Arg.Is<UserClaimCollectionWriteQuery>(uc => uc.UserId == ValidId), CancellationToken)
            .Returns([existingUserClaim]);

        AccessTokenGenerator.GenerateAccessToken(Arg.Is<CreateAccessTokenModel>(at => at.UserId == ValidId &&
                                                                                      at.Email == ValidEmail &&
                                                                                      at.FirstName == ValidFirstName &&
                                                                                      at.LastName == ValidLastName &&
                                                                                      at.UserName == ValidName &&
                                                                                      at.UserClaims.All(uc => uc.UserId == ValidId &&
                                                                                                              uc.Claim == AppClaims.Admin &&
                                                                                                              uc.Value == AppClaims.Admin)))
            .Returns(existingAccessTokenResult);

        UserReadRepository
            .GetAllAsync(Arg.Is<UserCollectionReadQuery>(m =>
                                                                        m.FirstName == ValidFirstName &&
                                                                        m.LastName == ValidLastName &&
                                                                        m.UserName == ValidName &&
                                                                        m.Page == ValidPageValue &&
                                                                        m.PageSize == ValidPageSizeValue &&
                                                                        m.SortOrder == ValidSortOrderProperty &&
                                                                        m.SortPropertyName == ValidSortPropertyName), CancellationToken)
            .Returns(existingUserPaginationList);
    }
}
