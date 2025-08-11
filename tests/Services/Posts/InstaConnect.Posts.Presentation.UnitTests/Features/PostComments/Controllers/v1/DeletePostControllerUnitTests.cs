using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Assertions;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.AddApiRequest;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.DeleteApiRequest;

namespace InstaConnect.PostComments.Presentation.UnitTests.Features.PostComments.Controllers.v1;


public class DeletePostCommentControllerUnitTests : BasePostCommentPresentationUnitTest
{
    private readonly DeletePostCommentApiRequestBuilderFactory _requestBuilderFactory;
    private readonly DeletePostCommentApiRequestBuilder _requestBuilder;
    private readonly DeletePostCommentApiRequest _request;

    private readonly PostCommentController _postCommentController;

    public DeletePostCommentControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostComment);
        _request = _requestBuilder.Create();

        _postCommentController = new(ApplicationMapper, ApplicationSender);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _postCommentController.DeleteAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithNoContentStatusCode();
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallTheApplicationSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _postCommentController.DeleteAsync(_request, CancellationToken);

        // Assert
        await ApplicationSender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
