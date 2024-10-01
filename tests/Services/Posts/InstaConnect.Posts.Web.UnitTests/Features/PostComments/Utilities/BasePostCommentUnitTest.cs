using AutoMapper;
using InstaConnect.Posts.Business.Features.PostComments.Commands.AddPostComment;
using InstaConnect.Posts.Business.Features.PostComments.Commands.UpdatePostComment;
using InstaConnect.Posts.Business.Features.PostComments.Models;
using InstaConnect.Posts.Business.Features.PostComments.Queries.GetAllPostComments;
using InstaConnect.Posts.Business.Features.PostComments.Queries.GetPostCommentById;
using InstaConnect.Posts.Common.Features.PostComments.Utilities;
using InstaConnect.Posts.Web.Features.PostComments.Mappings;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Web.Abstractions;
using InstaConnect.Shared.Web.Models.Users;
using InstaConnect.Shared.Web.UnitTests.Utilities;
using NSubstitute;

namespace InstaConnect.Posts.Web.UnitTests.Features.PostComments.Utilities;

public abstract class BasePostCommentUnitTest : BaseSharedUnitTest
{
    public BasePostCommentUnitTest() : base(
        Substitute.For<IInstaConnectSender>(),
        Substitute.For<ICurrentUserContext>(),
        new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<PostCommentCommandProfile>();
                    cfg.AddProfile<PostCommentQueryProfile>();
                }))))
    {

        var existingPostCommentQueryViewModel = new PostCommentQueryViewModel(
            PostCommentTestUtilities.ValidId,
            PostCommentTestUtilities.ValidContent,
            PostCommentTestUtilities.ValidPostId,
            PostCommentTestUtilities.ValidCurrentUserId,
            PostCommentTestUtilities.ValidUserName,
            PostCommentTestUtilities.ValidUserProfileImage);

        var existingPostCommentCommandViewModel = new PostCommentCommandViewModel(PostCommentTestUtilities.ValidId);
        var existingCurrentUserModel = new CurrentUserModel(PostCommentTestUtilities.ValidCurrentUserId, PostCommentTestUtilities.ValidUserName);
        var existingPostCommentPaginationCollectionModel = new PostCommentPaginationQueryViewModel(
            [existingPostCommentQueryViewModel],
            ValidPageValue,
            ValidPageSizeValue,
            ValidTotalCountValue,
            false,
            false);


        CurrentUserContext
            .GetCurrentUser()
            .Returns(existingCurrentUserModel);

        InstaConnectSender
            .SendAsync(Arg.Any<GetAllPostCommentsQuery>(), CancellationToken)
            .Returns(existingPostCommentPaginationCollectionModel);

        InstaConnectSender
            .SendAsync(Arg.Any<GetPostCommentByIdQuery>(), CancellationToken)
            .Returns(existingPostCommentQueryViewModel);

        InstaConnectSender
            .SendAsync(Arg.Any<AddPostCommentCommand>(), CancellationToken)
            .Returns(existingPostCommentCommandViewModel);

        InstaConnectSender
            .SendAsync(Arg.Any<UpdatePostCommentCommand>(), CancellationToken)
            .Returns(existingPostCommentCommandViewModel);
    }
}
