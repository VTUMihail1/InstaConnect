using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Models;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Builders;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.Posts.Controllers.v1;

public class AddPostControllerUnitTests : BasePostUnitTest
{
    private readonly User _user;
    private readonly Post _post;
    private readonly AddPostRequestBuilder _requestBuilder;
    private readonly PostController _postController;

    public AddPostControllerUnitTests()
    {
        _user = new UserBuilder().Create();
        _post = new PostBuilder(_user).Create();
        _requestBuilder = new(_post);
        _postController = new(
            ApplicationMapper,
            ApplicationSender);

        var request = _requestBuilder.Create();

        ApplicationSender.SetupAddCommand(request, _post, CancellationToken);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = _requestBuilder.Create();

        // Act
        var response = await _postController.AddAsync(request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithOkStatusCode();
    }

    [Fact]
    public async Task AddAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Arrange
        var request = _requestBuilder.Create();

        // Act
        var response = await _postController.AddAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(_post);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheApplicationSenderSendAsync_WhenRequestIsValid()
    {
        // Arrange
        var request = _requestBuilder.Create();

        // Act
        await _postController.AddAsync(request, CancellationToken);

        // Assert
        await ApplicationSender.ShouldReceiveOneSendAsync(request, CancellationToken);
    }
}
