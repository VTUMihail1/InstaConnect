using AutoMapper;
using InstaConnect.Follows.Business.Features.Follows.Utilities;
using InstaConnect.Posts.Business.Features.PostLikes.Mappings;
using InstaConnect.Posts.Business.Features.Posts.Mappings;
using InstaConnect.Posts.Data.Features.PostLikes.Abstract;
using InstaConnect.Posts.Data.Features.PostLikes.Models.Entitites;
using InstaConnect.Posts.Data.Features.PostLikes.Models.Filters;
using InstaConnect.Posts.Data.Features.Posts.Abstract;
using InstaConnect.Posts.Data.Features.Posts.Models.Entitites;
using InstaConnect.Posts.Data.Features.Posts.Models.Filters;
using InstaConnect.Posts.Data.Features.Users.Abstract;
using InstaConnect.Posts.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Business.UnitTests.Utilities;
using InstaConnect.Shared.Data.Abstractions;
using InstaConnect.Shared.Data.Models.Filters;
using InstaConnect.Shared.Data.Models.Pagination;
using NSubstitute;

namespace InstaConnect.Follows.Business.UnitTests.Features.Follows.Utilities;

public abstract class BasePostLikeUnitTest : BaseSharedUnitTest
{
    protected readonly string ValidId;
    protected readonly string InvalidId;
    protected readonly string ValidPostId;
    protected readonly string InvalidPostId;
    protected readonly string ValidTitle;
    protected readonly string ValidContent;
    protected readonly string ValidCurrentUserId;
    protected readonly string InvalidUserId;
    protected readonly string ValidUserName;
    protected readonly string ValidUserFirstName;
    protected readonly string ValidUserEmail;
    protected readonly string ValidUserLastName;
    protected readonly string ValidUserProfileImage;
    protected readonly string ValidPostLikePostId;
    protected readonly string ValidPostLikeCurrentUserId;

    protected IUserReadRepository UserReadRepository { get; }

    protected IUserWriteRepository UserWriteRepository { get; }

    protected IPostReadRepository PostReadRepository { get; }

    protected IPostWriteRepository PostWriteRepository { get; }

    protected IPostLikeReadRepository PostLikeReadRepository { get; }

    protected IPostLikeWriteRepository PostLikeWriteRepository { get; }

