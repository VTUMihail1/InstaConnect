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
using InstaConnect.Identity.Presentation.Features.Users.Mappings;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Helpers;
using InstaConnect.Shared.Presentation.Abstractions;
using InstaConnect.Shared.Presentation.Models.Users;
using InstaConnect.Shared.Presentation.UnitTests.Utilities;
using NSubstitute;

namespace InstaConnect.Identity.Presentation.UnitTests.Features.Users.Utilities;

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
            .SendAsync(Arg.Any<GetCurrentDetailedUserQuery>(), CancellationToken)
            .Returns(existingUserDetailedQueryViewModel);

        InstaConnectSender
            .SendAsync(Arg.Any<GetDetailedUserByIdQuery>(), CancellationToken)
            .Returns(existingUserDetailedQueryViewModel);

        InstaConnectSender
            .SendAsync(Arg.Any<UpdateUserCommand>(), CancellationToken)
            .Returns(existingUserCommandViewModel);

        InstaConnectSender
            .SendAsync(Arg.Any<AddUserCommand>(), CancellationToken)
            .Returns(existingUserCommandViewModel);

        InstaConnectSender
            .SendAsync(Arg.Any<LoginUserCommand>(), CancellationToken)
            .Returns(existingUserTokenCommandViewModel);
    }
}
