using InstaConnect.PostComments.Application.Features.PostComments.Queries.GetById;
using InstaConnect.PostComments.Application.UnitTests.Features.PostComments.Utilities;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Assertions;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.AddApiRequest;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.GetByIdQueryRequest;

namespace InstaConnect.PostComments.Application.UnitTests.Features.PostComments.Queries.GetById;

public class GetPostCommentByIdQueryHandlerUnitTests : BasePostCommentApplicationUnitTest
{
    private readonly GetPostCommentByIdQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetPostCommentByIdQueryRequestBuilder _requestBuilder;
    private readonly GetPostCommentByIdQueryRequest _request;

    private readonly GetPostCommentByIdQueryHandler _handler;

    public GetPostCommentByIdQueryHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostComment);
        _request = _requestBuilder.Create();

        _handler = new(ApplicationMapper, PostCommentService);

        PostCommentService.SetupGetByIdQuery(_request, PostComment, User, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _handler.Handle(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostComment, User);
    }

    [Fact]
    public async Task Handle_ShouldCallPostCommentServiceGetByIdAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await PostCommentService.ShouldReceiveOneGetByIdAsync(_request, CancellationToken);
    }
}
