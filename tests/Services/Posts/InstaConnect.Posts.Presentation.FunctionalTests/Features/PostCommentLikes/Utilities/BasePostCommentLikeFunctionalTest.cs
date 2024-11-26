using InstaConnect.Posts.Common.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstract;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Entitites;
using InstaConnect.Posts.Domain.Features.PostComments.Abstract;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Entitites;
using InstaConnect.Posts.Domain.Features.Posts.Abstract;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entitites;
using InstaConnect.Posts.Domain.Features.Users.Abstract;
using InstaConnect.Posts.Domain.Features.Users.Models.Entitites;
using InstaConnect.Posts.Infrastructure;
using InstaConnect.Posts.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Presentation.FunctionalTests.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeFunctionalTest : BaseSharedFunctionalTest, IClassFixture<FunctionalTestWebAppFactory>, IAsyncLifetime
{
    private const string API_ROUTE = "api/v1/post-comment-likes";

    protected IPostCommentLikeWriteRepository PostCommentLikeWriteRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var postCommentLikeRepository = serviceScope.ServiceProvider.GetRequiredService<IPostCommentLikeWriteRepository>();

            return postCommentLikeRepository;
        }
    }

    protected IPostCommentLikeReadRepository PostCommentLikeReadRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var postCommentLikeReadRepository = serviceScope.ServiceProvider.GetRequiredService<IPostCommentLikeReadRepository>();

            return postCommentLikeReadRepository;
        }
    }

    protected BasePostCommentLikeFunctionalTest(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(
        functionalTestWebAppFactory.CreateClient(),
        functionalTestWebAppFactory.Services.CreateScope(),
        API_ROUTE)
    {
    }

    protected async Task<string> CreatePostCommentLikeAsync(string userId, string postCommentId, CancellationToken cancellationToken)
    {
        var postCommentLike = new PostCommentLike(
            postCommentId,
            userId);

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var postCommentLikeWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IPostCommentLikeWriteRepository>();

        postCommentLikeWriteRepository.Add(postCommentLike);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return postCommentLike.Id;
    }

    protected async Task<string> CreatePostCommentAsync(string userId, string postId, CancellationToken cancellationToken)
    {
        var postComment = new PostComment(
            userId,
            postId,
            PostCommentLikeTestUtilities.ValidPostCommentContent);

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var postCommentWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IPostCommentWriteRepository>();

        postCommentWriteRepository.Add(postComment);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return postComment.Id;
    }

    protected async Task<string> CreatePostAsync(string userId, CancellationToken cancellationToken)
    {
        var post = new Post(
            PostCommentLikeTestUtilities.ValidPostTitle,
            PostCommentLikeTestUtilities.ValidPostContent,
            userId);

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var postWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IPostWriteRepository>();

        postWriteRepository.Add(post);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return post.Id;
    }

    protected async Task<string> CreateUserAsync(CancellationToken cancellationToken)
    {
        var user = new User(
            PostCommentLikeTestUtilities.ValidUserFirstName,
            PostCommentLikeTestUtilities.ValidUserLastName,
            PostCommentLikeTestUtilities.ValidUserEmail,
            PostCommentLikeTestUtilities.ValidUserName,
            PostCommentLikeTestUtilities.ValidUserProfileImage);

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var userWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IUserWriteRepository>();

        userWriteRepository.Add(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }

    public async Task InitializeAsync()
    {
        await EnsureDatabaseIsEmpty();
    }

    public async Task DisposeAsync()
    {
        await EnsureDatabaseIsEmpty();
    }

    private async Task EnsureDatabaseIsEmpty()
    {
        var dbContext = ServiceScope.ServiceProvider.GetRequiredService<PostsContext>();

        if (dbContext.PostCommentLikes.Any())
        {
            await dbContext.PostCommentLikes.ExecuteDeleteAsync(CancellationToken);
        }

        if (dbContext.PostComments.Any())
        {
            await dbContext.PostComments.ExecuteDeleteAsync(CancellationToken);
        }

        if (dbContext.Posts.Any())
        {
            await dbContext.Posts.ExecuteDeleteAsync(CancellationToken);
        }

        if (dbContext.Users.Any())
        {
            await dbContext.Users.ExecuteDeleteAsync(CancellationToken);
        }
    }
}
