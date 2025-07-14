using InstaConnect.Common.Tests.Utilities.DataAttributes;
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
        var command = _commandBuilder.WithUserId(userId).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Theory]
    [PostTitleNullData]
    [PostTitleEmptyData]
    [PostTitleTooShortData]
    [PostTitleTooLongData]
    public async Task SendAsync_ShouldThrowValidationException_WhenTitleIsInvalid(string title, string errorMessage)
    {
        // Arrange
        var command = _commandBuilder.WithTitle(title).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Theory]
    [PostContentNullData]
    [PostContentEmptyData]
    [PostContentTooShortData]
    [PostContentTooLongData]
    public async Task SendAsync_ShouldThrowValidationException_WhenContentIsInvalid(string content, string errorMessage)
    {
        // Arrange
        var command = _commandBuilder.WithContent(content).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenUserIdIsInvalid()
    {
        // Arrange
        var command = _commandBuilder.WithInvalidUserId().Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(command, CancellationToken);

        // Assert
        await action.ShouldThrowUserNotFoundExceptionAsync(command.CurrentUserId);
    }

    [Theory]
    [DefaultStringValueData]
    [DifferentCaseStringValueData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValidAndUserIdHasDifferentVariants(StringVariantType type)
    {
        // Arrange
        var command = _commandBuilder.WithUserId(_user.Id, type).Create();

        // Act
        var response = await ApplicationSender.SendAsync(command, CancellationToken);
        var post = await ServiceScope.GetPostAsync(response.Id, CancellationToken);

        // Assert
        response.ShouldSatisfy(post);
    }

    [Theory]
    [DefaultStringValueData]
    [DifferentCaseStringValueData]
    public async Task SendAsync_ShouldAddPost_WhenRequestIsValidAndUserIdHasDifferentVariants(StringVariantType type)
    {
        // Arrange
        var command = _commandBuilder.WithUserId(_user.Id, type).Create();

        // Act
        var response = await ApplicationSender.SendAsync(command, CancellationToken);
        var post = await ServiceScope.GetPostAsync(response.Id, CancellationToken);

        // Assert
        post.ShouldSatisfy(command);
    }
}
