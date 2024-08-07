using AutoMapper;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Mappings;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Business.Features.PostComments.Utilities;
using InstaConnect.Posts.Business.Features.PostLikes.Utilities;
using InstaConnect.Posts.Data.Features.PostCommentLikes.Abstract;
using InstaConnect.Posts.Data.Features.PostCommentLikes.Models.Entitites;
using InstaConnect.Posts.Data.Features.PostCommentLikes.Models.Filters;
using InstaConnect.Posts.Data.Features.PostComments.Abstract;
using InstaConnect.Posts.Data.Features.PostComments.Models.Entitites;
using InstaConnect.Posts.Data.Features.Users.Abstract;
using InstaConnect.Posts.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Business.UnitTests.Utilities;
using InstaConnect.Shared.Data.Abstractions;
using InstaConnect.Shared.Data.Models.Pagination;
using NSubstitute;

namespace InstaConnect.Posts.Business.UnitTests.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeUnitTest : BaseSharedUnitTest
{
    protected readonly string ValidId;
    protected readonly string InvalidId;
    protected readonly string ValidPostCommentId;
    protected readonly string InvalidPostCommentId;
    protected readonly string ValidPostCommentContent;
    protected readonly string ValidCurrentUserId;
    protected readonly string InvalidUserId;
    protected readonly string ValidUserName;
    protected readonly string ValidUserFirstName;
    protected readonly string ValidUserEmail;
    protected readonly string ValidUserLastName;
    protected readonly string ValidUserProfileImage;
    protected readonly string ValidPostCommentLikePostCommentId;
    protected readonly string ValidPostCommentLikeCurrentUserId;

    protected IUserReadRepository UserReadRepository { get; }

    protected IUserWriteRepository UserWriteRepository { get; }

    protected IPostCommentReadRepository PostCommentReadRepository { get; }

    protected IPostCommentWriteRepository PostCommentWriteRepository { get; }

    protected IPostCommentLikeReadRepository PostCommentLikeReadRepository { get; }

    protected IPostCommentLikeWriteRepository PostCommentLikeWriteRepository { get; }

