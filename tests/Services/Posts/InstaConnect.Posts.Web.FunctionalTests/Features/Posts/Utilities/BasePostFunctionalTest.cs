using InstaConnect.Posts.Business.Features.Posts.Utilities;
using InstaConnect.Posts.Data;
using InstaConnect.Posts.Data.Features.Posts.Abstract;
using InstaConnect.Posts.Data.Features.Posts.Models.Entitites;
using InstaConnect.Posts.Data.Features.Users.Abstract;
using InstaConnect.Posts.Data.Features.Users.Models.Entitites;
using InstaConnect.Posts.Web.FunctionalTests.Utilities;
using InstaConnect.Shared.Data.Abstractions;
using InstaConnect.Shared.Web.FunctionalTests.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Web.FunctionalTests.Features.Posts.Utilities;

public abstract class BasePostFunctionalTest : BaseSharedFunctionalTest, IClassFixture<FunctionalTestWebAppFactory>, IAsyncLifetime
{
    private const string API_ROUTE = "api/v1/posts";

    protected readonly string InvalidId;
    protected readonly string ValidTitle;
    protected readonly string ValidAddTitle;
    protected readonly string ValidUpdateTitle;
    protected readonly string ValidContent;
    protected readonly string ValidAddContent;
    protected readonly string ValidUpdateContent;
    protected readonly string InvalidUserId;
    protected readonly string ValidUserName;
    protected readonly string ValidAddUserName;
    protected readonly string ValidUpdateUserName;
    protected readonly string ValidUserFirstName;
    protected readonly string ValidUserEmail;
    protected readonly string ValidUserLastName;
    protected readonly string ValidUserProfileImage;


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
        InvalidId = GetAverageString(PostBusinessConfigurations.ID_MAX_LENGTH, PostBusinessConfigurations.ID_MIN_LENGTH);
        ValidTitle = GetAverageString(PostBusinessConfigurations.CONTENT_MAX_LENGTH, PostBusinessConfigurations.CONTENT_MIN_LENGTH);
        ValidAddTitle = GetAverageString(PostBusinessConfigurations.CONTENT_MAX_LENGTH, PostBusinessConfigurations.CONTENT_MIN_LENGTH);
        ValidUpdateTitle = GetAverageString(PostBusinessConfigurations.CONTENT_MAX_LENGTH, PostBusinessConfigurations.CONTENT_MIN_LENGTH);
        ValidContent = GetAverageString(PostBusinessConfigurations.CONTENT_MAX_LENGTH, PostBusinessConfigurations.CONTENT_MIN_LENGTH);
        ValidAddContent = GetAverageString(PostBusinessConfigurations.CONTENT_MAX_LENGTH, PostBusinessConfigurations.CONTENT_MIN_LENGTH);
        ValidUpdateContent = GetAverageString(PostBusinessConfigurations.CONTENT_MAX_LENGTH, PostBusinessConfigurations.CONTENT_MIN_LENGTH);
        InvalidUserId = GetAverageString(PostBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, PostBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
        ValidUserName = GetAverageString(PostBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidAddUserName = GetAverageString(PostBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidUpdateUserName = GetAverageString(PostBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidUserFirstName = GetAverageString(PostBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidUserLastName = GetAverageString(PostBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidUserEmail = GetAverageString(PostBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidUserProfileImage = GetAverageString(PostBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
    }

    protected async Task<string> CreatePostAsync(string userId, CancellationToken cancellationToken)
    {
        var post = new Post(
            ValidTitle,
            ValidContent,
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
