using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Assertions;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.AddApiRequest;
using InstaConnect.PostComments.Presentation.Features.PostComments.Controllers.v1;
using InstaConnect.PostComments.Presentation.Features.PostComments.Models.Requests;
using InstaConnect.PostComments.Presentation.UnitTests.Features.PostComments.Utilities;

namespace InstaConnect.PostComments.Presentation.UnitTests.Features.PostComments.Controllers.v1;

public class AddPostCommentControllerUnitTests : BasePostCommentPresentationUnitTest
{
    private readonly AddPostCommentApiRequestBuilderFactory _requestBuilderFactory;
    private readonly AddPostCommentApiRequestBuilder _requestBuilder;
    private readonly AddPostCommentApiRequest _request;

    private readonly PostCommentController _postCommentController;

    public AddPostCommentControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(Post, User);
        _request = _requestBuilder.Build();

        _postCommentController = new(ApplicationMapper, ApplicationSender);

        ApplicationSender.SetupAddCommandRequest(_request, PostComment, CancellationToken);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _postCommentController.AddAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithOkStatusCode();
    }

    [Fact]
    public async Task AddAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _postCommentController.AddAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostComment);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheApplicationSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _postCommentController.AddAsync(_request, CancellationToken);

        // Assert
        await ApplicationSender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
