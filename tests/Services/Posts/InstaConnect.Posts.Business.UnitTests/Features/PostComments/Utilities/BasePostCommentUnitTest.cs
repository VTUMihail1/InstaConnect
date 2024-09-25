using AutoMapper;
using InstaConnect.Posts.Business.Features.PostComments.Mappings;
using InstaConnect.Posts.Business.Features.PostComments.Utilities;
using InstaConnect.Posts.Business.Features.Posts.Utilities;
using InstaConnect.Posts.Data.Features.PostComments.Abstract;
using InstaConnect.Posts.Data.Features.PostComments.Models.Entitites;
using InstaConnect.Posts.Data.Features.PostComments.Models.Filters;
using InstaConnect.Posts.Data.Features.Posts.Abstract;
using InstaConnect.Posts.Data.Features.Posts.Models.Entitites;
using InstaConnect.Posts.Data.Features.Users.Abstract;
using InstaConnect.Posts.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Business.UnitTests.Utilities;
using InstaConnect.Shared.Data.Abstractions;
using InstaConnect.Shared.Data.Models.Pagination;
using NSubstitute;

namespace InstaConnect.Posts.Business.UnitTests.Features.PostComments.Utilities;

public abstract class BasePostCommentUnitTest : BaseSharedUnitTest
{
    protected readonly string ValidId;
    protected readonly string InvalidId;
    protected readonly string ValidPostId;
    protected readonly string InvalidPostId;
    protected readonly string ValidPostTitle;
    protected readonly string ValidPostContent;
    protected readonly string ValidContent;
    protected readonly string ValidCurrentUserId;
    protected readonly string InvalidUserId;
    protected readonly string ValidUserName;
    protected readonly string ValidUserFirstName;
    protected readonly string ValidUserEmail;
    protected readonly string ValidUserLastName;
    protected readonly string ValidUserProfileImage;
    protected readonly string ValidPostCommentPostId;
    protected readonly string ValidPostCommentCurrentUserId;

    protected IUserWriteRepository UserWriteRepository { get; }

    protected IPostReadRepository PostReadRepository { get; }

    protected IPostWriteRepository PostWriteRepository { get; }

    protected IPostCommentReadRepository PostCommentReadRepository { get; }

    protected IPostCommentWriteRepository PostCommentWriteRepository { get; }

