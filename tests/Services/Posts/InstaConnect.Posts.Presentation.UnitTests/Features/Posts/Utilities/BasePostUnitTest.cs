using AutoMapper;
using InstaConnect.Posts.Application.Features.Posts.Commands.AddPost;
using InstaConnect.Posts.Application.Features.Posts.Commands.UpdatePost;
using InstaConnect.Posts.Application.Features.Posts.Models;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAllPosts;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetPostById;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Presentation.Features.Posts.Mappings;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Helpers;
using InstaConnect.Shared.Presentation.Abstractions;
using InstaConnect.Shared.Presentation.Models.Users;
using InstaConnect.Shared.Presentation.UnitTests.Utilities;
using NSubstitute;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.Posts.Utilities;

public abstract class BasePostUnitTest : BaseSharedUnitTest
{
    public BasePostUnitTest() : base(
        Substitute.For<IInstaConnectSender>(),
        Substitute.For<ICurrentUserContext>(),
        new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<PostCommandProfile>();
                    cfg.AddProfile<PostQueryProfile>();
                }))))
    {

        var existingPostQueryViewModel = new PostQueryViewModel(
            PostTestUtilities.ValidId,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidContent,
            PostTestUtilities.ValidCurrentUserId,
            PostTestUtilities.ValidUserName,
            PostTestUtilities.ValidUserProfileImage);

        var existingPostCommandViewModel = new PostCommandViewModel(PostTestUtilities.ValidId);
        var existingCurrentUserModel = new CurrentUserModel(PostTestUtilities.ValidCurrentUserId, PostTestUtilities.ValidUserName);
        var existingPostPaginationCollectionModel = new PostPaginationQueryViewModel(
            [existingPostQueryViewModel],
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue,
            PostTestUtilities.ValidTotalCountValue,
            false,
            false);


        CurrentUserContext
            .GetCurrentUser()
            .Returns(existingCurrentUserModel);

        InstaConnectSender
            .SendAsync(Arg.Any<GetAllPostsQuery>(), CancellationToken)
            .Returns(existingPostPaginationCollectionModel);

        InstaConnectSender
            .SendAsync(Arg.Any<GetPostByIdQuery>(), CancellationToken)
            .Returns(existingPostQueryViewModel);

        InstaConnectSender
            .SendAsync(Arg.Any<AddPostCommand>(), CancellationToken)
            .Returns(existingPostCommandViewModel);

        InstaConnectSender
            .SendAsync(Arg.Any<UpdatePostCommand>(), CancellationToken)
            .Returns(existingPostCommandViewModel);
    }
}
