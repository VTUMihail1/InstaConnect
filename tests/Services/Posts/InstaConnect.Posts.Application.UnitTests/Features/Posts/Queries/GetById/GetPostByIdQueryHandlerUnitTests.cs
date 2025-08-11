using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.AddApiRequest;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.GetByIdQueryRequest;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Queries.GetById;

public class GetPostByIdQueryHandlerUnitTests : BasePostApplicationUnitTest
{
    private readonly GetPostByIdQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetPostByIdQueryRequestBuilder _requestBuilder;
    private readonly GetPostByIdQueryRequest _request;

    private readonly GetPostByIdQueryHandler _requestHandler;

    public GetPostByIdQueryHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(Post);
        _request = _requestBuilder.Create();

        _requestHandler = new(PostService, ApplicationMapper);

        PostService.SetupGetPostByIdQuery(_request, Post, User, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _requestHandler.Handle(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Post, User);
    }

    [Fact]
    public async Task Handle_ShouldCallPostServiceGetByIdAsync_WhenRequestIsValid()
    {
        // Act
        await _requestHandler.Handle(_request, CancellationToken);

        // Assert
        await PostService.ShouldReceiveOneGetByIdAsync(_request, CancellationToken);
    }
}
