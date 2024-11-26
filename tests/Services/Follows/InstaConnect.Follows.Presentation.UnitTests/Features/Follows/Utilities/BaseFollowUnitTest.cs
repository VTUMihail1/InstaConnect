using AutoMapper;
using InstaConnect.Follows.Application.Features.Follows.Commands.AddFollow;
using InstaConnect.Follows.Application.Features.Follows.Models;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetAllFollows;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetFollowById;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Common.Features.Users.Utilities;
using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;
using InstaConnect.Follows.Domain.Features.Users.Models.Entities;
using InstaConnect.Follows.Presentation.Features.Follows.Mappings;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Helpers;
using InstaConnect.Shared.Presentation.Abstractions;
using InstaConnect.Shared.Presentation.Models.Users;
using NSubstitute;

namespace InstaConnect.Follows.Presentation.UnitTests.Features.Follows.Utilities;

public abstract class BaseFollowUnitTest
{
    protected CancellationToken CancellationToken { get; }

    protected IInstaConnectSender InstaConnectSender { get; }

    protected ICurrentUserContext CurrentUserContext { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    public BaseFollowUnitTest()
    {

        CancellationToken = new();
        InstaConnectSender = Substitute.For<IInstaConnectSender>();
        CurrentUserContext = Substitute.For<ICurrentUserContext>();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<FollowCommandProfile>();
                    cfg.AddProfile<FollowQueryProfile>();
                })));
    }

    public string CreateCurrentUser()
    {
        var user = new User(
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidProfileImage);

        var existingCurrentUserModel = new CurrentUserModel(
            user.Id,
            UserTestUtilities.ValidName);

        CurrentUserContext
            .GetCurrentUser()
            .Returns(existingCurrentUserModel);

        return user.Id;
    }

    public string CreateUser()
    {
        var user = new User(
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidProfileImage);

        return user.Id;
    }

    public string CreateFollow(string followerId, string followingId)
    {
        var follow = new Follow(followerId, followingId);

        var followCommandViewModel = new FollowCommandViewModel(follow.Id);

        var followQueryViewModel = new FollowQueryViewModel(
            follow.Id,
            followerId,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidProfileImage,
            followingId,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidProfileImage);

        var followPaginationCollectionModel = new FollowPaginationQueryViewModel(
            [followQueryViewModel],
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue,
            FollowTestUtilities.ValidTotalCountValue,
            false,
            false);

        InstaConnectSender
            .SendAsync(Arg.Is<GetAllFollowsQuery>(m =>
                  m.FollowerId == followerId &&
                  m.FollowerName == UserTestUtilities.ValidName &&
                  m.FollowingId == followingId &&
                  m.FollowingName == UserTestUtilities.ValidName &&
                  m.SortOrder == FollowTestUtilities.ValidSortOrderProperty &&
                  m.SortPropertyName == FollowTestUtilities.ValidSortPropertyName &&
                  m.Page == FollowTestUtilities.ValidPageValue &&
                  m.PageSize == FollowTestUtilities.ValidPageSizeValue), CancellationToken)
            .Returns(followPaginationCollectionModel);

        InstaConnectSender
            .SendAsync(Arg.Is<GetFollowByIdQuery>(m => m.Id == follow.Id),
                                                    CancellationToken)
            .Returns(followQueryViewModel);

        InstaConnectSender
            .SendAsync(Arg.Is<AddFollowCommand>(m => m.CurrentUserId == followerId &&
                                                     m.FollowingId == followingId),
                                                     CancellationToken)
            .Returns(followCommandViewModel);

        return follow.Id;
    }
}
