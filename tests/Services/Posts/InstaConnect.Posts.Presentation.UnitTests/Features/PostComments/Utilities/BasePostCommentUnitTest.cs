﻿using AutoMapper;
using InstaConnect.Posts.Application.Features.PostComments.Commands.AddPostComment;
using InstaConnect.Posts.Application.Features.PostComments.Commands.UpdatePostComment;
using InstaConnect.Posts.Application.Features.PostComments.Models;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAllPostComments;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetPostCommentById;
using InstaConnect.Posts.Common.Features.PostComments.Utilities;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Entitites;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entitites;
using InstaConnect.Posts.Domain.Features.Users.Models.Entitites;
using InstaConnect.Posts.Presentation.Features.PostComments.Mappings;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Helpers;
using InstaConnect.Shared.Presentation.Abstractions;
using InstaConnect.Shared.Presentation.Models.Users;
using InstaConnect.Shared.Presentation.UnitTests.Utilities;
using NSubstitute;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.PostComments.Utilities;

public abstract class BasePostCommentUnitTest
{
    protected IInstaConnectSender InstaConnectSender { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    protected CancellationToken CancellationToken { get; }

    public BasePostCommentUnitTest()
    {
        InstaConnectSender = Substitute.For<IInstaConnectSender>();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<PostCommentCommandProfile>();
                    cfg.AddProfile<PostCommentQueryProfile>();
                })));
        CancellationToken = new CancellationToken();
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
        var postComment = new PostComment(user, post, PostCommentTestUtilities.ValidContent);

        var postCommentQueryViewModel = new PostCommentQueryViewModel(
            postComment.Id,
            PostCommentTestUtilities.ValidContent,
            post.Id,
            user.Id,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidProfileImage);

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
                  m.UserName == UserTestUtilities.ValidName &&
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
                  m.Content == PostCommentTestUtilities.ValidUpdateContent), CancellationToken)
            .Returns(postCommentCommandViewModel);

        return postComment;
    }
}