    public BasePostCommentLikeUnitTest() : base(
        Substitute.For<IUnitOfWork>(),
        new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<PostCommentLikeQueryProfile>();
                    cfg.AddProfile<PostCommentLikeCommandProfile>();
                }))),
        new EntityPropertyValidator())
    {
        ValidId = GetAverageString(PostCommentLikeBusinessConfigurations.ID_MAX_LENGTH, PostCommentLikeBusinessConfigurations.ID_MIN_LENGTH);
        InvalidId = GetAverageString(PostCommentLikeBusinessConfigurations.ID_MAX_LENGTH, PostCommentLikeBusinessConfigurations.ID_MIN_LENGTH);
        ValidPostCommentId = GetAverageString(PostCommentLikeBusinessConfigurations.POST_COMMENT_ID_MAX_LENGTH, PostCommentLikeBusinessConfigurations.POST_COMMENT_ID_MIN_LENGTH);
        InvalidPostCommentId = GetAverageString(PostCommentLikeBusinessConfigurations.POST_COMMENT_ID_MAX_LENGTH, PostCommentLikeBusinessConfigurations.POST_COMMENT_ID_MIN_LENGTH);
        ValidPostCommentContent = GetAverageString(PostCommentBusinessConfigurations.CONTENT_MAX_LENGTH, PostCommentBusinessConfigurations.CONTENT_MIN_LENGTH);
        InvalidUserId = GetAverageString(PostCommentLikeBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
        ValidUserName = GetAverageString(PostCommentLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidUserFirstName = GetAverageString(PostCommentLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidUserLastName = GetAverageString(PostCommentLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidUserEmail = GetAverageString(PostCommentLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidUserProfileImage = GetAverageString(PostCommentLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidCurrentUserId = GetAverageString(PostCommentLikeBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
        ValidPostCommentLikePostCommentId = GetAverageString(PostCommentLikeBusinessConfigurations.POST_COMMENT_ID_MAX_LENGTH, PostCommentLikeBusinessConfigurations.POST_COMMENT_ID_MIN_LENGTH);
        ValidPostCommentLikeCurrentUserId = GetAverageString(PostCommentLikeBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, PostCommentLikeBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);

        UserReadRepository = Substitute.For<IUserReadRepository>();
        UserWriteRepository = Substitute.For<IUserWriteRepository>();
        PostCommentReadRepository = Substitute.For<IPostCommentReadRepository>();
        PostCommentWriteRepository = Substitute.For<IPostCommentWriteRepository>();
        PostCommentLikeReadRepository = Substitute.For<IPostCommentLikeReadRepository>();
        PostCommentLikeWriteRepository = Substitute.For<IPostCommentLikeWriteRepository>();

        PostCommentLikeWriteRepository.When(x => x.Add(Arg.Is<PostCommentLike>(m => m.UserId == ValidCurrentUserId &&
                                                                                    m.PostCommentId == ValidPostCommentId)))
                         .Do(ci =>
                              {
                                  var postCommentLike = ci.Arg<PostCommentLike>();
                                  postCommentLike.Id = ValidId;
                              });

        var existingUser = new User(
            ValidUserFirstName,
            ValidUserLastName,
            ValidUserEmail,
            ValidUserName,
            ValidUserProfileImage)
        {
            Id = ValidCurrentUserId,
        };

        var existingPostCommentLikeUser = new User(
            ValidUserFirstName,
            ValidUserLastName,
            ValidUserEmail,
            ValidUserName,
            ValidUserProfileImage)
        {
            Id = ValidPostCommentLikeCurrentUserId,
        };

        var existingPostComment = new PostComment(
            ValidPostCommentLikeCurrentUserId,
            ValidPostCommentLikePostCommentId,
            ValidPostCommentContent
            )
        {
            Id = ValidPostCommentId,
            User = existingPostCommentLikeUser
        };

        var existingPostCommentLikePostComment = new PostComment(
            ValidPostCommentLikeCurrentUserId,
            ValidPostCommentLikePostCommentId,
            ValidPostCommentContent
            )
        {
            Id = ValidPostCommentLikePostCommentId,
            User = existingPostCommentLikeUser,
        };

        var existingPostCommentLike = new PostCommentLike(
            ValidPostCommentLikePostCommentId,
            ValidPostCommentLikeCurrentUserId)
        {
            Id = ValidId,
            User = existingPostCommentLikeUser,
            PostComment = existingPostCommentLikePostComment,
        };

        var existingPostCommentLikePaginationList = new PaginationList<PostCommentLike>(
            [existingPostCommentLike],
            ValidPageValue,
            ValidPageSizeValue,
            ValidTotalCountValue);

        UserReadRepository.GetByIdAsync(
            ValidCurrentUserId,
            CancellationToken)
            .Returns(existingUser);

        UserReadRepository.GetByIdAsync(
            ValidPostCommentLikeCurrentUserId,
            CancellationToken)
            .Returns(existingPostCommentLikeUser);

        UserWriteRepository.GetByIdAsync(
            ValidCurrentUserId,
            CancellationToken)
            .Returns(existingUser);

        UserWriteRepository.GetByIdAsync(
            ValidPostCommentLikeCurrentUserId,
            CancellationToken)
            .Returns(existingPostCommentLikeUser);

        PostCommentReadRepository.GetByIdAsync(
            ValidPostCommentId,
            CancellationToken)
            .Returns(existingPostComment);

        PostCommentWriteRepository.GetByIdAsync(
            ValidPostCommentId,
            CancellationToken)
            .Returns(existingPostComment);

        PostCommentReadRepository.GetByIdAsync(
            ValidPostCommentLikePostCommentId,
            CancellationToken)
            .Returns(existingPostCommentLikePostComment);

        PostCommentWriteRepository.GetByIdAsync(
            ValidPostCommentLikePostCommentId,
            CancellationToken)
            .Returns(existingPostCommentLikePostComment);

        PostCommentLikeReadRepository.GetByIdAsync(
            ValidId,
            CancellationToken)
            .Returns(existingPostCommentLike);

        PostCommentLikeWriteRepository.GetByIdAsync(
            ValidId,
            CancellationToken)
            .Returns(existingPostCommentLike);

        PostCommentLikeReadRepository.GetByUserIdAndPostCommentIdAsync(
            ValidPostCommentLikeCurrentUserId,
            ValidPostCommentLikePostCommentId,
            CancellationToken)
            .Returns(existingPostCommentLike);

        PostCommentLikeWriteRepository.GetByUserIdAndPostCommentIdAsync(
            ValidPostCommentLikeCurrentUserId,
            ValidPostCommentLikePostCommentId,
            CancellationToken)
            .Returns(existingPostCommentLike);

        PostCommentLikeReadRepository
            .GetAllAsync(Arg.Is<PostCommentLikeFilteredCollectionReadQuery>(m =>
                                                                        m.Page == ValidPageValue &&
                                                                        m.PageSize == ValidPageSizeValue &&
                                                                        m.SortOrder == ValidSortOrderProperty &&
                                                                        m.SortPropertyName == ValidSortPropertyName), CancellationToken)
            .Returns(existingPostCommentLikePaginationList);
    }
}
