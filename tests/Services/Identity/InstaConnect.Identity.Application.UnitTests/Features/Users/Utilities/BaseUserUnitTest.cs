using AutoMapper;
using InstaConnect.Identity.Application.Features.Users.Abstractions;
using InstaConnect.Identity.Application.Features.Users.Mappings;
using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entitites;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Entitites;
using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Entitites;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Filters;
using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Identity.Domain.Features.Users.Models;
using InstaConnect.Identity.Domain.Features.Users.Models.Entitites;
using InstaConnect.Identity.Domain.Features.Users.Models.Filters;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Helpers;
using InstaConnect.Shared.Application.Models;
using InstaConnect.Shared.Application.UnitTests.Utilities;
using InstaConnect.Shared.Common.Utilities;
using InstaConnect.Shared.Domain.Models.Pagination;
using NSubstitute;

namespace InstaConnect.Identity.Application.UnitTests.Features.Users.Utilities;

public abstract class BaseUserUnitTest : BaseSharedUnitTest
{
    protected IImageHandler ImageHandler { get; }

    protected IEventPublisher EventPublisher { get; }

    protected IUserReadRepository UserReadRepository { get; }

    protected IUserWriteRepository UserWriteRepository { get; }

    protected IUserClaimWriteRepository UserClaimWriteRepository { get; }

    protected IAccessTokenGenerator AccessTokenGenerator { get; }

    protected IPasswordHasher PasswordHasher { get; }

    protected IEmailConfirmationTokenPublisher EmailConfirmationTokenPublisher { get; }

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

    public User CreateUserWithUnconfirmedEmail()
    {
        var user = new User(
            SharedTestUtilities.GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength),
            UserTestUtilities.ValidPasswordHash,
            UserTestUtilities.ValidProfileImage);

        UserWriteRepository.GetByIdAsync(user.Id, CancellationToken)
            .Returns(user);

        UserWriteRepository.GetByNameAsync(user.UserName, CancellationToken)
            .Returns(user);

        UserWriteRepository.GetByEmailAsync(user.Email, CancellationToken)
            .Returns(user);

        return user;
    }

    public User CreateUser()
    {
        var user = new User(
            SharedTestUtilities.GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength),
            UserTestUtilities.ValidPasswordHash,
            UserTestUtilities.ValidProfileImage)
        {
            IsEmailConfirmed = true
        };

        var accessTokenResult = new AccessTokenResult(UserTestUtilities.ValidAccessTokenValue, UserTestUtilities.ValidUntil);

        var userClaim = new UserClaim(AppClaims.Admin, AppClaims.Admin, user.Id);

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
}
