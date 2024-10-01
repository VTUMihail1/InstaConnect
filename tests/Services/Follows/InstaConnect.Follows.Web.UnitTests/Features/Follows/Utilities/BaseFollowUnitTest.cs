using AutoMapper;
using InstaConnect.Follows.Business.Features.Follows.Commands.AddFollow;
using InstaConnect.Follows.Business.Features.Follows.Models;
using InstaConnect.Follows.Business.Features.Follows.Queries.GetAllFollows;
using InstaConnect.Follows.Business.Features.Follows.Queries.GetFollowById;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Web.Features.Follows.Mappings;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Web.Abstractions;
using InstaConnect.Shared.Web.Models.Users;
using InstaConnect.Shared.Web.UnitTests.Utilities;
using NSubstitute;

namespace InstaConnect.Follows.Web.UnitTests.Features.Follows.Utilities;

public abstract class BaseFollowUnitTest : BaseSharedUnitTest
{

    public BaseFollowUnitTest() : base(
        Substitute.For<IInstaConnectSender>(),
        Substitute.For<ICurrentUserContext>(),
        new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<FollowCommandProfile>();
                    cfg.AddProfile<FollowQueryProfile>();
                }))))
    {

        var existingMessageQueryViewModel = new FollowQueryViewModel(
            FollowTestUtilities.ValidId,
            FollowTestUtilities.ValidCurrentUserId,
            FollowTestUtilities.ValidUserName,
            FollowTestUtilities.ValidUserProfileImage,
            FollowTestUtilities.ValidFollowingId,
            FollowTestUtilities.ValidUserName,
            FollowTestUtilities.ValidUserProfileImage);

        var existingMessageCommandViewModel = new FollowCommandViewModel(FollowTestUtilities.ValidId);
        var existingCurrentUserModel = new CurrentUserModel(FollowTestUtilities.ValidCurrentUserId, FollowTestUtilities.ValidUserName);
        var existingMessagePaginationCollectionModel = new FollowPaginationQueryViewModel(
            [existingMessageQueryViewModel],
            ValidPageValue,
            ValidPageSizeValue,
            ValidTotalCountValue,
            false,
            false);


        CurrentUserContext
            .GetCurrentUser()
            .Returns(existingCurrentUserModel);

        InstaConnectSender
            .SendAsync(Arg.Any<GetAllFollowsQuery>(), CancellationToken)
            .Returns(existingMessagePaginationCollectionModel);

        InstaConnectSender
            .SendAsync(Arg.Any<GetFollowByIdQuery>(), CancellationToken)
            .Returns(existingMessageQueryViewModel);

        InstaConnectSender
            .SendAsync(Arg.Any<AddFollowCommand>(), CancellationToken)
            .Returns(existingMessageCommandViewModel);
    }
}
