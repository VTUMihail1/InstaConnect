using AutoMapper;
using InstaConnect.Posts.Application.Features.PostLikes.Commands.AddPostLike;
using InstaConnect.Posts.Application.Features.PostLikes.Models;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAllPostLikes;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetPostLikeById;
using InstaConnect.Posts.Common.Features.PostLikes.Utilities;
using InstaConnect.Posts.Presentation.Features.PostLikes.Mappings;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Helpers;
using InstaConnect.Shared.Presentation.Abstractions;
using InstaConnect.Shared.Presentation.Models.Users;
using InstaConnect.Shared.Presentation.UnitTests.Utilities;
using NSubstitute;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.PostLikes.Utilities;

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
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue,
            PostLikeTestUtilities.ValidTotalCountValue,
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
