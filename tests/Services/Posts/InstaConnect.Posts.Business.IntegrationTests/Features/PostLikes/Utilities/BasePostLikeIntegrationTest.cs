using InstaConnect.Posts.Business.Features.PostLikes.Utilities;
using InstaConnect.Posts.Business.Features.Posts.Utilities;
using InstaConnect.Posts.Business.IntegrationTests.Utilities;
using InstaConnect.Posts.Data;
using InstaConnect.Posts.Data.Features.PostLikes.Abstract;
using InstaConnect.Posts.Data.Features.PostLikes.Models.Entitites;
using InstaConnect.Posts.Data.Features.Posts.Abstract;
using InstaConnect.Posts.Data.Features.Posts.Models.Entitites;
using InstaConnect.Posts.Data.Features.Users.Abstract;
using InstaConnect.Posts.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Business.IntegrationTests.Utilities;
using InstaConnect.Shared.Data.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Business.IntegrationTests.Features.PostLikes.Utilities;

public abstract class BasePostLikeIntegrationTest : BaseSharedIntegrationTest, IClassFixture<IntegrationTestWebAppFactory>, IAsyncLifetime
{
    protected readonly string InvalidId;
    protected readonly string InvalidUserId;
    protected readonly string ValidUserName;
    protected readonly string ValidAddUserName;
    protected readonly string ValidUpdateUserName;
    protected readonly string ValidUserFirstName;
    protected readonly string ValidUserEmail;
    protected readonly string ValidUserLastName;
    protected readonly string ValidUserProfileImage;
    protected readonly string InvalidPostId;
    protected readonly string ValidPostTitle;
    protected readonly string ValidPostContent;

    protected IUserWriteRepository UserWriteRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var userWriteRepository = serviceScope.ServiceProvider.GetRequiredService<IUserWriteRepository>();

            return userWriteRepository;
        }
    }

    protected IPostLikeWriteRepository PostLikeWriteRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var postLikeWriteRepository = serviceScope.ServiceProvider.GetRequiredService<IPostLikeWriteRepository>();

            return postLikeWriteRepository;
        }
    }

    protected IPostLikeReadRepository PostLikeReadRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var postLikeReadRepository = serviceScope.ServiceProvider.GetRequiredService<IPostLikeReadRepository>();

            return postLikeReadRepository;
        }
    }

    protected BasePostLikeIntegrationTest(IntegrationTestWebAppFactory integrationTestWebAppFactory)
        : base(integrationTestWebAppFactory.Services.CreateScope())
    {
        InvalidId = GetAverageString(PostLikeBusinessConfigurations.ID_MAX_LENGTH, PostLikeBusinessConfigurations.ID_MIN_LENGTH);
        InvalidUserId = GetAverageString(PostLikeBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
        ValidUserName = GetAverageString(PostLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidAddUserName = GetAverageString(PostLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidUpdateUserName = GetAverageString(PostLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidUserFirstName = GetAverageString(PostLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidUserLastName = GetAverageString(PostLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidUserEmail = GetAverageString(PostLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidUserProfileImage = GetAverageString(PostLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        InvalidPostId = GetAverageString(PostLikeBusinessConfigurations.POST_ID_MAX_LENGTH, PostLikeBusinessConfigurations.POST_ID_MIN_LENGTH);
        ValidPostTitle = GetAverageString(PostBusinessConfigurations.TITLE_MAX_LENGTH, PostBusinessConfigurations.TITLE_MIN_LENGTH);
        ValidPostContent = GetAverageString(PostBusinessConfigurations.CONTENT_MAX_LENGTH, PostBusinessConfigurations.CONTENT_MIN_LENGTH);
    }

    protected async Task<string> CreatePostAsync(string userId, CancellationToken cancellationToken)
    {
        var post = new Post(
            ValidPostTitle,
            ValidPostContent,
            userId);

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var postWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IPostWriteRepository>();

        postWriteRepository.Add(post);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return post.Id;
    }

    protected async Task<string> CreatePostLikeAsync(string userId, string postId, CancellationToken cancellationToken)
    {
        var postLike = new PostLike(
            postId,
            userId);

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var postLikeWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IPostLikeWriteRepository>();

        postLikeWriteRepository.Add(postLike);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return postLike.Id;
    }

    protected async Task<string> CreateUserAsync(CancellationToken cancellationToken)
    {
        var user = new User(
            ValidUserFirstName,
            ValidUserLastName,
            ValidUserEmail,
            ValidUserName,
            ValidUserProfileImage);

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

        if (dbContext.PostLikes.Any())
        {
            await dbContext.Posts.ExecuteDeleteAsync(CancellationToken);
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
