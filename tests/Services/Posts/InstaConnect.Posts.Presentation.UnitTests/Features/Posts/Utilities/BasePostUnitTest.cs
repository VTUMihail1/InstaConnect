﻿using AutoMapper;
using InstaConnect.Posts.Application.Features.Posts.Commands.AddPost;
using InstaConnect.Posts.Application.Features.Posts.Commands.UpdatePost;
using InstaConnect.Posts.Application.Features.Posts.Models;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAllPosts;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetPostById;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entitites;
using InstaConnect.Posts.Domain.Features.Users.Models.Entitites;
using InstaConnect.Posts.Presentation.Features.Posts.Mappings;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Helpers;
using InstaConnect.Shared.Common.Utilities;
using NSubstitute;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.Posts.Utilities;

public abstract class BasePostUnitTest
{
    protected CancellationToken CancellationToken { get; }

    protected IInstaConnectSender InstaConnectSender { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    public BasePostUnitTest()
    {
        CancellationToken = new();
        InstaConnectSender = Substitute.For<IInstaConnectSender>();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<PostCommandProfile>();
                    cfg.AddProfile<PostQueryProfile>();
                })));
    }

    public User CreateUser()
    {
        var user = new User(
            SharedTestUtilities.GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.ProfileImageMaxLength, UserConfigurations.ProfileImageMinLength));

        return user;
    }

    public Post CreatePost()
    {
        var user = CreateUser();
        var post = new Post(
            SharedTestUtilities.GetAverageString(PostConfigurations.TitleMaxLength, PostConfigurations.TitleMinLength),
            SharedTestUtilities.GetAverageString(PostConfigurations.ContentMaxLength, PostConfigurations.ContentMinLength),
            user);

        var postQueryViewModel = new PostQueryViewModel(
            post.Id,
            post.Title,
            post.Content,
            user.Id,
            user.UserName,
            user.ProfileImage);

        var postCommandViewModel = new PostCommandViewModel(post.Id);
        var postPaginationCollectionModel = new PostPaginationQueryViewModel(
            [postQueryViewModel],
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue,
            PostTestUtilities.ValidTotalCountValue,
            false,
            false);

        InstaConnectSender
            .SendAsync(Arg.Is<GetAllPostsQuery>(m =>
                  m.Title == post.Title &&
                  m.UserId == user.Id &&
                  m.UserName == user.UserName &&
                  m.SortOrder == PostTestUtilities.ValidSortOrderProperty &&
                  m.SortPropertyName == PostTestUtilities.ValidSortPropertyName &&
                  m.Page == PostTestUtilities.ValidPageValue &&
                  m.PageSize == PostTestUtilities.ValidPageSizeValue), CancellationToken)
            .Returns(postPaginationCollectionModel);

        InstaConnectSender
            .SendAsync(Arg.Is<GetPostByIdQuery>(m => m.Id == post.Id), CancellationToken)
            .Returns(postQueryViewModel);

        InstaConnectSender
            .SendAsync(Arg.Is<AddPostCommand>(m =>
                  m.CurrentUserId == user.Id &&
                  m.Title == PostTestUtilities.ValidAddTitle &&
                  m.Content == PostTestUtilities.ValidAddContent), CancellationToken)
            .Returns(postCommandViewModel);

        InstaConnectSender
            .SendAsync(Arg.Is<UpdatePostCommand>(m =>
                  m.Id == post.Id &&
                  m.CurrentUserId == user.Id &&
                  m.Title == PostTestUtilities.ValidUpdateTitle &&
                  m.Content == PostTestUtilities.ValidUpdateContent), CancellationToken)
            .Returns(postCommandViewModel);

        return post;
    }
}
