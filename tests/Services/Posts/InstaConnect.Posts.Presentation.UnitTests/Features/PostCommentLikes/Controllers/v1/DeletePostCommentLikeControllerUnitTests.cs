using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Assertions;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.AddApiRequest;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.DeleteApiRequest;
using InstaConnect.PostCommentLikes.Presentation.Features.PostCommentLikes.Controllers.v1;
using InstaConnect.PostCommentLikes.Presentation.Features.PostCommentLikes.Models.Requests;
using InstaConnect.PostCommentLikes.Presentation.UnitTests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.PostCommentLikes.Presentation.UnitTests.Features.PostCommentLikes.Controllers.v1;


public class DeletePostCommentLikeControllerUnitTests : BasePostCommentLikePresentationUnitTest
{
    private readonly DeletePostCommentLikeApiRequestBuilderFactory _requestBuilderFactory;
    private readonly DeletePostCommentLikeApiRequestBuilder _requestBuilder;
    private readonly DeletePostCommentLikeApiRequest _request;

    private readonly PostCommentLikeController _postCommentLikeController;

    public DeletePostCommentLikeControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostCommentLike);
        _request = _requestBuilder.Create();

        _postCommentLikeController = new(ApplicationMapper, ApplicationSender);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _postCommentLikeController.DeleteAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithNoContentStatusCode();
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallTheApplicationSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _postCommentLikeController.DeleteAsync(_request, CancellationToken);

        // Assert
        await ApplicationSender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
