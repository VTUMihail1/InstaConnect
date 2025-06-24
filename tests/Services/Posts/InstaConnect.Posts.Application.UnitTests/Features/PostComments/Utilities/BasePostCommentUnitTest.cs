using AutoMapper;

using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Application.Helpers;
using InstaConnect.Common.Domain.Models.Pagination;
using InstaConnect.Common.Helpers;
using InstaConnect.Posts.Application.Extensions;
using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Filters;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Filters;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostComments.Utilities;

public abstract class BasePostCommentUnitTest
{
    protected IUnitOfWork UnitOfWork { get; }

    protected CancellationToken CancellationToken { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    protected IEntityPropertyValidator EntityPropertyValidator { get; }

    protected IUserRepository UserWriteRepository { get; }

    protected IPostWriteRepository PostWriteRepository { get; }

    protected IPostCommentService PostCommentService { get; }

    protected BasePostCommentUnitTest()
    {
        UnitOfWork = Substitute.For<IUnitOfWork>();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg => cfg.AddMaps(PostApplicationReference.Assembly))));
        EntityPropertyValidator = new EntityPropertyValidator();
        CancellationToken = new CancellationToken();
        UserWriteRepository = Substitute.For<IUserRepository>();
        PostWriteRepository = Substitute.For<IPostWriteRepository>();
        PostCommentService = Substitute.For<IPostCommentService>();
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

    private PostComment CreatePostCommentUtil(User user, Post post)
    {
        var postComment = PostCommentTestUtilities.CreatePostComment(
            user,
            post,
            []);

        var postCommentPaginationList = new PaginationList<PostComment>(
        [postComment],
        PostCommentTestUtilities.ValidPageValue,
        PostCommentTestUtilities.ValidPageSizeValue,
        PostCommentTestUtilities.ValidTotalCountValue);

        PostCommentService.GetByIdAsync(post, postComment.Id, CancellationToken)
            .Returns(postComment);

        PostCommentService
            .GetAllAsync(post, Arg.Is<PostCommentCollectionReadQuery>(m =>
                                                                        m.PostId == post.Id &&
                                                                        m.UserId == user.Id &&
                                                                        m.UserName == user.UserName &&
                                                                        m.Page == PostLikeTestUtilities.ValidPageValue &&
                                                                        m.PageSize == PostLikeTestUtilities.ValidPageSizeValue &&
                                                                        m.SortOrder == PostLikeTestUtilities.ValidSortOrderProperty &&
                                                                        m.SortPropertyName == PostLikeTestUtilities.ValidSortPropertyName), CancellationToken)
            .Returns(postCommentPaginationList);

        PostCommentService
            .When(x => x.UpdateAsync(
                post,
                postComment.Id,
                postComment.UserId,
                PostCommentTestUtilities.ValidUpdateContent,
                CancellationToken))
            .Do(call =>
            {
                var updatedPostComment = call.Arg<PostComment>();
                updatedPostComment.Update(PostCommentTestUtilities.ValidUpdateContent, PostCommentTestUtilities.ValidUpdateUpdatedAtUtc);
            });

        return postComment;
    }

    protected PostComment CreatePostComment()
    {
        var user = CreateUser();
        var post = CreatePost();
        var postComment = CreatePostCommentUtil(user, post);

        return postComment;
    }

    protected PostComment CreatePostCommentFactory()
    {
        var user = CreateUser();

        var post = PostTestUtilities.CreatePost(user, [], []);
        var postComment = PostCommentTestUtilities.CreatePostComment(user, post, []);

        PostCommentService.Add(post, PostCommentTestUtilities.ValidAddContent, user.Id)
            .Returns(postComment);

        return postComment;
    }
}
