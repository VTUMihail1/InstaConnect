using AutoMapper;
using InstaConnect.Posts.Business.Features.PostLikes.Commands.AddPostLike;
using InstaConnect.Posts.Business.Features.PostLikes.Models;
using InstaConnect.Posts.Business.Features.PostLikes.Queries.GetAllPostLikes;
using InstaConnect.Posts.Business.Features.PostLikes.Queries.GetPostLikeById;
using InstaConnect.Posts.Common.Features.PostLikes.Utilities;
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

        var existingPostLikeQueryViewModel = new PostLikeQueryViewModel(
            PostLikeTestUtilities.ValidId,
            PostLikeTestUtilities.ValidPostId,
            PostLikeTestUtilities.ValidCurrentUserId,
            PostLikeTestUtilities.ValidUserName,
            PostLikeTestUtilities.ValidUserProfileImage);

        var existingPostLikeCommandViewModel = new PostLikeCommandViewModel(PostLikeTestUtilities.ValidId);
        var existingCurrentUserModel = new CurrentUserModel(PostLikeTestUtilities.ValidCurrentUserId, PostLikeTestUtilities.ValidUserName);
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
            .SendAsync(Arg.Any<GetPostLikeByIdQuery>(), CancellationToken)
            .Returns(existingPostLikeQueryViewModel);

        InstaConnectSender
            .SendAsync(Arg.Any<AddPostLikeCommand>(), CancellationToken)
            .Returns(existingPostLikeCommandViewModel);
    }
}
