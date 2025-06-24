using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.Posts.Controllers.v1;

public class GetPostByIdControllerUnitTests : BasePostUnitTest
{
    private readonly User _user;
    private readonly Post _post;
    private readonly GetPostByIdRequestBuilder _requestBuilder;
    private readonly PostController _postController;

    public GetPostByIdControllerUnitTests()
    {
        _user = SetupUser();
        _post = SetupPost(_user);
        _requestBuilder = new(_post);
        _postController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = _requestBuilder.Create();

        // Act
        var response = await _postController.GetByIdAsync(request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithOkStatusCode();
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Arrange
        var request = _requestBuilder.Create();

        // Act
        var response = await _postController.GetByIdAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(_post, _user);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = _requestBuilder.Create();

        // Act
        await _postController.GetByIdAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender.ShouldReceiveOneSendAsync(request, CancellationToken);
    }
}
