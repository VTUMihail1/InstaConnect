using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Factories;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Factories;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.Posts.Controllers.v1;

public class UpdatePostControllerUnitTests : BasePostUnitTest
{
    private readonly User _user;
    private readonly Post _post;

    private readonly UpdatePostApiRequest _request;
    private readonly UpdatePostApiRequestBuilder _requestBuilder;

    private readonly PostController _postController;

    public UpdatePostControllerUnitTests()
    {
        _user = UserTestFactory.Create();
        _post = PostTestFactory.Create(_user);

        _requestBuilder = new(_post);
        _request = _requestBuilder.Create();

        _postController = new(ApplicationMapper, ApplicationSender);

        ApplicationSender.SetupUpdateCommand(_request, _post, CancellationToken);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _postController.UpdateAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithOkStatusCode();
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _postController.UpdateAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(_post);
    }

    [Fact]
    public async Task UpdateAsync_ShouldCallTheApplicationSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _postController.UpdateAsync(_request, CancellationToken);

        // Assert
        await ApplicationSender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
