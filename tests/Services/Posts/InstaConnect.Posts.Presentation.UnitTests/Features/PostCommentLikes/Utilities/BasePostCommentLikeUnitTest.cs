using AutoMapper;

using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Helpers;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Add;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetById;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Entities;
using InstaConnect.Posts.Domain.Features.Posts.Models;
using InstaConnect.Posts.Presentation.Extensions;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeUnitTest
{
    protected CancellationToken CancellationToken { get; }

    protected IInstaConnectSender InstaConnectSender { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    protected BasePostCommentLikeUnitTest()
    {
        CancellationToken = new CancellationToken();
        InstaConnectSender = Substitute.For<IInstaConnectSender>();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg => cfg.AddMaps(PostPresentationReference.Assembly))));
    }

    private static User CreateUserUtil()
    {
        var user = new User(
            DataFaker.GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength),
            DataFaker.GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength),
            DataFaker.GetAverageString(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength),
            DataFaker.GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength),
            DataFaker.GetAverageString(UserConfigurations.ProfileImageMaxLength, UserConfigurations.ProfileImageMinLength));

        return user;
    }

    protected static User CreateUser()
    {
        var user = CreateUserUtil();

        return user;
    }

    private static Post CreatePostUtil(User user)
    {
        var post = new Post(
            DataFaker.GetAverageString(PostConfigurations.TitleMaxLength, PostConfigurations.TitleMinLength),
            DataFaker.GetAverageString(PostConfigurations.ContentMaxLength, PostConfigurations.ContentMinLength),
            user);

        return post;
    }

    protected static Post CreatePost()
    {
        var user = CreateUser();
        var post = CreatePostUtil(user);

        return post;
    }

    private static PostComment CreatePostCommentUtil(User user, Post post)
    {
        var postComment = new PostComment(
            user,
            post,
            DataFaker.GetAverageString(PostCommentConfigurations.ContentMaxLength, PostCommentConfigurations.ContentMinLength));

        return postComment;
    }

    protected static PostComment CreatePostComment()
    {
        var user = CreateUser();
        var post = CreatePost();
        var postComment = CreatePostCommentUtil(user, post);

        return postComment;
    }

    private PostCommentLike CreatePostCommentLikeUtil(User user, PostComment postComment)
    {
        var postCommentLike = new PostCommentLike(postComment, user);

        var postCommentLikeQueryViewModel = new PostCommentLikeQueryViewModel(
            postCommentLike.Id,
            postComment.Id,
            user.Id,
            user.UserName,
            user.ProfileImage);

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
                  m.UserName == user.UserName &&
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

    protected PostCommentLike CreatePostCommentLike()
    {
        var user = CreateUser();
        var postComment = CreatePostComment();
        var postCommentLike = CreatePostCommentLikeUtil(user, postComment);

        return postCommentLike;
    }
}
