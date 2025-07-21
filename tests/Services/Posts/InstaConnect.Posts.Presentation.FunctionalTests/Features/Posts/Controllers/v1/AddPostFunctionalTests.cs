using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Content;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Title;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Utilities;

namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.Posts.Controllers.v1;

public class AddPostFunctionalTests : BasePostFunctionalTest
{
    private User _user;
    private Post _post;
    private AddPostApiRequestBuilder _requestBuilder;

    public AddPostFunctionalTests(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {

    }

    protected override async Task OnInitializeAsync()
    {
        _user = await ServiceScope.AddUserAsync(CancellationToken);
        _post = new PostBuilder(_user).Create();
        _requestBuilder = new(_post);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
    {
        // Arrange
        var request = _requestBuilder.Create();

        // Act
        var response = await HttpClient.AddPostStatusCodeUnauthorizedAsync(request, CancellationToken);

        // Assert
        response.ShouldBeUnauthorized();
    }

    [Fact]
    public async Task AddAsync_ShouldReturnUnauthorizedProblemDetails_WhenRequestIsUnauthorized()
    {
        // Arrange
        var request = _requestBuilder.Create();

        // Act
        var response = await HttpClient.AddPostProblemDetailsUnauthorizedAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyUnauthorized();
    }

    [Theory]
    [UserIdNullData]
    [UserIdEmptyData]
    [UserIdTooShortData]
    [UserIdTooLongData]
    public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenUserIdIsInvalid(string userId)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(userId).Create();

        // Act
        var response = await HttpClient.AddPostStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserIdNullData]
    [UserIdEmptyData]
    [UserIdTooShortData]
    [UserIdTooLongData]
    public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenUserIdIsInvalid(string userId, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(userId).Create();

        // Act
        var response = await HttpClient.AddPostProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyBadRequest(errorMessage);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenUserIdIsInvalid()
    {
        // Arrange
        var request = _requestBuilder.WithInvalidUserId().Create();

        // Act
        var action = await HttpClient.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowUserNotFoundExceptionAsync(request.CurrentUserId);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new AddPostApiRequest(
            existingUser.Id,
            new(PostTestUtilities.ValidAddTitle, PostTestUtilities.ValidAddContent)
        );

        // Act
        var response = await HttpClient.AddStatusCodeUnauthorizedAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenTitleIsNull()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new AddPostApiRequest(
            existingUser.Id,
            new(null, PostTestUtilities.ValidAddContent)
        );

        // Act
        var response = await HttpClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostConfigurations.TitleMinLength - 1)]
    [InlineData(PostConfigurations.TitleMaxLength + 1)]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenTitleLengthIsInvalid(int length)
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new AddPostApiRequest(
            existingUser.Id,
            new(DataFaker.GetString(length), PostTestUtilities.ValidAddContent)
        );

        // Act
        var response = await HttpClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenContentIsNull()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new AddPostApiRequest(
            existingUser.Id,
            new(PostTestUtilities.ValidAddTitle, null)
        );

        // Act
        var response = await HttpClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostConfigurations.ContentMinLength - 1)]
    [InlineData(PostConfigurations.ContentMaxLength + 1)]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenContentLengthIsInvalid(int length)
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new AddPostApiRequest(
            existingUser.Id,
            new(PostTestUtilities.ValidAddTitle, DataFaker.GetString(length))
        );

        // Act
        var response = await HttpClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var request = new AddPostApiRequest(
            null,
            new(PostTestUtilities.ValidAddTitle, PostTestUtilities.ValidAddContent)
        );

        // Act
        var response = await HttpClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var request = new AddPostApiRequest(
            DataFaker.GetString(length),
            new(PostTestUtilities.ValidAddTitle, PostTestUtilities.ValidAddContent)
        );

        // Act
        var response = await HttpClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnNotFoundResponse_WhenCurrentUserIsInvalid()
    {
        // Arrange
        var request = new AddPostApiRequest(
            UserTestUtilities.InvalidId,
            new(PostTestUtilities.ValidAddTitle, PostTestUtilities.ValidAddContent)
        );

        // Act
        var response = await HttpClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new AddPostApiRequest(
            existingUser.Id,
            new(PostTestUtilities.ValidAddTitle, PostTestUtilities.ValidAddContent)
        );

        // Act
        var response = await HttpClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task AddAsync_ShouldAddPost_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new AddPostApiRequest(
            existingUser.Id,
            new(PostTestUtilities.ValidAddTitle, PostTestUtilities.ValidAddContent)
        );

        // Act
        var response = await HttpClient.AddAsync(request, CancellationToken);

        var post = await PostWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        // Assert
        post
            .Should()
            .Match<Post>(m => m.Id == response.Id &&
                                 m.UserId == existingUser.Id &&
                                 m.Content == PostTestUtilities.ValidAddContent &&
                                 m.Title == PostTestUtilities.ValidAddTitle);
    }
}
