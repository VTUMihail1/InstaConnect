using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Factories;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Factories;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.Posts.Controllers.v1;


public class DeletePostControllerUnitTests : BasePostUnitTest
{
    private readonly User _user;
    private readonly Post _post;

    private readonly DeletePostApiRequest _request;
    private readonly DeletePostApiRequestBuilder _requestBuilder;

    private readonly PostController _postController;

    public DeletePostControllerUnitTests()
    {
        _user = UserTestFactory.Create();
        _post = PostTestFactory.Create(_user);

        _requestBuilder = new(_post);
        _request = _requestBuilder.Create();

        _postController = new(ApplicationMapper, ApplicationSender);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _postController.DeleteAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithNoContentStatusCode();
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallTheApplicationSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _postController.DeleteAsync(_request, CancellationToken);

        // Assert
        await ApplicationSender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
