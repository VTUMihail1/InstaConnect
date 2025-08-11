using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Queries.GetAll;
using InstaConnect.PostCommentLikes.Application.UnitTests.Features.PostCommentLikes.Utilities;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Assertions;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.AddApiRequest;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.GetAllQueryRequest;

namespace InstaConnect.PostCommentLikes.Application.UnitTests.Features.PostCommentLikes.Queries.GetAll;

public class GetAllPostCommentLikesQueryHandlerUnitTests : BasePostCommentLikeApplicationUnitTest
{
    private readonly GetAllPostCommentLikesQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllPostCommentLikesQueryRequestBuilder _requestBuilder;
    private readonly GetAllPostCommentLikesQueryRequest _request;

    private readonly GetAllPostCommentLikesQueryHandler _handler;

    public GetAllPostCommentLikesQueryHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostCommentLike, User);
        _request = _requestBuilder.Create();

        _handler = new(ApplicationMapper, PostCommentLikeService);

        PostCommentLikeService.SetupGetAllQuery(_request, PostCommentLike, User, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _handler.Handle(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostCommentLike, User, _request);
    }

    [Fact]
    public async Task Handle_ShouldCallPostCommentLikeServiceGetAllAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await PostCommentLikeService.ShouldReceiveOneGetAllAsync(_request, CancellationToken);
    }
}
