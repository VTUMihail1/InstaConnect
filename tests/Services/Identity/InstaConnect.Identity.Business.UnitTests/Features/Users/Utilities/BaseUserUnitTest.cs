using AutoMapper;
using InstaConnect.Identity.Business.Features.Users.Abstractions;
using InstaConnect.Identity.Business.Features.Users.Mappings;
using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Identity.Common.Features.Users.Utilities;
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
using InstaConnect.Shared.Common.Utilities;
using InstaConnect.Shared.Data.Abstractions;
using InstaConnect.Shared.Data.Models.Pagination;
using NSubstitute;

namespace InstaConnect.Identity.Business.UnitTests.Features.Users.Utilities;

public abstract class BaseUserUnitTest : BaseSharedUnitTest
{
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

    public BaseUserUnitTest() : base(
        Substitute.For<IUnitOfWork>(),
        new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<UserCommandProfile>();
                    cfg.AddProfile<UserQueryProfile>();
                }))),
        new EntityPropertyValidator())
    {
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
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidPasswordHash,
            UserTestUtilities.ValidProfileImage)
        {
            Id = UserTestUtilities.ValidId,
            IsEmailConfirmed = true
        };

        var existingUnconfirmedEmailUser = new User(
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidEmailWithUnconfirmedEmail,
            UserTestUtilities.ValidNameWithUnconfirmedEmail,
            UserTestUtilities.ValidPasswordHash,
            UserTestUtilities.ValidProfileImage)
        {
            Id = UserTestUtilities.ValidIdWithUnconfirmedEmail,
            IsEmailConfirmed = false
        };

        var existingTakenUser = new User(
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidTakenEmail,
            UserTestUtilities.ValidTakenName,
            UserTestUtilities.ValidPasswordHash,
            UserTestUtilities.ValidProfileImage)
        {
            Id = UserTestUtilities.ValidTakenId,
            IsEmailConfirmed = false
        };

        var existingEmailConfirmationToken = new EmailConfirmationToken(
            UserTestUtilities.ValidEmailConfirmationTokenValue,
            UserTestUtilities.ValidUntil,
            UserTestUtilities.ValidIdWithUnconfirmedEmail);

        var existingEmailConfirmationTokenWithConfirmedUser = new EmailConfirmationToken(
            UserTestUtilities.ValidEmailConfirmationTokenValueWithConfirmedUser,
            UserTestUtilities.ValidUntil,
            UserTestUtilities.ValidId);

        var existingEmailConfirmationTokenWithTokenUser = new EmailConfirmationToken(
            UserTestUtilities.ValidEmailConfirmationTokenValueWithTokenUser,
            UserTestUtilities.ValidUntil,
            UserTestUtilities.ValidTakenId);

        var existingForgotPasswordToken = new ForgotPasswordToken(
            UserTestUtilities.ValidForgotPasswordTokenValue,
            UserTestUtilities.ValidUntil,
            UserTestUtilities.ValidId);

        var existingForgotPasswordTokenWithTokenUser = new ForgotPasswordToken(
            UserTestUtilities.ValidForgotPasswordTokenValueWithTokenUser,
            UserTestUtilities.ValidUntil,
            UserTestUtilities.ValidTakenId);

        var existingPasswordHashResultModel = new PasswordHashResultModel(UserTestUtilities.ValidPasswordHash);

        var existingImageResult = new ImageResult(UserTestUtilities.ValidProfileImage);

        var existingAccessTokenResult = new AccessTokenResult(UserTestUtilities.ValidAccessTokenValue, UserTestUtilities.ValidUntil);

        var existingUserClaim = new UserClaim(AppClaims.Admin, AppClaims.Admin, UserTestUtilities.ValidId);

        var existingUserPaginationList = new PaginationList<User>(
            [existingUser],
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue,
            UserTestUtilities.ValidTotalCountValue);

        UserWriteRepository.GetByIdAsync(UserTestUtilities.ValidId, CancellationToken)
            .Returns(existingUser);

        UserWriteRepository.GetByNameAsync(UserTestUtilities.ValidName, CancellationToken)
            .Returns(existingUser);

        UserReadRepository.GetByIdAsync(UserTestUtilities.ValidId, CancellationToken)
            .Returns(existingUser);

        UserReadRepository.GetByNameAsync(UserTestUtilities.ValidName, CancellationToken)
            .Returns(existingUser);

        UserWriteRepository.GetByEmailAsync(UserTestUtilities.ValidEmail, CancellationToken)
            .Returns(existingUser);

        UserWriteRepository.GetByIdAsync(UserTestUtilities.ValidTakenId, CancellationToken)
            .Returns(existingTakenUser);

        UserWriteRepository.GetByNameAsync(UserTestUtilities.ValidTakenName, CancellationToken)
            .Returns(existingTakenUser);

        UserWriteRepository.GetByEmailAsync(UserTestUtilities.ValidTakenEmail, CancellationToken)
            .Returns(existingTakenUser);

        UserWriteRepository.GetByIdAsync(UserTestUtilities.ValidIdWithUnconfirmedEmail, CancellationToken)
            .Returns(existingUnconfirmedEmailUser);

        UserWriteRepository.GetByNameAsync(UserTestUtilities.ValidNameWithUnconfirmedEmail, CancellationToken)
            .Returns(existingUnconfirmedEmailUser);

        UserWriteRepository.GetByEmailAsync(UserTestUtilities.ValidEmailWithUnconfirmedEmail, CancellationToken)
            .Returns(existingUnconfirmedEmailUser);

        EmailConfirmationTokenWriteRepository.GetByValueAsync(UserTestUtilities.ValidEmailConfirmationTokenValue, CancellationToken)
            .Returns(existingEmailConfirmationToken);

        EmailConfirmationTokenWriteRepository.GetByValueAsync(UserTestUtilities.ValidEmailConfirmationTokenValueWithConfirmedUser, CancellationToken)
            .Returns(existingEmailConfirmationTokenWithConfirmedUser);

        EmailConfirmationTokenWriteRepository.GetByValueAsync(UserTestUtilities.ValidEmailConfirmationTokenValueWithTokenUser, CancellationToken)
            .Returns(existingEmailConfirmationTokenWithTokenUser);

        ForgotPasswordTokenWriteRepository.GetByValueAsync(UserTestUtilities.ValidForgotPasswordTokenValue, CancellationToken)
            .Returns(existingForgotPasswordToken);

        ForgotPasswordTokenWriteRepository.GetByValueAsync(UserTestUtilities.ValidForgotPasswordTokenValueWithTokenUser, CancellationToken)
            .Returns(existingForgotPasswordTokenWithTokenUser);

        PasswordHasher.Hash(UserTestUtilities.ValidPassword)
            .Returns(existingPasswordHashResultModel);

        PasswordHasher.Verify(UserTestUtilities.ValidPassword, UserTestUtilities.ValidPasswordHash)
            .Returns(true);

        ImageHandler.UploadAsync(Arg.Is<ImageUploadModel>(i => i.FormFile == UserTestUtilities.ValidFormFile), CancellationToken)
            .Returns(existingImageResult);

        UserClaimWriteRepository.GetAllAsync(Arg.Is<UserClaimCollectionWriteQuery>(uc => uc.UserId == UserTestUtilities.ValidId), CancellationToken)
            .Returns([existingUserClaim]);

        AccessTokenGenerator.GenerateAccessToken(Arg.Is<CreateAccessTokenModel>(at => at.UserId == UserTestUtilities.ValidId &&
                                                                                      at.Email == UserTestUtilities.ValidEmail &&
                                                                                      at.FirstName == UserTestUtilities.ValidFirstName &&
                                                                                      at.LastName == UserTestUtilities.ValidLastName &&
                                                                                      at.UserName == UserTestUtilities.ValidName &&
                                                                                      at.UserClaims.All(uc => uc.UserId == UserTestUtilities.ValidId &&
                                                                                                              uc.Claim == AppClaims.Admin &&
                                                                                                              uc.Value == AppClaims.Admin)))
            .Returns(existingAccessTokenResult);

        UserReadRepository
            .GetAllAsync(Arg.Is<UserCollectionReadQuery>(m =>
                                                                        m.FirstName == UserTestUtilities.ValidFirstName &&
                                                                        m.LastName == UserTestUtilities.ValidLastName &&
                                                                        m.UserName == UserTestUtilities.ValidName &&
                                                                        m.Page == UserTestUtilities.ValidPageValue &&
                                                                        m.PageSize == UserTestUtilities.ValidPageSizeValue &&
                                                                        m.SortOrder == UserTestUtilities.ValidSortOrderProperty &&
                                                                        m.SortPropertyName == UserTestUtilities.ValidSortPropertyName), CancellationToken)
            .Returns(existingUserPaginationList);
    }
}
