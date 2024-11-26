using InstaConnect.Posts.Common.Features.Posts.Utilities;
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

namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.Posts.Utilities;

public abstract class BasePostFunctionalTest : BaseSharedFunctionalTest, IClassFixture<FunctionalTestWebAppFactory>, IAsyncLifetime
{
    private const string API_ROUTE = "api/v1/posts";

    protected IPostWriteRepository PostWriteRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var postRepository = serviceScope.ServiceProvider.GetRequiredService<IPostWriteRepository>();

            return postRepository;
        }
    }

    protected IPostReadRepository PostReadRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var postReadRepository = serviceScope.ServiceProvider.GetRequiredService<IPostReadRepository>();

            return postReadRepository;
        }
    }

    protected BasePostFunctionalTest(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(
        functionalTestWebAppFactory.CreateClient(),
        functionalTestWebAppFactory.Services.CreateScope(),
        API_ROUTE)
    {
    }

    protected async Task<string> CreatePostAsync(string userId, CancellationToken cancellationToken)
    {
        var post = new Post(
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidContent,
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
            PostTestUtilities.ValidUserFirstName,
            PostTestUtilities.ValidUserLastName,
            PostTestUtilities.ValidUserEmail,
            PostTestUtilities.ValidUserName,
            PostTestUtilities.ValidUserProfileImage);

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
