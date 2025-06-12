using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;
using InstaConnect.Posts.Domain.Features.Posts.Models;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.Posts.Controllers.v1;


public class DeletePostControllerUnitTests : BasePostUnitTest
{
    private readonly User _user;
    private readonly Post _post;
    private readonly DeletePostRequestBuilder _requestBuilder;
    private readonly PostController _postController;

    public DeletePostControllerUnitTests()
    {
        _user = SetupUser();
        _post = SetupPost(_user);
        _requestBuilder = new(_post);
        _postController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = _requestBuilder.Create();

        // Act
        var response = await _postController.DeleteAsync(request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithNoContentStatusCode();
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = _requestBuilder.Create();

        // Act
        await _postController.DeleteAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender.ShouldReceiveOneSendAsync(request, CancellationToken);
    }
}
