using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;
using InstaConnect.Posts.Domain.Features.Posts.Models;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.Posts.Controllers.v1;

public class UpdatePostControllerUnitTests : BasePostUnitTest
{
    private readonly User _user;
    private readonly Post _post;
    private readonly UpdatePostRequestBuilder _requestBuilder;
    private readonly PostController _postController;

    public UpdatePostControllerUnitTests()
    {
        _user = SetupUser();
        _post = SetupPost(_user);
        _requestBuilder = new(_post);
        _postController = new(
            InstaConnectMapper,
            InstaConnectSender);

        var request = _requestBuilder.Create();
        var response = new UpdatePostCommandResponse(_post.Id, _post.CreatedAt, _post.UpdatedAt);

        InstaConnectSender.SetupUpdateCommand(request, response, CancellationToken);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = _requestBuilder.Create();

        // Act
        var response = await _postController.UpdateAsync(request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithOkStatusCode();
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Arrange
        var request = _requestBuilder.Create();

        // Act
        var response = await _postController.UpdateAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(_post);
    }

    [Fact]
    public async Task UpdateAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = _requestBuilder.Create();

        // Act
        await _postController.UpdateAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender.ShouldReceiveOneSendAsync(request, CancellationToken);
    }
}
