using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Builders;
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
        _user = new UserBuilder().Create();
        _post = new PostBuilder(_user).Create();
        _requestBuilder = new(_post);
        _postController = new(
            ApplicationMapper,
            ApplicationSender);

        var request = _requestBuilder.Create();

        ApplicationSender.SetupGetByIdQuery(request, _post, _user, CancellationToken);
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
    public async Task GetByIdAsync_ShouldCallTheApplicationSenderSendAsync_WhenRequestIsValid()
    {
        // Arrange
        var request = _requestBuilder.Create();

        // Act
        await _postController.GetByIdAsync(request, CancellationToken);

        // Assert
        await ApplicationSender.ShouldReceiveOneSendAsync(request, CancellationToken);
    }
}
