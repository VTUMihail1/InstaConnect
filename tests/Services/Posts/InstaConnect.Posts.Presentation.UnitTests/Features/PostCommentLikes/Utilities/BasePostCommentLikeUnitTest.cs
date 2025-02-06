using AutoMapper;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.AddPostCommentLike;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAllPostCommentLikes;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetPostCommentLikeById;
using InstaConnect.Posts.Common.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Common.Features.PostComments.Utilities;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Entitites;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Entitites;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entitites;
using InstaConnect.Posts.Domain.Features.Users.Models.Entitites;
using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Mappings;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Helpers;
using InstaConnect.Shared.Presentation.Abstractions;
using InstaConnect.Shared.Presentation.Helpers;
using InstaConnect.Shared.Presentation.Models.Users;
using InstaConnect.Shared.Presentation.UnitTests.Utilities;
using NSubstitute;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeUnitTest
{
    protected CancellationToken CancellationToken { get; }

    protected IInstaConnectSender InstaConnectSender { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    public BasePostCommentLikeUnitTest()
    {
        CancellationToken = new CancellationToken();
        InstaConnectSender = Substitute.For<IInstaConnectSender>();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<PostCommentLikeCommandProfile>();
                    cfg.AddProfile<PostCommentLikeQueryProfile>();
                })));
    }

    public User CreateUser()
    {
        var user = new User(
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidProfileImage);

        return user;
    }

    public Post CreatePost()
    {
        var user = CreateUser();
        var post = new Post(
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidContent,
            user);

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

        return postComment;
    }

    public PostCommentLike CreatePostCommentLike()
    {
        var user = CreateUser();
        var postComment = CreatePostComment();
        var postCommentLike = new PostCommentLike(postComment, user);

        var postCommentLikeQueryViewModel = new PostCommentLikeQueryViewModel(
            postCommentLike.Id,
            postComment.Id,
            user.Id,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidProfileImage);

        var postCommentLikeCommandViewModel = new PostCommentLikeCommandViewModel(postCommentLike.Id);
        var postCommentLikePaginationCollectionModel = new PostCommentLikePaginationQueryViewModel(
            [postCommentLikeQueryViewModel],
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue,
            PostCommentLikeTestUtilities.ValidTotalCountValue,
            false,
            false);

        InstaConnectSender
            .SendAsync(Arg.Is<GetAllPostCommentLikesQuery>(m =>
                  m.PostCommentId == postComment.Id &&
                  m.UserId == user.Id &&
                  m.UserName == UserTestUtilities.ValidName &&
                  m.SortOrder == PostCommentLikeTestUtilities.ValidSortOrderProperty &&
                  m.SortPropertyName == PostCommentLikeTestUtilities.ValidSortPropertyName &&
                  m.Page == PostCommentLikeTestUtilities.ValidPageValue &&
                  m.PageSize == PostCommentLikeTestUtilities.ValidPageSizeValue), CancellationToken)
            .Returns(postCommentLikePaginationCollectionModel);

        InstaConnectSender
            .SendAsync(Arg.Is<GetPostCommentLikeByIdQuery>(m => m.Id == postCommentLike.Id), CancellationToken)
            .Returns(postCommentLikeQueryViewModel);

        InstaConnectSender
            .SendAsync(Arg.Is<AddPostCommentLikeCommand>(m =>
                  m.CurrentUserId == user.Id &&
                  m.PostCommentId == postComment.Id), CancellationToken)
            .Returns(postCommentLikeCommandViewModel);

        return postCommentLike;
    }
}
