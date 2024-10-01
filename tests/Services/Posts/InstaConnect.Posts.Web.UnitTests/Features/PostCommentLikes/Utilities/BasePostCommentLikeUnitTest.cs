using AutoMapper;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Commands.AddPostCommentLike;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Queries.GetAllPostCommentLikes;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Queries.GetPostCommentLikeById;
using InstaConnect.Posts.Common.Features.PostCommentLikes.Utilities;
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
        var existingPostCommentLikeQueryViewModel = new PostCommentLikeQueryViewModel(
            PostCommentLikeTestUtilities.ValidId,
            PostCommentLikeTestUtilities.ValidPostCommentId,
            PostCommentLikeTestUtilities.ValidCurrentUserId,
            PostCommentLikeTestUtilities.ValidUserName,
            PostCommentLikeTestUtilities.ValidUserProfileImage);

        var existingPostCommentLikeCommandViewModel = new PostCommentLikeCommandViewModel(PostCommentLikeTestUtilities.ValidId);
        var existingCurrentUserModel = new CurrentUserModel(PostCommentLikeTestUtilities.ValidCurrentUserId, PostCommentLikeTestUtilities.ValidUserName);
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
