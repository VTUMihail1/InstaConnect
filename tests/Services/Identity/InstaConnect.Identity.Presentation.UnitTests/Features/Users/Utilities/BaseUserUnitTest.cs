using AutoMapper;
using InstaConnect.Identity.Application.Features.Users.Commands.EditCurrentUser;
using InstaConnect.Identity.Application.Features.Users.Commands.LoginUser;
using InstaConnect.Identity.Application.Features.Users.Commands.RegisterUser;
using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Application.Features.Users.Queries.GetAllUsers;
using InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentUser;
using InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentUserDetailed;
using InstaConnect.Identity.Application.Features.Users.Queries.GetUserById;
using InstaConnect.Identity.Application.Features.Users.Queries.GetUserByName;
using InstaConnect.Identity.Application.Features.Users.Queries.GetUserDetailedById;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Entitites;
using InstaConnect.Identity.Domain.Features.Users.Models.Entitites;
using InstaConnect.Identity.Presentation.Features.Users.Mappings;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Helpers;
using InstaConnect.Shared.Common.Utilities;
using NSubstitute;

namespace InstaConnect.Identity.Presentation.UnitTests.Features.Users.Utilities;

public abstract class BaseUserUnitTest
{
    protected CancellationToken CancellationToken { get; }

    protected IInstaConnectSender InstaConnectSender { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    public BaseUserUnitTest()
    {
        CancellationToken = new CancellationToken();
        InstaConnectSender = Substitute.For<IInstaConnectSender>();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<UserCommandProfile>();
                    cfg.AddProfile<UserQueryProfile>();
                })));
    }

    private User CreateUserUtil()
    {
        var user = new User(
            SharedTestUtilities.GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength),
            UserTestUtilities.ValidPasswordHash,
            UserTestUtilities.ValidProfileImage);

        var userQueryViewModel = new UserQueryViewModel(
            user.Id,
            user.FirstName,
            user.LastName,
            user.UserName,
            user.ProfileImage);

        var userDetailedQueryViewModel = new UserDetailedQueryViewModel(
            user.Id,
            user.FirstName,
            user.LastName,
            user.UserName,
            user.Email,
            user.ProfileImage);

        var userCommandViewModel = new UserCommandViewModel(user.Id);

        

        var userPaginationCollectionModel = new UserPaginationQueryViewModel(
            [userQueryViewModel],
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue,
            UserTestUtilities.ValidTotalCountValue,
            false,
            false);

        InstaConnectSender
            .SendAsync(Arg.Is<GetAllUsersQuery>(m =>
                  m.FirstName == user.FirstName &&
                  m.LastName == user.LastName &&
                  m.UserName == user.UserName &&
                  m.SortOrder == UserTestUtilities.ValidSortOrderProperty &&
                  m.SortPropertyName == UserTestUtilities.ValidSortPropertyName &&
                  m.Page == UserTestUtilities.ValidPageValue &&
                  m.PageSize == UserTestUtilities.ValidPageSizeValue), CancellationToken)
            .Returns(userPaginationCollectionModel);

        InstaConnectSender
            .SendAsync(Arg.Is<GetCurrentUserQuery>(u => u.CurrentUserId == user.Id), CancellationToken)
            .Returns(userQueryViewModel);

        InstaConnectSender
            .SendAsync(Arg.Is<GetUserByIdQuery>(m => m.Id == user.Id), CancellationToken)
            .Returns(userQueryViewModel);

        InstaConnectSender
            .SendAsync(Arg.Is<GetUserByNameQuery>(m => m.UserName == user.UserName), CancellationToken)
            .Returns(userQueryViewModel);

        InstaConnectSender
            .SendAsync(Arg.Is<GetCurrentDetailedUserQuery>(u => u.CurrentUserId == user.Id), CancellationToken)
            .Returns(userDetailedQueryViewModel);

        InstaConnectSender
            .SendAsync(Arg.Is<GetDetailedUserByIdQuery>(m => m.Id == user.Id), CancellationToken)
            .Returns(userDetailedQueryViewModel);

        InstaConnectSender
            .SendAsync(Arg.Is<UpdateUserCommand>(m => m.CurrentUserId == user.Id &&
                                                                m.UserName == UserTestUtilities.ValidUpdateName &&
                                                                m.FirstName == UserTestUtilities.ValidUpdateFirstName &&
                                                                m.LastName == UserTestUtilities.ValidUpdateLastName &&
                                                                m.ProfileImageFile == UserTestUtilities.ValidUpdateFormFile), CancellationToken)
            .Returns(userCommandViewModel);

        InstaConnectSender
            .SendAsync(Arg.Is<AddUserCommand>(m => m.Email == UserTestUtilities.ValidAddEmail &&
                                                                m.Password == UserTestUtilities.ValidAddPassword &&
                                                                m.ConfirmPassword == UserTestUtilities.ValidAddPassword &&
                                                                m.UserName == UserTestUtilities.ValidAddName &&
                                                                m.FirstName == UserTestUtilities.ValidAddFirstName &&
                                                                m.LastName == UserTestUtilities.ValidAddLastName &&
                                                                m.ProfileImage == UserTestUtilities.ValidAddFormFile), CancellationToken)
            .Returns(userCommandViewModel);

        return user;
    }

    protected User CreateUser()
    {
        var user = CreateUserUtil();

        return user;
    }

    private UserClaim CreateUserClaimUtil(User user)
    {
        var userClaim = new UserClaim(
            AppClaims.Admin,
            AppClaims.Admin,
            user);

        var userTokenCommandViewModel = new UserTokenCommandViewModel(UserTestUtilities.ValidAccessTokenValue, UserTestUtilities.ValidUntil);

        InstaConnectSender
            .SendAsync(Arg.Is<LoginUserCommand>(m => m.Email == user.Email &&
                                                     m.Password == UserTestUtilities.ValidPassword), CancellationToken)
            .Returns(userTokenCommandViewModel);

        return userClaim;
    }

    protected UserClaim CreateUserClaim()
    {
        var user = CreateUser();
        var userClaim = CreateUserClaimUtil(user);

        return userClaim;
    }
}
