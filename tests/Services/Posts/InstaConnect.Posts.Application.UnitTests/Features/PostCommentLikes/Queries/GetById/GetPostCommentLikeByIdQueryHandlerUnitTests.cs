using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Queries.GetById;
using InstaConnect.PostCommentLikes.Application.UnitTests.Features.PostCommentLikes.Utilities;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Assertions;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.AddApiRequest;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.GetByIdQueryRequest;

namespace InstaConnect.PostCommentLikes.Application.UnitTests.Features.PostCommentLikes.Queries.GetById;

public class GetPostCommentLikeByIdQueryHandlerUnitTests : BasePostCommentLikeApplicationUnitTest
{
    private readonly GetPostCommentLikeByIdQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetPostCommentLikeByIdQueryRequestBuilder _requestBuilder;
    private readonly GetPostCommentLikeByIdQueryRequest _request;

    private readonly GetPostCommentLikeByIdQueryHandler _handler;

    public GetPostCommentLikeByIdQueryHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostCommentLike);
        _request = _requestBuilder.Create();

        _handler = new(ApplicationMapper, PostCommentLikeService);

        PostCommentLikeService.SetupGetByIdQuery(_request, PostCommentLike, User, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _handler.Handle(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostCommentLike, User);
    }

    [Fact]
    public async Task Handle_ShouldCallPostCommentLikeServiceGetByIdAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await PostCommentLikeService.ShouldReceiveOneGetByIdAsync(_request, CancellationToken);
    }
}
