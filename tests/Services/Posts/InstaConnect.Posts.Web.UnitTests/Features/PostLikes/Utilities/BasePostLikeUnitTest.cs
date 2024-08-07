using AutoMapper;
using InstaConnect.Posts.Business.Features.PostLikes.Commands.AddPostLike;
using InstaConnect.Posts.Business.Features.PostLikes.Models;
using InstaConnect.Posts.Business.Features.PostLikes.Queries.GetAllFilteredPostLikes;
using InstaConnect.Posts.Business.Features.PostLikes.Queries.GetAllPostLikes;
using InstaConnect.Posts.Business.Features.PostLikes.Queries.GetPostLikeById;
using InstaConnect.Posts.Business.Features.PostLikes.Utilities;
using InstaConnect.Posts.Web.Features.PostLikes.Mappings;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Web.Abstractions;
using InstaConnect.Shared.Web.Models.Users;
using InstaConnect.Shared.Web.UnitTests.Utilities;
using NSubstitute;

namespace InstaConnect.Posts.Web.UnitTests.Features.PostLikes.Utilities;

public abstract class BasePostLikeUnitTest : BaseSharedUnitTest
{
    protected readonly string ValidId;
    protected readonly string ValidPostId;
    protected readonly string ValidCurrentUserId;
    protected readonly string ValidUserName;
    protected readonly string ValidUserProfileImage;

    public BasePostLikeUnitTest() : base(
        Substitute.For<IInstaConnectSender>(),
        Substitute.For<ICurrentUserContext>(),
        new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<PostLikeCommandProfile>();
                    cfg.AddProfile<PostLikeQueryProfile>();
                }))))
    {
        ValidId = GetAverageString(PostLikeBusinessConfigurations.ID_MAX_LENGTH, PostLikeBusinessConfigurations.ID_MIN_LENGTH);
        ValidPostId = GetAverageString(PostLikeBusinessConfigurations.POST_ID_MAX_LENGTH, PostLikeBusinessConfigurations.POST_ID_MIN_LENGTH);
        ValidCurrentUserId = GetAverageString(PostLikeBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
        ValidUserName = GetAverageString(PostLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidUserProfileImage = GetAverageString(PostLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);

        var existingPostLikeQueryViewModel = new PostLikeQueryViewModel(
            ValidId,
            ValidPostId,
            ValidCurrentUserId,
            ValidUserName,
            ValidUserProfileImage);

        var existingPostLikeCommandViewModel = new PostLikeCommandViewModel(ValidId);
        var existingCurrentUserModel = new CurrentUserModel(ValidCurrentUserId, ValidUserName);
        var existingPostLikePaginationCollectionModel = new PostLikePaginationQueryViewModel(
            [existingPostLikeQueryViewModel],
            ValidPageValue,
            ValidPageSizeValue,
            ValidTotalCountValue,
            false,
            false);


        CurrentUserContext
            .GetCurrentUser()
            .Returns(existingCurrentUserModel);

        InstaConnectSender
            .SendAsync(Arg.Any<GetAllPostLikesQuery>(), CancellationToken)
            .Returns(existingPostLikePaginationCollectionModel);

        InstaConnectSender
            .SendAsync(Arg.Any<GetAllFilteredPostLikesQuery>(), CancellationToken)
            .Returns(existingPostLikePaginationCollectionModel);

        InstaConnectSender
            .SendAsync(Arg.Any<GetPostLikeByIdQuery>(), CancellationToken)
            .Returns(existingPostLikeQueryViewModel);

        InstaConnectSender
            .SendAsync(Arg.Any<AddPostLikeCommand>(), CancellationToken)
            .Returns(existingPostLikeCommandViewModel);
    }
}
