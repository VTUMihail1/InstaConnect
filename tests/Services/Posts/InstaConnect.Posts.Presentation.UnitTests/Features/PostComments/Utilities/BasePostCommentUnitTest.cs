using AutoMapper;

using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Helpers;
using InstaConnect.Posts.Application.Features.PostComments.Commands.Add;
using InstaConnect.Posts.Application.Features.PostComments.Commands.Update;
using InstaConnect.Posts.Application.Features.PostComments.Models;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetById;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Entities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;
using InstaConnect.Posts.Domain.Features.Users.Utilities;
using InstaConnect.Posts.Presentation.Extensions;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.PostComments.Utilities;

public abstract class BasePostCommentUnitTest
{
    protected IApplicationSender ApplicationSender { get; }

    protected IApplicationMapper ApplicationMapper { get; }

    protected CancellationToken CancellationToken { get; }

    protected BasePostCommentUnitTest()
    {
        ApplicationSender = Substitute.For<IApplicationSender>();
        ApplicationMapper = new ApplicationMapper(
            new Mapper(
                new MapperConfiguration(cfg => cfg.AddMaps(PostPresentationReference.Assembly))));
        CancellationToken = new CancellationToken();
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

    private PostComment CreatePostCommentUtil(User user, Post post)
    {
        var postComment = new PostComment(
            user,
            post,
            DataFaker.GetAverageString(PostCommentConfigurations.ContentMaxLength, PostCommentConfigurations.ContentMinLength));

        var postCommentQueryViewModel = new PostCommentQueryViewModel(
            postComment.Id,
            postComment.Content,
            post.Id,
            user.Id,
            user.Name,
            user.ProfileImage);

        var postCommentCommandViewModel = new PostCommentCommandViewModel(postComment.Id);
        var postCommentPaginationCollectionModel = new PostCommentPaginationQueryViewModel(
            [postCommentQueryViewModel],
            PostCommentTestUtilities.ValidPageValue,
            PostCommentTestUtilities.ValidPageSizeValue,
            PostCommentTestUtilities.ValidTotalCountValue,
            false,
            false);

        ApplicationSender
            .SendAsync(Arg.Is<GetAllPostCommentsQuery>(m =>
                  m.PostId == post.Id &&
                  m.UserId == user.Id &&
                  m.UserName == user.Name &&
                  m.SortOrder == PostCommentTestUtilities.ValidSortOrderProperty &&
                  m.SortPropertyName == PostCommentTestUtilities.ValidSortPropertyName &&
                  m.Page == PostCommentTestUtilities.ValidPageValue &&
                  m.PageSize == PostCommentTestUtilities.ValidPageSizeValue), CancellationToken)
            .Returns(postCommentPaginationCollectionModel);

        ApplicationSender
            .SendAsync(Arg.Is<GetPostCommentByIdQuery>(m => m.Id == postComment.Id), CancellationToken)
            .Returns(postCommentQueryViewModel);

        ApplicationSender
            .SendAsync(Arg.Is<AddPostCommentCommand>(m =>
                  m.CurrentUserId == user.Id &&
                  m.PostId == post.Id &&
                  m.Content == PostCommentTestUtilities.ValidAddContent), CancellationToken)
            .Returns(postCommentCommandViewModel);

        ApplicationSender
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
