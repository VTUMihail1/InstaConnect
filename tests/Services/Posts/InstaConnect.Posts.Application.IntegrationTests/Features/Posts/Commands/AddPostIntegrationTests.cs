using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Application.IntegrationTests.Features.Posts.Commands;

public class AddPostIntegrationTests : BasePostIntegrationTest
{
    private User _user;
    private Post _post;
    private AddPostCommandBuilder _commandBuilder;

    public AddPostIntegrationTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {

    }

    protected override async Task OnInitializeAsync()
    {
        _user = await SetupUserAsync(CancellationToken);
        _post = new PostBuilder(_user).Create();
        _commandBuilder = new(_post);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenUserIdIsNull()
    {
        // Arrange
        var command = _commandBuilder.WithoutUserId().Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action.ShouldThrowValidationExceptionAsync();
    }

    [Theory]
    [UserIdOutOfBoundsMinData]
    [UserIdOutOfBoundsMaxData]
    public async Task SendAsync_ShouldThrowValidationException_WhenUserIdLengthIsInvalid(string userId)
    {
        // Arrange
        var command = _commandBuilder.WithUserId(userId).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action.ShouldThrowValidationExceptionAsync();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenTitleIsNull()
    {
        // Arrange
        var command = _commandBuilder.WithoutTitle().Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action.ShouldThrowValidationExceptionAsync();
    }

    [Theory]
    [PostTitleOutOfBoundsMinData]
    [PostTitleOutOfBoundsMaxData]
    public async Task SendAsync_ShouldThrowValidationException_WhenTitleLengthIsInvalid(string title)
    {
        // Arrange
        var command = _commandBuilder.WithTitle(title).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action.ShouldThrowValidationExceptionAsync();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenContentIsNull()
    {
        // Arrange
        var command = _commandBuilder.WithoutContent().Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action.ShouldThrowValidationExceptionAsync();
    }

    [Theory]
    [PostContentOutOfBoundsMinData]
    [PostContentOutOfBoundsMaxData]
    public async Task SendAsync_ShouldThrowValidationException_WhenContentLengthIsInvalid(string content)
    {
        // Arrange
        var command = _commandBuilder.WithContent(content).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action.ShouldThrowValidationExceptionAsync();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenUserIdIsInvalid()
    {
        // Arrange
        var command = _commandBuilder.WithInvalidUserId().Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action.ShouldThrowUserNotFoundExceptionAsync();
    }

    [Fact]
    public async Task SendAsync_ShouldReturnResponse_WhenCommandIsValid()
    {
        // Arrange
        var command = _commandBuilder.Create();

        // Act
        var response = await ApplicationSender.SendAsync(command, CancellationToken);
        var post = await PostWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        // Assert
        response.ShouldSatisfy(post);
    }

    [Fact]
    public async Task SendAsync_ShouldAddPost_WhenCommandIsValid()
    {
        // Arrange
        var command = _commandBuilder.Create();

        // Act
        var response = await ApplicationSender.SendAsync(command, CancellationToken);
        var post = await PostWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        // Assert
        post.ShouldSatisfy(command);
    }

    [Fact]
    public async Task SendAsync_ShouldAddPost_WhenUserIdIsDifferentCase()
    {
        // Arrange
        var command = _commandBuilder.WithDifferentCaseUserId(_user.Id).Create();

        // Act
        var response = await ApplicationSender.SendAsync(command, CancellationToken);
        var post = await PostWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        // Assert
        post.ShouldSatisfy(command);
    }
}
