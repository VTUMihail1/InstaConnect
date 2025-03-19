using AutoMapper;

using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Application.Helpers;
using InstaConnect.Common.Domain.Models.Pagination;
using InstaConnect.Common.Helpers;
using InstaConnect.Posts.Application.Extensions;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Filters;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Utilities;

public abstract class BasePostUnitTest
{
    protected IUnitOfWork UnitOfWork { get; }

    protected IPostFactory PostFactory { get; }

    protected IPostService PostService { get; }

    protected CancellationToken CancellationToken { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    protected IEntityPropertyValidator EntityPropertyValidator { get; }

    protected IUserWriteRepository UserWriteRepository { get; }

    protected IPostReadRepository PostReadRepository { get; }

    protected IPostWriteRepository PostWriteRepository { get; }

    protected BasePostUnitTest()
    {
        UnitOfWork = Substitute.For<IUnitOfWork>();
        PostFactory = Substitute.For<IPostFactory>();
        PostService = Substitute.For<IPostService>();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg => cfg.AddMaps(ApplicationReference.Assembly))));
        EntityPropertyValidator = new EntityPropertyValidator();
        CancellationToken = new CancellationToken();
        UserWriteRepository = Substitute.For<IUserWriteRepository>();
        PostReadRepository = Substitute.For<IPostReadRepository>();
        PostWriteRepository = Substitute.For<IPostWriteRepository>();
    }

    private User CreateUserUtil()
    {
        var user = UserTestUtilities.CreateUser();

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
        var post = PostTestUtilities.CreatePost(user, [], []);

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

        PostService
            .When(x => x.Update(post, PostTestUtilities.ValidUpdateTitle, PostTestUtilities.ValidUpdateContent))
            .Do(call =>
            {
                var updatedPost = call.Arg<Post>();
                updatedPost.Update(PostTestUtilities.ValidUpdateTitle, PostTestUtilities.ValidUpdateContent, PostTestUtilities.ValidUpdateUpdatedAtUtc);
            });

        return post;
    }

    protected Post CreatePost()
    {
        var user = CreateUser();
        var post = CreatePostUtil(user);

        return post;
    }

    public Post CreatePostFactory()
    {
        var user = CreateUser();

        var post = PostTestUtilities.CreatePost(user, [], []);

        PostFactory.Get(user.Id, PostTestUtilities.ValidAddTitle, PostTestUtilities.ValidAddContent)
            .Returns(post);

        return post;
    }
}
