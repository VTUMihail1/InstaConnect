using AutoMapper;
using InstaConnect.Posts.Business.Features.PostComments.Commands.AddPostComment;
using InstaConnect.Posts.Business.Features.PostComments.Commands.UpdatePostComment;
using InstaConnect.Posts.Business.Features.PostComments.Models;
using InstaConnect.Posts.Business.Features.PostComments.Queries.GetAllFilteredPostComments;
using InstaConnect.Posts.Business.Features.PostComments.Queries.GetAllPostComments;
using InstaConnect.Posts.Business.Features.PostComments.Queries.GetPostCommentById;
using InstaConnect.Posts.Business.Features.PostComments.Utilities;
using InstaConnect.Posts.Business.Features.Posts.Utilities;
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
    protected readonly string ValidId;
    protected readonly string ValidContent;
    protected readonly string ValidPostId;
    protected readonly string ValidCurrentUserId;
    protected readonly string ValidUserName;
    protected readonly string ValidUserProfileImage;

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
        ValidId = GetAverageString(PostCommentBusinessConfigurations.ID_MAX_LENGTH, PostCommentBusinessConfigurations.ID_MIN_LENGTH);
        ValidContent = GetAverageString(PostBusinessConfigurations.CONTENT_MAX_LENGTH, PostBusinessConfigurations.CONTENT_MIN_LENGTH);
        ValidPostId = GetAverageString(PostCommentBusinessConfigurations.POST_ID_MAX_LENGTH, PostCommentBusinessConfigurations.POST_ID_MIN_LENGTH);
        ValidCurrentUserId = GetAverageString(PostCommentBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, PostCommentBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
        ValidUserName = GetAverageString(PostCommentBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostCommentBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidUserProfileImage = GetAverageString(PostCommentBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostCommentBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);

        var existingPostCommentQueryViewModel = new PostCommentQueryViewModel(
            ValidId,
            ValidContent,
            ValidPostId,
            ValidCurrentUserId,
            ValidUserName,
            ValidUserProfileImage);

        var existingPostCommentCommandViewModel = new PostCommentCommandViewModel(ValidId);
        var existingCurrentUserModel = new CurrentUserModel(ValidCurrentUserId, ValidUserName);
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
            .SendAsync(Arg.Any<GetAllFilteredPostCommentsQuery>(), CancellationToken)
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
