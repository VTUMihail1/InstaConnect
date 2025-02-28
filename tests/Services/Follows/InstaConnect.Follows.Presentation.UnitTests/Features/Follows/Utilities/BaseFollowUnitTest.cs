using AutoMapper;

using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Helpers;
using InstaConnect.Follows.Application.Features.Follows.Commands.Add;
using InstaConnect.Follows.Application.Features.Follows.Models;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetAll;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetById;
using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;
using InstaConnect.Follows.Presentation.Extensions;

namespace InstaConnect.Follows.Presentation.UnitTests.Features.Follows.Utilities;

public abstract class BaseFollowUnitTest
{
    protected CancellationToken CancellationToken { get; }

    protected IInstaConnectSender InstaConnectSender { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    protected BaseFollowUnitTest()
    {

        CancellationToken = new();
        InstaConnectSender = Substitute.For<IInstaConnectSender>();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg => cfg.AddMaps(PresentationReference.Assembly))));
    }

    private static User CreateUserUtil()
    {
        var user = new User(
            SharedTestUtilities.GetAverageString(UserConfigurations.IdMaxLength, UserConfigurations.IdMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.ProfileImageMaxLength, UserConfigurations.ProfileImageMinLength),
            SharedTestUtilities.GetMaxDate(),
            SharedTestUtilities.GetMaxDate());

        return user;
    }

    protected static User CreateUser()
    {
        var user = CreateUserUtil();

        return user;
    }

    private Follow CreateFollowUtil(User follower, User following)
    {
        var follow = new Follow(
            SharedTestUtilities.GetAverageString(FollowConfigurations.IdMaxLength, FollowConfigurations.IdMinLength),
            follower,
            following,
            SharedTestUtilities.GetMaxDate(),
            SharedTestUtilities.GetMaxDate());

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

    protected Follow CreateFollow()
    {
        var follower = CreateUser();
        var following = CreateUser();
        var follow = CreateFollowUtil(follower, following);

        return follow;
    }
}
