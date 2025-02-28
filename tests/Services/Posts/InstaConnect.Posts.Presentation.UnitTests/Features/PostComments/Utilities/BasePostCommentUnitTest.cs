using AutoMapper;

using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Helpers;
using InstaConnect.Posts.Application.Features.PostComments.Commands.Add;
using InstaConnect.Posts.Application.Features.PostComments.Commands.Update;
using InstaConnect.Posts.Application.Features.PostComments.Models;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetById;
using InstaConnect.Posts.Common.Features.PostComments.Utilities;
using InstaConnect.Posts.Common.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Entities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;
using InstaConnect.Posts.Presentation.Extensions;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.PostComments.Utilities;

public abstract class BasePostCommentUnitTest
{
    protected IInstaConnectSender InstaConnectSender { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    protected CancellationToken CancellationToken { get; }

    protected BasePostCommentUnitTest()
    {
        InstaConnectSender = Substitute.For<IInstaConnectSender>();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg => cfg.AddMaps(PresentationReference.Assembly))));
        CancellationToken = new CancellationToken();
    }

    private static User CreateUserUtil()
    {
        var user = new User(
            SharedTestUtilities.GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.ProfileImageMaxLength, UserConfigurations.ProfileImageMinLength));

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
            SharedTestUtilities.GetAverageString(PostConfigurations.TitleMaxLength, PostConfigurations.TitleMinLength),
            SharedTestUtilities.GetAverageString(PostConfigurations.ContentMaxLength, PostConfigurations.ContentMinLength),
            user);

        return post;
    }

    protected static Post CreatePost()
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

        var postCommentQueryViewModel = new PostCommentQueryViewModel(
            postComment.Id,
            postComment.Content,
            post.Id,
            user.Id,
            user.UserName,
            user.ProfileImage);

        var postCommentCommandViewModel = new PostCommentCommandViewModel(postComment.Id);
        var postCommentPaginationCollectionModel = new PostCommentPaginationQueryViewModel(
            [postCommentQueryViewModel],
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue,
            PostCommentTestUtilities.ValidTotalCountValue,
            false,
            false);

        InstaConnectSender
            .SendAsync(Arg.Is<GetAllPostCommentsQuery>(m =>
                  m.PostId == post.Id &&
                  m.UserId == user.Id &&
                  m.UserName == user.UserName &&
                  m.SortOrder == PostCommentTestUtilities.ValidSortOrderProperty &&
                  m.SortPropertyName == PostCommentTestUtilities.ValidSortPropertyName &&
                  m.Page == PostCommentTestUtilities.ValidPageValue &&
                  m.PageSize == PostCommentTestUtilities.ValidPageSizeValue), CancellationToken)
            .Returns(postCommentPaginationCollectionModel);

        InstaConnectSender
            .SendAsync(Arg.Is<GetPostCommentByIdQuery>(m => m.Id == postComment.Id), CancellationToken)
            .Returns(postCommentQueryViewModel);

        InstaConnectSender
            .SendAsync(Arg.Is<AddPostCommentCommand>(m =>
                  m.CurrentUserId == user.Id &&
                  m.PostId == post.Id &&
                  m.Content == PostCommentTestUtilities.ValidAddContent), CancellationToken)
            .Returns(postCommentCommandViewModel);

        InstaConnectSender
            .SendAsync(Arg.Is<UpdatePostCommentCommand>(m =>
                  m.Id == postComment.Id &&
                  m.CurrentUserId == user.Id &&
                  m.Content == postComment.Content), CancellationToken)
            .Returns(postCommentCommandViewModel);

        return postComment;
    }

    protected PostComment CreatePostComment()
    {
        var user = CreateUser();
        var post = CreatePost();
        var postComment = CreatePostCommentUtil(user, post);

        return postComment;
    }
}
