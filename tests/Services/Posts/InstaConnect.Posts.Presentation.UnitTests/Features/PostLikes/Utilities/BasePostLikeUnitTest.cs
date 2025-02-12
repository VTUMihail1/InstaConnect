using AutoMapper;
using InstaConnect.Posts.Application.Features.PostLikes.Commands.AddPostLike;
using InstaConnect.Posts.Application.Features.PostLikes.Models;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAllPostLikes;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetPostLikeById;
using InstaConnect.Posts.Common.Features.PostLikes.Utilities;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Entitites;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entitites;
using InstaConnect.Posts.Domain.Features.Users.Models.Entitites;
using InstaConnect.Posts.Presentation.Features.PostLikes.Mappings;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Helpers;
using InstaConnect.Shared.Common.Utilities;
using NSubstitute;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.PostLikes.Utilities;

public abstract class BasePostLikeUnitTest
{
    protected IInstaConnectSender InstaConnectSender { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    protected CancellationToken CancellationToken { get; }

    public BasePostLikeUnitTest()
    {
        InstaConnectSender = Substitute.For<IInstaConnectSender>();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<PostLikeCommandProfile>();
                    cfg.AddProfile<PostLikeQueryProfile>();
                })));
        CancellationToken = new CancellationToken();
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

        return post;
    }

    public PostLike CreatePostLike()
    {
        var user = CreateUser();
        var post = CreatePost();
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
}
