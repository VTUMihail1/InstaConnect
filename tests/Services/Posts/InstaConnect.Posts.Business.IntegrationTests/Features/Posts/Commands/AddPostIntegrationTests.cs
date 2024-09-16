using Bogus;
using FluentAssertions;
using InstaConnect.Posts.Business.Features.Posts.Commands.AddPost;
using InstaConnect.Posts.Business.Features.Posts.Utilities;
using InstaConnect.Posts.Business.IntegrationTests.Features.Posts.Utilities;
using InstaConnect.Posts.Business.IntegrationTests.Utilities;
using InstaConnect.Posts.Data.Features.Posts.Models.Entitites;
using InstaConnect.Shared.Business.Exceptions.Base;
using InstaConnect.Shared.Business.Exceptions.User;

namespace InstaConnect.Posts.Business.IntegrationTests.Features.Posts.Commands;

public class AddPostIntegrationTests : BasePostIntegrationTest
{
    public AddPostIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new AddPostCommand(
            null!,
            ValidAddTitle,
            ValidAddContent
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(PostBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new AddPostCommand(
            Faker.Random.AlphaNumeric(length),
            ValidAddTitle,
            ValidAddContent
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenTitleIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new AddPostCommand(
            existingUserId,
            null!,
            ValidAddContent
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostBusinessConfigurations.TITLE_MIN_LENGTH - 1)]
    [InlineData(PostBusinessConfigurations.TITLE_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenTitleLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new AddPostCommand(
            existingUserId,
            Faker.Random.AlphaNumeric(length),
            ValidAddContent
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenContentIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new AddPostCommand(
            existingUserId,
            ValidAddTitle,
            null!
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostBusinessConfigurations.CONTENT_MIN_LENGTH - 1)]
    [InlineData(PostBusinessConfigurations.CONTENT_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenContentLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var anotherExistingUserId = await CreateUserAsync(CancellationToken);
        var command = new AddPostCommand(
            existingUserId,
            ValidAddTitle,
            Faker.Random.AlphaNumeric(length)
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new AddPostCommand(
            InvalidUserId,
            ValidAddTitle,
            ValidAddContent
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldAddPost_WhenPostIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new AddPostCommand(
            existingUserId,
            ValidAddTitle,
            ValidAddContent
        );

        // Act
        var response = await InstaConnectSender.SendAsync(command, CancellationToken);
        var post = await PostWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        // Assert
        post
            .Should()
            .Match<Post>(p => p.Id == response.Id &&
                              p.UserId == existingUserId &&
                              p.Title == ValidAddTitle &&
                              p.Content == ValidAddContent);
    }
}
