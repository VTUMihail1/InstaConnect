using AutoMapper;
using InstaConnect.Posts.Business.Features.Posts.Commands.AddPost;
using InstaConnect.Posts.Business.Features.Posts.Commands.UpdatePost;
using InstaConnect.Posts.Business.Features.Posts.Models;
using InstaConnect.Posts.Business.Features.Posts.Queries.GetAllFilteredPosts;
using InstaConnect.Posts.Business.Features.Posts.Queries.GetAllPosts;
using InstaConnect.Posts.Business.Features.Posts.Queries.GetPostById;
using InstaConnect.Posts.Business.Features.Posts.Utilities;
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
    protected readonly string ValidId;
    protected readonly string ValidContent;
    protected readonly string ValidTitle;
    protected readonly string ValidCurrentUserId;
    protected readonly string ValidUserName;
    protected readonly string ValidUserProfileImage;

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
        ValidId = GetAverageString(PostBusinessConfigurations.ID_MAX_LENGTH, PostBusinessConfigurations.ID_MIN_LENGTH);
        ValidTitle = GetAverageString(PostBusinessConfigurations.TITLE_MAX_LENGTH, PostBusinessConfigurations.TITLE_MIN_LENGTH);
        ValidContent = GetAverageString(PostBusinessConfigurations.CONTENT_MAX_LENGTH, PostBusinessConfigurations.CONTENT_MIN_LENGTH);
        ValidCurrentUserId = GetAverageString(PostBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, PostBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
        ValidUserName = GetAverageString(PostBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidUserProfileImage = GetAverageString(PostBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);

        var existingPostQueryViewModel = new PostQueryViewModel(
            ValidId,
            ValidTitle,
            ValidContent,
            ValidCurrentUserId,
            ValidUserName,
            ValidUserProfileImage);

        var existingPostCommandViewModel = new PostCommandViewModel(ValidId);
        var existingCurrentUserModel = new CurrentUserModel(ValidCurrentUserId, ValidUserName);
        var existingPostPaginationCollectionModel = new PostPaginationQueryViewModel(
            [existingPostQueryViewModel],
            ValidPageValue,
            ValidPageSizeValue,
            ValidTotalCountValue,
            false,
            false);


        CurrentUserContext
            .GetCurrentUser()
            .Returns(existingCurrentUserModel);

        InstaConnectSender
            .SendAsync(Arg.Any<GetAllPostsQuery>(), CancellationToken)
            .Returns(existingPostPaginationCollectionModel);

        InstaConnectSender
            .SendAsync(Arg.Any<GetAllFilteredPostsQuery>(), CancellationToken)
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
