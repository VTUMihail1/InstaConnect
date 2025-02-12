using AutoMapper;
using InstaConnect.Posts.Application.Features.PostLikes.Mappings;
using InstaConnect.Posts.Common.Features.PostLikes.Utilities;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.PostLikes.Abstract;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Entitites;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Filters;
using InstaConnect.Posts.Domain.Features.Posts.Abstract;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entitites;
using InstaConnect.Posts.Domain.Features.Users.Abstract;
using InstaConnect.Posts.Domain.Features.Users.Models.Entitites;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Helpers;
using InstaConnect.Shared.Domain.Models.Pagination;
using NSubstitute;

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

    public BasePostLikeUnitTest()
    {
        UnitOfWork = Substitute.For<IUnitOfWork>();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<PostLikeQueryProfile>();
                    cfg.AddProfile<PostLikeCommandProfile>();
                })));
        CancellationToken = new CancellationToken();
        EntityPropertyValidator = new EntityPropertyValidator();
        UserWriteRepository = Substitute.For<IUserWriteRepository>();
        PostReadRepository = Substitute.For<IPostReadRepository>();
        PostWriteRepository = Substitute.For<IPostWriteRepository>();
        PostLikeReadRepository = Substitute.For<IPostLikeReadRepository>();
        PostLikeWriteRepository = Substitute.For<IPostLikeWriteRepository>();
    }

    public User CreateUser()
    {
        var user = new User(
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidProfileImage);

        UserWriteRepository.GetByIdAsync(user.Id, CancellationToken)
            .Returns(user);

        return user;
    }

    public Post CreatePost()
    {
        var user = CreateUser();
        var post = new Post(
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidContent,
            user);

        PostWriteRepository.GetByIdAsync(post.Id, CancellationToken)
            .Returns(post);

        return post;
    }

    public PostLike CreatePostLike()
    {
        var user = CreateUser();
        var post = CreatePost();
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
                                                                        m.UserName == UserTestUtilities.ValidName &&
                                                                        m.PostId == post.Id &&
                                                                        m.Page == PostLikeTestUtilities.ValidPageValue &&
                                                                        m.PageSize == PostLikeTestUtilities.ValidPageSizeValue &&
                                                                        m.SortOrder == PostLikeTestUtilities.ValidSortOrderProperty &&
                                                                        m.SortPropertyName == PostLikeTestUtilities.ValidSortPropertyName), CancellationToken)
            .Returns(postLikePaginationList);

        return postLike;
    }
}
