using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Assertions;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.AddApiRequest;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.GetByIdApiRequest;
using InstaConnect.PostComments.Presentation.Features.PostComments.Controllers.v1;
using InstaConnect.PostComments.Presentation.Features.PostComments.Models.Requests;
using InstaConnect.PostComments.Presentation.UnitTests.Features.PostComments.Utilities;

namespace InstaConnect.PostComments.Presentation.UnitTests.Features.PostComments.Controllers.v1;

public class GetPostCommentByIdControllerUnitTests : BasePostCommentPresentationUnitTest
{
    private readonly GetPostCommentByIdApiRequestBuilderFactory _requestBuilderFactory;
    private readonly GetPostCommentByIdApiRequestBuilder _requestBuilder;
    private readonly GetPostCommentByIdApiRequest _request;

    private readonly PostCommentController _postCommentController;

    public GetPostCommentByIdControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostComment);
        _request = _requestBuilder.Build();

        _postCommentController = new(ApplicationMapper, ApplicationSender);

        ApplicationSender.SetupGetByIdQueryRequest(_request, PostComment, User, CancellationToken);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _postCommentController.GetByIdAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithOkStatusCode();
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _postCommentController.GetByIdAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostComment, User);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldCallTheApplicationSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _postCommentController.GetByIdAsync(_request, CancellationToken);

        // Assert
        await ApplicationSender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
