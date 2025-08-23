using InstaConnect.PostComments.Application.Features.PostComments.Queries.GetAll;
using InstaConnect.PostComments.Application.UnitTests.Features.PostComments.Utilities;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Assertions;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.AddApiRequest;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.GetAllQueryRequest;

namespace InstaConnect.PostComments.Application.UnitTests.Features.PostComments.Queries.GetAll;

public class GetAllPostCommentsQueryHandlerUnitTests : BasePostCommentApplicationUnitTest
{
    private readonly GetAllPostCommentsQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllPostCommentsQueryRequestBuilder _requestBuilder;
    private readonly GetAllPostCommentsQueryRequest _request;

    private readonly GetAllPostCommentsQueryHandler _handler;

    public GetAllPostCommentsQueryHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostComment, User);
        _request = _requestBuilder.Build();

        _handler = new(ApplicationMapper, PostCommentService);

        PostCommentService.SetupGetAllQuery(_request, PostComment, User, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _handler.Handle(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostComment, User, _request);
    }

    [Fact]
    public async Task Handle_ShouldCallPostCommentServiceGetAllAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await PostCommentService.ShouldReceiveOneGetAllAsync(_request, CancellationToken);
    }
}
