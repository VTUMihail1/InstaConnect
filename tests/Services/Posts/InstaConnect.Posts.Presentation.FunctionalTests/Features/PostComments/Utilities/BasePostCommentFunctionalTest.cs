using InstaConnect.Posts.Common.Features.PostComments.Utilities;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.PostComments.Abstract;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Entitites;
using InstaConnect.Posts.Domain.Features.Posts.Abstract;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entitites;
using InstaConnect.Posts.Domain.Features.Users.Abstract;
using InstaConnect.Posts.Domain.Features.Users.Models.Entitites;
using InstaConnect.Posts.Infrastructure;
using InstaConnect.Posts.Presentation.FunctionalTests.Features.PostComments.Abstractions;
using InstaConnect.Posts.Presentation.FunctionalTests.Features.PostComments.Helpers;
using InstaConnect.Posts.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Common.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.PostComments.Utilities;

public abstract class BasePostCommentFunctionalTest : IClassFixture<PostsWebApplicationFactory>, IAsyncLifetime
{
    protected CancellationToken CancellationToken { get; }

    protected IServiceScope ServiceScope { get; }

    protected IPostCommentsClient PostCommentsClient { get; }

    protected IPostCommentWriteRepository PostCommentWriteRepository
    {
        get
        {
            using var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var postCommentRepository = serviceScope.ServiceProvider.GetRequiredService<IPostCommentWriteRepository>();

            return postCommentRepository;
        }
    }

    protected IPostCommentReadRepository PostCommentReadRepository
    {
        get
        {
            using var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var postCommentReadRepository = serviceScope.ServiceProvider.GetRequiredService<IPostCommentReadRepository>();

            return postCommentReadRepository;
        }
    }

    protected BasePostCommentFunctionalTest(PostsWebApplicationFactory postsWebApplicationFactory)
    {
        ServiceScope = postsWebApplicationFactory.Services.CreateScope();
        CancellationToken = new();
        PostCommentsClient = new PostCommentsClient(postsWebApplicationFactory.CreateClient());
    }

    private async Task<User> CreateUserUtilAsync(CancellationToken cancellationToken)
    {
        var user = new User(
            SharedTestUtilities.GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.ProfileImageMaxLength, UserConfigurations.ProfileImageMinLength));

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var userWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IUserWriteRepository>();

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
            SharedTestUtilities.GetAverageString(PostConfigurations.TitleMaxLength, PostConfigurations.TitleMinLength),
            SharedTestUtilities.GetAverageString(PostConfigurations.ContentMaxLength, PostConfigurations.ContentMinLength),
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
            SharedTestUtilities.GetAverageString(PostCommentConfigurations.ContentMaxLength, PostCommentConfigurations.ContentMinLength));

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
