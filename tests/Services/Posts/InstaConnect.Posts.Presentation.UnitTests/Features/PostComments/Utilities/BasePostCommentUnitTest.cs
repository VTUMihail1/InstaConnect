using AutoMapper;
using InstaConnect.Posts.Application.Features.PostComments.Commands.AddPostComment;
using InstaConnect.Posts.Application.Features.PostComments.Commands.UpdatePostComment;
using InstaConnect.Posts.Application.Features.PostComments.Models;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAllPostComments;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetPostCommentById;
using InstaConnect.Posts.Common.Features.PostComments.Utilities;
using InstaConnect.Posts.Presentation.Features.PostComments.Mappings;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Helpers;
using InstaConnect.Shared.Presentation.Abstractions;
using InstaConnect.Shared.Presentation.Models.Users;
using InstaConnect.Shared.Presentation.UnitTests.Utilities;
using NSubstitute;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.PostComments.Utilities;

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
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue,
            PostCommentTestUtilities.ValidTotalCountValue,
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
