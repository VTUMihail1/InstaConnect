using InstaConnect.Posts.Business.Features.PostComments.Utilities;
using InstaConnect.Posts.Business.Features.Posts.Utilities;
using InstaConnect.Posts.Data;
using InstaConnect.Posts.Data.Features.PostComments.Abstract;
using InstaConnect.Posts.Data.Features.PostComments.Models.Entitites;
using InstaConnect.Posts.Data.Features.Posts.Abstract;
using InstaConnect.Posts.Data.Features.Posts.Models.Entitites;
using InstaConnect.Posts.Data.Features.Users.Abstract;
using InstaConnect.Posts.Data.Features.Users.Models.Entitites;
using InstaConnect.Posts.Web.FunctionalTests.Utilities;
using InstaConnect.Shared.Data.Abstractions;
using InstaConnect.Shared.Web.FunctionalTests.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Web.FunctionalTests.Features.PostComments.Utilities;

public abstract class BasePostCommentFunctionalTest : BaseSharedFunctionalTest, IClassFixture<FunctionalTestWebAppFactory>, IAsyncLifetime
{
    private const string API_ROUTE = "api/v1/post-comments";

    protected readonly string InvalidId;
    protected readonly string ValidContent;
    protected readonly string ValidAddContent;
    protected readonly string ValidUpdateContent;
    protected readonly string InvalidPostId;
    protected readonly string ValidPostTitle;
    protected readonly string ValidPostContent;
    protected readonly string InvalidUserId;
    protected readonly string ValidUserName;
    protected readonly string ValidAddUserName;
    protected readonly string ValidUpdateUserName;
    protected readonly string ValidUserFirstName;
    protected readonly string ValidUserEmail;
    protected readonly string ValidUserLastName;
    protected readonly string ValidUserProfileImage;


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
        InvalidId = GetAverageString(PostCommentBusinessConfigurations.ID_MAX_LENGTH, PostCommentBusinessConfigurations.ID_MIN_LENGTH);
        ValidContent = GetAverageString(PostCommentBusinessConfigurations.CONTENT_MAX_LENGTH, PostCommentBusinessConfigurations.CONTENT_MIN_LENGTH);
        ValidAddContent = GetAverageString(PostCommentBusinessConfigurations.CONTENT_MAX_LENGTH, PostCommentBusinessConfigurations.CONTENT_MIN_LENGTH);
        ValidUpdateContent = GetAverageString(PostCommentBusinessConfigurations.CONTENT_MAX_LENGTH, PostCommentBusinessConfigurations.CONTENT_MIN_LENGTH);
        InvalidPostId = GetAverageString(PostCommentBusinessConfigurations.POST_ID_MAX_LENGTH, PostCommentBusinessConfigurations.POST_ID_MIN_LENGTH);
        ValidPostTitle = GetAverageString(PostBusinessConfigurations.TITLE_MAX_LENGTH, PostBusinessConfigurations.TITLE_MIN_LENGTH);
        ValidPostContent = GetAverageString(PostBusinessConfigurations.CONTENT_MAX_LENGTH, PostBusinessConfigurations.CONTENT_MIN_LENGTH);
        InvalidUserId = GetAverageString(PostCommentBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, PostCommentBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
        ValidUserName = GetAverageString(PostCommentBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostCommentBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidAddUserName = GetAverageString(PostCommentBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostCommentBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidUpdateUserName = GetAverageString(PostCommentBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostCommentBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidUserFirstName = GetAverageString(PostCommentBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostCommentBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidUserLastName = GetAverageString(PostCommentBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostCommentBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidUserEmail = GetAverageString(PostCommentBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostCommentBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
        ValidUserProfileImage = GetAverageString(PostCommentBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH, PostCommentBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH);
    }

    protected async Task<string> CreatePostCommentAsync(string userId, string postId, CancellationToken cancellationToken)
    {
        var postComment = new PostComment(
            userId,
            postId,
            ValidContent);

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var postCommentWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IPostCommentWriteRepository>();

        postCommentWriteRepository.Add(postComment);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return postComment.Id;
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