    public BasePostCommentUnitTest() : base(
        Substitute.For<IUnitOfWork>(),
        new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<PostCommentQueryProfile>();
                    cfg.AddProfile<PostCommentCommandProfile>();
                }))),
        new EntityPropertyValidator())
    {
        ValidId = GetAverageString(PostCommentBusinessConfigurations.ID_MAX_LENGTH, PostCommentBusinessConfigurations.ID_MIN_LENGTH);
        InvalidId = GetAverageString(PostCommentBusinessConfigurations.ID_MAX_LENGTH, PostCommentBusinessConfigurations.ID_MIN_LENGTH);
        ValidPostId = GetAverageString(PostCommentBusinessConfigurations.POST_ID_MAX_LENGTH, PostCommentBusinessConfigurations.POST_ID_MIN_LENGTH);
        InvalidPostId = GetAverageString(PostCommentBusinessConfigurations.POST_ID_MAX_LENGTH, PostCommentBusinessConfigurations.POST_ID_MIN_LENGTH);
        ValidPostTitle = GetAverageString(PostBusinessConfigurations.TITLE_MAX_LENGTH, PostBusinessConfigurations.TITLE_MIN_LENGTH);
        ValidPostContent = GetAverageString(PostBusinessConfigurations.CONTENT_MAX_LENGTH, PostBusinessConfigurations.CONTENT_MIN_LENGTH);
        ValidContent = GetAverageString(PostCommentBusinessConfigurations.CONTENT_MAX_LENGTH, PostCommentBusinessConfigurations.CONTENT_MIN_LENGTH);
        InvalidUserId = GetAverageString(PostCommentBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, PostCommentBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
        ValidUserName = GetAverageString(PostCommentBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostCommentBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidUserFirstName = GetAverageString(PostCommentBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostCommentBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidUserLastName = GetAverageString(PostCommentBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostCommentBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidUserEmail = GetAverageString(PostCommentBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostCommentBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidUserProfileImage = GetAverageString(PostCommentBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostCommentBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidCurrentUserId = GetAverageString(PostCommentBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, PostCommentBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
        ValidPostCommentPostId = GetAverageString(PostCommentBusinessConfigurations.POST_ID_MAX_LENGTH, PostCommentBusinessConfigurations.POST_ID_MIN_LENGTH);
        ValidPostCommentCurrentUserId = GetAverageString(PostCommentBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, PostCommentBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);

        UserWriteRepository = Substitute.For<IUserWriteRepository>();
        PostReadRepository = Substitute.For<IPostReadRepository>();
        PostWriteRepository = Substitute.For<IPostWriteRepository>();
        PostCommentReadRepository = Substitute.For<IPostCommentReadRepository>();
        PostCommentWriteRepository = Substitute.For<IPostCommentWriteRepository>();

        var existingUser = new User(
            ValidUserFirstName,
            ValidUserLastName,
            ValidUserEmail,
            ValidUserName,
            ValidUserProfileImage)
        {
            Id = ValidCurrentUserId,
        };

        var existingPostCommentUser = new User(
            ValidUserFirstName,
            ValidUserLastName,
            ValidUserEmail,
            ValidUserName,
            ValidUserProfileImage)
        {
            Id = ValidPostCommentCurrentUserId,
        };

        var existingPost = new Post(
            ValidPostTitle,
            ValidPostContent,
            ValidCurrentUserId)
        {
            Id = ValidPostId,
        };

        var existingPostCommentPost = new Post(
            ValidPostTitle,
            ValidPostContent,
            ValidCurrentUserId)
        {
            Id = ValidPostCommentPostId,
        };

        var existingPostComment = new PostComment(
            ValidPostCommentCurrentUserId,
            ValidPostCommentPostId,
            ValidContent)
        {
            Id = ValidId,
            User = existingPostCommentUser,
            Post = existingPostCommentPost
        };

        var existingPostCommentPaginationList = new PaginationList<PostComment>(
            [existingPostComment],
            ValidPageValue,
            ValidPageSizeValue,
            ValidTotalCountValue);

        PostCommentReadRepository.GetByIdAsync(
            ValidId,
            CancellationToken)
            .Returns(existingPostComment);

        PostCommentWriteRepository.GetByIdAsync(
            ValidId,
            CancellationToken)
            .Returns(existingPostComment);

        UserWriteRepository.GetByIdAsync(
            ValidCurrentUserId,
            CancellationToken)
            .Returns(existingUser);

        UserWriteRepository.GetByIdAsync(
            ValidPostCommentCurrentUserId,
            CancellationToken)
            .Returns(existingPostCommentUser);

        PostReadRepository.GetByIdAsync(
            ValidPostId,
            CancellationToken)
            .Returns(existingPost);

        PostReadRepository.GetByIdAsync(
            ValidPostCommentPostId,
            CancellationToken)
            .Returns(existingPostCommentPost);

        PostWriteRepository.GetByIdAsync(
            ValidPostId,
            CancellationToken)
            .Returns(existingPost);

        PostWriteRepository.GetByIdAsync(
            ValidPostCommentPostId,
            CancellationToken)
            .Returns(existingPostCommentPost);

        PostCommentReadRepository
            .GetAllAsync(Arg.Is<PostCommentCollectionReadQuery>(m =>
                                                                        m.PostId == ValidPostCommentPostId &&
                                                                        m.UserId == ValidPostCommentCurrentUserId &&
                                                                        m.UserName == ValidUserName &&
                                                                        m.Page == ValidPageValue &&
                                                                        m.PageSize == ValidPageSizeValue &&
                                                                        m.SortOrder == ValidSortOrderProperty &&
                                                                        m.SortPropertyName == ValidSortPropertyName), CancellationToken)
            .Returns(existingPostCommentPaginationList);
    }
}
