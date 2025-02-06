using AutoMapper;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Mappings;
using InstaConnect.Posts.Common.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Common.Features.PostComments.Utilities;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstract;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Entitites;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Filters;
using InstaConnect.Posts.Domain.Features.PostComments.Abstract;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Entitites;
using InstaConnect.Posts.Domain.Features.Posts.Abstract;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entitites;
using InstaConnect.Posts.Domain.Features.Users.Abstract;
using InstaConnect.Posts.Domain.Features.Users.Models.Entitites;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Helpers;
using InstaConnect.Shared.Application.UnitTests.Utilities;
using InstaConnect.Shared.Domain.Models.Pagination;
using NSubstitute;

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

    public BasePostCommentLikeUnitTest()
    {
        UnitOfWork = Substitute.For<IUnitOfWork>();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<PostCommentLikeQueryProfile>();
                    cfg.AddProfile<PostCommentLikeCommandProfile>();
                })));
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

    public User CreateUser()
    {
        var user = new User(
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidProfileImage);

        UserWriteRepository.GetByIdAsync(user.Id, CancellationToken)
            .Returns(user);

        return user;
    }

    public Post CreatePost()
    {
        var user = CreateUser();
        var post = new Post(
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidContent,
            user);

        PostReadRepository.GetByIdAsync(post.Id, CancellationToken)
            .Returns(post);

        PostWriteRepository.GetByIdAsync(post.Id, CancellationToken)
            .Returns(post);

        return post;
    }

    public PostComment CreatePostComment()
    {
        var user = CreateUser();
        var post = CreatePost();
        var postComment = new PostComment(
            user,
            post,
            PostCommentTestUtilities.ValidContent);

        PostCommentReadRepository.GetByIdAsync(postComment.Id, CancellationToken)
            .Returns(postComment);

        PostCommentWriteRepository.GetByIdAsync(postComment.Id, CancellationToken)
            .Returns(postComment);

        return postComment;
    }

    public PostCommentLike CreatePostCommentLike()
    {
        var user = CreateUser();
        var postComment = CreatePostComment();
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
                                                                        m.UserName == UserTestUtilities.ValidName &&
                                                                        m.PostCommentId == postComment.Id &&
                                                                        m.Page == PostCommentLikeTestUtilities.ValidPageValue &&
                                                                        m.PageSize == PostCommentLikeTestUtilities.ValidPageSizeValue &&
                                                                        m.SortOrder == PostCommentLikeTestUtilities.ValidSortOrderProperty &&
                                                                        m.SortPropertyName == PostCommentLikeTestUtilities.ValidSortPropertyName), CancellationToken)
            .Returns(postCommentLikePaginationList);

        return postCommentLike;
    }
}
