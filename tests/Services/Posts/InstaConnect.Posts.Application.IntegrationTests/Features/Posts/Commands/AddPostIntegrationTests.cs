using InstaConnect.Common.Tests.Utilities.DataAttributes;
using InstaConnect.Common.Tests.Utilities.DataAttributes.String;
using InstaConnect.Common.Tests.Utilities.DataAttributes.String.Value;
using InstaConnect.Common.Tests.Utilities.Variants.String;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Content;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Title;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Utilities;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Application.IntegrationTests.Features.Posts.Commands;

public class AddPostIntegrationTests : BasePostIntegrationTest
{
    private User _user;
    private Post _post;
    private AddPostCommandBuilder _commandBuilder;

    public AddPostIntegrationTests(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {

    }

    protected override async Task OnInitializeAsync()
    {
        _user = await ServiceScope.AddUserAsync(CancellationToken);
        _post = new PostBuilder(_user).Create();
        _commandBuilder = new(_post);
    }

    [Theory]
    [UserIdNullData]
    [UserIdEmptyData]
    [UserIdTooShortData]
    [UserIdTooLongData]
    public async Task SendAsync_ShouldThrowValidationException_WhenUserIdIsInvalid(string userId, string errorMessage)
    {
        // Arrange
        var request = _commandBuilder.WithUserId(userId).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Theory]
    [PostTitleNullWithMessageData]
    [PostTitleEmptyWithMessageData]
    [PostTitleTooShortWithMessageData]
    [PostTitleTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenTitleIsInvalid(string title, string errorMessage)
    {
        // Arrange
        var request = _commandBuilder.WithTitle(title).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Theory]
    [PostContentNullWithMessageData]
    [PostContentEmptyWithMessageData]
    [PostContentTooShortWithMessageData]
    [PostContentTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenContentIsInvalid(string content, string errorMessage)
    {
        // Arrange
        var request = _commandBuilder.WithContent(content).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenUserIdIsInvalid()
    {
        // Arrange
        var request = _commandBuilder.WithInvalidUserId().Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowUserNotFoundExceptionAsync(request.CurrentUserId);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Arrange
        var request = _commandBuilder.Create();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var post = await ServiceScope.GetPostByIdAsync(response.Id, CancellationToken);

        // Assert
        response.ShouldSatisfy(post);
    }

    [Theory]
    [DifferentCaseStringVariantTypeData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValidAndUserIdHasDifferentVariants(StringVariantType type)
    {
        // Arrange
        var request = _commandBuilder.WithUserId(_user.Id, type).Create();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var post = await ServiceScope.GetPostByIdAsync(response.Id, CancellationToken);

        // Assert
        response.ShouldSatisfy(post);
    }

    [Fact]
    public async Task SendAsync_ShouldAddPost_WhenRequestIsValid()
    {
        // Arrange
        var request = _commandBuilder.Create();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var post = await ServiceScope.GetPostByIdAsync(response.Id, CancellationToken);

        // Assert
        post.ShouldSatisfy(request);
    }

    [Theory]
    [DifferentCaseStringVariantTypeData]
    public async Task SendAsync_ShouldAddPost_WhenRequestIsValidAndUserIdHasDifferentVariants(StringVariantType type)
    {
        // Arrange
        var request = _commandBuilder.WithUserId(_user.Id, type).Create();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var post = await ServiceScope.GetPostByIdAsync(response.Id, CancellationToken);

        // Assert
        post.ShouldSatisfy(request);
    }
}
