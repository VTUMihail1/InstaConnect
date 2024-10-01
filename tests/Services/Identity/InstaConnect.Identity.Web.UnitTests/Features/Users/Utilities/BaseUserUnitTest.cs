using AutoMapper;
using InstaConnect.Identity.Business.Features.Users.Commands.EditCurrentUser;
using InstaConnect.Identity.Business.Features.Users.Commands.LoginUser;
using InstaConnect.Identity.Business.Features.Users.Commands.RegisterUser;
using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Identity.Business.Features.Users.Queries.GetAllUsers;
using InstaConnect.Identity.Business.Features.Users.Queries.GetCurrentUser;
using InstaConnect.Identity.Business.Features.Users.Queries.GetCurrentUserDetailed;
using InstaConnect.Identity.Business.Features.Users.Queries.GetUserById;
using InstaConnect.Identity.Business.Features.Users.Queries.GetUserByName;
using InstaConnect.Identity.Business.Features.Users.Queries.GetUserDetailedById;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Web.Features.Users.Mappings;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Web.Abstractions;
using InstaConnect.Shared.Web.Models.Users;
using InstaConnect.Shared.Web.UnitTests.Utilities;
using NSubstitute;

namespace InstaConnect.Identity.Web.UnitTests.Features.Users.Utilities;

public abstract class BaseUserUnitTest : BaseSharedUnitTest
{
    public BaseUserUnitTest() : base(
        Substitute.For<IInstaConnectSender>(),
        Substitute.For<ICurrentUserContext>(),
        new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<UserCommandProfile>();
                    cfg.AddProfile<UserQueryProfile>();
                }))))
    {
        var existingUserQueryViewModel = new UserQueryViewModel(
            UserTestUtilities.ValidId,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidProfileImage);

        var existingUserDetailedQueryViewModel = new UserDetailedQueryViewModel(
            UserTestUtilities.ValidId,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidProfileImage);

        var existingUserCommandViewModel = new UserCommandViewModel(UserTestUtilities.ValidId);

        var existingUserTokenCommandViewModel = new UserTokenCommandViewModel(UserTestUtilities.ValidAccessTokenValue, UserTestUtilities.ValidUntil);

        var existingCurrentUserModel = new CurrentUserModel(UserTestUtilities.ValidId, UserTestUtilities.ValidName);

        var existingUserPaginationCollectionModel = new UserPaginationQueryViewModel(
            [existingUserQueryViewModel],
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue,
            UserTestUtilities.ValidTotalCountValue,
            false,
            false);


        CurrentUserContext
            .GetCurrentUser()
            .Returns(existingCurrentUserModel);

        InstaConnectSender
            .SendAsync(Arg.Any<GetAllUsersQuery>(), CancellationToken)
            .Returns(existingUserPaginationCollectionModel);

        InstaConnectSender
            .SendAsync(Arg.Any<GetCurrentUserQuery>(), CancellationToken)
            .Returns(existingUserQueryViewModel);

        InstaConnectSender
            .SendAsync(Arg.Any<GetUserByIdQuery>(), CancellationToken)
            .Returns(existingUserQueryViewModel);

        InstaConnectSender
            .SendAsync(Arg.Any<GetUserByNameQuery>(), CancellationToken)
            .Returns(existingUserQueryViewModel);

        InstaConnectSender
            .SendAsync(Arg.Any<GetCurrentUserDetailedQuery>(), CancellationToken)
            .Returns(existingUserDetailedQueryViewModel);

        InstaConnectSender
            .SendAsync(Arg.Any<GetUserDetailedByIdQuery>(), CancellationToken)
            .Returns(existingUserDetailedQueryViewModel);

        InstaConnectSender
            .SendAsync(Arg.Any<EditCurrentUserCommand>(), CancellationToken)
            .Returns(existingUserCommandViewModel);

        InstaConnectSender
            .SendAsync(Arg.Any<RegisterUserCommand>(), CancellationToken)
            .Returns(existingUserCommandViewModel);

        InstaConnectSender
            .SendAsync(Arg.Any<LoginUserCommand>(), CancellationToken)
            .Returns(existingUserTokenCommandViewModel);
    }
}
