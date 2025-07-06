using System.ComponentModel.DataAnnotations;

using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Application.IntegrationTests.Features.Posts.Commands;

public class UpdatePostIntegrationTests : BasePostIntegrationTest
{
    private User _user;
    private Post _post;
    private UpdatePostCommandBuilder _commandBuilder;

    public UpdatePostIntegrationTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {

    }

    protected override async Task OnInitializeAsync()
    {
        _user = await SetupUserAsync(CancellationToken);
        _post = await SetupPostAsync(_user, CancellationToken);
        _commandBuilder = new(_post);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenIdIsNull()
    {
        // Arrange
        var command = _commandBuilder.WithoutId().Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync();
    }

    [Theory]
    [PostIdOutOfBoundsMinData]
    [PostIdOutOfBoundsMaxData]
    public async Task SendAsync_ShouldThrowValidationException_WhenIdLengthIsInvalid(string id)
    {
        // Arrange
        var command = _commandBuilder.WithId(id).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenUserIdIsNull()
    {
        // Arrange
        var command = _commandBuilder.WithoutUserId().Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync();
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
        await action.ShouldThrowInvalidValidationExceptionAsync();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenTitleIsNull()
    {
        // Arrange
        var command = _commandBuilder.WithoutTitle().Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync();
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
        await action.ShouldThrowInvalidValidationExceptionAsync();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenContentIsNull()
    {
        // Arrange
        var command = _commandBuilder.WithoutContent().Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync();
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
        await action.ShouldThrowInvalidValidationExceptionAsync();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowPostNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var command = _commandBuilder.WithInvalidId().Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action.ShouldThrowPostNotFoundExceptionAsync();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowAccountForbiddenException_WhenUserIdIsInvalid()
    {
        // Arrange
        var user = await SetupUserAsync(CancellationToken);
        var command = _commandBuilder.WithUserId(user.Id).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action.ShouldThrowUserForbiddenExceptionAsync();
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
    public async Task SendAsync_ShouldUpdatePost_WhenCommandIsValid()
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
    public async Task SendAsync_ShouldUpdatePost_WhenIdIsDifferentCase()
    {
        // Arrange
        var command = _commandBuilder.WithDifferentCaseId(_post.Id).Create();

        // Act
        await ApplicationSender.SendAsync(command, CancellationToken);
        var post = await PostWriteRepository.GetByIdAsync(command.Id, CancellationToken);

        // Assert
        post.ShouldSatisfy(command);
    }

    [Fact]
    public async Task SendAsync_ShouldUpdatePost_WhenUserIdIsDifferentCase()
    {
        // Arrange
        var command = _commandBuilder.WithDifferentCaseId(_user.Id).Create();

        // Act
        await ApplicationSender.SendAsync(command, CancellationToken);
        var post = await PostWriteRepository.GetByIdAsync(command.Id, CancellationToken);

        // Assert
        post.ShouldSatisfy(command);
    }
}
