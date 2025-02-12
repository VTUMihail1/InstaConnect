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
using InstaConnect.Shared.Common.Utilities;
using NSubstitute;

namespace InstaConnect.Follows.Presentation.UnitTests.Features.Follows.Utilities;

public abstract class BaseFollowUnitTest
{
    protected CancellationToken CancellationToken { get; }

    protected IInstaConnectSender InstaConnectSender { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    public BaseFollowUnitTest()
    {

        CancellationToken = new();
        InstaConnectSender = Substitute.For<IInstaConnectSender>();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<FollowCommandProfile>();
                    cfg.AddProfile<FollowQueryProfile>();
                })));
    }

    public User CreateUser()
    {
        var user = new User(
            SharedTestUtilities.GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.ProfileImageMaxLength, UserConfigurations.ProfileImageMinLength));

        return user;
    }

    public Follow CreateFollow()
    {
        var follower = CreateUser();
        var following = CreateUser();
        var follow = new Follow(follower, following);

        var followCommandViewModel = new FollowCommandViewModel(follow.Id);

        var followQueryViewModel = new FollowQueryViewModel(
            follow.Id,
            follower.Id,
            follower.UserName,
            follower.ProfileImage,
            following.Id,
            following.UserName,
            following.ProfileImage);

        var followPaginationCollectionModel = new FollowPaginationQueryViewModel(
            [followQueryViewModel],
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue,
            FollowTestUtilities.ValidTotalCountValue,
            false,
            false);

        InstaConnectSender
            .SendAsync(Arg.Is<GetAllFollowsQuery>(m =>
                  m.FollowerId == follower.Id &&
                  m.FollowerName == follower.UserName &&
                  m.FollowingId == following.Id &&
                  m.FollowingName == following.UserName &&
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
            .SendAsync(Arg.Is<AddFollowCommand>(m => m.CurrentUserId == follower.Id &&
                                                     m.FollowingId == following.Id),
                                                     CancellationToken)
            .Returns(followCommandViewModel);

        return follow;
    }
}
