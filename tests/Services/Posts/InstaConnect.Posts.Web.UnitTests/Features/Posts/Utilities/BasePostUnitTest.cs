using AutoMapper;
using InstaConnect.Posts.Business.Features.Posts.Commands.AddPost;
using InstaConnect.Posts.Business.Features.Posts.Commands.UpdatePost;
using InstaConnect.Posts.Business.Features.Posts.Models;
using InstaConnect.Posts.Business.Features.Posts.Queries.GetAllPosts;
using InstaConnect.Posts.Business.Features.Posts.Queries.GetPostById;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Web.Features.Posts.Mappings;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Web.Abstractions;
using InstaConnect.Shared.Web.Models.Users;
using InstaConnect.Shared.Web.UnitTests.Utilities;
using NSubstitute;

namespace InstaConnect.Posts.Web.UnitTests.Features.Posts.Utilities;

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
