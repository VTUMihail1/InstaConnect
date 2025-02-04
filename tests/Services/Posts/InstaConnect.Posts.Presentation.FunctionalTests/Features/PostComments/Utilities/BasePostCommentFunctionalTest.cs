using InstaConnect.PostComments.Presentation.FunctionalTests.Features.PostComments.Helpers;
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
using InstaConnect.Posts.Presentation.FunctionalTests.Features.Posts.Abstractions;
using InstaConnect.Posts.Presentation.FunctionalTests.Features.Posts.Helpers;
using InstaConnect.Posts.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Presentation.FunctionalTests.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.PostComments.Utilities;

public abstract class BasePostCommentFunctionalTest : IClassFixture<FunctionalTestWebAppFactory>, IAsyncLifetime
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

    protected BasePostCommentFunctionalTest(FunctionalTestWebAppFactory functionalTestWebAppFactory)
    {
        ServiceScope = functionalTestWebAppFactory.Services.CreateScope();
        CancellationToken = new();
        PostCommentsClient = new PostCommentsClient(functionalTestWebAppFactory.CreateClient());
    }

    protected async Task<User> CreateUserAsync(CancellationToken cancellationToken)
    {
        var user = new User(
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidProfileImage);

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var userWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IUserWriteRepository>();

        userWriteRepository.Add(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user;
    }

    protected async Task<Post> CreatePostAsync(CancellationToken cancellationToken)
    {
        var user = await CreateUserAsync(CancellationToken);
        var post = new Post(
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidContent,
            user);

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var postWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IPostWriteRepository>();

        postWriteRepository.Add(post);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return post;
    }

    protected async Task<PostComment> CreatePostCommentAsync(CancellationToken cancellationToken)
    {
        var user = await CreateUserAsync(cancellationToken);
        var post = await CreatePostAsync(cancellationToken);
        var postComment = new PostComment(
            user,
            post,
            PostCommentTestUtilities.ValidContent);

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var postCommentWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IPostCommentWriteRepository>();

        postCommentWriteRepository.Add(postComment);
        await unitOfWork.SaveChangesAsync(cancellationToken);

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
