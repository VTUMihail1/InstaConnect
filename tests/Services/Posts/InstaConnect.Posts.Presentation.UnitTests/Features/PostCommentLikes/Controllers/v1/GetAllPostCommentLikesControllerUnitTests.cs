using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Assertions;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.AddApiRequest;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.GetAllApiRequest;
using InstaConnect.PostCommentLikes.Presentation.Features.PostCommentLikes.Controllers.v1;
using InstaConnect.PostCommentLikes.Presentation.Features.PostCommentLikes.Models.Requests;
using InstaConnect.PostCommentLikes.Presentation.UnitTests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.PostCommentLikes.Presentation.UnitTests.Features.PostCommentLikes.Controllers.v1;

public class GetAllPostCommentLikesControllerUnitTests : BasePostCommentLikePresentationUnitTest
{
    private readonly GetAllPostCommentLikesApiRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllPostCommentLikesApiRequestBuilder _requestBuilder;
    private readonly GetAllPostCommentLikesApiRequest _request;

    private readonly PostCommentLikeController _postCommentLikeController;

    public GetAllPostCommentLikesControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostCommentLike, User);
        _request = _requestBuilder.Create();

        _postCommentLikeController = new(ApplicationMapper, ApplicationSender);

        ApplicationSender.SetupGetAllQueryRequest(_request, PostCommentLike, User, CancellationToken);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _postCommentLikeController.GetAllAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithOkStatusCode();
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _postCommentLikeController.GetAllAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostCommentLike, User, _request);
    }

    [Fact]
    public async Task GetAllAsync_ShouldCallTheApplicationSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _postCommentLikeController.GetAllAsync(_request, CancellationToken);

        // Assert
        await ApplicationSender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
