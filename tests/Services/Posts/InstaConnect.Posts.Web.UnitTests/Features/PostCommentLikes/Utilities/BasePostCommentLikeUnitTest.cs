using AutoMapper;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Commands.AddPostCommentLike;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Queries.GetAllPostCommentLikes;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Queries.GetPostCommentLikeById;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Web.Features.PostCommentLikes.Mappings;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Web.Abstractions;
using InstaConnect.Shared.Web.Models.Users;
using InstaConnect.Shared.Web.UnitTests.Utilities;
using NSubstitute;

namespace InstaConnect.Posts.Web.UnitTests.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeUnitTest : BaseSharedUnitTest
{
    protected readonly string ValidId;
    protected readonly string ValidPostCommentId;
    protected readonly string ValidCurrentUserId;
    protected readonly string ValidUserName;
    protected readonly string ValidUserProfileImage;

    public BasePostCommentLikeUnitTest() : base(
        Substitute.For<IInstaConnectSender>(),
        Substitute.For<ICurrentUserContext>(),
        new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<PostCommentLikeCommandProfile>();
                    cfg.AddProfile<PostCommentLikeQueryProfile>();
                }))))
    {
        ValidId = GetAverageString(PostCommentLikeBusinessConfigurations.ID_MAX_LENGTH, PostCommentLikeBusinessConfigurations.ID_MIN_LENGTH);
        ValidPostCommentId = GetAverageString(PostCommentLikeBusinessConfigurations.POST_COMMENT_ID_MAX_LENGTH, PostCommentLikeBusinessConfigurations.POST_COMMENT_ID_MIN_LENGTH);
        ValidCurrentUserId = GetAverageString(PostCommentLikeBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, PostCommentLikeBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
        ValidUserName = GetAverageString(PostCommentLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostCommentLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidUserProfileImage = GetAverageString(PostCommentLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostCommentLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);

        var existingPostCommentLikeQueryViewModel = new PostCommentLikeQueryViewModel(
            ValidId,
            ValidPostCommentId,
            ValidCurrentUserId,
            ValidUserName,
            ValidUserProfileImage);

        var existingPostCommentLikeCommandViewModel = new PostCommentLikeCommandViewModel(ValidId);
        var existingCurrentUserModel = new CurrentUserModel(ValidCurrentUserId, ValidUserName);
        var existingPostCommentLikePaginationCollectionModel = new PostCommentLikePaginationQueryViewModel(
            [existingPostCommentLikeQueryViewModel],
            ValidPageValue,
            ValidPageSizeValue,
            ValidTotalCountValue,
            false,
            false);


        CurrentUserContext
            .GetCurrentUser()
            .Returns(existingCurrentUserModel);

        InstaConnectSender
            .SendAsync(Arg.Any<GetAllPostCommentLikesQuery>(), CancellationToken)
            .Returns(existingPostCommentLikePaginationCollectionModel);

        InstaConnectSender
            .SendAsync(Arg.Any<GetPostCommentLikeByIdQuery>(), CancellationToken)
            .Returns(existingPostCommentLikeQueryViewModel);

        InstaConnectSender
            .SendAsync(Arg.Any<AddPostCommentLikeCommand>(), CancellationToken)
            .Returns(existingPostCommentLikeCommandViewModel);
    }
}
