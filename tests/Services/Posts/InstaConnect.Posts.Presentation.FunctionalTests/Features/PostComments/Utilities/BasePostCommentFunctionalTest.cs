using InstaConnect.Posts.Common.Features.PostComments.Utilities;
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

namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.PostComments.Utilities;

public abstract class BasePostCommentFunctionalTest : BaseSharedFunctionalTest, IClassFixture<FunctionalTestWebAppFactory>, IAsyncLifetime
{
    private const string API_ROUTE = "api/v1/post-comments";


    protected IPostCommentWriteRepository PostCommentWriteRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var postCommentRepository = serviceScope.ServiceProvider.GetRequiredService<IPostCommentWriteRepository>();

            return postCommentRepository;
        }
    }

    protected IPostCommentReadRepository PostCommentReadRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var postCommentReadRepository = serviceScope.ServiceProvider.GetRequiredService<IPostCommentReadRepository>();

            return postCommentReadRepository;
        }
    }

    protected BasePostCommentFunctionalTest(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(
        functionalTestWebAppFactory.CreateClient(),
        functionalTestWebAppFactory.Services.CreateScope(),
        API_ROUTE)
    {
    }

    protected async Task<string> CreatePostCommentAsync(string userId, string postId, CancellationToken cancellationToken)
    {
        var postComment = new PostComment(
            userId,
            postId,
            PostCommentTestUtilities.ValidContent);

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var postCommentWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IPostCommentWriteRepository>();

        postCommentWriteRepository.Add(postComment);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return postComment.Id;
    }

    protected async Task<string> CreatePostAsync(string userId, CancellationToken cancellationToken)
    {
        var post = new Post(
            PostCommentTestUtilities.ValidPostTitle,
            PostCommentTestUtilities.ValidPostContent,
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
            PostCommentTestUtilities.ValidUserFirstName,
            PostCommentTestUtilities.ValidUserLastName,
            PostCommentTestUtilities.ValidUserEmail,
            PostCommentTestUtilities.ValidUserName,
            PostCommentTestUtilities.ValidUserProfileImage);

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
