using AutoMapper;

using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Application.Helpers;
using InstaConnect.Common.Domain.Models.Pagination;
using InstaConnect.Common.Helpers;
using InstaConnect.Posts.Application.Extensions;
using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Filters;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Filters;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostLikes.Utilities;

public abstract class BasePostLikeUnitTest
{
    protected IUnitOfWork UnitOfWork { get; }

    protected CancellationToken CancellationToken { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    protected IEntityPropertyValidator EntityPropertyValidator { get; }

    protected IUserWriteRepository UserWriteRepository { get; }

    protected IPostReadRepository PostReadRepository { get; }

    protected IPostWriteRepository PostWriteRepository { get; }

    protected IPostLikeReadRepository PostLikeReadRepository { get; }

    protected IPostLikeWriteRepository PostLikeWriteRepository { get; }

    protected BasePostLikeUnitTest()
    {
        UnitOfWork = Substitute.For<IUnitOfWork>();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg => cfg.AddMaps(ApplicationReference.Assembly))));
        CancellationToken = new CancellationToken();
        EntityPropertyValidator = new EntityPropertyValidator();
        UserWriteRepository = Substitute.For<IUserWriteRepository>();
        PostReadRepository = Substitute.For<IPostReadRepository>();
        PostWriteRepository = Substitute.For<IPostWriteRepository>();
        PostLikeReadRepository = Substitute.For<IPostLikeReadRepository>();
        PostLikeWriteRepository = Substitute.For<IPostLikeWriteRepository>();
    }

    private User CreateUserUtil()
    {
        var user = new User(
            SharedTestUtilities.GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.ProfileImageMaxLength, UserConfigurations.ProfileImageMinLength));

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
        var post = new Post(
            SharedTestUtilities.GetAverageString(PostConfigurations.TitleMaxLength, PostConfigurations.TitleMinLength),
            SharedTestUtilities.GetAverageString(PostConfigurations.ContentMaxLength, PostConfigurations.ContentMinLength),
            user);

        var postPaginationList = new PaginationList<Post>(
            [post],
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue,
            PostTestUtilities.ValidTotalCountValue);

        PostReadRepository.GetByIdAsync(
            post.Id,
            CancellationToken)
            .Returns(post);

        PostWriteRepository.GetByIdAsync(
            post.Id,
            CancellationToken)
            .Returns(post);

        PostReadRepository
            .GetAllAsync(Arg.Is<PostCollectionReadQuery>(m =>
                                                                        m.Title == post.Title &&
                                                                        m.UserId == user.Id &&
                                                                        m.UserName == user.UserName &&
                                                                        m.Page == PostTestUtilities.ValidPageValue &&
                                                                        m.PageSize == PostTestUtilities.ValidPageSizeValue &&
                                                                        m.SortOrder == PostTestUtilities.ValidSortOrderProperty &&
                                                                        m.SortPropertyName == PostTestUtilities.ValidSortPropertyName), CancellationToken)
            .Returns(postPaginationList);

        return post;
    }

    protected Post CreatePost()
    {
        var user = CreateUser();
        var post = CreatePostUtil(user);

        return post;
    }

    private PostLike CreatePostLikeUtil(User user, Post post)
    {
        var postLike = new PostLike(post, user);

        var postLikePaginationList = new PaginationList<PostLike>(
        [postLike],
        PostLikeTestUtilities.ValidPageValue,
        PostLikeTestUtilities.ValidPageSizeValue,
        PostLikeTestUtilities.ValidTotalCountValue);

        PostLikeReadRepository.GetByIdAsync(postLike.Id, CancellationToken)
            .Returns(postLike);

        PostLikeWriteRepository.GetByIdAsync(postLike.Id, CancellationToken)
            .Returns(postLike);

        PostLikeWriteRepository.GetByUserIdAndPostIdAsync(user.Id, post.Id, CancellationToken)
            .Returns(postLike);

        PostLikeReadRepository
            .GetAllAsync(Arg.Is<PostLikeCollectionReadQuery>(m =>
                                                                        m.UserId == user.Id &&
                                                                        m.UserName == user.UserName &&
                                                                        m.PostId == post.Id &&
                                                                        m.Page == PostLikeTestUtilities.ValidPageValue &&
                                                                        m.PageSize == PostLikeTestUtilities.ValidPageSizeValue &&
                                                                        m.SortOrder == PostLikeTestUtilities.ValidSortOrderProperty &&
                                                                        m.SortPropertyName == PostLikeTestUtilities.ValidSortPropertyName), CancellationToken)
            .Returns(postLikePaginationList);

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
