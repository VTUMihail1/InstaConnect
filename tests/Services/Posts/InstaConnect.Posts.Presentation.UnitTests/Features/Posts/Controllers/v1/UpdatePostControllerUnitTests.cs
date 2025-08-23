using InstaConnect.Common.Tests.Assertions;
using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.AddApiRequest;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.UpdateApiRequest;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.Posts.Controllers.v1;

public class UpdatePostControllerUnitTests : BasePostPresentationUnitTest
{
    private readonly UpdatePostApiRequestBuilderFactory _requestBuilderFactory;
    private readonly UpdatePostApiRequestBuilder _requestBuilder;
    private readonly UpdatePostApiRequest _request;

    private readonly PostController _postController;

    public UpdatePostControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(Post);
        _request = _requestBuilder.Build();

        _postController = new(ApplicationMapper, ApplicationSender);

        ApplicationSender.SetupUpdateCommandRequest(_request, Post, CancellationToken);
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
        response.ShouldSatisfy(Post);
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
