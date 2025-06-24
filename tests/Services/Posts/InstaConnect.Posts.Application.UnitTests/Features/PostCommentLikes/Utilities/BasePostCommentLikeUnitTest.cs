using AutoMapper;

using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Application.Helpers;
using InstaConnect.Common.Domain.Models.Pagination;
using InstaConnect.Common.Helpers;
using InstaConnect.Posts.Application.Extensions;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Filters;
using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Filters;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Filters;
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

    protected IUserRepository UserWriteRepository { get; }

    protected IPostReadRepository PostReadRepository { get; }

    protected IPostWriteRepository PostWriteRepository { get; }

    protected IPostCommentLikeService PostCommentLikeService { get; }

    protected BasePostCommentLikeUnitTest()
    {
        UnitOfWork = Substitute.For<IUnitOfWork>();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg => cfg.AddMaps(PostApplicationReference.Assembly))));
        CancellationToken = new CancellationToken();
        EntityPropertyValidator = new EntityPropertyValidator();
        UserWriteRepository = Substitute.For<IUserRepository>();
        PostReadRepository = Substitute.For<IPostReadRepository>();
        PostWriteRepository = Substitute.For<IPostWriteRepository>();
        PostCommentLikeService = Substitute.For<IPostCommentLikeService>();
    }

    private User CreateUserUtil()
    {
        var user = UserTestUtilities.CreateUser();

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
        var post = PostTestUtilities.CreatePost(user, [], []);

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

    private static PostComment CreatePostCommentUtil(User user, Post post)
    {
        var postComment = PostCommentTestUtilities.CreatePostComment(user, post, []);

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
        var postCommentLike = PostCommentLikeTestUtilities.CreatePostCommentLike(user, postComment);

        var postLikePaginationList = new PaginationList<PostCommentLike>(
        [postCommentLike],
        PostCommentLikeTestUtilities.ValidPageValue,
        PostCommentLikeTestUtilities.ValidPageSizeValue,
        PostCommentLikeTestUtilities.ValidTotalCountValue);

        PostCommentLikeService.GetByIdAsync(
            postCommentLike.PostComment.Post,
            postCommentLike.PostCommentId,
            postCommentLike.PostComment.PostId, CancellationToken)
            .Returns(postCommentLike);

        PostCommentLikeService
            .GetAllAsync(postCommentLike.PostComment.Post, postCommentLike.PostCommentId, Arg.Is<PostCommentLikeCollectionReadQuery>(m => m.UserId == user.Id &&
                                                                        m.UserName == user.UserName &&
                                                                        m.Page == PostLikeTestUtilities.ValidPageValue &&
                                                                        m.PageSize == PostLikeTestUtilities.ValidPageSizeValue &&
                                                                        m.SortOrder == PostLikeTestUtilities.ValidSortOrderProperty &&
                                                                        m.SortPropertyName == PostLikeTestUtilities.ValidSortPropertyName), CancellationToken)
            .Returns(postLikePaginationList);

        return postCommentLike;
    }

    protected PostCommentLike CreatePostCommentLike()
    {
        var user = CreateUser();
        var postComment = CreatePostComment();
        var postCommentLike = CreatePostCommentLikeUtil(user, postComment);

        return postCommentLike;
    }

    protected PostCommentLike CreatePostCommentLikeFactory()
    {
        var user = CreateUser();

        var post = PostTestUtilities.CreatePost(user, [], []);
        var postComment = PostCommentTestUtilities.CreatePostComment(user, post, []);
        var postCommentLike = PostCommentLikeTestUtilities.CreatePostCommentLike(user, postComment);

        PostCommentLikeService.AddAsync(post, postCommentLike.Id, user.Id, CancellationToken)
            .Returns(postCommentLike);

        return postCommentLike;
    }
}
