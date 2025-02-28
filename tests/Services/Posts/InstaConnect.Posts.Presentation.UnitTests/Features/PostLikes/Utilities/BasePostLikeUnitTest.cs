using AutoMapper;

using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Helpers;
using InstaConnect.Posts.Application.Features.PostLikes.Commands.Add;
using InstaConnect.Posts.Application.Features.PostLikes.Models;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetById;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;
using InstaConnect.Posts.Presentation.Extensions;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.PostLikes.Utilities;

public abstract class BasePostLikeUnitTest
{
    protected IInstaConnectSender InstaConnectSender { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    protected CancellationToken CancellationToken { get; }

    protected BasePostLikeUnitTest()
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

    private PostLike CreatePostLikeUtil(User user, Post post)
    {
        var postLike = new PostLike(post, user);

        var postLikeQueryViewModel = new PostLikeQueryViewModel(
            postLike.Id,
            post.Id,
            user.Id,
            user.UserName,
            user.ProfileImage);

        var postLikeCommandViewModel = new PostLikeCommandViewModel(postLike.Id);
        var postLikePaginationCollectionModel = new PostLikePaginationQueryViewModel(
            [postLikeQueryViewModel],
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue,
            PostLikeTestUtilities.ValidTotalCountValue,
            false,
            false);

        InstaConnectSender
            .SendAsync(Arg.Is<GetAllPostLikesQuery>(m =>
                  m.PostId == post.Id &&
                  m.UserId == user.Id &&
                  m.UserName == user.UserName &&
                  m.SortOrder == PostLikeTestUtilities.ValidSortOrderProperty &&
                  m.SortPropertyName == PostLikeTestUtilities.ValidSortPropertyName &&
                  m.Page == PostLikeTestUtilities.ValidPageValue &&
                  m.PageSize == PostLikeTestUtilities.ValidPageSizeValue), CancellationToken)
            .Returns(postLikePaginationCollectionModel);

        InstaConnectSender
            .SendAsync(Arg.Is<GetPostLikeByIdQuery>(m => m.Id == postLike.Id), CancellationToken)
            .Returns(postLikeQueryViewModel);

        InstaConnectSender
            .SendAsync(Arg.Is<AddPostLikeCommand>(m =>
                  m.CurrentUserId == user.Id &&
                  m.PostId == post.Id), CancellationToken)
            .Returns(postLikeCommandViewModel);

        return postLike;
    }

    protected PostLike CreatePostLike()
    {
        var user = CreateUser();
        var post = CreatePost();
        var postLike = CreatePostLikeUtil(user, post);

        return postLike;
    }
}
