using InstaConnect.PostComments.Application.Features.PostComments.Commands.Delete;
using InstaConnect.PostComments.Application.UnitTests.Features.PostComments.Utilities;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Assertions;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.AddApiRequest;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.DeleteCommandRequest;

namespace InstaConnect.PostComments.Application.UnitTests.Features.PostComments.Commands.Delete;

public class DeletePostCommentCommandHandlerUnitTests : BasePostCommentApplicationUnitTest
{
    private readonly DeletePostCommentCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly DeletePostCommentCommandRequestBuilder _requestBuilder;
    private readonly DeletePostCommentCommandRequest _request;

    private readonly DeletePostCommentCommandHandler _handler;

    public DeletePostCommentCommandHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostComment);
        _request = _requestBuilder.Create();

        _handler = new(ApplicationMapper, PostCommentService);
    }

    [Fact]
    public async Task Handle_ShouldCallPostCommentServiceDeleteAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await PostCommentService.ShouldReceiveOneDeleteAsync(_request, CancellationToken);
    }
}