    public BasePostLikeUnitTest() : base(
        Substitute.For<IUnitOfWork>(),
        new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<PostLikeQueryProfile>();
                    cfg.AddProfile<PostLikeCommandProfile>();
                }))),
        new EntityPropertyValidator())
    {
        ValidId = GetAverageString(PostLikeBusinessConfigurations.ID_MAX_LENGTH, PostLikeBusinessConfigurations.ID_MIN_LENGTH);
        InvalidId = GetAverageString(PostLikeBusinessConfigurations.ID_MAX_LENGTH, PostLikeBusinessConfigurations.ID_MIN_LENGTH);
        ValidPostId = GetAverageString(PostLikeBusinessConfigurations.POST_ID_MAX_LENGTH, PostLikeBusinessConfigurations.POST_ID_MIN_LENGTH);
        InvalidPostId = GetAverageString(PostLikeBusinessConfigurations.POST_ID_MAX_LENGTH, PostLikeBusinessConfigurations.POST_ID_MIN_LENGTH);
        ValidTitle = GetAverageString(PostBusinessConfigurations.TITLE_MAX_LENGTH, PostBusinessConfigurations.TITLE_MIN_LENGTH);
        ValidContent = GetAverageString(PostBusinessConfigurations.CONTENT_MAX_LENGTH, PostBusinessConfigurations.CONTENT_MIN_LENGTH);
        InvalidUserId = GetAverageString(PostLikeBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
        ValidUserName = GetAverageString(PostLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidUserFirstName = GetAverageString(PostLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidUserLastName = GetAverageString(PostLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidUserEmail = GetAverageString(PostLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidUserProfileImage = GetAverageString(PostLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidCurrentUserId = GetAverageString(PostLikeBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
        ValidPostLikePostId = GetAverageString(PostLikeBusinessConfigurations.POST_ID_MAX_LENGTH, PostLikeBusinessConfigurations.POST_ID_MIN_LENGTH);
        ValidPostLikeCurrentUserId = GetAverageString(PostLikeBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);

        UserReadRepository = Substitute.For<IUserReadRepository>();
        UserWriteRepository = Substitute.For<IUserWriteRepository>();
        PostReadRepository = Substitute.For<IPostReadRepository>();
        PostWriteRepository = Substitute.For<IPostWriteRepository>();
        PostLikeReadRepository = Substitute.For<IPostLikeReadRepository>();
        PostLikeWriteRepository = Substitute.For<IPostLikeWriteRepository>();

        PostLikeWriteRepository.When(x => x.Add(Arg.Is<PostLike>(m => m.UserId == ValidCurrentUserId &&
                                                                      m.PostId == ValidPostId)))
                         .Do(ci =>
                              {
                                  var postLike = ci.Arg<PostLike>();
                                  postLike.Id = ValidId;
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

        var existingPostLikeUser = new User(
            ValidUserFirstName,
            ValidUserLastName,
            ValidUserEmail,
            ValidUserName,
            ValidUserProfileImage)
        {
            Id = ValidPostLikeCurrentUserId,
        };

        var existingPost = new Post(
            ValidTitle,
            ValidContent,
            ValidPostLikeCurrentUserId)
        {
            Id = ValidPostId,
            User = existingPostLikeUser,
        };

        var existingPostLikePost = new Post(
            ValidTitle,
            ValidContent,
            ValidPostLikeCurrentUserId)
        {
            Id = ValidPostLikePostId,
            User = existingPostLikeUser,
        };

        var existingPostLike = new PostLike(
            ValidPostLikePostId,
            ValidPostLikeCurrentUserId)
        {
            Id = ValidId,
            User = existingPostLikeUser,
            Post = existingPostLikePost,
        };

        var existingPostLikePaginationList = new PaginationList<PostLike>(
            [existingPostLike],
            ValidPageValue,
            ValidPageSizeValue,
            ValidTotalCountValue);

        UserReadRepository.GetByIdAsync(
            ValidCurrentUserId,
            CancellationToken)
            .Returns(existingUser);

        UserReadRepository.GetByIdAsync(
            ValidPostLikeCurrentUserId,
            CancellationToken)
            .Returns(existingPostLikeUser);

        UserWriteRepository.GetByIdAsync(
            ValidCurrentUserId,
            CancellationToken)
            .Returns(existingUser);

        UserWriteRepository.GetByIdAsync(
            ValidPostLikeCurrentUserId,
            CancellationToken)
            .Returns(existingPostLikeUser);

        PostReadRepository.GetByIdAsync(
            ValidPostId,
            CancellationToken)
            .Returns(existingPost);

        PostWriteRepository.GetByIdAsync(
            ValidPostId,
            CancellationToken)
            .Returns(existingPost);

        PostReadRepository.GetByIdAsync(
            ValidPostLikePostId,
            CancellationToken)
            .Returns(existingPostLikePost);

        PostWriteRepository.GetByIdAsync(
            ValidPostLikePostId,
            CancellationToken)
            .Returns(existingPostLikePost);

        PostLikeReadRepository.GetByIdAsync(
            ValidId,
            CancellationToken)
            .Returns(existingPostLike);

        PostLikeWriteRepository.GetByIdAsync(
            ValidId,
            CancellationToken)
            .Returns(existingPostLike);

        PostLikeReadRepository.GetByUserIdAndPostIdAsync(
            ValidPostLikeCurrentUserId,
            ValidPostLikePostId,
            CancellationToken)
            .Returns(existingPostLike);

        PostLikeWriteRepository.GetByUserIdAndPostIdAsync(
            ValidPostLikeCurrentUserId,
            ValidPostLikePostId,
            CancellationToken)
            .Returns(existingPostLike);

        PostLikeReadRepository
            .GetAllFilteredAsync(Arg.Is<PostLikeFilteredCollectionReadQuery>(m =>
                                                                        m.Page == ValidPageValue &&
                                                                        m.PageSize == ValidPageSizeValue &&
                                                                        m.SortOrder == ValidSortOrderProperty &&
                                                                        m.SortPropertyName == ValidSortPropertyName), CancellationToken)
            .Returns(existingPostLikePaginationList);

        PostLikeReadRepository
            .GetAllAsync(Arg.Is<PostLikeCollectionReadQuery>(m =>
                                                                        m.Page == ValidPageValue &&
                                                                        m.PageSize == ValidPageSizeValue &&
                                                                        m.SortOrder == ValidSortOrderProperty &&
                                                                        m.SortPropertyName == ValidSortPropertyName), CancellationToken)
            .Returns(existingPostLikePaginationList);
    }
}
