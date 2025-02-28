using AutoMapper;

using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Application.Helpers;
using InstaConnect.Common.Application.Models;
using InstaConnect.Common.Domain.Models.Pagination;
using InstaConnect.Common.Helpers;
using InstaConnect.Identity.Application.Extensions;
using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Application.Features.Users.Abstractions;
using InstaConnect.Identity.Common.Tests.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Entities;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Filters;
using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Identity.Domain.Features.Users.Models;
using InstaConnect.Identity.Domain.Features.Users.Models.Filters;

namespace InstaConnect.Identity.Application.UnitTests.Features.Users.Utilities;

public abstract class BaseUserUnitTest
{
    protected CancellationToken CancellationToken { get; }

    protected IUnitOfWork UnitOfWork { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    protected IEntityPropertyValidator EntityPropertyValidator { get; }

    protected IImageHandler ImageHandler { get; }

    protected IEventPublisher EventPublisher { get; }

    protected IUserReadRepository UserReadRepository { get; }

    protected IUserWriteRepository UserWriteRepository { get; }

    protected IUserClaimWriteRepository UserClaimWriteRepository { get; }

    protected IAccessTokenGenerator AccessTokenGenerator { get; }

    protected IPasswordHasher PasswordHasher { get; }

    protected IEmailConfirmationTokenPublisher EmailConfirmationTokenPublisher { get; }

    protected BaseUserUnitTest()
    {
        CancellationToken = new();
        UnitOfWork = Substitute.For<IUnitOfWork>();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg => cfg.AddMaps(ApplicationReference.Assembly))));
        EntityPropertyValidator = new EntityPropertyValidator();
        ImageHandler = Substitute.For<IImageHandler>();
        EventPublisher = Substitute.For<IEventPublisher>();
        UserReadRepository = Substitute.For<IUserReadRepository>();
        UserWriteRepository = Substitute.For<IUserWriteRepository>();
        PasswordHasher = Substitute.For<IPasswordHasher>();
        AccessTokenGenerator = Substitute.For<IAccessTokenGenerator>();
        UserClaimWriteRepository = Substitute.For<IUserClaimWriteRepository>();
        EmailConfirmationTokenPublisher = Substitute.For<IEmailConfirmationTokenPublisher>();

        PasswordHasher.Verify(UserTestUtilities.ValidPassword, UserTestUtilities.ValidPasswordHash)
            .Returns(true);

        PasswordHasher.Hash(UserTestUtilities.ValidAddPassword)
            .Returns(new PasswordHashResultModel(UserTestUtilities.ValidAddPasswordHash));

        PasswordHasher.Verify(UserTestUtilities.ValidAddPassword, UserTestUtilities.ValidAddPasswordHash)
            .Returns(true);

        PasswordHasher.Hash(UserTestUtilities.ValidUpdatePassword)
            .Returns(new PasswordHashResultModel(UserTestUtilities.ValidUpdatePasswordHash));

        PasswordHasher.Verify(UserTestUtilities.ValidUpdatePassword, UserTestUtilities.ValidUpdatePasswordHash)
            .Returns(true);

        ImageHandler.UploadAsync(Arg.Is<ImageUploadModel>(i => i.FormFile == UserTestUtilities.ValidAddFormFile), CancellationToken)
            .Returns(new ImageResult(UserTestUtilities.ValidAddProfileImage));

        ImageHandler.UploadAsync(Arg.Is<ImageUploadModel>(i => i.FormFile == UserTestUtilities.ValidUpdateFormFile), CancellationToken)
            .Returns(new ImageResult(UserTestUtilities.ValidUpdateProfileImage));
    }

    private UserClaim CreateUserClaimUtil(User user)
    {
        var accessTokenResult = new AccessTokenResult(
            UserTestUtilities.ValidAccessTokenValue,
            UserTestUtilities.ValidUntil);

        var userClaim = new UserClaim(
            AppClaims.Admin,
            AppClaims.Admin,
            user);

        UserClaimWriteRepository.GetAllAsync(Arg.Is<UserClaimCollectionWriteQuery>(uc => uc.UserId == user.Id), CancellationToken)
            .Returns([userClaim]);

        AccessTokenGenerator.GenerateAccessToken(Arg.Is<CreateAccessTokenModel>(at => at.UserId == user.Id &&
                                                                                      at.Email == user.Email &&
                                                                                      at.FirstName == user.FirstName &&
                                                                                      at.LastName == user.LastName &&
                                                                                      at.UserName == user.UserName &&
                                                                                      at.UserClaims.All(uc => uc.UserId == user.Id &&
                                                                                                              uc.Claim == AppClaims.Admin &&
                                                                                                              uc.Value == AppClaims.Admin)))
            .Returns(accessTokenResult);

        return userClaim;
    }

    protected UserClaim CreateUserClaim()
    {
        var user = CreateUser();

        var userClaim = CreateUserClaimUtil(user);

        return userClaim;
    }

    protected UserClaim CreateUserClaimWithUnconfirmedUserEmail()
    {
        var user = CreateUserWithUnconfirmedEmail();

        var userClaim = CreateUserClaimUtil(user);

        return userClaim;
    }

    private User CreateUserUtil(bool isEmailConfirmed)
    {
        var user = new User(
            SharedTestUtilities.GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength),
            UserTestUtilities.ValidPasswordHash,
            UserTestUtilities.ValidProfileImage)
        {
            IsEmailConfirmed = isEmailConfirmed
        };

        var userPaginationList = new PaginationList<User>(
            [user],
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue,
            UserTestUtilities.ValidTotalCountValue);

        UserWriteRepository.GetByIdAsync(user.Id, CancellationToken)
            .Returns(user);

        UserWriteRepository.GetByNameAsync(user.UserName, CancellationToken)
            .Returns(user);

        UserWriteRepository.GetByEmailAsync(user.Email, CancellationToken)
            .Returns(user);

        UserReadRepository.GetByIdAsync(user.Id, CancellationToken)
            .Returns(user);

        UserReadRepository.GetByNameAsync(user.UserName, CancellationToken)
            .Returns(user);

        UserReadRepository.GetByEmailAsync(user.Email, CancellationToken)
            .Returns(user);

        UserReadRepository
            .GetAllAsync(Arg.Is<UserCollectionReadQuery>(m =>
                                                                        m.FirstName == user.FirstName &&
                                                                        m.LastName == user.LastName &&
                                                                        m.UserName == user.UserName &&
                                                                        m.Page == UserTestUtilities.ValidPageValue &&
                                                                        m.PageSize == UserTestUtilities.ValidPageSizeValue &&
                                                                        m.SortOrder == UserTestUtilities.ValidSortOrderProperty &&
                                                                        m.SortPropertyName == UserTestUtilities.ValidSortPropertyName), CancellationToken)
            .Returns(userPaginationList);

        return user;
    }

    protected User CreateUser()
    {
        var user = CreateUserUtil(true);

        return user;
    }



    protected User CreateUserWithUnconfirmedEmail()
    {
        var user = CreateUserUtil(false);

        return user;
    }
}
