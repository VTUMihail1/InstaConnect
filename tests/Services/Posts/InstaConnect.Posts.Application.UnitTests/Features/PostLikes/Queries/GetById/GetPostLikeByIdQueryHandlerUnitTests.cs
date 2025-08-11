using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetById;
using InstaConnect.PostLikes.Application.UnitTests.Features.PostLikes.Utilities;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Assertions;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.AddApiRequest;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.GetByIdQueryRequest;

namespace InstaConnect.PostLikes.Application.UnitTests.Features.PostLikes.Queries.GetById;

public class GetPostLikeByIdQueryHandlerUnitTests : BasePostLikeApplicationUnitTest
{
    private readonly GetPostLikeByIdQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetPostLikeByIdQueryRequestBuilder _requestBuilder;
    private readonly GetPostLikeByIdQueryRequest _request;

    private readonly GetPostLikeByIdQueryHandler _handler;

    public GetPostLikeByIdQueryHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostLike);
        _request = _requestBuilder.Create();

        _handler = new(PostLikeService, ApplicationMapper);

        PostLikeService.SetupGetByIdQuery(_request, PostLike, User, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _handler.Handle(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostLike, User);
    }

    [Fact]
    public async Task Handle_ShouldCallPostLikeServiceGetByIdAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await PostLikeService.ShouldReceiveOneGetByIdAsync(_request, CancellationToken);
    }
}
