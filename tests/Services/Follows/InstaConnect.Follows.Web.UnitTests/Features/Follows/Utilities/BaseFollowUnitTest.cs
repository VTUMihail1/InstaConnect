using AutoMapper;
using InstaConnect.Follows.Business.Features.Follows.Commands.AddFollow;
using InstaConnect.Follows.Business.Features.Follows.Models;
using InstaConnect.Follows.Business.Features.Follows.Queries.GetAllFilteredFollows;
using InstaConnect.Follows.Business.Features.Follows.Queries.GetAllFollows;
using InstaConnect.Follows.Business.Features.Follows.Queries.GetFollowById;
using InstaConnect.Follows.Business.Features.Follows.Utilities;
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
    protected readonly string ValidId;
    protected readonly string ValidFollowingId;
    protected readonly string ValidCurrentUserId;
    protected readonly string ValidUserName;
    protected readonly string ValidUserProfileImage;

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
        ValidId = GetAverageString(FollowBusinessConfigurations.ID_MAX_LENGTH, FollowBusinessConfigurations.ID_MIN_LENGTH);
        ValidFollowingId = GetAverageString(FollowBusinessConfigurations.FOLLOWING_ID_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_ID_MIN_LENGTH);
        ValidCurrentUserId = GetAverageString(FollowBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, FollowBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
        ValidUserName = GetAverageString(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH);
        ValidUserProfileImage = GetAverageString(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH, FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH);

        var existingMessageQueryViewModel = new FollowQueryViewModel(
            ValidId,
            ValidCurrentUserId,
            ValidUserName,
            ValidUserProfileImage,
            ValidFollowingId,
            ValidUserName,
            ValidUserProfileImage);

        var existingMessageCommandViewModel = new FollowCommandViewModel(ValidId);
        var existingCurrentUserModel = new CurrentUserModel(ValidCurrentUserId, ValidUserName);
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
            .SendAsync(Arg.Any<GetAllFilteredFollowsQuery>(), CancellationToken)
            .Returns(existingMessagePaginationCollectionModel);

        InstaConnectSender
            .SendAsync(Arg.Any<GetFollowByIdQuery>(), CancellationToken)
            .Returns(existingMessageQueryViewModel);

        InstaConnectSender
            .SendAsync(Arg.Any<AddFollowCommand>(), CancellationToken)
            .Returns(existingMessageCommandViewModel);
    }
}
