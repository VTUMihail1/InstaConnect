using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Assertions;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.AddApiRequest;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.DeleteApiRequest;
using InstaConnect.PostLikes.Presentation.Features.PostLikes.Controllers.v1;
using InstaConnect.PostLikes.Presentation.Features.PostLikes.Models.Requests;
using InstaConnect.PostLikes.Presentation.UnitTests.Features.PostLikes.Utilities;

namespace InstaConnect.PostLikes.Presentation.UnitTests.Features.PostLikes.Controllers.v1;


public class DeletePostLikeControllerUnitTests : BasePostLikePresentationUnitTest
{
    private readonly DeletePostLikeApiRequestBuilderFactory _requestBuilderFactory;
    private readonly DeletePostLikeApiRequestBuilder _requestBuilder;
    private readonly DeletePostLikeApiRequest _request;

    private readonly PostLikeController _postLikeController;

    public DeletePostLikeControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostLike);
        _request = _requestBuilder.Build();

        _postLikeController = new(ApplicationMapper, ApplicationSender);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _postLikeController.DeleteAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithNoContentStatusCode();
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallTheApplicationSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _postLikeController.DeleteAsync(_request, CancellationToken);

        // Assert
        await ApplicationSender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
