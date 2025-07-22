using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Factories;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Factories;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.Posts.Controllers.v1;

public class GetPostByIdControllerUnitTests : BasePostUnitTest
{
    private readonly User _user;
    private readonly Post _post;

    private readonly GetPostByIdApiRequest _request;
    private readonly GetPostByIdApiRequestBuilder _requestBuilder;

    private readonly PostController _postController;

    public GetPostByIdControllerUnitTests()
    {
        _user = UserTestFactory.Create();
        _post = PostTestFactory.Create(_user);

        _requestBuilder = new(_post);
        _request = _requestBuilder.Create();

        _postController = new(ApplicationMapper, ApplicationSender);

        ApplicationSender.SetupGetByIdQuery(_request, _post, _user, CancellationToken);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _postController.GetByIdAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithOkStatusCode();
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _postController.GetByIdAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(_post, _user);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldCallTheApplicationSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _postController.GetByIdAsync(_request, CancellationToken);

        // Assert
        await ApplicationSender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
