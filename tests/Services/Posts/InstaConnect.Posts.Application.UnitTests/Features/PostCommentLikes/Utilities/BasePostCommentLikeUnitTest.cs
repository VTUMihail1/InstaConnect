using AutoMapper;

using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Application.Helpers;
using InstaConnect.Common.Domain.Models.Pagination;
using InstaConnect.Common.Helpers;
using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Application.Extensions;
using InstaConnect.Posts.Common.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Common.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Filters;
using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Filters;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeUnitTest
{
    protected IUnitOfWork UnitOfWork { get; }

    protected CancellationToken CancellationToken { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    protected IEntityPropertyValidator EntityPropertyValidator { get; }

    protected IUserWriteRepository UserWriteRepository { get; }

    protected IPostReadRepository PostReadRepository { get; }

    protected IPostWriteRepository PostWriteRepository { get; }

    protected IPostCommentReadRepository PostCommentReadRepository { get; }

    protected IPostCommentWriteRepository PostCommentWriteRepository { get; }

    protected IPostCommentLikeReadRepository PostCommentLikeReadRepository { get; }

    protected IPostCommentLikeWriteRepository PostCommentLikeWriteRepository { get; }

    protected BasePostCommentLikeUnitTest()
    {
        UnitOfWork = Substitute.For<IUnitOfWork>();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg => cfg.AddMaps(ApplicationReference.Assembly))));
        CancellationToken = new CancellationToken();
        EntityPropertyValidator = new EntityPropertyValidator();
        UserWriteRepository = Substitute.For<IUserWriteRepository>();
        PostReadRepository = Substitute.For<IPostReadRepository>();
        PostWriteRepository = Substitute.For<IPostWriteRepository>();
        PostCommentReadRepository = Substitute.For<IPostCommentReadRepository>();
        PostCommentWriteRepository = Substitute.For<IPostCommentWriteRepository>();
        PostCommentLikeReadRepository = Substitute.For<IPostCommentLikeReadRepository>();
        PostCommentLikeWriteRepository = Substitute.For<IPostCommentLikeWriteRepository>();
    }

    private User CreateUserUtil()
    {
        var user = new User(
            SharedTestUtilities.GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.ProfileImageMaxLength, UserConfigurations.ProfileImageMinLength));

        UserWriteRepository.GetByIdAsync(user.Id, CancellationToken)
            .Returns(user);

        return user;
    }

    protected User CreateUser()
    {
        var user = CreateUserUtil();

        return user;
    }

    private Post CreatePostUtil(User user)
    {
        var post = new Post(
            SharedTestUtilities.GetAverageString(PostConfigurations.TitleMaxLength, PostConfigurations.TitleMinLength),
            SharedTestUtilities.GetAverageString(PostConfigurations.ContentMaxLength, PostConfigurations.ContentMinLength),
            user);

        PostWriteRepository.GetByIdAsync(
            post.Id,
            CancellationToken)
            .Returns(post);

        return post;
    }

    protected Post CreatePost()
    {
        var user = CreateUser();
        var post = CreatePostUtil(user);

        return post;
    }

    private PostComment CreatePostCommentUtil(User user, Post post)
    {
        var postComment = new PostComment(
            user,
            post,
            SharedTestUtilities.GetAverageString(PostCommentConfigurations.ContentMaxLength, PostCommentConfigurations.ContentMinLength));

        var postCommentPaginationList = new PaginationList<PostComment>(
        [postComment],
        PostCommentTestUtilities.ValidPageValue,
        PostCommentTestUtilities.ValidPageSizeValue,
        PostCommentTestUtilities.ValidTotalCountValue);

        PostCommentWriteRepository.GetByIdAsync(postComment.Id, CancellationToken)
            .Returns(postComment);

        PostCommentReadRepository.GetByIdAsync(postComment.Id, CancellationToken)
            .Returns(postComment);

        PostCommentReadRepository
            .GetAllAsync(Arg.Is<PostCommentCollectionReadQuery>(m =>
                                                                        m.UserId == user.Id &&
                                                                        m.UserName == user.UserName &&
                                                                        m.PostId == post.Id &&
                                                                        m.Page == PostCommentTestUtilities.ValidPageValue &&
                                                                        m.PageSize == PostCommentTestUtilities.ValidPageSizeValue &&
                                                                        m.SortOrder == PostCommentTestUtilities.ValidSortOrderProperty &&
                                                                        m.SortPropertyName == PostCommentTestUtilities.ValidSortPropertyName), CancellationToken)
            .Returns(postCommentPaginationList);

        return postComment;
    }

    protected PostComment CreatePostComment()
    {
        var user = CreateUser();
        var post = CreatePost();
        var postComment = CreatePostCommentUtil(user, post);

        return postComment;
    }

    private PostCommentLike CreatePostCommentLikeUtil(User user, PostComment postComment)
    {
        var postCommentLike = new PostCommentLike(postComment, user);

        var postCommentLikePaginationList = new PaginationList<PostCommentLike>(
        [postCommentLike],
        PostCommentLikeTestUtilities.ValidPageValue,
        PostCommentLikeTestUtilities.ValidPageSizeValue,
        PostCommentLikeTestUtilities.ValidTotalCountValue);

        PostCommentLikeReadRepository.GetByIdAsync(postCommentLike.Id, CancellationToken)
            .Returns(postCommentLike);

        PostCommentLikeWriteRepository.GetByIdAsync(postCommentLike.Id, CancellationToken)
            .Returns(postCommentLike);

        PostCommentLikeWriteRepository.GetByUserIdAndPostCommentIdAsync(user.Id, postComment.Id, CancellationToken)
            .Returns(postCommentLike);

        PostCommentLikeReadRepository
            .GetAllAsync(Arg.Is<PostCommentLikeCollectionReadQuery>(m =>
                                                                        m.UserId == user.Id &&
                                                                        m.UserName == user.UserName &&
                                                                        m.PostCommentId == postComment.Id &&
                                                                        m.Page == PostCommentLikeTestUtilities.ValidPageValue &&
                                                                        m.PageSize == PostCommentLikeTestUtilities.ValidPageSizeValue &&
                                                                        m.SortOrder == PostCommentLikeTestUtilities.ValidSortOrderProperty &&
                                                                        m.SortPropertyName == PostCommentLikeTestUtilities.ValidSortPropertyName), CancellationToken)
            .Returns(postCommentLikePaginationList);

        return postCommentLike;
    }

    protected PostCommentLike CreatePostCommentLike()
    {
        var user = CreateUser();
        var postComment = CreatePostComment();
        var postCommentLike = CreatePostCommentLikeUtil(user, postComment);

        return postCommentLike;
    }
}
