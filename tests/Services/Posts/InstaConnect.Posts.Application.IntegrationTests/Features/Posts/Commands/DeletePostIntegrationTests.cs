using System.Data.Common;

using InstaConnect.Common.Tests.Utilities.DataAttributes.String;
using InstaConnect.Common.Tests.Utilities.DataAttributes.String.Value;
using InstaConnect.Common.Tests.Utilities.Variants.String;
using InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Utilities;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Application.IntegrationTests.Features.Posts.Commands;

public class DeletePostIntegrationTests : BasePostIntegrationTest
{
    private User _user;
    private Post _post;
    private DeletePostCommandBuilder _commandBuilder;

    public DeletePostIntegrationTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {

    }

    protected override async Task OnInitializeAsync()
    {
        _user = await ServiceScope.AddUserAsync(CancellationToken);
        _post = await ServiceScope.AddPostAsync(_user, CancellationToken);
        _commandBuilder = new(_post);
    }

    [Theory]
    [PostIdNullWithMessageData]
    [PostIdEmptyWithMessageData]
    [PostIdTooShortWithMessageData]
    [PostIdTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenIdIsInvalid(string id, string errorMessage)
    {
        // Arrange
        var request = _commandBuilder.WithId(id).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Theory]
    [UserIdNullWithMessageData]
    [UserIdEmptyWithMessageData]
    [UserIdTooShortWithMessageData]
    [UserIdTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenUserIdIsInvalid(string userId, string errorMessage)
    {
        // Arrange
        var request = _commandBuilder.WithUserId(userId).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowPostNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var request = _commandBuilder.WithInvalidId().Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowPostNotFoundExceptionAsync(request.Id);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowPostForbiddenException_WhenUserDoesNotOwnPost()
    {
        // Arrange
        var user = await ServiceScope.AddUserAsync(CancellationToken);
        var request = _commandBuilder.WithUserId(user.Id).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowPostForbiddenExceptionAsync(_post.Id, user.Id);
    }

    [Fact]
    public async Task SendAsync_ShouldDeletePost_WhenRequestIsValid()
    {
        // Arrange
        var request = _commandBuilder.Create();

        // Act
        await ApplicationSender.SendAsync(request, CancellationToken);
        var post = await ServiceScope.GetPostByIdAsync(request.Id, CancellationToken);

        // Assert
        post.ShouldBeNull();
    }

    [Theory]
    [DifferentCaseStringVariantTypeData]
    public async Task SendAsync_ShouldDeletePost_WhenRequestIsValidAndIdHasDifferentVariants(StringVariantType type)
    {
        // Arrange
        var request = _commandBuilder.WithId(_post.Id, type).Create();

        // Act
        await ApplicationSender.SendAsync(request, CancellationToken);
        var post = await ServiceScope.GetPostByIdAsync(request.Id, CancellationToken);

        // Assert
        post.ShouldBeNull();
    }

    [Theory]
    [DifferentCaseStringVariantTypeData]
    public async Task SendAsync_ShouldDeletePost_WhenRequestIsValidAndUserIdHasDifferentVariants(StringVariantType type)
    {
        // Arrange
        var request = _commandBuilder.WithUserId(_user.Id, type).Create();

        // Act
        await ApplicationSender.SendAsync(request, CancellationToken);
        var post = await ServiceScope.GetPostByIdAsync(request.Id, CancellationToken);

        // Assert
        post.ShouldBeNull();
    }
}
