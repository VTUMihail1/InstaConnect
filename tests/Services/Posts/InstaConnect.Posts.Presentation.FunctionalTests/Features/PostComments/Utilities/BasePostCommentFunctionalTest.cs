using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Infrastructure;
using InstaConnect.Posts.Presentation.FunctionalTests.Features.PostComments.Abstractions;
using InstaConnect.Posts.Presentation.FunctionalTests.Features.PostComments.Helpers;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.PostComments.Utilities;

public abstract class BasePostCommentFunctionalTest : IClassFixture<PostWebApplicationFactory>, IAsyncLifetime
{
    protected CancellationToken CancellationToken { get; }

    protected IServiceScope ServiceScope { get; }

    protected IPostCommentsClient PostCommentsClient { get; }

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

    protected BasePostCommentFunctionalTest(PostWebApplicationFactory postsWebApplicationFactory)
    {
        ServiceScope = postsWebApplicationFactory.Services.CreateScope();
        CancellationToken = new();
        PostCommentsClient = new PostCommentsClient(postsWebApplicationFactory.CreateClient());
    }

    private async Task<User> CreateUserUtilAsync(CancellationToken cancellationToken)
    {
        var user = new User(
            DataFaker.GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength),
            DataFaker.GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength),
            DataFaker.GetAverageString(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength),
            DataFaker.GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength),
            DataFaker.GetAverageString(UserConfigurations.ProfileImageMaxLength, UserConfigurations.ProfileImageMinLength));

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var userWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IUserRepository>();

        userWriteRepository.Add(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user;
    }

    protected async Task<User> CreateUserAsync(CancellationToken cancellationToken)
    {
        var user = await CreateUserUtilAsync(cancellationToken);

        return user;
    }

    private async Task<Post> CreatePostAsyncUtil(User user, CancellationToken cancellationToken)
    {
        var post = new Post(
            DataFaker.GetAverageString(PostConfigurations.TitleMaxLength, PostConfigurations.TitleMinLength),
            DataFaker.GetAverageString(PostConfigurations.ContentMaxLength, PostConfigurations.ContentMinLength),
            user);

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var postWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IPostWriteRepository>();

        postWriteRepository.Add(post);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return post;
    }

    protected async Task<Post> CreatePostAsync(CancellationToken cancellationToken)
    {
        var user = await CreateUserAsync(CancellationToken);
        var post = await CreatePostAsyncUtil(user, cancellationToken);

        return post;
    }

    protected async Task<PostComment> CreatePostCommentUtilAsync(User user, Post post, CancellationToken cancellationToken)
    {
        var postComment = new PostComment(
            user,
            post,
            DataFaker.GetAverageString(PostCommentConfigurations.ContentMaxLength, PostCommentConfigurations.ContentMinLength));

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var postCommentWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IPostCommentWriteRepository>();

        postCommentWriteRepository.Add(postComment);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return postComment;
    }

    protected async Task<PostComment> CreatePostCommentAsync(CancellationToken cancellationToken)
    {
        var user = await CreateUserAsync(cancellationToken);
        var post = await CreatePostAsync(cancellationToken);
        var postComment = await CreatePostCommentUtilAsync(user, post, cancellationToken);

        return postComment;
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

        if (await dbContext.PostComments.AnyAsync(CancellationToken))
        {
            await dbContext.PostComments.ExecuteDeleteAsync(CancellationToken);
        }

        if (await dbContext.Posts.AnyAsync(CancellationToken))
        {
            await dbContext.Posts.ExecuteDeleteAsync(CancellationToken);
        }

        if (await dbContext.Users.AnyAsync(CancellationToken))
        {
            await dbContext.Users.ExecuteDeleteAsync(CancellationToken);
        }
    }
}
