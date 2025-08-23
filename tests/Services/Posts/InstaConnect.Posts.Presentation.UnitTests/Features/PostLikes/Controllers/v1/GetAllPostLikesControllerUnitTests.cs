using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Assertions;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.AddApiRequest;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.GetAllApiRequest;
using InstaConnect.PostLikes.Presentation.Features.PostLikes.Controllers.v1;
using InstaConnect.PostLikes.Presentation.Features.PostLikes.Models.Requests;
using InstaConnect.PostLikes.Presentation.UnitTests.Features.PostLikes.Utilities;

namespace InstaConnect.PostLikes.Presentation.UnitTests.Features.PostLikes.Controllers.v1;

public class GetAllPostLikesControllerUnitTests : BasePostLikePresentationUnitTest
{
    private readonly GetAllPostLikesApiRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllPostLikesApiRequestBuilder _requestBuilder;
    private readonly GetAllPostLikesApiRequest _request;

    private readonly PostLikeController _postLikeController;

    public GetAllPostLikesControllerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostLike, User);
        _request = _requestBuilder.Build();

        _postLikeController = new(ApplicationMapper, ApplicationSender);

        ApplicationSender.SetupGetAllQueryRequest(_request, PostLike, User, CancellationToken);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _postLikeController.GetAllAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithOkStatusCode();
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _postLikeController.GetAllAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostLike, User, _request);
    }

    [Fact]
    public async Task GetAllAsync_ShouldCallTheApplicationSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _postLikeController.GetAllAsync(_request, CancellationToken);

        // Assert
        await ApplicationSender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
